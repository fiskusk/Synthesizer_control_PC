using System;
using System.Windows.Forms;
using Synthesizer_PC_control.Utilities;

namespace Synthesizer_PC_control.Model
{
    public class RefFreq : I_UiLinked
    {
        private decimal refInFreq;
        private bool isDoubled;
        private bool isDivBy2;
        private UInt16 refDivider;
        private decimal pfdFreq;
        private bool isUiUpdated;

        private readonly TextBox ui_refInFreq;
        private readonly CheckBox ui_refDoubler;
        private readonly CheckBox ui_refDiv2;
        private readonly NumericUpDown ui_refDivider;
        private readonly Label ui_pfdFreqShowLabel;

        public RefFreq(TextBox ui_refInFreq, CheckBox ui_refDoubler, 
            CheckBox ui_refDiv2, NumericUpDown ui_refDivider, Label ui_pfdFreqShowLabel)
        {
            this.ui_refInFreq = ui_refInFreq;
            this.ui_refDoubler = ui_refDoubler;
            this.ui_refDiv2 = ui_refDiv2;
            this.ui_refDivider = ui_refDivider;
            this.ui_pfdFreqShowLabel = ui_pfdFreqShowLabel;

            this.refInFreq = 10.0M;
            this.isDoubled = false;
            this.isDivBy2 = false;
            this.refDivider = 1;
            this.pfdFreq = 10.0M;
            
            //UpdateUiElements();
        }

        #region Setters

        public void SetRefFreqValue(string value)
        {
            value = value.Replace(" ", string.Empty);
            value = value.Replace(".", ",");
            SetRefFreqValue(Convert.ToDecimal(value));
        }

        public void SetRefFreqValue(decimal value)
        {
            this.refInFreq = value;

            UpdateUiElements();
        }

        public void SetRefDoubler(bool value)
        {
            this.isDoubled = value;

            UpdateUiElements();
        }

        public void SetRefDivBy2(bool value)
        {
            this.isDivBy2 = value;

            UpdateUiElements();
        }

        public void SetRDivider(UInt16 value)
        {
            this.refDivider = value;

            UpdateUiElements();
        }

        public void SetPfdFreq(decimal value)
        {
            // Ochrana formátu
            this.pfdFreq = value;

            UpdateUiElements();
        }

        public void SetPfdFreq(string value)
        {
            value = value.Replace(" ", string.Empty);
            value = value.Replace(".", ",");
            SetPfdFreq(Convert.ToDecimal(value));
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
            return this.isDoubled;
        }

        public bool IsDividedBy2()
        {
            return this.isDivBy2;
        }

        public UInt16 uint16_GetRefDividerValue()
        {
            return this.refDivider;
        }

        public bool IsUiUpdated()
        {
            return this.isUiUpdated;
        }

        public decimal decimal_GetPfdFreq()
        {
            return this.pfdFreq;
        }

        #endregion

        public void UpdateUiElements() 
        {
            isUiUpdated = false;
            if(isDoubled)
                ui_refDoubler.Checked = true;
            else
                ui_refDoubler.Checked = false;
            
            if(isDivBy2)
                ui_refDiv2.Checked = true; 
            else
                ui_refDiv2.Checked = false; 

            if (refInFreq < 10 || refInFreq > 210)
            {
                if (refInFreq < 10)
                    refInFreq = 10;
                else
                    refInFreq = 210;
                MessageBox.Show("The value entered is outside the allowed range for input signal reference frequency <10 - 210>", "Reference freq value out of range!", 
                MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
            ui_refInFreq.Text = string.Format("{0:f6}", refInFreq);

            try
            {
                ui_refDivider.Value = refDivider;
            }
            catch
            {
                if (refDivider < ui_refDivider.Minimum)
                    refDivider = (UInt16)ui_refDivider.Minimum;
                else if (refDivider > ui_refDivider.Maximum)
                    refDivider = (UInt16)ui_refDivider.Maximum;
                ui_refDivider.Value = refDivider;
                MessageBox.Show("The value entered is outside the allowed range for the R divider <1 - 1023>", "R div value out of range!", 
                MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }

            ui_pfdFreqShowLabel.Text = MyFormat.ParseFrequencyDecimalValue(pfdFreq);

            isUiUpdated = true;

            
        } 
    }
}