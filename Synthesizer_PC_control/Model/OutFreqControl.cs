using System;
using System.Windows.Forms;
using System.Drawing;

namespace Synthesizer_PC_control.Model
{
    public enum SynthMode
    {
        FRACTIONAL,
        INTEGER
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

        public OutFreqControl(NumericUpDown ui_intN, NumericUpDown ui_fracN, 
                              NumericUpDown ui_mod, ComboBox ui_mode, 
                              ComboBox ui_aDiv, NumericUpDown ui_phaseP)
        {
            this.ui_intN    = ui_intN;
            this.ui_fracN   = ui_fracN;
            this.ui_mod     = ui_mod;
            this.ui_mode    = ui_mode;
            this.ui_aDiv    = ui_aDiv;
            this.ui_phaseP  = ui_phaseP;

            intN    = 400;
            fracN   = 0;
            mod     = 125;

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

        public void SetFracNVal(UInt16 value)
        {
            if (value < ui_fracN.Minimum)
                value = (UInt16)ui_fracN.Minimum;
            else if (value > ui_fracN.Maximum)
                value = (UInt16)ui_fracN.Maximum;

            this.fracN = value;

            UpdateUiElements();
        }
        
        public void SetModVal(UInt16 value)
        {
            if (value < ui_mod.Minimum)
                value = (UInt16)ui_mod.Minimum;
            else if (value > ui_mod.Maximum)
                value = (UInt16)ui_mod.Maximum;

            this.mod = value;

            ui_fracN.Maximum = value - 1;

            UpdateUiElements();
        }

        public void SetSynthMode(SynthMode value)
        {
            if (value == SynthMode.FRACTIONAL)
            {
                ui_intN.Minimum = 19;
                ui_intN.Maximum = 4091;
            }
            else
            {
                ui_intN.Minimum = 16;
                ui_intN.Maximum = 65535;
            }

            this.mode = value;

            UpdateUiElements();
        }

        public void SetADivVal(UInt16 value)
        {
            this.aDiv = value;

            UpdateUiElements();
        }

        public void SetPPhaseVal(UInt16 value)
        {
            if (value < ui_phaseP.Minimum)
                value = (UInt16)ui_phaseP.Minimum;
            else if (value > ui_phaseP.Maximum)
                value = (UInt16)ui_phaseP.Maximum;

            this.phaseP = value;

            UpdateUiElements();
        }

        #endregion

        #region Getters
        public UInt16 uint16_GetIntNVal()
        {
            return intN;
        }

        public UInt16 uint16_GetFracNVal()
        {
            return fracN;
        }

        public UInt16 uint16_GetModVal()
        {
            return mod;
        }

        public SynthMode GetSynthMode()
        {
            return mode;
        }

        public UInt16 uint16_GetADivVal()
        {
            return (UInt16)(1 << aDiv);
        }

        public UInt16 SelectedIndex_GetADivVal()
        {
            return aDiv;
        }

        public UInt16 uint16_GetPhasePVal()
        {
            return phaseP;
        }

        #endregion

        public void RecalcRegsForNewPfdFreq(bool value)
        {
            if (value == true)
            {
                if ((intN / 2) < ui_intN.Minimum)
                {
                    intN = (UInt16)ui_intN.Minimum;
                    mod  = (UInt16)ui_mod.Minimum;
                }
                else
                {
                    intN = (UInt16)(intN/2);
                    mod  = (UInt16)(mod*2);
                }
            }
            else
            {
                if ((intN * 2) > ui_intN.Maximum)
                {
                    intN = (UInt16)ui_intN.Maximum;
                    mod  = (UInt16)ui_mod.Maximum;
                }
                else
                {
                    intN = (UInt16)(intN*2);
                    mod  = (UInt16)(mod/2);
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

            this.ui_intN.Value  = intN;
            this.ui_fracN.Value = fracN;
            this.ui_mod.Value   = mod;
            this.ui_mode.SelectedIndex = (int)mode;
            this.ui_aDiv.SelectedIndex = aDiv;
            this.ui_phaseP.Value = phaseP;

            isUiUpdated = true;
        }
    }
}