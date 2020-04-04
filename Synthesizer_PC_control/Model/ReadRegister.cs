using System.Windows.Forms;

namespace Synthesizer_PC_control.Model
{
    /// <summary>
    /// This class is used to handle the read register. 
    /// (readed current VCO, readed ADC, adc mode)
    /// </summary>
    public class ReadRegister
    {
        /// <summary>
        /// Enumerable for ADC mode (TEMPERATURE, TUNE_PIN)
        /// </summary>
        public enum AdcMode
        {
            TEMPERATURE,
            TUNE_PIN
        }

        /// <summary>
        /// Current VCO number
        /// </summary>
        private string readedCurrentVCO;

        /// <summary>
        /// readed ADC value
        /// </summary>
        private string readedADC;

        /// <summary>
        /// ADC mode
        /// </summary>
        private AdcMode adcMode;

        // hold UI elements for read register group
        private readonly TextBox ui_ReadedCurrentVCO;
        private readonly TextBox ui_ReadedADC;
        private readonly ComboBox ui_AdcMode;

        /// <summary>
        /// Contructor for the read register. 
        /// (readed current VCO, readed ADC, adc mode)
        /// </summary>
        /// <param name="ui_ReadedCurrentVCO"> TextBox UI element for current VCO number </param>
        /// <param name="ui_ReadedADC"> TextBox UI element for readed ADC value </param>
        /// <param name="ui_AdcMode"> TextBox UI element for ADC mode </param>
        public ReadRegister(TextBox ui_ReadedCurrentVCO, TextBox ui_ReadedADC,
                            ComboBox ui_AdcMode)
        {
            this.ui_ReadedCurrentVCO = ui_ReadedCurrentVCO;
            this.ui_ReadedADC = ui_ReadedADC;
            this.ui_AdcMode = ui_AdcMode;
        }

        /// <summary>
        /// Updates all graphic user elements
        /// </summary>
        public void UpdateUiElements()
        {
            ui_ReadedCurrentVCO.Text = readedCurrentVCO;
            ui_ReadedADC.Text = readedADC;
            ui_AdcMode.SelectedIndex = (int)adcMode;
        }

        #region Setters

        /// <summary>
        /// Sets current VCO number
        /// </summary>
        /// <param name="value"> VCO number as string </param>
        public void SetReadedCurrentVCO(string value)
        {
            readedCurrentVCO = value;

            UpdateUiElements();
        }

        /// <summary>
        /// Sets readed ADC value
        /// </summary>
        /// <param name="value"> adc value as string </param>
        public void SetReadededADC(string value)
        {
            readedADC = value;

            UpdateUiElements();
        }

        /// <summary>
        /// Sets ADC mode
        /// </summary>
        /// <param name="value"> adc mode </param>
        public void SetAdcMode(AdcMode value)
        {
            adcMode = value;

            UpdateUiElements();
        }

        #endregion

        #region Getters

        /// <summary>
        /// This funtion gets ADC mode
        /// </summary>
        /// <returns> adc mode </returns>
        public AdcMode GetAdcMode()
        {
            return adcMode;
        }

        #endregion

    }
}