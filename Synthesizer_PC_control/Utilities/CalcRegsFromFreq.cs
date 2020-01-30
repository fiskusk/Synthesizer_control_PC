using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace Synthesizer_PC_control.Utilities
{
    class CalcRegsFromFreq
    {
        public struct Fraction
        {
            public Fraction(int n, int d)
            {
                N = n;
                D = d;
            }
            public int N { get; private set; }
            public int D { get; private set; }
        }

        public static Fraction RealToFraction(double value, double accuracy)
        {
            if (accuracy <= 0.0 || accuracy >= 1.0)
            {
                throw new ArgumentOutOfRangeException("accuracy", "Must be > 0 and < 1.");
            }

            int sign = Math.Sign(value);

            if (sign == -1)
            {
                value = Math.Abs(value);
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
                    upper_n = middle_n;
                    upper_d = middle_d;
                }
                else if (middle_n < (value - maxError) * middle_d)
                {
                    // middle < real - error : middle is our new lower
                    lower_n = middle_n;
                    lower_d = middle_d;
                }
                else
                {
                    // Middle is our best fraction
                    return new Fraction((n * middle_d + middle_n) * sign, middle_d);
                }
            }
        }
        public static void CalcSynthesizerRegValuesFromInpFreq(Form1 view)
        {
            string f_ref_string = view.RefFTextBox.Text;
            f_ref_string = f_ref_string.Replace(" ", string.Empty);
            f_ref_string = f_ref_string.Replace(".", ",");

            string f_input_string = view.InputFreqTextBox.Text;
            f_input_string = f_input_string.Replace(" ", string.Empty);
            f_input_string = f_input_string.Replace(".", ",");

            decimal f_ref = decimal.Parse(f_ref_string);
            decimal f_input = decimal.Parse(f_input_string);

            view.RDivUpDown.Value = 1;

            if (f_input >= 3000 && f_input <= 6000)
            {
                view.ADivComboBox.SelectedIndex = 0;
            }
            else if (f_input >= 1500 && f_input < 3000)
            {
                view.ADivComboBox.SelectedIndex = 1;
            }
            else if (f_input >= 750 && f_input < 1500)
            {
                view.ADivComboBox.SelectedIndex = 2;
            }
            else if (f_input >= 375 && f_input < 750)
            {
                view.ADivComboBox.SelectedIndex = 3;
            }
            else if (f_input >= 187.5M && f_input < 375)
            {
                view.ADivComboBox.SelectedIndex = 4;
            }
            else if (f_input >= 93.75M && f_input < 187.5M)
            {
                view.ADivComboBox.SelectedIndex = 5;
            }
            else if (f_input >= 46.875M && f_input < 93.75M)
            {
                view.ADivComboBox.SelectedIndex = 6;
            }
            else if (f_input >= 23.5M && f_input < 46.875M)
            {
                view.ADivComboBox.SelectedIndex = 7;
            }
            else if (f_input >= 1500 && f_input < 3000)
            {
                view.ADivComboBox.SelectedIndex = 8;
            }

            UInt16 DIVA = (UInt16)(1 << view.ADivComboBox.SelectedIndex);
            decimal IntN = (f_input*DIVA/(f_ref/view.RDivUpDown.Value));
            decimal zbytek = IntN-(UInt16)IntN;

            if (zbytek>0)
            {
                Fraction pokus = new Fraction();
                //Fraction[] zaloha;
                double accuracy;
                int correction=1;
                //zaloha = new Fraction[500];
                UInt16 cnt = 0;
                do
                {
                    accuracy = 0.000001;
                    do
                    {
                        pokus = RealToFraction((double)zbytek, accuracy);
                        //zaloha[cnt] = pokus;
                        cnt++;
                        accuracy = accuracy*10;
                    } while ((pokus.D < 2 || pokus.D > 4095) && accuracy <= 0.00001*correction);
                    if ((pokus.D < 2 || pokus.D > 4095))
                    {

                        view.RDivUpDown.Value = view.RDivUpDown.Value + 1;
                        IntN = (f_input*DIVA/(f_ref/view.RDivUpDown.Value));
                        zbytek = IntN-(UInt16)IntN;
                        if (IntN > 4091)
                        {
                            correction = correction * 10;
                            view.RDivUpDown.Value = view.RDivUpDown.Value - 1;
                            IntN = (f_input*DIVA/(f_ref/view.RDivUpDown.Value));
                            zbytek = IntN-(UInt16)IntN;
                        }
                    }
                } while((pokus.D < 2 || pokus.D > 4095) && accuracy < 1);
                if ((pokus.D < 2 || pokus.D > 4095))
                {
                    view.ModeIntFracComboBox.SelectedIndex = 0;
                    pokus = new Fraction (1, 4095);
                }
                view.ModeIntFracComboBox.SelectedIndex = 0;
                view.ModNumUpDown.Value = pokus.D;
                view.FracNNumUpDown.Value = pokus.N;
            }
            else
            {
                view.ModeIntFracComboBox.SelectedIndex = 1;
            }
            view.IntNNumUpDown.Value = (UInt16)IntN;

            string f_outA_string = view.fOutAScreenLabel.Text;
            f_outA_string = f_outA_string.Replace(" ", string.Empty);
            f_outA_string = f_outA_string.Replace(".", ",");

            double f_out_A = double.Parse(f_outA_string);

            double delta = ((double)f_input - f_out_A) * 1e6;
            delta  = Math.Round(delta, 3, MidpointRounding.AwayFromZero);
            if (Math.Abs(delta) > 10)
                view.DeltaShowLabel.ForeColor = System.Drawing.Color.Red;
            else
                view.DeltaShowLabel.ForeColor = System.Drawing.Color.Black;

            view.DeltaShowLabel.Text = delta.ToString ("0.###");

        }


    }
}
