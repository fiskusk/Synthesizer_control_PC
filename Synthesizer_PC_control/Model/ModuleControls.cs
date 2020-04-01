using System;
using System.Windows.Forms;
using Synthesizer_PC_control.Utilities;

namespace Synthesizer_PC_control.Model
{   
    /// <summary>
    /// This class is used to handle the synthesizer module states (outputs, reference signal).
    /// </summary>
    class ModuleControls : I_UiLinked
    {
        /// <summary>
        /// hold value if is active output 1
        /// </summary>
        private bool out1State;

        /// <summary>
        /// hold value if is active output 2
        /// </summary>
        private bool out2State;

        /// <summary>
        /// hold value if is active internal reference or external
        /// </summary>
        private bool intRefState;

        // hold synthesizer module UI elements
        private readonly Button ui_out1OnOff;
        private readonly Button ui_out2OnOff;
        private readonly Button ui_intExtRef;
        
        /// <summary>
        /// Constructor for ModuleControls
        /// </summary>
        /// <param name="ui_out1OnOff"> UI element for module output 1 button </param>
        /// <param name="ui_out2OnOff"> UI element for module output 2 button </param>
        /// <param name="ui_intExtRef"> UI element for module reference button </param>
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

        public void UpdateUiElements() 
        { 
            if(out1State)    // Out 1 is active
                ui_out1OnOff.Text = "Out 1 Off"; 
            else
                ui_out1OnOff.Text = "Out 1 On"; 
            
            if(out2State)    // Out 2 is active
                ui_out2OnOff.Text = "Out 2 Off"; 
            else
                ui_out2OnOff.Text = "Out 2 On"; 

            if(intRefState)    // Internal reference is active
                ui_intExtRef.Text = "Ext Ref"; 
            else
                ui_intExtRef.Text = "Int Ref"; 
        } 

        #region Getters

        /// <summary>
        /// This function using for creating control register value.
        /// From actual module controls states create hexademimal string value
        /// </summary>
        /// <returns> string represents hexedecimal value of control register </returns>
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

        /// <summary>
        /// This function get synthesizer module output 1 state
        /// </summary>
        /// <returns> true - active, false - disabled </returns>
        public bool GetOut1State()
        {
            return out1State;
        }

        /// <summary>
        /// This function get synthesizer module output 2 state
        /// </summary>
        /// <returns> true - active, false - disabled </returns>
        public bool GetOut2State()
        {
            return out2State;
        }

        /// <summary>
        /// This function get synthesizer module internal reference state
        /// </summary>
        /// <returns> true - internal, false - external </returns>
        public bool GetIntRefState()
        {
            return intRefState;
        }

        #endregion

        #region Setters
        
        /// <summary>
        /// Use this function to set synth. output 1
        /// </summary>
        /// <param name="value"> true - enable, false - disable </param>
        public void SetOut1(bool value)
        {
            if (out1State != value)
            {
                out1State = value;

                UpdateUiElements();
            }
        }

        /// <summary>
        /// Use this function to set synth. output 2
        /// </summary>
        /// <param name="value"> true - enable, false - disable </param>
        public void SetOut2(bool value)
        {
            if (out2State != value)
            {
                out2State = value;

                UpdateUiElements();
            }
        }

        /// <summary>
        /// Use this function to set synth. signal reference
        /// </summary>
        /// <param name="value"> true - internal, false - external </param>
        public void SetIntRef(bool value)
        {
            if (intRefState != value)
            {
                intRefState = value;

                UpdateUiElements();
            }
        }

        #endregion
    }
}