using System;
using System.Windows.Forms;
using System.Drawing;

using Synthesizer_PC_control.Controllers;

namespace Synthesizer_PC_control.Model
{
    public class SynthFreqInfo : I_UiLinked
    {
        private string badVcoMsg = "Warning: With the current setting, the VCO frequency is outside the limits. <3000 ~ 6000>";  

        private decimal vcoFreq;
        private decimal fOutA;
        private decimal fOutB;
        private readonly Label ui_fVco;
        private readonly Label ui_fOutA;
        private readonly Label ui_fOutB;
        public SynthFreqInfo(Label ui_fVco, Label ui_fOutA, Label ui_fOutB)
        {
            this.ui_fVco  = ui_fVco;
            this.ui_fOutA = ui_fOutA;
            this.ui_fOutB = ui_fOutB;
        }

        #region Setters
        public bool SetVcoFreq(decimal value)
        {
            bool status;
            if ((value < 3000) || (value > 6000))
            {
                ui_fVco.ForeColor = Color.Red;
                ConsoleController.Console().Write(badVcoMsg);
                value = 0;
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

        public void SetOutAFreq(decimal value)
        {
            this.fOutA = value;

            UpdateUiElements();
        }

        public void SetOutBFreq(decimal value)
        {
            this.fOutB = value;

            UpdateUiElements();
        }
        #endregion

        #region Getters
        public decimal decimal_GetVcoFreq()
        {
            return this.vcoFreq;
        }

        public decimal decimal_GetOutAFreq()
        {
            return this.fOutA;
        }

        public decimal decimal_GetOutBFreq()
        {
            return this.fOutB;
        }

        #endregion

        public void UpdateUiElements()
        {
            
            this.ui_fVco.Text = vcoFreq.ToString("0.0## ### #");
            this.ui_fOutA.Text = fOutA.ToString("0.0## ### #");
            this.ui_fOutB.Text = fOutB.ToString("0.0## ### #");
        }
    }
}