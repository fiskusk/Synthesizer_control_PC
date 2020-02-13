using System;
using System.Windows.Forms;

namespace Synthesizer_PC_control.Model
{
    public class DirectFreqControl : I_UiLinked
    {
        private decimal directFreqInput;
        private decimal deltaFreq;
        private readonly TextBox ui_directFreqInput;
        private readonly Label ui_deltaFreqLabel;
        public DirectFreqControl(TextBox ui_directFreqInput, Label ui_deltaFreqLabel)
        {
            this.ui_directFreqInput = ui_directFreqInput;
            this.ui_deltaFreqLabel  = ui_deltaFreqLabel;

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
            //ui_directFreqInput.Text = MyFormat.ParseFrequencyDecimalValue(directFreqInput);
            ui_directFreqInput.Text = string.Format("{0:f7}", directFreqInput);

            if (Math.Abs(deltaFreq) > 10)
                ui_deltaFreqLabel.ForeColor = System.Drawing.Color.Red;
            else
                ui_deltaFreqLabel.ForeColor = System.Drawing.Color.Black;
            ui_deltaFreqLabel.Text = deltaFreq.ToString ("0.###");
        }

    }
}