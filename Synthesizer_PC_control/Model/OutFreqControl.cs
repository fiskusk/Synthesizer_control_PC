using System;
using System.Windows.Forms;
using System.Drawing;
using Synthesizer_PC_control.Controllers;

namespace Synthesizer_PC_control.Model
{   
    /// <summary>
    /// Enumerable for synthesizer mode. It can be FRACTIONAL mode or INTEGER mode.
    /// </summary>
    public enum SynthMode
    {
        FRACTIONAL,
        INTEGER
    }

    /// <summary>
    /// This class is used to handle output frequency controls of the PLO.
    /// (Int-N, Frac-N, modus, mode, A-divider, Phase setting, Lock-Detect function, 
    /// automatic computing LD-Function, PLO output B signal path, 
    /// VCO to Int counter feedback path)
    /// </summary>
    public class OutFreqControl : I_UiLinked
    {
        // error messages
        private string wrongLDFncMsg = "Warning: The 'Lock-Detect function' is set to the wrong lock type due to the synthesizer mode set.";

        /// <summary>
        /// Integer-N value
        /// </summary>
        private UInt16 intN;

        /// <summary>
        /// Fractional-N value
        /// </summary>
        private UInt16 fracN;

        /// <summary>
        /// modulus value
        /// </summary>
        private UInt16 mod;

        /// <summary>
        /// synthesizer mode
        /// </summary>
        private SynthMode mode;

        /// <summary>
        /// VCO output to out A-divider value
        /// </summary>
        private UInt16 aDiv;

        /// <summary>
        /// phase correction value
        /// </summary>
        private UInt16 phaseP;

        /// <summary>
        /// Lock-Detect function
        /// </summary>
        private int LDFunctionIndex;

        /// <summary>
        /// auto-computinf LD-function value
        /// </summary>
        private bool autoLDFunction;

        /// <summary>
        /// OutB internal path
        /// </summary>
        private int outBPath;

        /// <summary>
        /// VCO to N counter internal path
        /// </summary>
        private int FBPath;

        // hold UI elements for PLO output frequency controls group
        private readonly NumericUpDown ui_intN;
        private readonly NumericUpDown ui_fracN;
        private readonly NumericUpDown ui_mod;
        private readonly ComboBox ui_mode;
        private readonly ComboBox ui_aDiv;
        private readonly NumericUpDown ui_phaseP;
        private readonly ComboBox ui_LDFunction;
        private readonly Label ui_LDFunctionLabel;
        private readonly CheckBox ui_autoLDFunction;
        private readonly ComboBox ui_outBPath;
        private readonly ComboBox ui_FBPath;

        /// <summary>
        /// Constructor for operations with output frequency controls of the PLO.
        /// (Int-N, Frac-N, modus, mode, A-divider, Phase setting, Lock-Detect function, 
        /// automatic computing LD-Function, PLO output B signal path, 
        /// VCO to Int counter feedback path)
        /// </summary>
        /// <param name="ui_intN"> NumericUpDown UI element for Int-N value </param>
        /// <param name="ui_fracN"> NumericUpDown UI element for Frac-N value </param>
        /// <param name="ui_mod"> NumericUpDown UI element for modulus value </param>
        /// <param name="ui_mode"> ComboBox UI element for synthesizer mode </param>
        /// <param name="ui_aDiv"> ComboBox UI element for A-divider</param>
        /// <param name="ui_phaseP"> NumericUpDown UI element for phase correction </param>
        /// <param name="ui_LDFunction"> ComboBox UI element for Lock-Detect function </param>
        /// <param name="ui_autoLDFunction"> CheckBox UI element for auto computing LD-function </param>
        /// <param name="ui_outBPath"> ComboBox UI element for outBpath select </param>
        /// <param name="ui_LDFunctionLabel"> Label UI element for LD function label</param>
        /// <param name="ui_FBPath"> ComboBox UI element for VCO to N-counter feedback path </param>
        public OutFreqControl(NumericUpDown ui_intN, NumericUpDown ui_fracN, 
                              NumericUpDown ui_mod, ComboBox ui_mode, 
                              ComboBox ui_aDiv, NumericUpDown ui_phaseP,
                              ComboBox ui_LDFunction, CheckBox ui_autoLDFunction,
                              ComboBox ui_outBPath, Label ui_LDFunctionLabel,
                              ComboBox ui_FBPath)
        {
            this.ui_intN    = ui_intN;
            this.ui_fracN   = ui_fracN;
            this.ui_mod     = ui_mod;
            this.ui_mode    = ui_mode;
            this.ui_aDiv    = ui_aDiv;
            this.ui_phaseP  = ui_phaseP;
            this.ui_LDFunction      = ui_LDFunction;
            this.ui_autoLDFunction  = ui_autoLDFunction;
            this.ui_outBPath        = ui_outBPath;
            this.ui_LDFunctionLabel = ui_LDFunctionLabel;
            this.ui_FBPath          = ui_FBPath;

            intN    = 400;
            fracN   = 0;
            mod     = 125;
        }

        /// <summary>
        /// Updates all graphic user elements
        /// </summary>
        public void UpdateUiElements()
        {
            this.ui_intN.Value  = intN;
            this.ui_fracN.Value = fracN;
            this.ui_mod.Value   = mod;
            this.ui_mode.SelectedIndex = (int)mode;
            this.ui_aDiv.SelectedIndex = aDiv;
            this.ui_phaseP.Value = phaseP;
            this.ui_LDFunction.SelectedIndex = LDFunctionIndex;
            this.ui_autoLDFunction.Checked = autoLDFunction;
            this.ui_outBPath.SelectedIndex = outBPath;
            this.ui_FBPath.SelectedIndex = FBPath;
        }

        #region Setters

        /// <summary>
        /// Function first check if new value is beyond limits. 
        /// If yes, change it to minimum or maximum. Then set new value
        /// update UI elements.
        /// </summary>
        /// <param name="value"> new UInt16 Int-N value </param>
        public void SetIntNVal(UInt16 value)
        {
            if (intN != value)
            {
                if (value < ui_intN.Minimum)
                    value = (UInt16)ui_intN.Minimum;
                else if (value > ui_intN.Maximum)
                    value = (UInt16)ui_intN.Maximum;

                this.intN = value;

                UpdateUiElements();
            }
        }

        /// <summary>
        /// Function first check if new value is beyond limits. 
        /// If yes, change it to minimum or maximum. Then set new value
        /// update UI elements.
        /// </summary>
        /// <param name="value"> new UInt16 Frac-N value </param>
        public void SetFracNVal(UInt16 value)
        {
            if (fracN != value)
            {
                if (value < ui_fracN.Minimum)
                    value = (UInt16)ui_fracN.Minimum;
                else if (value > ui_fracN.Maximum)
                    value = (UInt16)ui_fracN.Maximum;

                this.fracN = value;

                UpdateUiElements();
            }
        }
        
        /// <summary>
        /// Function first check if new value is beyond limits. 
        /// If yes, change it to minimum or maximum. Then set new value, 
        /// update maximum for Frac-N and update UI elements.
        /// </summary>
        /// <param name="value"> new UInt16 Mod value </param>
        public void SetModVal(UInt16 value)
        {
            if (mod != value)
            {
                if (value < ui_mod.Minimum)
                    value = (UInt16)ui_mod.Minimum;
                else if (value > ui_mod.Maximum)
                    value = (UInt16)ui_mod.Maximum;

                this.mod = value;

                ui_fracN.Maximum = value - 1;

                UpdateUiElements();
            }
        }
        
        /// <summary>
        /// Function first set new Int-N minimum and maximum limits according to
        /// PLO mode and if is enabled auto-LD-Function set appropriate value.
        /// Then set new PLO mode value and update UI elements.
        /// </summary>
        /// <param name="value"> new mode (FRACTIONAL/ INTEGER) </param>
        public void SetSynthMode(SynthMode value)
        {
            if (mode != value)
            {
                if (value == SynthMode.FRACTIONAL)
                {
                    ui_intN.Minimum = 19;
                    ui_intN.Maximum = 4091;
                    if (autoLDFunction)
                        LDFunctionIndex = 0;
                }
                else
                {
                    ui_intN.Minimum = 16;
                    ui_intN.Maximum = 65535;
                    if (autoLDFunction)
                        LDFunctionIndex = 1;
                }

                this.mode = value;

                UpdateUiElements();
            }
        }

        /// <summary>
        /// Sets new A-divider value
        /// </summary>
        /// <param name="value"> UInt16 A-divider value </param>
        public void SetADivVal(UInt16 value)
        {
            if (aDiv != value)
            {
                this.aDiv = value;

                UpdateUiElements();
            }
        }

        /// <summary>
        /// First check if new value is beyond limit, adjust it if neccessary
        /// and then set new phase value
        /// </summary>
        /// <param name="value"> new UInt16 Phase-P value </param>
        public void SetPPhaseVal(UInt16 value)
        {
            if (phaseP != value)
            {
                if (value < ui_phaseP.Minimum)
                    value = (UInt16)ui_phaseP.Minimum;
                else if (value > ui_phaseP.Maximum)
                    value = (UInt16)ui_phaseP.Maximum;

                this.phaseP = value;

                UpdateUiElements();
            }
        }

        /// <summary>
        /// Sets new Lock-Detect function index
        /// </summary>
        /// <param name="value"> 
        ///     0 - Frac-N lock detect, 
        ///     1 - Int-N lock detect 
        /// </param>
        public void SetLDFunctionIndex(int value)
        {
            if (LDFunctionIndex != value)
            {
                this.LDFunctionIndex = value;

                UpdateUiElements();
            }
        }

        /// <summary>
        /// Enable/Disable auto computing LD-function. If enabled set 
        /// appropriate LD-function index value.
        /// </summary>
        /// <param name="value"> 
        ///     true - enabled, 
        ///     false - disabled 
        /// </param>
        public void SetAutoLDFunction(bool value)
        {
            if (autoLDFunction != value)
            {
                this.autoLDFunction = value;

                if (value)
                {
                    if (mode == SynthMode.FRACTIONAL)
                        LDFunctionIndex = 0;
                    else
                        LDFunctionIndex = 1;
                }

                UpdateUiElements();
            }
        }

        /// <summary>
        /// Sets new output B internal path value
        /// </summary>
        /// <param name="value"> 
        ///     0 - Out B from divided VCO output, 
        ///     1 - Out B from fundamental frequency 
        /// </param>
        public void SetOutBPath(int value)
        {
            if (outBPath != value)
            {
                this.outBPath = value;

                UpdateUiElements();
            }
        }

        /// <summary>
        /// Sets new VCO to N-counter feedback path
        /// </summary>
        /// <param name="value"> 
        ///     0 - Divided, 
        ///     1 - Fundamental 
        /// </param>
        public void SetFBPath(int value)
        {
            if (FBPath != value)
            {
                this.FBPath = value;

                UpdateUiElements();
            }
        }

        #endregion

        #region Getters
        /// <summary>
        /// Function for get Int-N value
        /// </summary>
        /// <returns> UInt16 Int-N value </returns>
        public UInt16 uint16_GetIntNVal()
        {
            return intN;
        }

        /// <summary>
        /// Function for get Frac-N value
        /// </summary>
        /// <returns> UInt16 Frac-N value </returns>
        public UInt16 uint16_GetFracNVal()
        {
            return fracN;
        }

        /// <summary>
        /// Function for get modus value
        /// </summary>
        /// <returns> UInt16 modus value </returns>
        public UInt16 uint16_GetModVal()
        {
            return mod;
        }

        /// <summary>
        /// Function for get PLO mode value
        /// </summary>
        /// <returns> PLO mode </returns>
        public SynthMode GetSynthMode()
        {
            return mode;
        }

        /// <summary>
        /// Function for get A-divider value
        /// </summary>
        /// <returns> UInt16 A-Divider value </returns>
        public UInt16 uint16_GetADivVal()
        {
            return (UInt16)(1 << aDiv);
        }

        /// <summary>
        /// Function for get A-divider index
        /// </summary>
        /// <returns> A-divider index </returns>
        public UInt16 SelectedIndex_GetADivVal()
        {
            return aDiv;
        }

        /// <summary>
        /// Function for get Phase-P value
        /// </summary>
        /// <returns> Phase-P value </returns>
        public UInt16 uint16_GetPhasePVal()
        {
            return phaseP;
        }

        /// <summary>
        /// Function for get Lock-Detect function index
        /// </summary>
        /// <returns> 
        ///     LD-function index 
        ///     0 - Frac-N lock detect, 
        ///     1 - Int-N lock detect
        /// </returns>
        public int GetLDFunctionIndex()
        {
            return LDFunctionIndex;
        }

        /// <summary>
        /// gets status auto LD-function computing
        /// </summary>
        /// <returns> 
        ///     true - LD-func auto set, 
        ///     false - disabled auto set LD-func 
        /// </returns>
        public bool GetAutoLDFunctionIsChecked()
        {
            return autoLDFunction;
        }

        /// <summary>
        /// gets output B internal path
        /// </summary>
        /// <returns> 
        ///     0 - Out B from divided VCO output, 
        ///     1 - Out B from fundamental frequency 
        /// </returns>
        public int GetOutBPathIndex()
        {
            return outBPath;
        }

        /// <summary>
        /// gets VCO to N-counter feedback path
        /// </summary>
        /// <returns> 
        ///     0 - Divided, 
        ///     1 - Fundamental 
        /// </returns>
        public int GetFBPathIndex()
        {
            return FBPath;
        }

        #endregion

        #region Other output frequency control functions

        /// <summary>
        /// Function recalc new Int-N and modus values 
        /// for reference frequency doubled/divided-by-two. This allows 
        /// As a result, the output frequency does not change.
        /// </summary>
        /// <param name="value"> 
        ///     true - calcs for reference doubler, 
        ///     false - calcs for reference div-by-2 
        /// </param>
        public void RecalcRegsForNewPfdFreq(bool value)
        {
            if (value == true)
            {
                SetIntNVal((UInt16)(intN/2));
                SetModVal((UInt16)(mod*2));
            }
            else
            {
                SetIntNVal((UInt16)(intN*2));
                SetModVal((UInt16)(mod/2));
            }
        }

        /// <summary>
        /// This function used for check if appropriate mode 
        /// due to LD-function is selected. If not, print into console error 
        /// message end set ForeColor to Red.
        /// </summary>
        /// <param name="forceApply"> Forced to check settings </param>
        public void CheckIfLDfuncToAppropriateModeIsSellected(bool forceApply)
        {
            if (autoLDFunction == false || forceApply ==  true)
            {
                if (LDFunctionIndex == 0)
                {
                    if (mode == SynthMode.FRACTIONAL)
                        ui_LDFunctionLabel.ForeColor = Color.Black;
                    else if (ui_LDFunctionLabel.ForeColor != Color.Red)
                    {
                        ui_LDFunctionLabel.ForeColor = Color.Red;
                        ConsoleController.Console().Write(wrongLDFncMsg);
                    }
                }
                else
                {
                    if (mode == SynthMode.INTEGER)
                        ui_LDFunctionLabel.ForeColor = Color.Black;
                    else if (ui_LDFunctionLabel.ForeColor != Color.Red)
                    {
                        ui_LDFunctionLabel.ForeColor = Color.Red;
                        ConsoleController.Console().Write(wrongLDFncMsg);
                    }
                }
            }
        }

        #endregion
    }
}