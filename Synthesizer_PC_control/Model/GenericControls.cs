using System.Windows.Forms;

namespace Synthesizer_PC_control.Model
{
    /// <summary>
    /// This class is used to handle the generic controls. 
    /// (MUX pin configuration, register 4 double buffered mode, 
    /// integer mode for F = 0, counter reset mode)
    /// </summary>
    public class GenericControls : I_UiLinked
    {
        /// <summary>
        /// MUX pin configuration index
        /// </summary>
        private int muxPinModeIndex;

        /// <summary>
        /// Register 4 double buffer by register 0
        /// </summary>
        private bool reg4DoubleBuffered;

        /// <summary>
        /// Integer mode for F = 0
        /// </summary>
        private bool f0AutoIntNMode;

        /// <summary>
        /// Counter reset mode
        /// </summary>
        private bool RandNCountersReset;

        // hold UI elements for generic controls group
        private readonly ComboBox ui_MuxPinMode;
        private readonly CheckBox ui_Reg4DoubleBuffered;
        private readonly CheckBox ui_F0AutoIntNMode;
        private readonly CheckBox ui_RandNCountersReset;

        /// <summary>
        /// Constructor for the generic controls. 
        /// (MUX pin configuration, register 4 double buffered mode, 
        /// integer mode for F = 0, counter reset mode)
        /// </summary>
        /// <param name="ui_MuxPinMode"> ComboBox UI element for mux pin configuration </param>
        /// <param name="ui_Reg4DoubleBuffered"> CheckBox UI element for register 4 double buffered mode</param>
        /// <param name="ui_F0AutoIntNMode"> CheckBox UI element for integer mode if F=0 </param>
        /// <param name="ui_RandNCountersReset"> CheckBox UI element for R and N counter reset mode </param>
        public GenericControls(ComboBox ui_MuxPinMode, CheckBox ui_Reg4DoubleBuffered,
                               CheckBox ui_F0AutoIntNMode, CheckBox ui_RandNCountersReset)
        {
            this.ui_MuxPinMode          = ui_MuxPinMode;
            this.ui_Reg4DoubleBuffered  = ui_Reg4DoubleBuffered;
            this.ui_F0AutoIntNMode      = ui_F0AutoIntNMode;
            this.ui_RandNCountersReset  = ui_RandNCountersReset;

            this.muxPinModeIndex = 1;
        }

        /// <summary>
        /// Updates all graphic user elements
        /// </summary>
        public void UpdateUiElements()
        {
            ui_MuxPinMode.SelectedIndex = muxPinModeIndex;
            ui_Reg4DoubleBuffered.Checked = reg4DoubleBuffered;
            ui_F0AutoIntNMode.Checked = f0AutoIntNMode;
            ui_RandNCountersReset.Checked = RandNCountersReset;
        }

        #region Setters

        /// <summary>
        /// Set mux configuration index.
        /// </summary>
        /// <param name="value">
        ///     0 - Three-state output
        ///     1 - D_VDD
        ///     2 - D_GND
        ///     3 - R-divider output
        ///     4 - N-divider output/2
        ///     5 - Analog lock detect
        ///     6 - Digital lock detect
        ///     7 - Sync Input
        ///     8-11 - Reserved
        ///     12 - Read SPI registers 06
        ///     13-15 - Reserved
        /// </param>
        public void SetMuxPinMode(int value)
        {
            if (muxPinModeIndex != value)
            {
                this.muxPinModeIndex = value;

                UpdateUiElements();
            }
        }

        /// <summary>
        /// Sets register 4 double buffered mode (by register 0)
        /// </summary>
        /// <param name="value">
        ///     0 - disabled
        ///     1 - enabled
        /// </param>
        public void SetReg4DoubleBuffered(bool value)
        {
            if (reg4DoubleBuffered != value)
            {
                this.reg4DoubleBuffered = value;

                UpdateUiElements();
            }
        }

        /// <summary>
        /// Sets integer mode for F = 0
        /// </summary>
        /// <param name="value">
        ///     true = If F[11:0] = 0, then fractional-N mode is set
        ///     false = If F[11:0] = 0, then integer-N mode is auto set
        /// </param>
        public void SetF0AutoIntNMode(bool value)
        {
            if (f0AutoIntNMode != value)
            {
                this.f0AutoIntNMode = value;

                UpdateUiElements();
            }
        }

        /// <summary>
        /// Sets counter reset mode.
        /// </summary>
        /// <param name="value">
        ///     false = Normal operation
        ///     true =  R and N counters reset
        /// </param>
        public void SetRandNCountersReset(bool value)
        {
            if (RandNCountersReset != value)
            {
                this.RandNCountersReset = value;

                UpdateUiElements();
            }
        }
        #endregion

        #region Getters

        /// <summary>
        /// This function get integer mode for F = 0
        /// </summary>
        /// <returns>
        ///     true = If F[11:0] = 0, then fractional-N mode is set
        ///     false = If F[11:0] = 0, then integer-N mode is auto set
        /// </returns>
        public bool GetF0AutoIntNMode()
        {
            return this.f0AutoIntNMode;
        }

        /// <summary>
        /// Get register 4 double buffered mode (by register 0)
        /// </summary>
        /// <returns>
        ///     0 - disabled
        ///     1 - enabled
        /// </returns>
        public bool GetReg4DoubleBuffered()
        {
            return this.reg4DoubleBuffered;
        }
        #endregion
    }
}