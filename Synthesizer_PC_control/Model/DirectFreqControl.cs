using System;
using System.Windows.Forms;
using System.Drawing;

namespace Synthesizer_PC_control.Model
{
    public class DirectFreqControl : I_UiLinked
    {
        private decimal directFreqInput;
        private decimal deltaFreq;
        private decimal calcFreq;
        private decimal freqAtOut1;
        private decimal freqAtOut2;
        private bool activeOut1;
        private bool activeOut2;
        private readonly TextBox ui_directFreqInput;
        private readonly Label ui_deltaFreqLabel;
        private readonly Label ui_calcFreq;
        private readonly Label ui_freqAtOut1;
        private readonly Label ui_freqAtOut2;
        private readonly Label ui_activeOut1;
        private readonly Label ui_activeOut2;
        public DirectFreqControl(TextBox ui_directFreqInput, Label ui_deltaFreqLabel,
                                 Label ui_calcFreq, Label ui_freqAtOut1, 
                                 Label ui_freqAtOut2, Label ui_activeOut1, 
                                 Label ui_activeOut2)
        {
            this.ui_directFreqInput = ui_directFreqInput;
            this.ui_deltaFreqLabel  = ui_deltaFreqLabel;
            this.ui_calcFreq        = ui_calcFreq;
            this.ui_freqAtOut1      = ui_freqAtOut1;
            this.ui_freqAtOut2      = ui_freqAtOut2;
            this.ui_activeOut1      = ui_activeOut1;
            this.ui_activeOut2      = ui_activeOut2;

            this.directFreqInput = 500.0M;
            this.deltaFreq = 0;
        }

        #region Setters
        public void SetDirectInputFreqValue(string value)
        {
            value = value.Replace(" ", string.Empty);
            value = value.Replace(".", ",");
            SetDirectInputFreqValue(Convert.ToDecimal(value));
        }

        public void SetDirectInputFreqValue(decimal value)
        {
            this.directFreqInput = value;

            UpdateUiElements();
        }

        public void SetDeltaFreqValue(string value)
        {
            value = value.Replace(" ", string.Empty);
            value = value.Replace(".", ",");
            SetDeltaFreqValue(Convert.ToDecimal(value));
        }

        public void SetDeltaFreqValue(decimal value)
        {
            value = Math.Round(value, 3, MidpointRounding.AwayFromZero);
            this.deltaFreq = value;

            UpdateUiElements();
        }

        public void SetCalcFreq(decimal value)
        {
            this.calcFreq = value;

            UpdateUiElements();
        }
        public void SetFreqAtOut1(decimal value)
        {
            this.freqAtOut1 = value;

            UpdateUiElements();
        }
        
        public void SetFreqAtOut2(decimal value)
        {
            this.freqAtOut2 = value;

            UpdateUiElements();
        }

        public void SetActiveOut1(bool value)
        {
            this.activeOut1 = value;

            UpdateUiElements();
        }

        public void SetActiveOut2(bool value)
        {
            this.activeOut2 = value;

            UpdateUiElements();
        }

        #endregion

        #region Getters
        public string string_GetDirectInputFreqVal()
        {
            return this.directFreqInput.ToString();
        }

        public decimal decimal_GetDirectInputFreqVal()
        {
            return this.directFreqInput;
        }
        #endregion

        public void UpdateUiElements()
        {
            if (directFreqInput < 23.5M || directFreqInput > 12000)
            {
                if (directFreqInput < 23.5M)
                    directFreqInput = 23.5M;
                else
                    directFreqInput = 12000;
                MessageBox.Show("The value entered is outside the allowed range for output frequency <23.5M - 12000>", "Output freq value out of range!", 
                MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
            ui_directFreqInput.Text = directFreqInput.ToString("0.000 000");
            //string pokus = MyFormat.ParseFrequencyDecimalValue(directFreqInput, 6); // FIXME this shit
            //ui_directFreqInput.Text = string.Format("{0:f6}", directFreqInput);

            if (Math.Abs(deltaFreq) > 10)
                ui_deltaFreqLabel.ForeColor = System.Drawing.Color.Red;
            else
                ui_deltaFreqLabel.ForeColor = System.Drawing.Color.Black;
            ui_deltaFreqLabel.Text = deltaFreq.ToString ("0.###");

            ui_calcFreq.Text = calcFreq.ToString("0.### ### #");
            ui_freqAtOut1.Text = freqAtOut1.ToString("0.0## ### #");
            ui_freqAtOut2.Text = freqAtOut2.ToString("0.0## ### #");

            if (activeOut1)
            {
                ui_activeOut1.Text = "ON";
                ui_activeOut1.BackColor = Color.LimeGreen;
            }
            else
            {
                ui_activeOut1.Text = "OFF";
                ui_activeOut1.BackColor = SystemColors.ControlDark;
            }

            if (activeOut2)
            {
                ui_activeOut2.Text = "ON";
                ui_activeOut2.BackColor = Color.LimeGreen;
            }
            else
            {
                ui_activeOut2.Text = "OFF";
                ui_activeOut2.BackColor = SystemColors.ControlDark;
            }
        }

    }
}