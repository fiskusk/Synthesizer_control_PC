using System;
using System.Windows.Forms;
using System.Drawing;

namespace Synthesizer_PC_control.Model
{
    public enum SynthMode
    {
        INTEGER,
        FRACTIONAL
    }
    public class OutFreqControl : I_UiLinked
    {
        private UInt16 intN;
        private UInt16 fracN;
        private UInt16 mod;
        private SynthMode mode;
        private UInt16 aDiv;
        private UInt16 phaseP;
        private bool isUiUpdated;

        private readonly NumericUpDown ui_intN;
        private readonly NumericUpDown ui_fracN;
        private readonly NumericUpDown ui_mod;
        private readonly ComboBox ui_mode;
        private readonly ComboBox ui_aDiv;
        private readonly NumericUpDown ui_phaseP; 

        public OutFreqControl(NumericUpDown ui_intN, NumericUpDown ui_fracN, NumericUpDown ui_mod, ComboBox ui_mode, ComboBox ui_aDiv, NumericUpDown ui_phaseP)
        {
            this.ui_intN = ui_intN;
            this.ui_fracN = ui_fracN;
            this.ui_mod = ui_mod;
            this.ui_mode = ui_mode;
            this.ui_aDiv = ui_aDiv;
            this.ui_phaseP = ui_phaseP;

            //UpdateUiElements();
        }

        #region Setters
        public void SetIntNVal(UInt16 value)
        {
            if (value < ui_intN.Minimum)
                value = (UInt16)ui_intN.Minimum;
            else if (value > ui_intN.Maximum)
                value = (UInt16)ui_intN.Maximum;

            this.intN = value;

            UpdateUiElements();
        }
        #endregion

        #region Getters
        public UInt16 uint16_GetIntNVal()
        {
            return intN;
        }

        #endregion

        public void ChangeIntNVal(bool value)
        {
            if (value == true)
            {
                if ((intN / 2) < ui_intN.Minimum)
                    intN = (UInt16)ui_intN.Minimum;
                else
                {
                    intN = (UInt16)(intN/2);
                    // TODO double mod value to get same frequency
                }
            }
            else
            {
                if ((intN * 2) > ui_intN.Maximum)
                    intN = (UInt16)ui_intN.Maximum;
                else
                {
                    intN = (UInt16)(intN*2);

                }
            }

            UpdateUiElements();
        }

        public void ChangeIntNBackColor(Color backColor)
        {
            ui_intN.BackColor = backColor;
        }

        public bool IsUiUpdated()
        {
            return this.isUiUpdated;
        }

        public void UpdateUiElements()
        {
            isUiUpdated = false;

            this.ui_intN.Value = intN;

            isUiUpdated = true;
        }
    }
}