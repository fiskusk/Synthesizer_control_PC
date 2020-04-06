using System;
using System.Windows.Forms;
using Synthesizer_PC_control.Utilities;
using Synthesizer_PC_control.Controllers;
using System.Linq;

namespace Synthesizer_PC_control.Model
{
    /// <summary>
    /// Class is used for work with synthesizer registers.
    /// </summary>
    class MyRegister : I_UiLinked
    {
        // error messages
        private string badAddressMsg = "Warning: An incorrect address was detected while parsing the specified registry value. Address value changed to the correct.";

        /// <summary>
        /// handle textbox UI element 
        /// </summary>
        private TextBox uiElement;

        /// <summary>
        /// handle string value
        /// </summary>
        private string value;

        /// <summary>
        /// handle if update UI is enabled
        /// </summary>
        private readonly bool updateUI;

        /// <summary>
        /// Constructor for work with registers, which doesn't have UI element
        /// </summary>
        /// <param name="value"> value of this MyRegister</param>
        public MyRegister(string value)
        {
            this.value = value;
            updateUI = false;
        }

        /// <summary>
        /// Constructor for work with sythesizer registers, which have UI element
        /// </summary>
        /// <param name="value"> value of this MyRegister </param>
        /// <param name="uiElement"> Assigned UI element </param>
        public MyRegister(string value, TextBox uiElement)
        {
            this.value = value;
            this.uiElement = uiElement;

            updateUI = true;

            UpdateUiElements();
        }

        /// <summary>
        /// Updates all graphic user elements
        /// </summary>
        public void UpdateUiElements()
        {
            if (!updateUI)
                return;

            uiElement.Text = value;
        }

        #region Getters

        /// <summary>
        ///  Get 32-bit unsigned integer of register.
        /// </summary>
        /// <returns> Uint32 register value </returns>
        public UInt32 uint32_GetValue()
        {
            var ret = UInt32.Parse(value, System.Globalization.NumberStyles.HexNumber);
            return ret;
        }
        
        /// <summary>
        /// Get string representation of register value as hexadecimal number
        /// </summary>
        /// <returns> string hexadecimal register value </returns>
        public string string_GetValue()
        {
            return value;
        }

        #endregion

        #region Setters

        /// <summary>
        /// This function set register value represented as string
        /// </summary>
        /// <param name="value"> value to set represented as string </param>
        public void SetValue(string value)
        {
            // it first detects if the new value differs from the original value, ignoring the case
            if (!string.Equals(this.value, value, StringComparison.CurrentCultureIgnoreCase))
            {
                if (updateUI) // if value has UI element, check that the registry address is set correctly
                {
                    try
                    {
                        // get uiElementName and parse only numbers
                        string sender = string.Join("", uiElement.Name.ToCharArray().Where(Char.IsDigit));
                        // now get first number and store it as register number
                        int regNumber = int.Parse(Convert.ToString(sender[0]));
                        // convert the input string to uint32 number
                        UInt32 uint32_inputValue = UInt32.Parse(value, System.Globalization.NumberStyles.HexNumber);

                        // get current address from input value and parse it as UInt32 number
                        UInt32 correctedAddress = uint32_inputValue;
                        // Now set the correct address from the previously obtained registration number
                        correctedAddress = BitOperations.ChangeNBits(correctedAddress, (UInt32)regNumber, 3, 0);

                        // Now find out if the corrected value differs from the input value and write error message.
                        if ( correctedAddress != uint32_inputValue )
                        {
                            value = Convert.ToString(correctedAddress, 16);
                            ConsoleController.Console().Write(badAddressMsg);
                        }
                    }
                    catch
                    {
                        value = this.value;
                        ConsoleController.Console().Write("bad value");
                    }
                }
                this.value = value;
                UpdateUiElements();
            }
        }

        /// <summary>
        /// This function set register value represented as 32-bit unsigned integer number
        /// </summary>
        /// <param name="value"> value to set represented as 32-bit unsigned integer number </param>
        public void SetValue(UInt32 value)
        {
            SetValue(Convert.ToString(value, 16));
        }
        
        /// <summary>
        /// This function set registers values represented as string hexadecimal number
        /// </summary>
        /// <param name="registers"> array of MyRegister registers </param>
        /// <param name="values"> corresponding values to set </param>
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

        #region Registers Bit Operations functions

        /// <summary>
        /// This function allows you to change N consecutive bits in register with the specified value.
        /// </summary>
        /// <param name="changingValue"> The new value that will be changed in the original registry </param>
        /// <param name="N"> number of bits to be changed </param>
        /// <param name="startingBit"> The bit from which the value will change </param>
        public void ChangeNBits(UInt32 changingValue, int N, int startingBit)
        {
            UInt32 reg = this.uint32_GetValue();    // get original register value as number
            reg =  BitOperations.ChangeNBits(reg, changingValue, N, startingBit);
            this.SetValue(reg); // Set new value into model
        }

        /// <summary>
        /// This function allows you to change a specific bit in register with the specified value.
        /// </summary>
        /// <param name="bit"> number of bit in 32-bit unsigned integer number to change </param>
        /// <param name="bitState"> Bit state to change to. (RESET or SET) </param>
        public void SetResetOneBit(UInt16 bit, BitState bitState)
        {
            UInt32 reg = this.uint32_GetValue();
            reg = BitOperations.SetResetOneBit(reg, bit, bitState);
            this.SetValue(reg);
        }
        
        #endregion
        
    }
}
