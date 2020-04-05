using System;

namespace Synthesizer_PC_control.Utilities
{
    /// <summary>
    /// This class is inspired by code on this website:
    /// https://stackoverflow.com/questions/5124743/algorithm-for-simplifying-decimal-to-fractions/32903747#32903747
    /// This class include static fucntion for transfer real number into fraction.
    /// </summary>
    class Fractions
    {
        /// <summary>
        /// Fraction type for numerator and denumerator
        /// </summary>
        public struct Fraction
        {
            /// <summary>
            /// Contructor for Fraction
            /// </summary>
            /// <param name="n"> numerator integer number </param>
            /// <param name="d"> denumerator integer number </param>
            public Fraction(int n, int d)
            {
                N = n;  
                D = d;  
            }
            public int N { get; private set; }
            public int D { get; private set; }
        }

        /// <summary>
        /// Use this function to convert a real double number to a fraction 
        /// with a specified precision.
        /// </summary>
        /// <param name="value"> real double number to conversion </param>
        /// <param name="accuracy"> accuracy of coversion </param>
        /// <returns> fraction (numerator, denominator) </returns>
        public static Fraction RealToFraction(double value, double accuracy)
        {
            // check if accuracy is within limits
            if (accuracy <= 0.0 || accuracy >= 1.0)
            {
                throw new ArgumentOutOfRangeException("accuracy", "Must be > 0 and < 1.");
            }

            int sign = Math.Sign(value);    // check sign

            if (sign == -1)
            {
                value = Math.Abs(value);    // make absolute number
            }

            // Accuracy is the maximum relative error; convert to absolute maxError
            double maxError = sign == 0 ? accuracy : value * accuracy;

            int n = (int) Math.Floor(value);
            value -= n;

            if (value < maxError)
            {
                return new Fraction(sign * n, 1);
            }

            if (1 - maxError < value)
            {
                return new Fraction(sign * (n + 1), 1);
            }

            // The lower fraction is 0/1
            int lower_n = 0;
            int lower_d = 1;

            // The upper fraction is 1/1
            int upper_n = 1;
            int upper_d = 1;

            while (true)
            {
                // The middle fraction is (lower_n + upper_n) / (lower_d + upper_d)
                int middle_n = lower_n + upper_n;
                int middle_d = lower_d + upper_d;

                if (middle_d * (value + maxError) < middle_n)
                {
                    // real + error < middle : middle is our new upper
                    Seek(ref upper_n, ref upper_d, lower_n, lower_d, (un, ud) => (lower_d + ud) * (value + maxError) < (lower_n + un));
                }
                else if (middle_n < (value - maxError) * middle_d)
                {
                    // middle < real - error : middle is our new lower
                    Seek(ref lower_n, ref lower_d, upper_n, upper_d, (ln, ld) => (ln + upper_n) < (value - maxError) * (ld + upper_d));
                }
                else
                {
                    // Middle is our best fraction
                    return new Fraction((n * middle_d + middle_n) * sign, middle_d);
                }
            }
        }

        /// <summary>
        /// Binary seek for the value where f() becomes false.
        /// </summary>
        private static void Seek(ref int a, ref int b, int ainc, int binc, Func<int, int, bool> f)
        {
            a += ainc;
            b += binc;

            if (f(a, b))
            {
                int weight = 1;

                do
                {
                    weight *= 2;
                    a += ainc * weight;
                    b += binc * weight;
                }
                while (f(a, b));

                do
                {
                    weight /= 2;

                    int adec = ainc * weight;
                    int bdec = binc * weight;

                    if (!f(a - adec, b - bdec))
                    {
                        a -= adec;
                        b -= bdec;
                    }
                }
                while (weight > 1);
            }
        }
    }
}
