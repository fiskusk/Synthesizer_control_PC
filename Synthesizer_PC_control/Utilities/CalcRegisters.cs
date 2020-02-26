using System;
using Synthesizer_PC_control.Model;

namespace Synthesizer_PC_control.Utilities
{
    public struct CalcRegs
    {
        public UInt16 intN;
        public UInt16 fracN;
        public UInt16 mod;
        public UInt16 rDiv;
        public SynthMode mode;
        public int aDivIndex;
        public decimal delta;
    }
    
    public static class  CalcRegisters
    {
        private static decimal static_refInFreq;
        private static bool static_isDoubled;
        private static bool static_isDivBy2;
        private static int static_outBPathIndex;
        private static decimal static_fPfd;
        private static UInt16 static_aDivIndex;
        public static CalcRegs CalcRegistersFromInput(decimal f_input, 
                                                    decimal refInFreq, 
                                                    bool isDoubled, 
                                                    bool isDivBy2, 
                                                    int outBPathIndex)
        {
            static_refInFreq      = refInFreq;
            static_isDoubled      = isDoubled;
            static_isDivBy2       = isDivBy2;
            static_outBPathIndex  = outBPathIndex;

            CalcRegs calcRegs = new CalcRegs();
            CalcRegs calculatedSettings = new CalcRegs();

            calculatedSettings.delta = 99999;

            UInt16      intN;
            UInt16      fracN;
            UInt16      mod;
            SynthMode   mode;
            UInt16      rDivValue = 1;
            decimal     remainder;
            decimal     calcFreq;
            decimal     delta;

            CalcIntNFromFrequency(f_input, rDivValue, out intN, out remainder);
            
            if (remainder > 0.0000000000000001M)
            {
                mode = SynthMode.FRACTIONAL;

                if (TryToCalcFractPart(remainder, f_input, rDivValue, 
                    out rDivValue, intN, out intN, out fracN, 
                    out mod, f_input) == false)
                {
                    decimal copyFInput = f_input;
                    for (int i = 0; i < 20; i++)
                    {
                        copyFInput = copyFInput - 0.000001M;
                        rDivValue = 1;
                        CalcIntNFromFrequency(copyFInput, rDivValue, 
                                              out intN, out remainder);
                        if (remainder > 0.0000000000000001M)
                        {
                            mode = SynthMode.FRACTIONAL;
                            if (TryToCalcFractPart(remainder, f_input, rDivValue, 
                                                    out rDivValue, intN, 
                                                    out intN, out fracN, 
                                                    out mod, copyFInput) == true)
                            {
                                calcFreq = CalcFreqInfo(mode, intN,
                                                        fracN, mod, 
                                                        (UInt16)outBPathIndex, 
                                                        copyFInput);
                                delta = Math.Abs((f_input - calcFreq) * 1e6M);
                            }
                            else
                            {
                                delta = 99999;
                            }
                        }
                        else
                        {
                            mode = SynthMode.INTEGER;
                            calcFreq = CalcFreqInfo(mode, intN,
                                                        fracN, mod, 
                                                        (UInt16)outBPathIndex, 
                                                        copyFInput);
                            delta = Math.Abs((f_input - calcFreq) * 1e6M);
                        }
                        // store new calc values if its smallest than last stored
                        if (calculatedSettings.delta > delta)
                        {
                            calculatedSettings.intN = intN;
                            calculatedSettings.fracN = fracN;
                            calculatedSettings.mod = mod;
                            calculatedSettings.rDiv = rDivValue;
                            calculatedSettings.mode = mode;
                            calculatedSettings.aDivIndex = static_aDivIndex;
                            calculatedSettings.delta = delta;
                        }
                    }
                    copyFInput = f_input;
                    for (int i = 0; i < 20; i++)
                    {
                        copyFInput = copyFInput + 0.000001M;
                        rDivValue = 1;
                        CalcIntNFromFrequency(copyFInput, rDivValue, 
                                              out intN, out remainder);
                        if (remainder > 0.0000000000000001M)
                        {
                            mode = SynthMode.FRACTIONAL;
                            if (TryToCalcFractPart(remainder, f_input, rDivValue, 
                                                    out rDivValue, intN, 
                                                    out intN, out fracN, out mod, 
                                                    copyFInput) == true)
                            {
                                calcFreq = CalcFreqInfo(mode, intN, fracN, mod, 
                                                        (UInt16)outBPathIndex, 
                                                        copyFInput);
                                delta = Math.Abs((f_input - calcFreq) * 1e6M);
                            }
                            else
                            {
                                delta = 99999;
                            }
                        }
                        else
                        {
                            mode = SynthMode.INTEGER;
                            calcFreq = CalcFreqInfo(mode, intN, fracN, 
                                                    mod, (UInt16)outBPathIndex, 
                                                    copyFInput);
                            delta = Math.Abs((f_input - calcFreq) * 1e6M);
                        }
                        // store new calc values if its smallest than last stored
                        if (calculatedSettings.delta > delta)
                        {
                            calculatedSettings.intN = intN;
                            calculatedSettings.fracN = fracN;
                            calculatedSettings.mod = mod;
                            calculatedSettings.rDiv = rDivValue;
                            calculatedSettings.mode = mode;
                            calculatedSettings.aDivIndex = static_aDivIndex;
                            calculatedSettings.delta = delta;
                        }
                    }
                    calcRegs = calculatedSettings;
                }
                else
                {
                    calcRegs.aDivIndex = static_aDivIndex;
                    calcRegs.rDiv = rDivValue;
                    calcRegs.intN = intN;
                    calcRegs.fracN = fracN;
                    calcRegs.mod = mod;
                }
            }
            else
            {
                calcRegs.mode = SynthMode.INTEGER;
                calcRegs.rDiv = rDivValue;
                calcRegs.aDivIndex = static_aDivIndex;
                calcRegs.intN = intN;
            }

            return calcRegs;
        }

        public static void CalcIntNFromFrequency(decimal frequency, UInt16 rDivValue,
                                          out UInt16 intN, out decimal remainder)
        {
            static_fPfd = static_refInFreq * ((1 + Convert.ToUInt16(static_isDoubled)) / 
                (decimal)(rDivValue * (1 + Convert.ToUInt16(static_isDivBy2))));

            decimal intN_decimal;

            if (frequency <= 6000)
            {
                static_aDivIndex = FindAndSetCorrespondingADivValue(frequency);
                intN_decimal = (frequency * (1 << static_aDivIndex) / static_fPfd);
            }
            else
            {
                if (static_outBPathIndex == 0)
                {
                    static_aDivIndex = FindAndSetCorrespondingADivValue(frequency / 2);
                    intN_decimal = (frequency / 2) * (1 << static_aDivIndex) /  static_fPfd;
                }
                else
                {
                    intN_decimal = (frequency / 2) / static_fPfd;
                }
            }

            intN = (UInt16)intN_decimal;

            remainder = intN_decimal-intN;
        }

        private static UInt16 FindAndSetCorrespondingADivValue(decimal value)
        {
            UInt16 divAIndex;
            if (value >= 3000 && value <= 6000)
            {
                divAIndex = 0;
            }
            else if (value >= 1500 && value < 3000)
            {
                divAIndex = 1;
            }
            else if (value >= 750 && value < 1500)
            {
                divAIndex = 2;
            }
            else if (value >= 375 && value < 750)
            {
                divAIndex = 3;
            }
            else if (value >= 187.5M && value < 375)
            {
                divAIndex = 4;
            }
            else if (value >= 93.75M && value < 187.5M)
            {
                divAIndex = 5;
            }
            else if (value >= 46.875M && value < 93.75M)
            {
                divAIndex = 6;
            }
            else if (value >= 23.5M && value < 46.875M)
            {
                divAIndex = 7;
            }
            else
            {
                divAIndex = 1;
            }

            return divAIndex;
        }

        private static bool TryToCalcFractPart(decimal remainder, decimal f_input, 
                                       UInt16 rDivValueIn, out UInt16 rDivValue,
                                       UInt16 intNIn, out UInt16 intN, 
                                       out UInt16 fracN, out UInt16 mod, 
                                       decimal frequency)
        {
            bool success;

            rDivValue = rDivValueIn;
            intN = (UInt16)intNIn;

            Fractions.Fraction pokus = new Fractions.Fraction();

            double accuracy;
            int correction=1000;
            UInt16 cnt = 0;

            do
            {
                accuracy = 0.000001;
                do
                {
                    pokus = Fractions.RealToFraction((double)remainder, accuracy);
                    cnt++;
                    accuracy = accuracy*10;
                } while ((pokus.D < 2 || pokus.D > 4095) && accuracy <= 0.00001*correction);
                if ((pokus.D < 2 || pokus.D > 4095))
                {
                    rDivValue++;
                    CalcIntNFromFrequency(frequency, rDivValue,  out intN, 
                                          out remainder);
                    if (intN > 4091)
                    {
                        correction = correction * 10;
                        rDivValue--;
                        CalcIntNFromFrequency(frequency, rDivValue, out intN, 
                                              out remainder);
                    }
                }
            } while((pokus.D < 2 || pokus.D > 4095) && accuracy < 1);

            if ((pokus.D < 2 || pokus.D > 4095))
            {
                success = false;
                rDivValue = 1;
            }
            else
            {
                success = true;
            }

            mod = (UInt16)pokus.D;
            fracN = (UInt16)pokus.N;

            return success;
        }

        private static decimal CalcFreqInfo(SynthMode mode, UInt16 intN, 
                                    UInt16 fracN, UInt16 mod, UInt16 outBpath, 
                                    decimal desiredFreq)
        {
            decimal calcFreq;

            if (desiredFreq <= 6000)
            {
                if (mode == SynthMode.INTEGER)
                    calcFreq = (static_fPfd * intN) / (1 << static_aDivIndex);
                else
                    calcFreq = (static_fPfd / (1 << static_aDivIndex)) * (intN + (fracN / (mod * 1.0M)));
            }
            else
            {
                if (mode == SynthMode.INTEGER)
                    calcFreq = (static_fPfd * intN) / (1 << static_aDivIndex);
                else
                    calcFreq = (static_fPfd / (1 << static_aDivIndex)) * (intN + (fracN / (mod * 1.0M)));

                if (outBpath == 1)
                    calcFreq = calcFreq * (1 << static_aDivIndex);
            }

            return calcFreq;

        }
    }
}