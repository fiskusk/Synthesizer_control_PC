using System;
using System.Windows.Forms;
using System.Drawing;

using Synthesizer_PC_control.Controllers;


namespace Synthesizer_PC_control.Model
{
    public class RefFreq : I_UiLinked
    {
        private string badLDSpeedAdjMsg = "Warning: The 'LD Speed adjustment' value is set improperly with respect to the current frequency at the PFD input.";
        private string badInputRefFreqMsg = "Warning: The value entered in ref. freq is outside the allowed range for input signal reference frequency. Maximum ref. input freq. is 210 MHz if reference doubler is disabled, or 105 MHz if enabled.";
        private string badPfdFreqMsg = "Warning: The PFD input frequency is too high. For Frac-N mode is alowed max 125 MHz and for Int-N mode is allowed 140 MHz";
        private UInt16 maxRefInputFreq = 210;   // maximum Reference Input signal freq if doubler is disabled (210MHz), if enabled max is 105MHz
        private UInt16 minRefInputFreq = 10;    // minimum ref input freq
        private UInt16 maxPfdFreq = 125;        // maximum PFD freq for Frac-N mode (125MHz), if mode is Int-N maximum is (140MHz)
        private SynthMode synthMode;
        private decimal refInFreq;
        private bool isDoubled;
        private bool isDivBy2;
        private UInt16 refDivider;
        private decimal pfdFreq;
        private int LDSpeedAdj;
        private bool autoLdSpeedAdj;
        private readonly TextBox ui_refInFreq;
        private readonly CheckBox ui_refDoubler;
        private readonly CheckBox ui_refDiv2;
        private readonly NumericUpDown ui_refDivider;
        private readonly Label ui_pfdFreqShowLabel;
        private readonly ComboBox ui_LDSpeedAdj;
        private readonly CheckBox ui_autoLdSpeedAdj;
        private readonly Label ui_LDSpeedAdjLabel;
        private readonly Label ui_internalRefLabel;

        public RefFreq(TextBox ui_refInFreq, CheckBox ui_refDoubler, 
                       CheckBox ui_refDiv2, NumericUpDown ui_refDivider, 
                       Label ui_pfdFreqShowLabel, ComboBox ui_LDSpeedAdj,
                       CheckBox ui_autoLdSpeedAdj, Label ui_LDSpeedAdjLabel,
                       Label ui_internalRefLabel)
        {
            this.ui_refInFreq = ui_refInFreq;
            this.ui_refDoubler = ui_refDoubler;
            this.ui_refDiv2 = ui_refDiv2;
            this.ui_refDivider = ui_refDivider;
            this.ui_pfdFreqShowLabel = ui_pfdFreqShowLabel;
            this.ui_LDSpeedAdj = ui_LDSpeedAdj;
            this.ui_autoLdSpeedAdj = ui_autoLdSpeedAdj;
            this.ui_LDSpeedAdjLabel = ui_LDSpeedAdjLabel;
            this.ui_internalRefLabel = ui_internalRefLabel;

            this.refInFreq = 10.0M;
            this.isDoubled = false;
            this.isDivBy2 = false;
            this.refDivider = 1;
            this.pfdFreq = 10.0M;
            
            //UpdateUiElements();
        }

        #region Setters

        public void SetSynthModeInfoVariable(SynthMode value)
        {
            if (synthMode != value)
            {
                this.synthMode = value;

                SetPfdFreq();

                UpdateUiElements();
            }
        }
        public void SetRefFreqValue(string value)
        {
            value = value.Replace(" ", string.Empty);
            value = value.Replace(".", ",");
            SetRefFreqValue(Convert.ToDecimal(value));
        }

        public void SetRefFreqValue(decimal value)
        {
            if (value != refInFreq)
            {
                if (value < minRefInputFreq || value > maxRefInputFreq)
                {
                    value = this.refInFreq;
                    ConsoleController.Console().Write(badInputRefFreqMsg);
                }
                else
                {
                    this.refInFreq = value;
                }

                SetPfdFreq();

                UpdateUiElements();
            }
        }

        public void SetRefDoubler(bool value)
        {
            if (value != isDoubled)
            {
                if (value == false)
                {
                    maxRefInputFreq = 210;
                    if (refInFreq > maxRefInputFreq)
                    {
                        refInFreq = 210;
                        ConsoleController.Console().Write(badInputRefFreqMsg);
                    }
                }
                else
                {
                    maxRefInputFreq = 105;
                    if (refInFreq > maxRefInputFreq)
                    {
                        refInFreq = 105;
                        ConsoleController.Console().Write(badInputRefFreqMsg);
                    }
                }

                this.isDoubled = value;

                SetPfdFreq();

                UpdateUiElements();
            }
        }

        public void SetRefDivBy2(bool value)
        {
            if (isDivBy2 != value)
            {
                this.isDivBy2 = value;
                
                SetPfdFreq();

                UpdateUiElements();
            }
        }

        public void SetRDivider(UInt16 value)
        {
            if (refDivider != value)
            {
                if (value < ui_refDivider.Minimum || value > ui_refDivider.Maximum)
                {
                    if (value < ui_refDivider.Minimum)
                        value = (UInt16)ui_refDivider.Minimum;
                    else
                        value = (UInt16)ui_refDivider.Maximum;
                }

                this.refDivider = value;

                SetPfdFreq();

                UpdateUiElements();
            }
        }

        private void SetPfdFreq()
        {
            if (synthMode == SynthMode.FRACTIONAL)
            {
                maxPfdFreq = 125;
            }
            else
            {
                maxPfdFreq = 140;
            }

            this.pfdFreq = refInFreq * ((1 + Convert.ToUInt16(isDoubled)) / 
                (decimal)(refDivider * (1 + Convert.ToUInt16(isDivBy2))));

            if (pfdFreq > maxPfdFreq)
            {
                ConsoleController.Console().Write(badPfdFreqMsg);
                ui_pfdFreqShowLabel.ForeColor = Color.Red;
            }
            else
            {
                ui_pfdFreqShowLabel.ForeColor = Color.Black;
            }
        }

        public void SetLDSpeedAdj(int value)
        {
            if (LDSpeedAdj != value)
            {
                if (value == 0)
                {
                    if (pfdFreq > 32)
                    {
                        ConsoleController.Console().Write(badLDSpeedAdjMsg);
                        ui_LDSpeedAdjLabel.ForeColor = Color.Red;
                    }
                    else
                    {
                        ui_LDSpeedAdjLabel.ForeColor = Color.Black;
                    }
                }
                else
                {
                    if (pfdFreq <= 32)
                    {
                        ConsoleController.Console().Write(badLDSpeedAdjMsg);
                        ui_LDSpeedAdjLabel.ForeColor = Color.Red;
                    }
                    else
                    {
                        ui_LDSpeedAdjLabel.ForeColor = Color.Black;
                    }
                }
                LDSpeedAdj = value;

                UpdateUiElements();
            }
        }

        public void SetAutoLDSpeedAdj(bool value)
        {
            if (autoLdSpeedAdj != value)
            {
                if (value)
                {
                    if(pfdFreq <= 32)
                        LDSpeedAdj = 0;
                    else
                        LDSpeedAdj = 1;
                    ui_LDSpeedAdjLabel.ForeColor = Color.Black;
                }
                
                autoLdSpeedAdj = value;

                UpdateUiElements();
            }
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

        public bool GetIsDoubled()
        {
            return this.isDoubled;
        }

        public bool GetIsDividedBy2()
        {
            return this.isDivBy2;
        }

        public UInt16 uint16_GetRefDividerValue()
        {
            return this.refDivider;
        }

        public decimal decimal_GetPfdFreq()
        {
            return this.pfdFreq;
        }

        public bool bool_GetAutoLdSpeedAdj()
        {
            return this.autoLdSpeedAdj;
        }

        #endregion

        public void ChangeRefInpUIEnabled(bool state)
        {
            ui_refInFreq.Enabled = state;
            if (state)
                ui_internalRefLabel.Text = "External";
            else
                ui_internalRefLabel.Text = "Internal";
        }

        public void UpdateUiElements() 
        {
            ui_refDoubler.Checked = isDoubled;
            ui_refDiv2.Checked = isDivBy2; 
            ui_refInFreq.Text = string.Format("{0:f6}", refInFreq);
            ui_refDivider.Value = refDivider;
            ui_pfdFreqShowLabel.Text = MyFormat.ParseFrequencyDecimalValue(pfdFreq);
            ui_autoLdSpeedAdj.Checked = autoLdSpeedAdj;
            ui_LDSpeedAdj.SelectedIndex = LDSpeedAdj;
        } 
    }
}