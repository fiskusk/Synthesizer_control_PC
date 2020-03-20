using System.Windows.Forms;

namespace Synthesizer_PC_control.Model
{
    public class ReadRegister
    {
        public enum AdcMode
        {
            TEMPERATURE,
            TUNE_PIN
        }

        private string readedCurrentVCO;
        private string readedADC;
        private AdcMode adcMode;

        private readonly TextBox ui_ReadedCurrentVCO;
        private readonly TextBox ui_ReadedADC;
        private readonly ComboBox ui_AdcMode;

        public ReadRegister(TextBox ui_ReadedCurrentVCO, TextBox ui_ReadedADC,
                            ComboBox ui_AdcMode)
        {
            this.ui_ReadedCurrentVCO = ui_ReadedCurrentVCO;
            this.ui_ReadedADC = ui_ReadedADC;
            this.ui_AdcMode = ui_AdcMode;
        }

        public void SetReadedCurrentVCO(string value)
        {
            readedCurrentVCO = value;

            UpdateUiElements();
        }

        public void SetReadededADC(string value)
        {
            readedADC = value;

            UpdateUiElements();
        }

        public void SetAdcMode(AdcMode value)
        {
            adcMode = value;

            UpdateUiElements();
        }

        public AdcMode GetAdcMode()
        {
            return adcMode;
        }

        public void UpdateUiElements()
        {
            ui_ReadedCurrentVCO.Text = readedCurrentVCO;
            ui_ReadedADC.Text = readedADC;
            ui_AdcMode.SelectedIndex = (int)adcMode;
        }
    }
}