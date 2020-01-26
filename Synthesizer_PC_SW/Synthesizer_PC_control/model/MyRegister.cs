using System;
using System.Windows.Forms;
using Synthesizer_PC_control.Utilities;

namespace Synthesizer_PC_control.Model
{
    class MyRegister : I_UiLinked
    {
        private TextBox uiElement;

        private string value;
        private readonly bool updateUI;

        public MyRegister(string value)
        {
            this.value = value;
            updateUI = false;
        }
        public MyRegister(string value, TextBox uiElement)
        {
            this.value = value;
            this.uiElement = uiElement;

            updateUI = true;

            UpdateUiElements();
        }

        public void UpdateUiElements()
        {
            if (!updateUI)
                return;

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

        public static void SetValues(MyRegister[] registers, string[] values)
        {
            if (registers.Length != values.Length)
                return;

            for (int i = 0; i < registers.Length; i++)
            {
                registers[i].SetValue(values[i]);
            }
        }

        #endregion

        #region Bit Operations functions

        public void ChangeNBits(UInt32 changingValue, int N, int startingBit)
        {
            UInt32 reg = this.uint32_GetValue();
            reg =  BitOperations.ChangeNBits(reg, changingValue, N, startingBit);
            this.SetValue(reg);
        }

        public void SetResetOneBit(UInt16 bit, BitState bitState)
        {
            UInt32 reg = this.uint32_GetValue();
            reg = BitOperations.SetResetOneBit(reg, bit, bitState);
            this.SetValue(reg);
        }
        
        #endregion
        
    }
}
