using System;
using System.Windows.Forms;

namespace Synthesizer_PC_control.Model
{  
    /// <summary>
    /// This class is used to handle the VCO controls. 
    /// (VCO auto selection state, VAS response to temperature drift, 
    /// frequency and enabled state of output 1 and 2, internal or external ref state) 
    /// </summary>
    public class VcoControls : I_UiLinked
    {
        /// <summary>
        /// VCO auto selection state
        /// </summary>
        private bool autoVcoSelectionState;

        /// <summary>
        /// VAS response to temperature drift
        /// </summary>
        private bool VASTempComState;

        /// <summary>
        /// RFOUT Mute until Lock Detect Mode (MTLD)
        /// </summary>
        private bool muteUntilLockDetectMode;

        /// <summary>
        /// Mute Delay (in MTLD)
        /// </summary>
        private bool delayLDtoMTLD;

        /// <summary>
        /// Delay in miliseconds when delayLDtoMTLD = true
        /// </summary>
        private decimal delayMsValue;

        /// <summary>
        /// Manual selection of VCO and VCO sub-band when VAS is disabled
        /// </summary>
        private UInt16 manualVCOSelectValue;

        /// <summary>
        /// Band select clock divider value. 
        /// </summary>
        private UInt16 bandSelClockDivValue;

        /// <summary>
        /// Sets 12-bit clock divider value
        /// </summary>
        private UInt16 clockDividerValue;

        /// <summary>
        /// State for automatic calc CDIV value to apropriate delay from delay input
        /// </summary>
        private bool autoCdivCalc;

        /// <summary>
        /// Mute Delay in miliseconds 
        /// </summary>
        private UInt16 delayInput;

        // hold UI elements for VCO controls group
        private readonly CheckBox ui_AutoVcoSelection;
        private readonly CheckBox ui_VASTempCom;
        private readonly CheckBox ui_MuteUntilLockDetect;
        private readonly CheckBox ui_DelayToPreventFlickering;
        private readonly NumericUpDown ui_ManualVCOSelect;
        private readonly NumericUpDown ui_BandSelClockDiv;
        private readonly NumericUpDown ui_ClockDivider;
        private readonly Label ui_DelayLabel;
        private readonly CheckBox ui_AutoCDIVCalc;
        private readonly NumericUpDown ui_DelayInput;

        /// <summary>
        /// Controller for the VCO controls. 
        /// (VCO auto selection state, VAS response to temperature drift, 
        /// frequency and enabled state of output 1 and 2, internal or external ref state) 
        /// </summary>
        /// <param name="ui_AutoVcoSelection"> CheckBox UI element for VCO auto selection </param>
        /// <param name="ui_VASTempCom"> CheckBox UI element for VAS response to temperature drift </param>
        /// <param name="ui_MuteUntilLockDetect"> CheckBox UI element for RFOUT Mute until Lock Detect Mode (MTLD) </param>
        /// <param name="ui_DelayToPreventFlickering"> CheckBox UI element for delay in miliseconds when delayLDtoMTLD = true </param>
        /// <param name="ui_ManualVCOSelect"> NumericUpDown UI element for manual selection of VCO and VCO sub-band when VAS is disabled </param>
        /// <param name="ui_DelayLabel"> Label UI element for delay label </param>
        /// <param name="ui_BandSelClockDiv"> NumericUpDown UI element for band select clock divider value </param>
        /// <param name="ui_ClockDivider"> NumericUpDown UI element for 12-bit clock divider value </param>
        /// <param name="ui_AutoCDIVCalc"> CheckBox UI element for automatic calc CDIV value to apropriate delay from delay input </param>
        /// <param name="ui_DelayInput"> NumericUpDown UI element for mute Delay in miliseconds </param>
        public VcoControls(CheckBox ui_AutoVcoSelection, CheckBox ui_VASTempCom,
                           CheckBox ui_MuteUntilLockDetect, CheckBox ui_DelayToPreventFlickering, 
                           NumericUpDown ui_ManualVCOSelect, Label ui_DelayLabel,
                           NumericUpDown ui_BandSelClockDiv, NumericUpDown ui_ClockDivider, 
                           CheckBox ui_AutoCDIVCalc, NumericUpDown ui_DelayInput)
        {
            this.ui_AutoVcoSelection    = ui_AutoVcoSelection;
            this.ui_VASTempCom          = ui_VASTempCom;
            this.ui_MuteUntilLockDetect = ui_MuteUntilLockDetect;
            this.ui_DelayToPreventFlickering = ui_DelayToPreventFlickering;
            this.ui_ManualVCOSelect     = ui_ManualVCOSelect;
            this.ui_BandSelClockDiv     = ui_BandSelClockDiv;
            this.ui_ClockDivider        = ui_ClockDivider;
            this.ui_DelayLabel          = ui_DelayLabel;
            this.ui_AutoCDIVCalc        = ui_AutoCDIVCalc;
            this.ui_DelayInput          = ui_DelayInput;

            manualVCOSelectValue = 64;
            bandSelClockDivValue = 64;
            clockDividerValue    = 64;
            delayInput           = 1024;
        }

        /// <summary>
        /// Updates all graphic user elements
        /// </summary>
        public void UpdateUiElements()
        {
            this.ui_AutoVcoSelection.Checked        = autoVcoSelectionState;
            this.ui_VASTempCom.Checked              = VASTempComState;
            this.ui_MuteUntilLockDetect.Checked     = muteUntilLockDetectMode;
            this.ui_DelayToPreventFlickering.Checked = delayLDtoMTLD;
            this.ui_ManualVCOSelect.Value           = manualVCOSelectValue;
            this.ui_BandSelClockDiv.Value           = bandSelClockDivValue;
            this.ui_ClockDivider.Value              = clockDividerValue;
            this.ui_DelayLabel.Text                 = delayMsValue.ToString("#### ms");
            this.ui_AutoCDIVCalc.Checked            = autoCdivCalc;
            this.ui_DelayInput.Value                = delayInput;
            ui_AutoVcoSelection.Invalidate();
            ui_AutoVcoSelection.Update();
            ui_AutoVcoSelection.Refresh();
            Application.DoEvents();
        }

        #region Setters

        /// <summary>
        /// Sets automatic selection VCO
        /// </summary>
        /// <param name="value">
        ///     false = disabled automatic VCO selection,
        ///     true = enabled automatic VCO selection
        /// </param>
        public void SetAutoVcoSelectionState(bool value)
        {
            if (this.autoVcoSelectionState != value)
            {
                this.autoVcoSelectionState = value;

                if (autoVcoSelectionState == true)
                {
                    ui_ManualVCOSelect.Enabled = false;
                    ui_VASTempCom.Enabled = true;
                }
                else
                {
                    ui_ManualVCOSelect.Enabled = true;
                    ui_VASTempCom.Enabled = false;
                }

            }
                UpdateUiElements();
        }

        /// <summary>
        /// Sets VAS response to temperature drift
        /// </summary>
        /// <param name="value">
        ///     false = VAS temperature compensation disabled,
        ///     true =  VAS temperature compensation enabled
        /// </param>
        public void SetVASTempComState(bool value)
        {
            if (this.VASTempComState != value)
            {
                this.VASTempComState = value;

                UpdateUiElements();
            }
        }

        /// <summary>
        /// Sets RFOUT Mute until Lock Detect Mode
        /// </summary>
        /// <param name="value">
        ///     false = Disables RFOUT Mute until Lock Detect Mode,
        ///     true = Enables RFOUT Mute until Lock Detect Mode
        /// </param>
        public void SetMuteUntilLockDetectMode(bool value)
        {
            if (this.muteUntilLockDetectMode != value)
            {
                this.muteUntilLockDetectMode = value;

                UpdateUiElements();
            }
        }

        /// <summary>
        /// Sets mute delay
        /// </summary>
        /// <param name="value">
        ///     false = Do not delay LD to MTLD function to prevent flickering,
        ///     true = Delay LD to MTLD function to prevent flickering
        /// </param>
        public void SetDelayToPreventFlickeringState(bool value)
        {
            if (this.delayLDtoMTLD != value)
            {
                this.delayLDtoMTLD = value;

                UpdateUiElements();
            }
        }

        /// <summary>
        /// Manual selection of VCO and VCO sub-band when VAS is disabled
        /// </summary>
        /// <param name="value"> value 0 - 63 (64 VCos) </param>
        public void SetManualVCOSelectValue(UInt16 value)
        {
            if (this.manualVCOSelectValue != value)
            {
                this.manualVCOSelectValue = value;

                UpdateUiElements();
            }
        }

        /// <summary>
        /// Sets band select clock divider value. If it neccessary fix value.
        /// </summary>
        /// <param name="value"> BS clock divider value (1-1023) </param>
        public void SetBandSelClockDivValue(UInt16 value)
        {
            if (value < 1)
                value = 1;
            else if (value > 1023)
                value = 1023;
            if (this.bandSelClockDivValue != value)
            {
                this.bandSelClockDivValue = value;

                UpdateUiElements();
            }
        }

        /// <summary>
        /// Sets 12-bit clock divider value. If it neccessary fix value.
        /// </summary>
        /// <param name="value"> CDIV value (1 - 4095) </param>
        public void SetClockDividerValue(UInt16 value)
        {
            if (value < 1)
                value = 1;
            else if (value > 4095)
                value = 4095;
            if (this.clockDividerValue != value)
            {
                this.clockDividerValue = value;

                UpdateUiElements();
            }
        }

        /// <summary>
        /// Calculate delay in ms and set it. 
        /// </summary>
        /// <param name="modValue"> modus value </param>
        /// <param name="fPfd"> PFD frequency in MHz</param>
        public void SetDelayLabel(UInt16 modValue, decimal fPfd)
        {
            this.delayMsValue = clockDividerValue * modValue/(fPfd * 1000);

            UpdateUiElements();
        }

        /// <summary>
        /// Sets automatic CDIV calculation state.
        /// </summary>
        /// <param name="value">
        ///     false = automatic CDIV calculation Disabled,
        ///     true = automatic CDIV calculation Enabled
        /// </param>
        public void SetAutoCdivCalc(bool value)
        {
            this.autoCdivCalc = value;

            if (value == true)
            {
                ui_DelayInput.Enabled = true;
                ui_ClockDivider.Enabled = false;
            }
            else
            {
                ui_DelayInput.Enabled = false;
                ui_ClockDivider.Enabled = true;
            }

            UpdateUiElements();
        }

        /// <summary>
        /// Sets delay in ms.
        /// </summary>
        /// <param name="value"> Delay in ms </param>
        public void SetDelayInputValue(UInt16 value)
        {
            this.delayInput = value;

            UpdateUiElements();
        }

        #endregion

        #region Getters

        /// <summary>
        /// Gets automatic selection VCO
        /// </summary>
        /// <returns>
        ///     false = disabled automatic VCO selection,
        ///     true = enabled automatic VCO selection
        /// </returns>
        public bool GetAutoVcoSelectionState()
        {
            return this.autoVcoSelectionState;
        }

        /// <summary>
        /// Gets band select clock divider value.
        /// </summary>
        /// <returns> BS clock divider value (1-1023) </returns>
        public UInt16 GetBandSelClockDivValue()
        {
            return this.bandSelClockDivValue;
        }

        /// <summary>
        /// Gets 12-bit clock divider value.
        /// </summary>
        /// <returns> CDIV value (1 - 4095) </returns>
        public UInt16 GetClockDividerValue()
        {
            return this.clockDividerValue;
        }

        /// <summary>
        /// Gets delay input in miliseconds.
        /// </summary>
        /// <returns> delay input in miliseconds </returns>
        public UInt16 GetDelayInputValue()
        {
            return this.delayInput;
        }

        /// <summary>
        /// Gets if automatic CDIV calculations is enabled.
        /// </summary>
        /// <returns>
        ///     false = automatic CDIV calculation Disabled,
        ///     true = automatic CDIV calculation Enabled
        /// </returns>
        public bool GetAutoCDiv()
        {
            return this.autoCdivCalc;
        }
        #endregion

        #region Other functions

        /// <summary>
        /// This function calculate and set new band select clock divider value
        /// from the input PFD frequency
        /// </summary>
        /// <param name="pfdFreq"> PFD frequency in MHz </param>
        public void CalcBandSelClockDivValue(decimal pfdFreq)
        {
            UInt16 bandSelClockDivValue = (UInt16)(pfdFreq / 0.050M);

            SetBandSelClockDivValue(bandSelClockDivValue);
        }

        /// <summary>
        /// This function calculate and set new clock divider value from input delay
        /// to appropriate PFD frequency a modus. If value overflow, it set maximum 4095.
        /// </summary>
        /// <param name="delay"> delay in ms </param>
        /// <param name="fPfd"> PFD frequency in MHz </param>
        /// <param name="mod"> modulus value </param>
        public void CalcCDIVValue(UInt16 delay, decimal fPfd, UInt16 mod)
        {
            UInt16 clockDividerValue;
            try{
                clockDividerValue = (UInt16)(delay*fPfd*1000/mod);
            }
            catch{
                clockDividerValue = 4095;
            }

            SetClockDividerValue(clockDividerValue);
        }

        #endregion
    }
}