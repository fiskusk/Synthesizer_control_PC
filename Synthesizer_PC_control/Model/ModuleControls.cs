using System;
using System.Windows.Forms;
using Synthesizer_PC_control.Utilities;

namespace Synthesizer_PC_control.Model
{
    class ModuleControls : I_UiLinked
    {
        private bool out1State;
        private bool out2State;
        private bool intRefState;
        private readonly Button ui_out1OnOff;
        private readonly Button ui_out2OnOff;
        private readonly Button ui_intExtRef;
        
        public ModuleControls(Button ui_out1OnOff, Button ui_out2OnOff, Button ui_intExtRef)
        {
            this.ui_out1OnOff = ui_out1OnOff;
            this.ui_out2OnOff = ui_out2OnOff;
            this.ui_intExtRef = ui_intExtRef;

            out1State = false;
            out2State = false;
            intRefState = false;

            UpdateUiElements();
        }

        public string GetControlRegister()
        {
            UInt32 control_register = 0;

            if (out1State)
                control_register = BitOperations.SetResetOneBit(control_register, 0, BitState.SET);
            else
                control_register = BitOperations.SetResetOneBit(control_register, 0, BitState.RESET);

            if (out2State)
                control_register = BitOperations.SetResetOneBit(control_register, 1, BitState.SET);
            else
                control_register = BitOperations.SetResetOneBit(control_register, 1, BitState.RESET);

            if (intRefState)
                control_register = BitOperations.SetResetOneBit(control_register, 2, BitState.RESET);
            else
                control_register = BitOperations.SetResetOneBit(control_register, 2, BitState.SET);

            return Convert.ToString(control_register, 16);
        }

        public void SetOut1(bool value)
        {
            if (out1State != value)
            {
                out1State = value;

                UpdateUiElements();
            }
        }

        public void SetOut2(bool value)
        {
            if (out2State != value)
            {
                out2State = value;

                UpdateUiElements();
            }
        }

        public void SetIntRef(bool value)
        {
            if (intRefState != value)
            {
                intRefState = value;

                UpdateUiElements();
            }
        }

        public bool GetOut1State()
        {
            return out1State;
        }

        public bool GetOut2State()
        {
            return out2State;
        }

        public bool GetIntRefState()
        {
            return intRefState;
        }

        public void UpdateUiElements() 
        { 
            if(out1State)    // Out 1 je aktivni
                ui_out1OnOff.Text = "Out 1 Off"; 
            else
                ui_out1OnOff.Text = "Out 1 On"; 
            
            if(out2State)    // Out 2 je aktivni
                ui_out2OnOff.Text = "Out 2 Off"; 
            else
                ui_out2OnOff.Text = "Out 2 On"; 

            if(intRefState)    // Interní reference je aktivni
                ui_intExtRef.Text = "Ext Ref"; 
            else
                ui_intExtRef.Text = "Int Ref"; 
        } 
    }
}