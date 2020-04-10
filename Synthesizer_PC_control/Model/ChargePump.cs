using System;
using System.Windows.Forms;
using System.Collections.Generic;

using Synthesizer_PC_control.Controllers;

namespace Synthesizer_PC_control.Model
{   
    /// <summary>
    /// Enumerable for clock divider mode (Mute Until Lock Delay, Fast-lock enabled, Phase Adjustment mode)
    /// </summary>
    public enum ClockDividerMode
    {
        MuteUntilLockDelay,
        FastLockEnable,
        PhaseAdjustment
    }

    /// <summary>
    /// This class is used to handle the charge pump control. 
    /// (set resistor, currently set index of current, linearity, test mode, 
    /// state of fast lock, phase adjustment mode, CP output tri-state mode, 
    /// cycle slip reduction mode) 
    /// </summary>
    public class ChargePump : I_UiLinked
    {
        // error message
        private string badCurrentMsg = "Warning: In 'Cycle Slip Reduction' or 'Fast-Lock' mode, the current value must be set to its minimum value.";

        /// <summary>
        /// Resistor value that set current of charge pump (CP)
        /// </summary>
        private UInt16 rSet;

        /// <summary>
        /// Index of currently set current of CP
        /// </summary>
        private int currentIndex;

        /// <summary>
        /// Index of CP linearity
        /// </summary>
        private int linearityIndex;

        /// <summary>
        /// Index of charge-pump test modes
        /// </summary>
        private int testModeIndex;

        /// <summary>
        /// State of fast-lock mode
        /// </summary>
        private bool fastLockEnabled;

        /// <summary>
        /// State of phase adjustment mode
        /// </summary>
        private bool phaseAdjustmentEnabled;

        /// <summary>
        /// State of tri-state CP output mode
        /// </summary>
        private bool triStateEnabled;

        /// <summary>
        /// State of cycle slip reduction mode
        /// </summary>
        private bool cycleSlipReductEnabled;

        /// <summary>
        /// Determinates if combobox with current values is filled.
        /// </summary>
        private bool isFillCurrentCombobox;

        /// <summary>
        /// This variable prevents the function from accidentally starting
        /// </summary>
        private bool disableHandler = false;

        // hold UI elements for charge pump controls group
        private readonly TextBox ui_Rset;
        private readonly ComboBox ui_Current;
        private readonly ComboBox ui_Linearity;
        private readonly ComboBox ui_Test;
        private readonly CheckBox ui_FastLock;
        private readonly CheckBox ui_PhaseAdjustment;
        private readonly CheckBox ui_TriState;
        private readonly CheckBox ui_CycleSlipReduct;
        private readonly Label ui_CurrentLabel;
        private readonly Label ui_LinearityLabel;

        /// <summary>
        /// Controller for the charge pump control. 
        /// (set resistor, currently set index of current, linearity, test mode, 
        /// state of fast lock, phase adjustment mode, CP output tri-state mode, 
        /// cycle slip reduction mode) 
        /// </summary>
        /// <param name="ui_Rset"> TextBox UI element for set resistor Rset value </param>
        /// <param name="ui_Current"> ComboBox UI element for current of CP </param>
        /// <param name="ui_Linearity"> ComboBox UI element for linearity of CP </param>
        /// <param name="ui_Test"> ComboBox UI element for test modes of CP </param>
        /// <param name="ui_FastLock"> CheckBox UI element for fast-lock </param>
        /// <param name="ui_TriState"> CheckBox UI element for tristate of CP </param>
        /// <param name="ui_CycleSlipReduct"> CheckBox UI element for cycle slip reduction mode </param>
        /// <param name="ui_CurrentLabel"> Label UI element for current label </param>
        /// <param name="ui_LinearityLabel"> Label UI element for linearity label </param>
        /// <param name="ui_PhaseAdjustment"> CheckBox UI element for phase adjustment control </param>
        public ChargePump(TextBox ui_Rset, ComboBox ui_Current, ComboBox ui_Linearity,
                          ComboBox ui_Test, CheckBox ui_FastLock, CheckBox ui_TriState, 
                          CheckBox ui_CycleSlipReduct, Label ui_CurrentLabel, Label ui_LinearityLabel,
                          CheckBox ui_PhaseAdjustment)
        {
            this.ui_Rset    = ui_Rset;
            this.ui_Current = ui_Current;
            this.ui_Linearity   = ui_Linearity;
            this.ui_Test        = ui_Test;
            this.ui_FastLock    = ui_FastLock;
            this.ui_TriState    = ui_TriState;
            this.ui_CycleSlipReduct = ui_CycleSlipReduct;
            this.ui_CurrentLabel    = ui_CurrentLabel;
            this.ui_LinearityLabel  = ui_LinearityLabel;
            this.ui_PhaseAdjustment = ui_PhaseAdjustment;
        }

        /// <summary>
        /// Updates all graphic user elements
        /// </summary>
        public void UpdateUiElements()
        {
            ui_Rset.Text = rSet.ToString();
            ui_Current.SelectedIndex = currentIndex;
            ui_Linearity.SelectedIndex = linearityIndex;
            ui_Test.SelectedIndex = testModeIndex;
            ui_FastLock.Checked = fastLockEnabled;
            ui_PhaseAdjustment.Checked = phaseAdjustmentEnabled;
            ui_CycleSlipReduct.Checked = cycleSlipReductEnabled;
            ui_TriState.Checked = triStateEnabled;
        }

        #region Setters

        /// <summary>
        /// This function check new value for Rset if is beyond limits, adjust it
        /// if neccessary, calculate new currents for appropriate indexes
        /// and update UI elements.
        /// </summary>
        /// <param name="value"> UInt16 resistor value, determinates current of CP </param>
        public void SetRSetValue(UInt16 value)
        {
            if (rSet != value)
            {
                if (value > 10000)
                    value = 10000;
                else if (value < 2700)
                    value = 2700;

                this.rSet = value;

                FillCurrentItemsFromRSetValue();

                UpdateUiElements();
            }
        }

        /// <summary>
        /// Parse string Rset value and set as UInt16. Then check new value 
        /// for Rset if is beyond limits, adjust it if neccessary. Then 
        /// calculate new currents for appropriate indexes and update UI elements.
        /// </summary>
        /// <param name="value"> string resistor value, determinates current of CP </param>
        public void SetRSetValue(string value)
        {
            if (value != string.Empty)
                SetRSetValue(Convert.ToUInt16(value));
            else
                UpdateUiElements();
        }

        /// <summary>
        /// This function set new current index. If is sellected cycle slip mode
        /// or fast lock mode and current index is greater than zero
        /// print error message and set index to zero. In this modes value must 
        /// be set to minimum current value.
        /// </summary>
        /// <param name="value"> index of charge pump current </param>
        public void SetCurrentIndex(int value)
        {
            if (currentIndex != value)
            {
                if ((cycleSlipReductEnabled == true || fastLockEnabled == true) && value != 0)
                {
                    ConsoleController.Console().Write(badCurrentMsg);
                    this.currentIndex = 0;
                }
                else
                {
                    this.currentIndex = value;
                }

                UpdateUiElements();
            }
        }

        /// <summary>
        /// This function set charge pump linearity index value. For Integer-N
        /// it must be 0. For Fractional-N it can be 1-3. This function autoset
        /// correct value.
        /// </summary>
        /// <param name="value"> 
        ///     index of charge pump linearity. 
        ///     0 - Disables the CP linearity mode (integer-N mode),
        ///     1 - CP linearity 10% mode (frac-N mode),
        ///     2 - CP linearity 20% mode (frac-N mode),
        ///     3 - CP linearity 30% mode (frac-N mode)
        /// </param>
        /// <param name="synthMode"> synthesizer mode - FRACTIONAL or INTEGER </param>
        public void SetLinearityIndex(int value, SynthMode synthMode)
        {
            if (linearityIndex != value)
            {
                if (synthMode == SynthMode.INTEGER)
                {
                    if (value != 0)
                        value = 0;
                }
                else
                {
                    if (value == 0)
                        value = 1;
                }

                this.linearityIndex = value;

                UpdateUiElements();
            }
        }

        /// <summary>
        /// This function force set linearity index
        /// </summary>
        /// <param name="value"> 
        ///     index of charge pump linearity. 
        ///     0 - Disables the CP linearity mode (integer-N mode),
        ///     1 - CP linearity 10% mode (frac-N mode),
        ///     2 - CP linearity 20% mode (frac-N mode),
        ///     3 - CP linearity 30% mode (frac-N mode)
        /// </param>
        public void SetLinearityIndex(int value)
        {
            if (linearityIndex != value)
            {
                this.linearityIndex = value;

                UpdateUiElements();
            }
        }

        /// <summary>
        /// This function set charge pump test mode index
        /// </summary>
        /// <param name="value"> 
        ///     charge pump test mode index 
        ///     0 - normal mode,
        ///     1 - Long Reset mode,
        ///     2 - Force CP into source mode,
        ///     3 - Force CP into sink mode.
        /// </param>
        public void SetTestModeIndex(int value)
        {
            if (testModeIndex != value)
            {
                this.testModeIndex = value;

                UpdateUiElements();
            }
        }

        /// <summary>
        /// This function control fast lock mode. If enabled, current index is set 
        /// to minimum value (zero) and phase Adjustment is disabled
        /// </summary>
        /// <param name="value"> 
        ///     true - fast lock enabled, 
        ///     false - fast lock disabled 
        /// </param>
        public void SetFastLockMode(bool value)
        {
            if (fastLockEnabled != value)
            {
                disableHandler = true;  // disable new execution

                this.fastLockEnabled = value;
                if (value ==  true)
                {
                    this.currentIndex = 0;
                    this.phaseAdjustmentEnabled = false;
                }

                UpdateUiElements();

                disableHandler = false;
            }
        }

        /// <summary>
        /// This function set phase adjustment mode
        /// </summary>
        /// <param name="value"> 
        ///     true - enabled,
        ///     false - disabled 
        /// </param>
        public void SetPhaseAdjustmentMode(bool value)
        {
            if (phaseAdjustmentEnabled != value)
            {
                disableHandler = true;  // disable new execution

                this.phaseAdjustmentEnabled = value;
                if (value == true)
                    this.fastLockEnabled = false;

                UpdateUiElements();

                disableHandler = false;
            }
        }

        /// <summary>
        /// This function set cycle slip mode. If true, current index set to zero.
        /// </summary>
        /// <param name="value"> 
        ///     true - enabled, 
        ///     false - disabled 
        /// </param>
        public void SetCycleSlipMode(bool value)
        {
            if (cycleSlipReductEnabled != value)
            {
                this.cycleSlipReductEnabled = value;

                if (value == true)
                {
                    this.currentIndex = 0;
                }

                UpdateUiElements();
            }
        }

        /// <summary>
        /// This function set charge pump tri-state mode
        /// </summary>
        /// <param name="value"> 
        ///     true - enabled, 
        ///     false - disabled 
        /// </param>
        public void SetTriStateMode(bool value)
        {
            if (triStateEnabled != value)
            {
                this.triStateEnabled = value;

                UpdateUiElements();
            }
        }
        #endregion

        #region Getters

        /// <summary>
        /// This function get if current combobox is Filed
        /// </summary>
        /// <returns> 
        ///     true - combobox is filed, 
        ///     false - combobox isn't filled 
        /// </returns>
        public bool isCurrentComboboxFilled()
        {
            return isFillCurrentCombobox;
        }

        /// <summary>
        /// This function get resistor Rset value
        /// </summary>
        /// <returns> resistor Rset value </returns>
        public UInt16 GetRSetValue()
        {
            return rSet;
        }

        /// <summary>
        /// This function get if execution is enabled or disabled
        /// </summary>
        /// <returns> 
        ///     true - excecution disabled, 
        ///     false - excecution enabled 
        /// </returns>
        public bool GetDisableHandler()
        {
            return disableHandler;
        }

        /// <summary>
        /// This function get linearity index
        /// </summary>
        /// <returns> linearity index value </returns>
        public int GetLinearityIndex()
        {
            return linearityIndex;
        }

        #endregion

        #region Other charge pump functions

        /// <summary>
        /// This function is used for recalculate particular current values in
        /// combobox due to resistor Rset value
        /// </summary>
        private void FillCurrentItemsFromRSetValue()
        {
            isFillCurrentCombobox = false;

            IList<string> list = new List<string>();
            decimal I_cp;
            for (UInt16 cp = 0; cp < 16; cp++)
            {
                I_cp = (decimal)(1.63*1000)/(decimal)(rSet) * (1 + cp);
                I_cp = Math.Round(I_cp, 3, MidpointRounding.AwayFromZero);
                list.Add(Convert.ToString(I_cp) + " mA");
            }
            ui_Current.DataSource = list;

            isFillCurrentCombobox = true;
        }

        #endregion
    }
}