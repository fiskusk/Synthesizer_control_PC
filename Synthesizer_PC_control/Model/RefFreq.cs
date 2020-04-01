using System;
using System.Windows.Forms;
using System.Drawing;

using Synthesizer_PC_control.Controllers;


namespace Synthesizer_PC_control.Model
{
    /// <summary>
    /// This class is used to handle the reference frequency of PLO
    /// (doubler, divider/2, R-divider, reference frequency, PFD frequency, 
    /// Lock-Detect speed, auto compute LD-Speed).
    /// </summary>
    public class RefFreq : I_UiLinked
    {
        // error messages
        private string badLDSpeedAdjMsg = "Warning: The 'LD Speed adjustment' value is set improperly with respect to the current frequency at the PFD input.";
        private string badInputRefFreqMsg = "Warning: The value entered in ref. freq is outside the allowed range for input signal reference frequency. Maximum ref. input freq. is 210 MHz if reference doubler is disabled, or 105 MHz if enabled.";
        private string badPfdFreqMsg = "Warning: The PFD input frequency is too high. For Frac-N mode is alowed max 125 MHz and for Int-N mode is allowed 140 MHz";

        // limits for some elements
        /// <summary>
        /// maximum Reference Input signal freq if doubler is disabled (210MHz), if enabled max is 105MHz
        /// </summary>
        private UInt16 maxRefInputFreq = 210;

        /// <summary>
        /// minimum ref input freq
        /// </summary>
        private UInt16 minRefInputFreq = 10;

        /// <summary>
        /// maximum PFD freq for Frac-N mode (125MHz), if mode is Int-N maximum is (140MHz)
        /// </summary>
        private UInt16 maxPfdFreq = 125;

        /// <summary>
        /// Holds synthesizer mode (Frac., Integer)
        /// </summary>
        private SynthMode synthMode;

        /// <summary>
        /// Decimal value of reference frequency
        /// </summary>
        private decimal refInFreq;

        /// <summary>
        /// Hold if PLO has reference frequency doubled or not
        /// </summary>
        private bool isDoubled;

        /// <summary>
        /// Hold if PLO has reference frequency divided by two or not
        /// </summary>
        private bool isDivBy2;

        /// <summary>
        /// Hold reference R-divider value
        /// </summary>
        private UInt16 refDivider;

        /// <summary>
        /// Hold frequency at phase frequency detector (PFD)
        /// </summary>
        private decimal pfdFreq;

        /// <summary>
        /// Lock-Detect speed adjustment
        /// </summary>
        private int LDSpeedAdjIndex;

        /// <summary>
        /// Auto calculate correct value of LDspeedAdj
        /// </summary>
        private bool autoLdSpeedAdj;

        /// <summary>
        /// hold value if is active internal reference or external
        /// </summary>
        private bool intRefState;

        // hold UI elements for reference frequency controls group
        private readonly TextBox ui_refInFreq;
        private readonly CheckBox ui_refDoubler;
        private readonly CheckBox ui_refDiv2;
        private readonly NumericUpDown ui_refDivider;
        private readonly Label ui_pfdFreqShowLabel;
        private readonly ComboBox ui_LDSpeedAdj;
        private readonly CheckBox ui_autoLdSpeedAdj;
        private readonly Label ui_LDSpeedAdjLabel;
        private readonly Label ui_internalRefLabel;

        /// <summary>
        /// Constructor for operations with reference frequency of PLO.
        /// (doubler, divider/2, R-divider, reference frequency, PFD frequency, 
        /// Lock-Detect speed, auto compute LD-Speed).
        /// </summary>
        /// <param name="ui_refInFreq"> TextBox UI element for reference input frequency </param>
        /// <param name="ui_refDoubler"> CheckBox UI element for control ref. doubler </param>
        /// <param name="ui_refDiv2"> CheckBox UI element for control ref. divider by two </param>
        /// <param name="ui_refDivider"> NumericUpDown UI element for control R-Divider value </param>
        /// <param name="ui_pfdFreqShowLabel"> Label UI element for printing calculated PFD frequency value </param>
        /// <param name="ui_LDSpeedAdj"> ComboBox UI element for control LD speed adjustment </param>
        /// <param name="ui_autoLdSpeedAdj"> CheckBox UI element for control auto-computing LD speed adjustment </param>
        /// <param name="ui_LDSpeedAdjLabel"> Label UI element for LD speed adj. label </param>
        /// <param name="ui_internalRefLabel"> Label UI element for Internal/External label </param>
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
        }

        /// <summary>
        /// Updates all graphic user elements
        /// </summary>
        public void UpdateUiElements() 
        {
            ui_refDoubler.Checked = isDoubled;
            ui_refDiv2.Checked = isDivBy2; 
            ui_refInFreq.Text = refInFreq.ToString("0.000 000");
            ui_refDivider.Value = refDivider;
            ui_pfdFreqShowLabel.Text = pfdFreq.ToString("0.000 000");
            ui_autoLdSpeedAdj.Checked = autoLdSpeedAdj;
            ui_LDSpeedAdj.SelectedIndex = LDSpeedAdjIndex;
            ui_refInFreq.Enabled = intRefState;

            if (intRefState)
                ui_internalRefLabel.Text = "External";
            else
                ui_internalRefLabel.Text = "Internal";
        } 

        #region Setters

        /// <summary>
        /// This function set PLO mode and then recalc PFD frequency
        /// </summary>
        /// <param name="value"> synthesizer mode </param>
        public void SetSynthModeInfoVariable(SynthMode value)
        {
            if (synthMode != value)
            {
                this.synthMode = value;

                if (synthMode == SynthMode.FRACTIONAL)
                    maxPfdFreq = 125;
                else
                    maxPfdFreq = 140;

                RecalcPfdFreq();

                UpdateUiElements();
            }
        }

        /// <summary>
        /// Function set reference frequency from input string.
        /// It remove all spaces and replace dot decimal separator by comma separator.
        /// </summary>
        /// <param name="value"> input reference freq value as string </param>
        /// <returns> model value was changed or was not </returns>
        public bool SetRefFreqValue(string value)
        {
            value = value.Replace(" ", string.Empty);
            value = value.Replace(".", ",");
            return SetRefFreqValue(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Function set reference frequency from decimal value
        /// </summary>
        /// <param name="value"> input decimal value </param>
        /// <returns> model value was changed or was not </returns>
        public bool SetRefFreqValue(decimal value)
        {
            bool changed;
            if (value != refInFreq)
            {
                changed = true;

                // check limits
                if (value < minRefInputFreq || value > maxRefInputFreq)
                {
                    value = this.refInFreq;
                    ConsoleController.Console().Write(badInputRefFreqMsg);
                }
                else
                {
                    this.refInFreq = value;
                }

                RecalcPfdFreq();

                UpdateUiElements();
            }
            else
            {
                changed = false;
            }
            return changed;
        }

        /// <summary>
        /// Set reference frequency doubler state, check limits a then recalc PFD freq.
        /// </summary>
        /// <param name="value">true - doubler active, false - doubler disabled </param>
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

                RecalcPfdFreq();

                UpdateUiElements();
            }
        }

        /// <summary>
        /// Set reference frequency divider by two and recalc PFD frequency
        /// </summary>
        /// <param name="value">true - divider by two enabled, false - disabled </param>
        public void SetRefDivBy2(bool value)
        {
            if (isDivBy2 != value)
            {
                this.isDivBy2 = value;
                
                RecalcPfdFreq();

                UpdateUiElements();
            }
        }

        /// <summary>
        /// Set R-divider value, check limits and recalc PFD frequency
        /// </summary>
        /// <param name="value"> R-divider UInt16 value </param>
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

                RecalcPfdFreq();

                UpdateUiElements();
            }
        }

        /// <summary>
        /// Set Lock-Detect speed adjustment index and check if setting is correct
        /// </summary>
        /// <param name="value"> Lock-Detect speed adjustment (0 - PFD freq > 32, 1 - PFD freq <= 32)</param>
        public void SetLDSpeedAdjIndex(int value)
        {
            if (LDSpeedAdjIndex != value)
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
                LDSpeedAdjIndex = value;

                UpdateUiElements();
            }
        }
        
        /// <summary>
        /// It enable/disable auto calculating correct LD speed adj index.
        /// If it enabled, set correct LD speed and update UI elements.
        /// </summary>
        /// <param name="value"> true - enabled, false - disabled </param>
        public void SetAutoLDSpeedAdj(bool value)
        {
            if (autoLdSpeedAdj != value)
            {
                if (value)
                {
                    if(pfdFreq <= 32)
                        LDSpeedAdjIndex = 0;
                    else
                        LDSpeedAdjIndex = 1;
                    ui_LDSpeedAdjLabel.ForeColor = Color.Black;
                }
                
                autoLdSpeedAdj = value;

                UpdateUiElements();
            }
        }

        /// <summary>
        /// It set whether internal reference is active or is active external
        /// </summary>
        /// <param name="state"> true - internal, false - external </param>
        public void SetIntRefInpEnabled(bool state)
        {
            this.intRefState = state;
            
            UpdateUiElements();
        }

        #endregion

        #region Getters
        
        /// <summary>
        /// Get reference frequency value as string.
        /// </summary>
        /// <returns> string ref. freq. </returns>
        public string string_GetRefFreqValue()
        {
            return this.refInFreq.ToString();
        }

        /// <summary>
        /// Get reference frequency value as decimal number
        /// </summary>
        /// <returns> decimal ref. freq. number </returns>
        public decimal decimal_GetRefFreqValue()
        {
            return this.refInFreq;
        }

        /// <summary>
        /// Get state if reference frequency is doubled or not
        /// </summary>
        /// <returns> true - doubler enabled, false - doubler disabled </returns>
        public bool GetIsDoubled()
        {
            return this.isDoubled;
        }

        /// <summary>
        ///  Get state if reference frequency is divided by two or not
        /// </summary>
        /// <returns> true - divided by two enabled, false - disabled </returns>
        public bool GetIsDividedBy2()
        {
            return this.isDivBy2;
        }
        
        /// <summary>
        /// Get UInt16 R-divider value.
        /// </summary>
        /// <returns> UInt16 R-divider value </returns>
        public UInt16 uint16_GetRefDividerValue()
        {
            return this.refDivider;
        }

        /// <summary>
        /// Get decimal value of PFD frequency
        /// </summary>
        /// <returns> decimal value of PFD frequency </returns>
        public decimal decimal_GetPfdFreq()
        {
            return this.pfdFreq;
        }

        /// <summary>
        /// Get state if auto LD-speed computing is enabled, or disabled
        /// </summary>
        /// <returns> true - compute LD-speed automaticaly, false - user manual mode </returns>
        public bool bool_GetAutoLdSpeedAdj()
        {
            return this.autoLdSpeedAdj;
        }

        #endregion

        #region Calculating function

        /// <summary>
        /// This function is used for recalulate PFD frequency and check if PFD is beyond limints
        /// </summary>
        private void RecalcPfdFreq()
        {
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

        #endregion
    }
}