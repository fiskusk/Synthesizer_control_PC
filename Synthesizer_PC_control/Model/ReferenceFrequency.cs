using System;
using System.Windows.Forms;

namespace Synthesizer_PC_control.Model
{
    public class ReferenceFrequency : I_UiLinked
    {
        private decimal refInFreq;
        private bool isDoubled;
        private bool isDiv2;
        private UInt16 refDivider;
        private decimal pfdFreq;

        private readonly TextBox ui_refInFreq;
        private readonly CheckBox ui_refDoubler;
        private readonly CheckBox ui_refDiv2;
        private readonly NumericUpDown ui_refDivider;

        public ReferenceFrequency(TextBox ui_refInFreq, CheckBox ui_refDoubler, 
                            CheckBox ui_refDiv2, NumericUpDown ui_refDivider)
        {
            this.ui_refInFreq = ui_refInFreq;
            this.ui_refDoubler = ui_refDoubler;
            this.ui_refDiv2 = ui_refDiv2;
            this.ui_refDivider = ui_refDivider;

            this.refDivider = 1; // FIXME delete this after complete OOD
            //UpdateUiElements();
        }

        #region Setters

        public void SetRefFreqValue(string value)
        {
            value = value.Replace(" ", string.Empty);
            value = value.Replace(".", ",");
            this.refInFreq = Convert.ToDecimal(value);

            UpdateUiElements();
        }

        public void SetRefFreqValue(decimal value)
        {
            this.refInFreq = value;

            UpdateUiElements();
        }

        public void SetRefDoubler(bool value)
        {
            isDoubled = value;

            UpdateUiElements();
        }

        #endregion

        #region Getters
        
        public string string_GetRefFreqValue()
        {
            return this.refInFreq.ToString();
        }

        public decimal decimal_GetRefFreqValue()
        {
            return this.refInFreq;
        }

        public bool IsDoubled()
        {
            return isDoubled;
        }

        #endregion

        public void UpdateUiElements() 
        { 
            if(isDoubled)
                ui_refDoubler.Checked = true;
            else
                ui_refDoubler.Checked = false;
            
            if(isDiv2)
                ui_refDiv2.Checked = true; 
            else
                ui_refDiv2.Checked = false; 

            ui_refInFreq.Text = string.Format("{0:f6}", refInFreq);

            ui_refDivider.Value = refDivider;
        } 


    }
}