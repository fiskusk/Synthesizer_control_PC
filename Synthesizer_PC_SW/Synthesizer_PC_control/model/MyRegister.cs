using System;
using System.Windows.Forms;

namespace Synthesizer_PC_control.Model
{
    class MyRegister : I_UiLinked
    {
        private TextBox uiElement;

        private string value; // FIXME private

        public MyRegister(string value, TextBox uiElement)
        {
            this.value = value;
            this.uiElement = uiElement;

            UpdateUiElements();
        }

        public void UpdateUiElements()
        {
            uiElement.Text = value;
        }

        #region Getters
        //UInt32 reg0 = UInt32.Parse(Reg0TextBox.Text, System.Globalization.NumberStyles.HexNumber);
        public UInt32 uint32_GetValue()
        {
            var ret = UInt32.Parse(value, System.Globalization.NumberStyles.HexNumber);
            return ret;
        }

        public string string_GetValue()
        {
            return value;
        }
        #endregion

        #region Setters

        public void SetValue(string value)
        {
            this.value = value;
            UpdateUiElements();
        }

        public void SetValue(UInt32 value)
        {
            this.value = Convert.ToString(value, 16);
            UpdateUiElements();
        }
        #endregion
    }
}
