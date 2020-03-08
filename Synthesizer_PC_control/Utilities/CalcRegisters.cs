using System;
using Synthesizer_PC_control.Model;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

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
        public decimal calcFreq;
    }
    
    public static class  CalcRegisters
    {
        private static decimal static_refInFreq;
        private static bool static_isDoubled;
        private static bool static_isDivBy2;
        private static int static_outBPathIndex;
        private static int static_FBPathIndex;
        public static CalcRegs CalcRegistersFromInput(decimal f_input, 
                                                    decimal refInFreq, 
                                                    bool isDoubled, 
                                                    bool isDivBy2, 
                                                    int outBPathIndex,
                                                    int FBPathIndex)
        {
            static_refInFreq      = refInFreq;
            static_isDoubled      = isDoubled;
            static_isDivBy2       = isDivBy2;
            static_outBPathIndex  = outBPathIndex;
            static_FBPathIndex    = FBPathIndex;            // FIXME implement FBPath into calculations

            CalcRegs calcRegs = new CalcRegs();
            CalcRegs[] calculatedSettings = new CalcRegs[100];
            
            Action calcJob1 = () => 
            {
                decimal copyFInputDown = f_input + 0.000001M;
                ThreadPool.SetMinThreads(50,50);
                ParallelEnumerable.Range(0, 50).WithDegreeOfParallelism(50).ForAll(i =>
                {
                    copyFInputDown = copyFInputDown - 0.000001M;
                    calculatedSettings[i] = CalcFracModVals(copyFInputDown, f_input);
                });
            };

            Action calcJob2 = () => 
            {
                decimal copyFInputUp = f_input;
                ThreadPool.SetMinThreads(50,50);
                ParallelEnumerable.Range(50, 50).WithDegreeOfParallelism(50).ForAll(i =>
                {
                    copyFInputUp = copyFInputUp + 0.000001M;
                    calculatedSettings[i] = CalcFracModVals(copyFInputUp, f_input);
                });
            };

            var tasks = new[] {
                Task.Factory.StartNew(calcJob1),
                Task.Factory.StartNew(calcJob2)
            };

            Task.WaitAll(tasks);

            int indexOfMinimum = 0;
            decimal deltaMinimum = Math.Abs((f_input - calculatedSettings[indexOfMinimum].calcFreq) * 1e6M);
            decimal delta;

            for (int i = 0; i < calculatedSettings.Length; i++)
            {
                delta = Math.Abs((f_input - calculatedSettings[i].calcFreq) * 1e6M);

                if (delta < deltaMinimum)
                {
                    deltaMinimum = delta;
                    indexOfMinimum = i;
                }
            }

            calcRegs = calculatedSettings[indexOfMinimum];

            return calcRegs;
        }
        public static  CalcRegs CalcFracModVals(decimal fInputNew, decimal fInputOriginal)
        {
            UInt16      rDivValueDown = 1;
            UInt16      aDivIndexDown;
            UInt16      intNDown;
            SynthMode   modeDown;
            UInt16      fracNDown;
            UInt16      modDown;
            decimal     fPfdDown;
            decimal     remainderDown;
            decimal     calcFreqDown;

            CalcRegs calcRegs = new CalcRegs();

            CalcIntNFromFrequency(fInputNew, rDivValueDown, 
                                out intNDown, out remainderDown, 
                                out aDivIndexDown, out fPfdDown);
            if (remainderDown > 0.0000000001M)
            {
                modeDown = SynthMode.FRACTIONAL;
                if (TryToCalcFractPart(remainderDown, rDivValueDown, 
                                        out rDivValueDown, intNDown, 
                                        out intNDown, out fracNDown, 
                                        out modDown, fInputNew,
                                        aDivIndexDown, fPfdDown, out fPfdDown) == true)
                {
                    calcFreqDown = CalcFreqInfo(modeDown, intNDown,
                                            fracNDown, modDown, 
                                            fInputNew, fPfdDown,
                                            aDivIndexDown);
                }
                else
                {
                    calcFreqDown = 0;
                }
            }
            else
            {
                modeDown = SynthMode.INTEGER;
                fracNDown = 0;
                modDown = 0;
                calcFreqDown = CalcFreqInfo(modeDown, intNDown,
                                        fracNDown, modDown, fInputNew, 
                                        fPfdDown, aDivIndexDown);
            }
            // store new calc values if its smallest than last stored
            calcRegs.intN = intNDown;
            calcRegs.fracN = fracNDown;
            calcRegs.mod = modDown;
            calcRegs.rDiv = rDivValueDown;
            calcRegs.mode = modeDown;
            calcRegs.aDivIndex = aDivIndexDown;
            calcRegs.calcFreq = calcFreqDown;

            return calcRegs;
        }

        public static void CalcIntNFromFrequency(decimal frequency, UInt16 rDivValue,
                                          out UInt16 intN, out decimal remainder,
                                          out UInt16 aDivIndex, out decimal fPfd)
        {
            fPfd = static_refInFreq * ((1 + Convert.ToUInt16(static_isDoubled)) / 
                (decimal)(rDivValue * (1 + Convert.ToUInt16(static_isDivBy2))));

            decimal intN_decimal;

            if (frequency <= 6000)
            {
                aDivIndex = FindAndSetCorrespondingADivValue(frequency);
                intN_decimal = (frequency * (1 << aDivIndex) / fPfd);
            }
            else
            {
                aDivIndex = FindAndSetCorrespondingADivValue(frequency / 2);
                if (static_outBPathIndex == 0)
                {
                    intN_decimal = (frequency / 2) * (1 << aDivIndex) /  fPfd;
                }
                else
                {
                    intN_decimal = (frequency / 2) / fPfd;
                }
            }

            intN = (UInt16)intN_decimal;

            remainder = intN_decimal - intN;
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

        private static bool TryToCalcFractPart(decimal remainder, 
                                       UInt16 rDivValueIn, out UInt16 rDivValue,
                                       UInt16 intNIn, out UInt16 intN, 
                                       out UInt16 fracN, out UInt16 mod, 
                                       decimal frequency, UInt16 aDivIndex,
                                       decimal fPfdIn, out decimal fPfd)
        {
            bool success;
            fPfd = fPfdIn;

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
                    if (remainder > 0.0000000001M)
                        pokus = Fractions.RealToFraction((double)remainder, accuracy);
                    cnt++;
                    accuracy = accuracy*10;
                } while ((pokus.D < 2 || pokus.D > 4095) && accuracy <= 0.00001*correction);
                if ((pokus.D < 2 || pokus.D > 4095))
                {
                    rDivValue++;
                    CalcIntNFromFrequency(frequency, rDivValue,  out intN, 
                                          out remainder, out aDivIndex, out fPfd);
                    if (intN > 4091)
                    {
                        accuracy = 1;
                        success = false;
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
                                    UInt16 fracN, UInt16 mod, 
                                    decimal desiredFreq, decimal fPfd, UInt16 aDivIndex)
        {
            decimal calcFreq;

            if (desiredFreq <= 6000)
            {
                if (mode == SynthMode.INTEGER)
                    calcFreq = (fPfd * intN) / (1 << aDivIndex);
                else
                    calcFreq = (fPfd / (1 << aDivIndex)) * (intN + (fracN / (mod * 1.0M)));
            }
            else
            {
                if (mode == SynthMode.INTEGER)
                    calcFreq = (fPfd * intN) / (1 << aDivIndex);
                else
                    calcFreq = (fPfd / (1 << aDivIndex)) * (intN + (fracN / (mod * 1.0M)));

                if (static_outBPathIndex == 1)
                    calcFreq = calcFreq * (1 << aDivIndex);
            }

            return calcFreq;

        }
    }
}