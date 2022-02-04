using System.Windows.Forms;
using System;

namespace Synthesizer_PC_control.Model
{
    /// <summary>
    /// This class is used to handle the VCO calibration controls. 
    /// (calibration frequency step, actual calibrating frequency, current VCO)
    /// </summary>
    public class VcoCalibration : I_UiLinked
    {
        /// <summary>
        /// VCO calibration frequency step
        /// </summary>
        private decimal frequencyStep;
        /// <summary>
        /// current frequency
        /// </summary>
        private decimal currentFrequency;
        /// <summary>
        /// Current VCO number
        /// </summary>
        private UInt16 currentVCO;


        // hold UI elements for read register group
        private readonly TextBox ui_FrequencyStep;
        private readonly Label ui_CurrentFrequency;
        private readonly Label ui_ReadedCurrentVCO;
        private readonly TabControl ui_RegistersTabControl;
        private readonly TabPage ui_VcoCalibrationTabPage;
        private readonly Button ui_PerformVcoCalibrationButton;
        private readonly Button ui_AbortCallibrationButton;

        /// <summary>
        /// Contructor for the VCO calibration controls. 
        /// (calibration frequency step, actual calibrating frequency, current VCO)
        /// </summary>
        /// <param name="ui_ReadedCurrentVCO"> TextBox UI element for current VCO number </param>
        /// <param name="ui_ReadedADC"> TextBox UI element for readed ADC value </param>
        /// <param name="ui_AdcMode"> TextBox UI element for ADC mode </param>
        public VcoCalibration(TextBox ui_FrequencyStep, Label ui_ActualFrequency,
                            Label ui_ReadedCurrentVCO, TabControl ui_RegistersTabControl,
                            TabPage ui_VcoCalibrationTabPage, Button ui_PerformVcoCalibrationButton,
                            Button ui_AbortCallibrationButton)
        {
            this.ui_FrequencyStep = ui_FrequencyStep;
            this.ui_CurrentFrequency = ui_ActualFrequency;
            this.ui_ReadedCurrentVCO = ui_ReadedCurrentVCO;
            this.ui_RegistersTabControl = ui_RegistersTabControl;
            this.ui_VcoCalibrationTabPage = ui_VcoCalibrationTabPage;
            this.ui_PerformVcoCalibrationButton = ui_PerformVcoCalibrationButton;
            this.ui_AbortCallibrationButton = ui_AbortCallibrationButton;
        }

        /// <summary>
        /// Updates all graphic user elements
        /// </summary>
        public void UpdateUiElements()
        {
            ui_FrequencyStep.Text = frequencyStep.ToString();
            ui_CurrentFrequency.Text = currentFrequency.ToString();
            ui_ReadedCurrentVCO.Text = currentVCO.ToString();

            ui_ReadedCurrentVCO.Invalidate();
            ui_ReadedCurrentVCO.Update();
            ui_ReadedCurrentVCO.Refresh();
            Application.DoEvents();
        }

        public void EnableAbortVcoCalibrationButton(bool enabled)
        {
            ui_AbortCallibrationButton.Enabled = enabled;
        }

        public void EnablePerformVcoCalibrationButton(bool enabled)
        {
            ui_PerformVcoCalibrationButton.Enabled = enabled;
        }

        public void SetFocusToVcoCalibTab()
        {
            ui_RegistersTabControl.SelectedTab = ui_VcoCalibrationTabPage;
            ui_PerformVcoCalibrationButton.Focus();
        }

        #region Setters

        public void SetFrequencyStep(decimal value)
        {
            frequencyStep = value;

            UpdateUiElements();
        }

        public void SetCurrentFrequency(decimal value)
        {
            currentFrequency = value;

            UpdateUiElements();
        }

        public void SetReadedCurrentVCO(UInt16 value)
        {
            currentVCO = value;

            UpdateUiElements();
        }

        #endregion

        #region Getters

        public decimal GetFrequencyStep()
        {
            return frequencyStep;
        }

        public decimal GetCurrentFrequency()
        {
            return currentFrequency;
        }

        public UInt16 GetReadedCurrentVCO()
        {
            return currentVCO;
        }

        #endregion

    }
}