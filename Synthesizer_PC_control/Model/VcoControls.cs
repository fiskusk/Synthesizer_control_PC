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
        private decimal delayMsValue;
        private UInt16 manualVCOSelectValue;
        private UInt16 bandSelClockDivValue;
        private UInt16 clockDividerValue;
        private bool autoCdivCalc;
        private UInt16 delayInput;

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
            SetBandSelClockDivValue(bandSelClockDivValue);
        }

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

        public void SetDelayLabel(UInt16 modValue, decimal fPfd)
        {
            this.delayMsValue = clockDividerValue * modValue/(fPfd * 1000);

            UpdateUiElements();
        }

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

        public void SetDelayInputValue(UInt16 value)
        {
            this.delayInput = value;

            UpdateUiElements();
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

        public UInt16 GetClockDividerValue()
        {
            return this.clockDividerValue;
        }

        public UInt16 GetDelayInputValue()
        {
            return this.delayInput;
        }
        #endregion


        public void UpdateUiElements()
        {
            this.ui_AutoVcoSelection.Checked        = autoVcoSelectionState;
            this.ui_VASTempCom.Checked              = VASTempComState;
            this.ui_MuteUntilLockDetect.Checked     = muteUntilLockDetectState;
            this.ui_DelayToPreventFlickering.Checked = delayToPreventFlickeringState;
            this.ui_ManualVCOSelect.Value           = manualVCOSelectValue;
            this.ui_BandSelClockDiv.Value           = bandSelClockDivValue;
            this.ui_ClockDivider.Value              = clockDividerValue;
            this.ui_DelayLabel.Text                 = delayMsValue.ToString("#### ms");
        }
    }
}