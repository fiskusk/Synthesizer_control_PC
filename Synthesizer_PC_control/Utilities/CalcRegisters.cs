using System;
using Synthesizer_PC_control.Model;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Synthesizer_PC_control.Utilities
{
    /// <summary>
    /// Structure for calculated register settings from input frequency
    /// </summary>
    public struct CalcRegs
    {
        /// <summary>
        /// Integer-N value
        /// </summary>
        public UInt16 intN;

        /// <summary>
        /// Fractional-N value
        /// </summary>
        public UInt16 fracN;

        /// <summary>
        /// Modulus value
        /// </summary>
        public UInt16 mod;

        /// <summary>
        /// R-divider value
        /// </summary>
        public UInt16 rDiv;

        /// <summary>
        /// PLO mode
        /// </summary>
        public SynthMode mode;

        /// <summary>
        /// A-divider index value
        /// </summary>
        public int aDivIndex;

        /// <summary>
        /// calculated frequency
        /// </summary>
        public decimal calcFreq;

        /// <summary>
        /// desired frequency
        /// </summary>
        public decimal desiredFreq;
    }
    
    /// <summary>
    /// Registers values calculations. It contains public function for calculating 
    /// registers values from input desired frequency.
    /// </summary>
    public static class  CalcRegisters
    {
        /// <summary>
        /// It holds reference input frequency
        /// </summary>
        private static decimal static_refInFreq;

        /// <summary>
        /// It holds if reference frequency is doubled
        /// </summary>
        private static bool static_isDoubled;

        /// <summary>
        /// It holds if reference frequency is divided by two
        /// </summary>
        private static bool static_isDivBy2;

        /// <summary>
        /// It holds RF path output B
        /// </summary>
        private static int static_outBPathIndex;

        /// <summary>
        /// It holds VCO to integer-counter feedback path
        /// </summary>
        private static int static_FBPathIndex;
        
        /// <summary>
        /// This funtion calculate register settings for desired frequency
        /// </summary>
        /// <param name="f_input"> desired synthesizer output frequency </param>
        /// <param name="refInFreq"> reference signal frequency at module input </param>
        /// <param name="isDoubled"> state if reference freq is doubled </param>
        /// <param name="isDivBy2"> state if ref freq is divided by two</param>
        /// <param name="outBPathIndex"> synth OUTB path select (0 - VCO divided, 1 - VCO fundamental) </param>
        /// <param name="FBPathIndex"> VCO to N counter feedback mode (0 - divided, 1 - fundamental) </param>
        /// <returns> struct CalcRegs that include calculated settings</returns>
        public static CalcRegs CalcRegistersFromInput(decimal f_input, 
                                                    decimal refInFreq, 
                                                    bool isDoubled, 
                                                    bool isDivBy2, 
                                                    int outBPathIndex,
                                                    int FBPathIndex)
        {
            // set static parameters (these param have fixed value)
            static_refInFreq      = refInFreq;
            static_isDoubled      = isDoubled;
            static_isDivBy2       = isDivBy2;
            static_outBPathIndex  = outBPathIndex;
            static_FBPathIndex    = FBPathIndex;            // FIXME implement FBPath into calculations

            /// <summary>
            ///  variable for store each calc register  
            /// </summary>
            CalcRegs[] calculatedSettings = new CalcRegs[100];  
            
            /// <summary>
            /// calc in parralel task 50x by 1Hz decrement, including f_input value
            /// </summary>
            Action calcJob1 = () => 
            {
                // initial value. In first step include f_input value
                decimal copyFInputDown = f_input + 0.000001M;
                ThreadPool.SetMinThreads(50,50);

                ParallelEnumerable.Range(0, 50).WithDegreeOfParallelism(50).ForAll(i =>
                {
                    // in each step decrese frequency by 1Hz
                    copyFInputDown = copyFInputDown - 0.000001M;
                    // and recalculate new settings and store it into array
                    calculatedSettings[i] = CalcRegSettings(copyFInputDown);
                });
            };

            /// <summary>
            /// calc in parralel task 50x by 1Hz increment
            /// </summary>
            Action calcJob2 = () => 
            {
                // initial value.
                decimal copyFInputUp = f_input;
                ThreadPool.SetMinThreads(50,50);    

                ParallelEnumerable.Range(50, 50).WithDegreeOfParallelism(50).ForAll(i =>
                {
                    // in each step increase frequency by 1Hz
                    copyFInputUp = copyFInputUp + 0.000001M;
                    // and recalculate new settings and store it into array
                    calculatedSettings[i] = CalcRegSettings(copyFInputUp);
                });
            };

            // start this tasks
            var tasks = new[] {
                Task.Factory.StartNew(calcJob1),
                Task.Factory.StartNew(calcJob2)
            };

            // wait for all task, here sometimes freeze at any time
            Task.WaitAll(tasks);


            // now find mimimum delta and return corrensponding values
            int indexOfMinimum = 0;
            indexOfMinimum = GetIndexForMinDelta(f_input, calculatedSettings);

            return calculatedSettings[indexOfMinimum];
        }

        /// <summary>
        /// This function find position of smallest delta between 
        /// calculated frequency and desired frequency in calculated settings array
        /// </summary>
        /// <param name="f_input"> desired frequency </param>
        /// <param name="calculatedSettings"> data array of calculated settings </param>
        /// <returns></returns>
        private static int GetIndexForMinDelta(decimal f_input, CalcRegs[] calculatedSettings)
        {
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

            return indexOfMinimum;
        }

        /// <summary>
        /// This function try to find optimal register values for desired values
        /// </summary>
        /// <param name="desiredFreq"> frequency from which the register values are to be calculated </param>
        /// <returns> Calculated register values </returns>
        private static  CalcRegs CalcRegSettings(decimal desiredFreq)
        {
            // declare variables for calculated values
            UInt16      rDivValue = 1;  // initial R-divider value 
            UInt16      aDivIndex;
            UInt16      intN;
            SynthMode   mode;
            UInt16      fracN;
            UInt16      mod;
            decimal     fPfd;
            decimal     remainder;
            decimal     calcFreq;

            /// <summary>
            /// calculated register settings
            /// </summary>
            CalcRegs calcRegs = new CalcRegs();

            // first calculate integer part and eventualy remainder
            CalcIntNFromFrequency(desiredFreq, rDivValue, 
                                out intN, out remainder, 
                                out aDivIndex, out fPfd);

            if (remainder > 0.0000000001M)
            {
                // if remainder is greater than approx. zero, then calculate fractional part
                mode = SynthMode.FRACTIONAL;    // set mode as Fractional

                bool success;
                success = TryToCalcFractPart(remainder, rDivValue, 
                                        out rDivValue, intN, 
                                        out intN, out fracN, 
                                        out mod, desiredFreq,
                                        aDivIndex, fPfd, out fPfd);

                // if success calculate according frequency from this values
                if (success == true)
                {
                    calcFreq = CalcFreqInfo(mode, intN,
                                            fracN, mod, 
                                            desiredFreq, fPfd,
                                            aDivIndex);
                }
                else
                {
                    calcFreq = 0;   // if the calculations was not successful, set zero 
                }
            }
            else
            {
                // if remainder is zero, this is Integer mode
                mode = SynthMode.INTEGER;   // synth. mode is integer
                fracN = 0;  // it doesn't matter
                mod = 0;    // it doesn't matter
                // calculate according frequency from this values
                calcFreq = CalcFreqInfo(mode, intN,
                                        fracN, mod, desiredFreq, 
                                        fPfd, aDivIndex);
            }

            // return calculated register settings
            calcRegs.intN = intN;
            calcRegs.fracN = fracN;
            calcRegs.mod = mod;
            calcRegs.rDiv = rDivValue;
            calcRegs.mode = mode;
            calcRegs.aDivIndex = aDivIndex;
            calcRegs.calcFreq = calcFreq;
            calcRegs.desiredFreq = desiredFreq;

            return calcRegs;
        }

        /// <summary>
        /// This function calculates the integer part from the given frequency
        /// </summary>
        /// <param name="frequency"> desired frequency value </param>
        /// <param name="rDivValue"> R-divider value</param>
        /// <param name="intN"> calculated Int-N value </param>
        /// <param name="remainder"> the remainder of the division </param>
        /// <param name="aDivIndex"> calculated corresponding A-divider Index </param>
        /// <param name="fPfd"> calculated frequency at PFD input </param>
        private static void CalcIntNFromFrequency(decimal frequency, UInt16 rDivValue,
                                          out UInt16 intN, out decimal remainder,
                                          out UInt16 aDivIndex, out decimal fPfd)
        {
            // calculate frequency at PFD input
            fPfd = static_refInFreq * ((1 + Convert.ToUInt16(static_isDoubled)) / 
                (decimal)(rDivValue * (1 + Convert.ToUInt16(static_isDivBy2))));

            // calculate Int-N value for corresponding band
            decimal intN_decimal;

            if (frequency <= 6000)
            {
                // find corresponding A-Div index
                aDivIndex = FindADivIndex(frequency);
                // calculate Int-N as decimal number
                intN_decimal = (frequency * (1 << aDivIndex) / fPfd);
            }
            else
            {
                // find corresponding A-Div index
                aDivIndex = FindADivIndex(frequency / 2);

                // calculate Int-N as decimal number with respect to the set 
                // RF output B path
                if (static_outBPathIndex == 0)
                {
                    intN_decimal = (frequency / 2) * (1 << aDivIndex) /  fPfd;
                }
                else
                {
                    intN_decimal = (frequency / 2) / fPfd;
                }
            }

            intN = (UInt16)intN_decimal;        // get integer part of Int-N

            remainder = intN_decimal - intN;    // get remainder of the division
        }

        /// <summary>
        /// This function finds the corresponding A-divider index to the specified frequency
        /// </summary>
        /// <param name="value"> frequency to which the A-div value is sought </param>
        /// <returns> finded A-divider index value </returns>
        private static UInt16 FindADivIndex(decimal value)
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

        /// <summary>
        /// The function tries to find a fractional part
        /// </summary>
        /// <param name="remainder"> input remainder of the division </param>
        /// <param name="rDivValueIn"> initial R-divider value </param>
        /// <param name="rDivValue"> output R-divider value </param>
        /// <param name="intNIn"> initial Int-N value </param>
        /// <param name="intN"> output Int-N value </param>
        /// <param name="fracN"> calculated Frac-N value </param>
        /// <param name="mod"> calculated Mod value </param>
        /// <param name="frequency"> desired frequency </param>
        /// <param name="aDivIndex"> A-divider value </param>
        /// <param name="fPfdIn"> initial frequency at PFD input </param>
        /// <param name="fPfd"> output freq at PFD input </param>
        /// <returns> If successfully find fract part return true, if not, return false</returns>
        private static bool TryToCalcFractPart(decimal remainder, 
                                       UInt16 rDivValueIn, out UInt16 rDivValue,
                                       UInt16 intNIn, out UInt16 intN, 
                                       out UInt16 fracN, out UInt16 mod, 
                                       decimal frequency, UInt16 aDivIndex,
                                       decimal fPfdIn, out decimal fPfd)
        {
            /// <summary>
            /// success of operation
            /// </summary>
            bool success;

            fPfd = fPfdIn;              // load initial PFD frequency
            rDivValue = rDivValueIn;    // load initial R-divider value
            intN = intNIn;              // load initial Integer-N value

            Fractions.Fraction fracPart = new Fractions.Fraction();
            
            double accuracy;            // accuracy of coversion
            int correction=1000;        

            // do this while applies that denominator is within limits (2-4095 including)
            // and  accuracy is less than 1.
            do
            {
                accuracy = 0.000001;
                // do this while applies that denominator is within limits (2-4095 including)
                // and  accuracy is less than 0.00001 * correction.
                do
                {
                    if (remainder > 0.0000000001M)
                        fracPart = Fractions.RealToFraction((double)remainder, accuracy);

                    accuracy = accuracy*10;
                } while ((fracPart.D < 2 || fracPart.D > 4095) && accuracy <= 0.00001*correction);

                // check that the denominator is not outside the limits
                if ((fracPart.D < 2 || fracPart.D > 4095))
                {
                    // if yes increase R-divider value by one
                    rDivValue++;
                    // and then re-calculate Integer-N value
                    CalcIntNFromFrequency(frequency, rDivValue,  out intN, 
                                          out remainder, out aDivIndex, out fPfd);
                    // if new calculated Int-N value is still to high
                    if (intN > 4091)
                    {
                        // accuracy set to one, do-while loop will be terminated
                        accuracy = 1;
                        success = false;
                    }
                }
            } while((fracPart.D < 2 || fracPart.D > 4095) && accuracy < 1);
            
            if ((fracPart.D < 2 || fracPart.D > 4095))
            {
                success = false;
                rDivValue = 1;
            }
            else
            {
                success = true;
            }

            mod = (UInt16)fracPart.D;       // get modulus value
            fracN = (UInt16)fracPart.N;     // get Fractional-N value

            return success;
        }

        /// <summary>
        /// This function calculate frequency info from register settings
        /// </summary>
        /// <param name="mode"> PLO mode (FRACTIONAL, INTEGER) </param>
        /// <param name="intN"> Integer-N value </param>
        /// <param name="fracN"> Fractional-N value </param>
        /// <param name="mod"> modulus value </param>
        /// <param name="desiredFreq"> desired output frequency </param>
        /// <param name="fPfd"> frequency at PFD input </param>
        /// <param name="aDivIndex"> A-divider index number </param>
        /// <returns> output calculated frequency </returns>
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