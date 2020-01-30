using System;
using System.Windows.Forms;
using Synthesizer_PC_control.Utilities;

namespace Synthesizer_PC_control.Model
{
    class ModuleControls : I_UiLinked
    {
        private readonly Button ui_out1OnOff;
        private bool isOut1On;
        private readonly Button ui_out2OnOff;
        private bool isOut2On;
        private readonly Button ui_intExtRef;
        private bool isIntRef;
        
        public ModuleControls(Button ui_out1OnOff, Button ui_out2OnOff, Button ui_intExtRef)
        {
            this.ui_out1OnOff = ui_out1OnOff;
            this.ui_out2OnOff = ui_out2OnOff;
            this.ui_intExtRef = ui_intExtRef;

            UpdateUiElements();
        }

        public string GetControlRegister()
        {
            UInt32 control_register = 0;

            if (isOut1On)
                control_register = BitOperations.SetResetOneBit(control_register, 0, BitState.SET);
            else
                control_register = BitOperations.SetResetOneBit(control_register, 0, BitState.RESET);

            if (isOut2On)
                control_register = BitOperations.SetResetOneBit(control_register, 1, BitState.SET);
            else
                control_register = BitOperations.SetResetOneBit(control_register, 1, BitState.RESET);

            if (isIntRef)
                control_register = BitOperations.SetResetOneBit(control_register, 2, BitState.RESET);
            else
                control_register = BitOperations.SetResetOneBit(control_register, 2, BitState.SET);

            return Convert.ToString(control_register, 16);
        }

        public void SetOut1(bool setReset)
        {
            if (setReset)
                isOut1On = true;
            else
                isOut1On = false;

            UpdateUiElements();
        }

        public void SetOut2(bool setReset)
        {
            if (setReset)
                isOut2On = true;
            else
                isOut2On = false;

            UpdateUiElements();
        }

        public void SetIntRef(bool setReset)
        {
            if (setReset)
                isIntRef = true;
            else
                isIntRef = false;

            UpdateUiElements();
        }

        public bool GetOut1State()
        {
            if (isOut1On)
                return true;
            else
                return false;
        }

        public bool GetOut2State()
        {
            if (isOut2On)
                return true;
            else
                return false;
        }

        public bool GetRefState()
        {
            if (isIntRef)
                return true;
            else
                return false;
        }

        public void UpdateUiElements() 
        { 
            if(isOut1On)    // Out 1 je aktivni
            { 
                ui_out1OnOff.Text = "Out 1 Off"; 
            }
            else
            {
                ui_out1OnOff.Text = "Out 1 On"; 
            }
            
            if(isOut2On)    // Out 2 je aktivni
            { 
                ui_out2OnOff.Text = "Out 2 Off"; 
            }
            else
            {
                ui_out2OnOff.Text = "Out 2 On"; 
            }

            if(isIntRef)    // Interní reference je aktivni
            { 
                ui_intExtRef.Text = "Ext Ref"; 
            }
            else
            {
                ui_intExtRef.Text = "Int Ref"; 
            }
        } 
    }
}