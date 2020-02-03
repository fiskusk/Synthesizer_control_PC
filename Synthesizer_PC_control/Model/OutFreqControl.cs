using System;
using System.Windows.Forms;

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
        public void UpdateUiElements()
        {

        }
    }
}