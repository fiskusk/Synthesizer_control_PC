using System.Windows.Forms;

using Synthesizer_PC_control.Controllers;

namespace Synthesizer_PC_control.Model
{
    /// <summary>
    /// Enumerable for synthesizer output enebled state
    /// </summary>
    public enum OutEnState
    {
        DISABLE,
        ENABLE
    }

    /// <summary>
    /// This class is used to handle the synthesizer output controls.
    /// (controls for enable synthesizer output A and B, 
    /// controls for control synthesizer output power at out A and B)
    /// </summary>
    public class SynthOutputControls : I_UiLinked
    {
        // error messages
        private string wrongBPwrMsg = "Warning: Output power at 'Out B' is limited to maximum +2 dBm. This limitation is due to the frequency doubler circuit used at Out 2";

        /// <summary>
        /// state at synthesizer output A 
        /// </summary>
        private OutEnState outAEn;

        /// <summary>
        /// state at synthesizer output B
        /// </summary>
        private OutEnState outBEn;

        /// <summary>
        /// Synthesizer output A index
        /// </summary>
        private int outAPwrIndex;

        /// <summary>
        /// Synthesizer output B index
        /// </summary>
        private int outBPwrIndex;

        // hold UI elements for synthesizer frequency info group
        private readonly ComboBox ui_outAEnable;
        private readonly ComboBox ui_outBEnable;
        private readonly ComboBox ui_outAPwr;
        private readonly ComboBox ui_outBPwr;

        /// <summary>
        /// Constructor for the synthesizer output controls.
        /// (controls for enable synthesizer output A and B, 
        /// controls for control synthesizer output power at out A and B)
        /// </summary>
        /// <param name="ui_outAEnable"> ComboBox UI element for synthesize output A enabling control </param>
        /// <param name="ui_outBEnable"> ComboBox UI element for synthesize output B enabling control </param>
        /// <param name="ui_outAPwr"> ComboBox UI element for synthesizer output A power control </param>
        /// <param name="ui_outBPwr"> ComboBox UI element for synthesizer output B power control </param>
        public SynthOutputControls(ComboBox ui_outAEnable, ComboBox ui_outBEnable,
                                   ComboBox ui_outAPwr, ComboBox ui_outBPwr)
        {
            this.ui_outAEnable  = ui_outAEnable;
            this.ui_outBEnable  = ui_outBEnable;
            this.ui_outAPwr     = ui_outAPwr;
            this.ui_outBPwr     = ui_outBPwr;

            this.ui_outAEnable.SelectedIndex  = 0;
            this.ui_outBEnable.SelectedIndex  = 0;
            this.ui_outAPwr.SelectedIndex     = 0;
            this.ui_outBPwr.SelectedIndex     = 0;

            outAEn  = OutEnState.DISABLE;
            outBEn  = OutEnState.DISABLE;
            outAPwrIndex = 0;
            outBPwrIndex = 0;

            UpdateUiElements();
        }

        /// <summary>
        /// Updates all graphic user elements
        /// </summary>
        public void UpdateUiElements()
        {
            this.ui_outAEnable.SelectedIndex = (int)outAEn;
            this.ui_outBEnable.SelectedIndex = (int)outBEn;
            this.ui_outAPwr.SelectedIndex = outAPwrIndex;
            this.ui_outBPwr.SelectedIndex = outBPwrIndex;
        }

        #region Setters

        /// <summary>
        /// This function set state for synthesizer output A
        /// </summary>
        /// <param name="value"> enable or disable out A </param>
        public void SetOutAEnable(OutEnState value)
        {
            if (this.outAEn != value)
            {
                this.outAEn = value;

                UpdateUiElements();
            }
        }

        /// <summary>
        /// This function set state for synthesizer output B
        /// </summary>
        /// <param name="value"> enable or disable out B </param>
        public void SetOutBEnable(OutEnState value)
        {
            if (this.outBEn != value)
            {
                this.outBEn = value;

                UpdateUiElements();
            }
        }

        /// <summary>
        /// This function set power at synthesizer output A
        /// </summary>
        /// <param name="value"> 
        ///     0 is -4dBm, 
        ///     1 is -1dBm, 
        ///     2 is +2dBm, 
        ///     3 is +5dBm
        /// </param>
        public void SetOutAPwr(int value)
        {
            if (this.outAPwrIndex != value)
            {
                this.outAPwrIndex = value;

                UpdateUiElements();
            }
        }

        /// <summary>
        /// This function set power at synthesizer output B.
        /// If set 3, will be set current value at model and print error msg into console
        /// </summary>
        /// <param name="value"> 
        ///     index value 
        ///     0 is -4dBm, 
        ///     1 is -1dBm, 
        ///     2 is +2dBm, 
        ///     3 is +5dBm 
        ///     [last value is not possible, because maximum power at frequency 
        ///     doubler connected at output B is +3dBm]) 
        /// </param>
        /// <returns> success of operation </returns>
        public bool SetOutBPwr(int value)
        {
            bool state;
            if (value == 3)
            {
                value = outBPwrIndex;
                ConsoleController.Console().Write(wrongBPwrMsg);
                state = false;
            }
            else
            {
                state = true;
            }

            this.outBPwrIndex = value;

            UpdateUiElements();

            return state;
        }
        #endregion

        #region Getters

        /// <summary>
        /// This function return current index of sellected power at output B
        /// </summary>
        /// <returns> current index of sellected power at output B </returns>
        public int GetOutBPwrIndex()
        {
            return outBPwrIndex;
        }

        #endregion
    }
}