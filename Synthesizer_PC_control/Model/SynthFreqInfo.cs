using System;
using System.Windows.Forms;
using System.Drawing;

using Synthesizer_PC_control.Controllers;

namespace Synthesizer_PC_control.Model
{
    /// <summary>
    /// This class is used to handle the synthesizer frequency info.
    /// (frequency at synthesizer output A and B, VCO)
    /// </summary>
    public class SynthFreqInfo : I_UiLinked
    {   
        // error messages
        private string badVcoMsg = "Warning: With the current setting, the VCO frequency is outside the limits. <3000 ~ 6000>";  

        /// <summary>
        /// frequency at VCO
        /// </summary>
        private decimal vcoFreq;

        /// <summary>
        /// frequency at synthesizer output A
        /// </summary>
        private decimal fOutA;

        /// <summary>
        /// frequency at synthesizer output B
        /// </summary>
        private decimal fOutB;

        // hold UI elements for synthesizer frequency info group
        private readonly Label ui_fVco;
        private readonly Label ui_fOutA;
        private readonly Label ui_fOutB;

        /// <summary>
        /// Constructor for the synthesizer frequency info. 
        /// (frequency at synthesizer output A and B, VCO)
        /// </summary>
        /// <param name="ui_fVco"> Label UI element for frequency at VCO </param>
        /// <param name="ui_fOutA"> Label UI element for frequency at synthesizer output A </param>
        /// <param name="ui_fOutB"> Label UI element for frequency at synthesizer output B </param>
        public SynthFreqInfo(Label ui_fVco, Label ui_fOutA, Label ui_fOutB)
        {
            this.ui_fVco  = ui_fVco;
            this.ui_fOutA = ui_fOutA;
            this.ui_fOutB = ui_fOutB;
        }

        /// <summary>
        /// Updates all graphic user elements
        /// </summary>
        public void UpdateUiElements()
        {
            this.ui_fVco.Text = vcoFreq.ToString("0.000 000 #");
            this.ui_fOutA.Text = fOutA.ToString("0.000 000 #");
            this.ui_fOutB.Text = fOutB.ToString("0.000 000 #");
        }

        #region Setters
        /// <summary>
        /// At first this function check if new value is beyond limits, if yes then
        /// set freq at out A/B to zero and print into console error message.
        /// If no set new VCO frecuency and update UI elements.
        /// </summary>
        /// <param name="value"> new VCO frequency as decimal value </param>
        /// <returns> false if VCO is beyond limits, true if value is within limits </returns>
        public bool SetVcoFreq(decimal value)
        {
            bool status;
            if ((value < 3000) || (value > 6000))
            {
                ui_fVco.ForeColor = Color.Red;
                ConsoleController.Console().Write(badVcoMsg);
                fOutA = 0;
                fOutB = 0;
                status = false;
            }
            else
            {
                ui_fVco.ForeColor = Color.Black;
                status = true;
            }

            this.vcoFreq = value;

            UpdateUiElements();
            return status;
        }

        /// <summary>
        /// This function set frequency at PLO output A
        /// </summary>
        /// <param name="value"> new PLO frequency at output A as decimal number </param>
        public void SetOutAFreq(decimal value)
        {
            if (this.fOutA != value)
            {
                this.fOutA = value;

                UpdateUiElements();
            }
        }

        /// <summary>
        /// This function set frequency at PLO output B
        /// </summary>
        /// <param name="value"> new PLO frequency at output B as decimal number </param>
        public void SetOutBFreq(decimal value)
        {
            if (this.fOutB != value)
            {
                this.fOutB = value;

                UpdateUiElements();
            }
        }
        #endregion

        #region Getters

        /// <summary>
        /// Function returns VCO frequency
        /// </summary>
        /// <returns> VCO frequency as decimal number </returns>
        public decimal decimal_GetVcoFreq()
        {
            return this.vcoFreq;
        }

        /// <summary>
        /// Function returns frequency at PLO output A
        /// </summary>
        /// <returns> output frequency at PLO output A as decimal number </returns>
        public decimal decimal_GetOutAFreq()
        {
            return this.fOutA;
        }

        /// <summary>
        /// Function returns frequency at PLO output B
        /// </summary>
        /// <returns> output frequency at PLO output B as decimal number </returns>
        public decimal decimal_GetOutBFreq()
        {
            return this.fOutB;
        }

        #endregion
    }
}