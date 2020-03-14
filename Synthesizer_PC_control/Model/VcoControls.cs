using System;
using System.Windows.Forms;

namespace Synthesizer_PC_control.Model
{
    public class VcoControls : I_UiLinked
    {
        private bool autoVcoSelectionState;
        private bool VASTempComState;
        private bool muteUntilLockDetectState;
        private bool delayToPreventFlickeringState;
        private bool muteUntilLockDelayState;
        private UInt16 manualVCOSelectValue;
        private UInt16 bandSelClockDivValue;
        private UInt16 clockDividerValue;

        private readonly CheckBox ui_AutoVcoSelection;
        private readonly CheckBox ui_VASTempCom;
        private readonly CheckBox ui_MuteUntilLockDetect;
        private readonly CheckBox ui_DelayToPreventFlickering;
        private readonly CheckBox ui_MuteUntilLockDelay;
        private readonly NumericUpDown ui_ManualVCOSelect;
        private readonly NumericUpDown ui_BandSelClockDiv;
        private readonly NumericUpDown ui_ClockDivider;

        public VcoControls(CheckBox ui_AutoVcoSelection, CheckBox ui_VASTempCom,
                           CheckBox ui_MuteUntilLockDetect, CheckBox ui_DelayToPreventFlickering, 
                           CheckBox ui_MuteUntilLockDelay, NumericUpDown ui_ManualVCOSelect,
                           NumericUpDown ui_BandSelClockDiv, NumericUpDown ui_ClockDivider)
        {
            this.ui_AutoVcoSelection    = ui_AutoVcoSelection;
            this.ui_VASTempCom          = ui_VASTempCom;
            this.ui_MuteUntilLockDetect = ui_MuteUntilLockDetect;
            this.ui_DelayToPreventFlickering = ui_DelayToPreventFlickering;
            this.ui_MuteUntilLockDelay  = ui_MuteUntilLockDelay;
            this.ui_ManualVCOSelect     = ui_ManualVCOSelect;
            this.ui_BandSelClockDiv     = ui_BandSelClockDiv;
            this.ui_ClockDivider        = ui_ClockDivider;

            manualVCOSelectValue = 64;
            bandSelClockDivValue = 64;
            clockDividerValue    = 64;
        }

        #region Setters
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

                UpdateUiElements();
            }
        }

        public void SetVASTempComState(bool value)
        {
            if (this.VASTempComState != value)
            {
                this.VASTempComState = value;

                UpdateUiElements();
            }
        }

        public void SetMuteUntilLockDetectState(bool value)
        {
            if (this.muteUntilLockDetectState != value)
            {
                this.muteUntilLockDetectState = value;

                UpdateUiElements();
            }
        }

        public void SetDelayToPreventFlickeringState(bool value)
        {
            if (this.delayToPreventFlickeringState != value)
            {
                this.delayToPreventFlickeringState = value;

                UpdateUiElements();
            }
        }

        public void SetMuteUntilLockDelayState(bool value)
        {
            if (this.muteUntilLockDelayState != value)
            {
                this.muteUntilLockDelayState = value;

                UpdateUiElements();
            }
        }

        public void SetManualVCOSelectValue(UInt16 value)
        {
            if (this.manualVCOSelectValue != value)
            {
                this.manualVCOSelectValue = value;

                UpdateUiElements();
            }
        }

        public void CalcBandSelClockDivValue(decimal pfdFreq)
        {
            UInt16 bandSelClockDivValue = (UInt16)(pfdFreq / 0.050M);
            if (bandSelClockDivValue < 1)
                bandSelClockDivValue = 1;
            else if (bandSelClockDivValue > 1023)
                bandSelClockDivValue = 1023;
            SetBandSelClockDivValue(bandSelClockDivValue);
        }

        public void SetBandSelClockDivValue(UInt16 value)
        {
            if (this.bandSelClockDivValue != value)
            {
                this.bandSelClockDivValue = value;

                UpdateUiElements();
            }
        }

        public void SetClockDividerValue(UInt16 value)
        {
            if (this.clockDividerValue != value)
            {
                this.clockDividerValue = value;

                UpdateUiElements();
            }
        }

        #endregion

        #region Getters
        public bool GetAutoVcoSelectionState()
        {
            return this.autoVcoSelectionState;
        }

        public UInt16 GetBandSelClockDivValue()
        {
            return this.bandSelClockDivValue;
        }
        #endregion


        public void UpdateUiElements()
        {
            this.ui_AutoVcoSelection.Checked        = autoVcoSelectionState;
            this.ui_VASTempCom.Checked              = VASTempComState;
            this.ui_MuteUntilLockDetect.Checked     = muteUntilLockDetectState;
            this.ui_DelayToPreventFlickering.Checked = delayToPreventFlickeringState;
            this.ui_MuteUntilLockDelay.Checked      = muteUntilLockDelayState;
            this.ui_ManualVCOSelect.Value           = manualVCOSelectValue;
            this.ui_BandSelClockDiv.Value           = bandSelClockDivValue;
            this.ui_ClockDivider.Value              = clockDividerValue;
        }
    }
}