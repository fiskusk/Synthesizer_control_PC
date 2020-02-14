using System;
using System.Windows.Forms;
using System.Drawing;

namespace Synthesizer_PC_control.Model
{
    public class SynthFreqInfo : I_UiLinked
    {
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
        public void SetVcoFreq(decimal value)
        {
            this.vcoFreq = value;

            UpdateUiElements();
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
            
            this.ui_fVco.Text = MyFormat.ParseFrequencyDecimalValue(vcoFreq);

            if ((vcoFreq < 3000) || (vcoFreq > 6000))
                ui_fVco.ForeColor = Color.Red;
            else
                ui_fVco.ForeColor = Color.Black;

            this.ui_fOutA.Text = MyFormat.ParseFrequencyDecimalValue(fOutA);
            this.ui_fOutB.Text = MyFormat.ParseFrequencyDecimalValue(fOutB);
        }
    }
}