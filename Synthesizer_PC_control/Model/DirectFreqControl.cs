using System;
using System.Windows.Forms;
using System.Drawing;

namespace Synthesizer_PC_control.Model
{
    /// <summary>
    /// This class is used to handle the direct frequency input control. 
    /// (direct frequency input, delta frequency, calculated frequency, 
    /// frequency and enabled state of output 1 and 2, internal or external ref state) 
    /// </summary>
    public class DirectFreqControl : I_UiLinked
    {
        /// <summary>
        /// Hold direct frequency input
        /// </summary>
        private decimal directFreqInput;

        /// <summary>
        /// Hold delta frequency
        /// </summary>
        private decimal deltaFreq;

        /// <summary>
        /// Hold calculated frequency
        /// </summary>
        private decimal calcFreq;

        /// <summary>
        /// Hold frequency at first output
        /// </summary>
        private decimal freqAtOut1;

        // Hold frequency at second output
        private string freqAtOut2;

        /// <summary>
        /// Hold state of active output 1
        /// </summary>
        private bool activeOut1;

        /// <summary>
        /// Hold state of active output 2
        /// </summary>
        private bool activeOut2;

        /// <summary>
        /// Hold state if internal reference is selected 
        /// </summary>
        private bool intRefState;

        // hold UI elements for direct frequency controls group
        private readonly TextBox ui_directFreqInput;
        private readonly Label ui_deltaFreqLabel;
        private readonly Label ui_calcFreq;
        private readonly Label ui_freqAtOut1;
        private readonly Label ui_freqAtOut2;
        private readonly Label ui_activeOut1;
        private readonly Label ui_activeOut2;
        private readonly Label ui_intRefState;

        /// <summary>
        /// Constructor for the direct frequency input control. 
        /// (direct frequency input, delta frequency, calculated frequency, 
        /// frequency and enabled state of output 1 and 2, internal or external ref state) 
        /// </summary>
        /// <param name="ui_directFreqInput"> TextBox UI element for direct frequency input </param>
        /// <param name="ui_deltaFreqLabel"> Label UI element for delta frequency value </param>
        /// <param name="ui_calcFreq"> Label UI element for calculated frequency valu e</param>
        /// <param name="ui_freqAtOut1"> Label UI element for frequency at output 1 </param>
        /// <param name="ui_freqAtOut2"> Label UI element for frequency at output 2 </param>
        /// <param name="ui_activeOut1"> Label UI element for state if output 1 is active </param>
        /// <param name="ui_activeOut2"> Label UI element for state if output 1 is active </param>
        /// <param name="ui_intRefState"> Label UI element for internal or external reference state </param>
        public DirectFreqControl(TextBox ui_directFreqInput, Label ui_deltaFreqLabel,
                                 Label ui_calcFreq, Label ui_freqAtOut1, 
                                 Label ui_freqAtOut2, Label ui_activeOut1, 
                                 Label ui_activeOut2, Label ui_intRefState)
        {
            this.ui_directFreqInput = ui_directFreqInput;
            this.ui_deltaFreqLabel  = ui_deltaFreqLabel;
            this.ui_calcFreq        = ui_calcFreq;
            this.ui_freqAtOut1      = ui_freqAtOut1;
            this.ui_freqAtOut2      = ui_freqAtOut2;
            this.ui_activeOut1      = ui_activeOut1;
            this.ui_activeOut2      = ui_activeOut2;
            this.ui_intRefState        = ui_intRefState;

            this.directFreqInput = 500.0M;
            this.deltaFreq = 0;
        }

        /// <summary>
        /// Updates all graphic user elements
        /// </summary>
        public void UpdateUiElements()
        {
            ui_directFreqInput.Text = directFreqInput.ToString("0.000 000");
            ui_deltaFreqLabel.Text = deltaFreq.ToString ("+ 0.###;- 0.###;0");
            ui_calcFreq.Text = calcFreq.ToString("0.000 000 #");
            ui_freqAtOut1.Text = freqAtOut1.ToString("0.000 000 #");
            ui_freqAtOut2.Text = freqAtOut2;

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

            if (intRefState)
                ui_intRefState.Text = "Internal";
            else
                ui_intRefState.Text = "External";
        }

        #region Setters

        /// <summary>
        /// Function set direct frequency input string.
        /// It remove all spaces and replace dot decimal separator by comma separator.
        /// If input string is empty, value was minimum possible (23,4375 MHz)
        /// </summary>
        /// <param name="value"> input direct frequency string </param>
        public void SetDirectInputFreqValue(string value)
        {
            value = value.Replace(" ", string.Empty);
            value = value.Replace(".", ",");

            if (value == string.Empty)
                value = "23,4375";

            SetDirectInputFreqValue(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Function check is value is beyond limits, adjust it if necessary and show MessageBox, 
        /// and then set direct frequency
        /// </summary>
        /// <param name="value"> input decimal value </param>
        public void SetDirectInputFreqValue(decimal value)
        {
            if (value < 23.4375M || value > 12000)
            {
                if (value < 23.4375M)
                    value = 23.4375M;
                else
                    value = 12000;
                MessageBox.Show("The value entered is outside the allowed range for output frequency <23.4375 - 12000>", "Output freq value out of range!", 
                MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }

            this.directFreqInput = value;

            UpdateUiElements();
        }

        /// <summary>
        /// Function set delta frequency input string.
        /// It remove all spaces and replace dot decimal separator by comma separator.
        /// </summary>
        /// <param name="value"> delta frequency string </param>
        public void SetDeltaFreqValue(string value)
        {
            value = value.Replace(" ", string.Empty);
            value = value.Replace(".", ",");
            SetDeltaFreqValue(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Function round input decimal number on 3 decimals and if
        /// rouded value is greater than 10 set ForeColor to Red, otherwise to Black.false
        /// Then set new value into model.
        /// </summary>
        /// <param name="value"> delta frequency as decimal number </param>
        public void SetDeltaFreqValue(decimal value)
        {
            value = Math.Round(value, 3, MidpointRounding.AwayFromZero);

            if (Math.Abs(value) > 10)
                ui_deltaFreqLabel.ForeColor = System.Drawing.Color.Red;
            else
                ui_deltaFreqLabel.ForeColor = System.Drawing.Color.Black;

            this.deltaFreq = value;

            UpdateUiElements();
        }
        
        /// <summary>
        /// This function set into model new calculated frequency
        /// </summary>
        /// <param name="value"> calculated frequency as decimal number </param>
        public void SetCalcFreq(decimal value)
        {
            this.calcFreq = value;

            UpdateUiElements();
        }

        /// <summary>
        /// Set frequency at synthesizer module output 1
        /// </summary>
        /// <param name="value"> decimal representation synthesizer module frequency at output 1 </param>
        public void SetFreqAtOut1(decimal value)
        {
            this.freqAtOut1 = value;

            UpdateUiElements();
        }
        
        /// <summary>
        /// Check input frequency for synthesizer module output 2, 
        /// and if value is less than 5000 show red collored text "OutB freq Low"
        /// or if value is greater than 12000 show red collored text "OutB freq Hi"
        /// </summary>
        /// <param name="value"> decimal representation synthesizer module frequency at output 2 </param>
        public void SetFreqAtOut2(decimal value)
        {
            if (value >= 5000 && value <= 12000)
            {
                this.freqAtOut2 = value.ToString("0.0## ### #");
                this.ui_freqAtOut2.ForeColor = Color.Black;
            }
            else if (value < 5000)
            {
                this.freqAtOut2 = "OutB freq Low";
                this.ui_freqAtOut2.ForeColor = Color.Red;
            }
            else if (value > 12000)
            {
                this.freqAtOut2 = "OutB freq Hi";
                this.ui_freqAtOut2.ForeColor = Color.Red;
            }

            UpdateUiElements();
        }

        /// <summary>
        /// This function set if synthesizer module output 1 is active or not
        /// </summary>
        /// <param name="value"> 
        ///     0 - output disabled, 
        ///     1 - output enabled 
        /// </param>
        public void SetActiveOut1(bool value)
        {
            this.activeOut1 = value;

            UpdateUiElements();
        }

        /// <summary>
        /// This function set if synthesizer module output 2 is active or not
        /// </summary>
        /// <param name="value"> 
        ///     0 - output disabled, 
        ///     1 - output enabled
        /// </param>
        public void SetActiveOut2(bool value)
        {
            this.activeOut2 = value;

            UpdateUiElements();
        }

        /// <summary>
        /// This function set state if synthesizer module has sellected 
        /// internal or external reference
        /// </summary>
        /// <param name="value">
        ///     0 - external reference, 
        ///     1 - internal reference 
        /// </param>
        public void SetIntRefState(bool value)
        {
            this.intRefState = value;

            UpdateUiElements();
        }

        #endregion

        #region Getters

        /// <summary>
        /// Function for get direct frequency input value
        /// </summary>
        /// <returns> direct frequency input as string </returns>
        public string string_GetDirectInputFreqVal()
        {
            return this.directFreqInput.ToString();
        }

        /// <summary>
        /// Function for get direct frequency input value
        /// </summary>
        /// <returns> direct frequency input as decimal value </returns>
        public decimal decimal_GetDirectInputFreqVal()
        {
            return this.directFreqInput;
        }

        /// <summary>
        /// Function for get if output 1 is active or not
        /// </summary>
        /// <returns> synthesizer module output 1 is enabled (true) or disabled (false) </returns>
        public bool GetActiveOut1()
        {
            return this.activeOut1;
        }

        /// <summary>
        /// Function for get if output 2 is active or not
        /// </summary>
        /// <returns> synthesizer module output 2 is enabled (true) or disabled (false) </returns>
        public bool GetActiveOut2()
        {
            return this.activeOut2;
        }

        /// <summary>
        /// This function return frequency at synthesizer module output 1
        /// </summary>
        /// <returns> frequency at synthesizer module output 1 as sting </returns>
        public string string_GetFreqAtOut1()
        {
            return this.freqAtOut1.ToString("0.000000");
        }

        /// <summary>
        /// This function return frequency at synthesizer module output 2
        /// </summary>
        /// <returns> frequency at synthesizer module output 2 as sting </returns>
        public string string_GetFreqAtOut2()
        {
            return this.freqAtOut2;
        }
        
        #endregion
    }
}