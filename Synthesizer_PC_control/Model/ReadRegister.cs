using System.Windows.Forms;

namespace Synthesizer_PC_control.Model
{
    public class ReadRegister
    {
        private string readedCurrentVCO;

        private readonly TextBox ui_ReadedCurrentVCO;
        public ReadRegister(TextBox ui_ReadedCurrentVCO)
        {
            this.ui_ReadedCurrentVCO = ui_ReadedCurrentVCO;
        }

        public void SetReadedCurrentVCO(string value)
        {
            if (value != readedCurrentVCO)
            {
                readedCurrentVCO = value;

                UpdateUiElements();
            }
        }

        public void UpdateUiElements()
        {
            ui_ReadedCurrentVCO.Text = readedCurrentVCO;
        }
    }
}