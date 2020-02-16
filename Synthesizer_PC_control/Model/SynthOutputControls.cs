using System.Windows.Forms;

using Synthesizer_PC_control.Controllers;

namespace Synthesizer_PC_control.Model
{
    public enum OutEnState
    {
        DISABLE,
        ENABLE
    }

    public class SynthOutputControls : I_UiLinked
    {
        private OutEnState outAEn;
        private OutEnState outBEn;
        private int outAPwr;
        private int outBPwr;
        private string wrongBPwrMessage = "Warning: Output power at 'Out B' is limited to maximum +2 dBm. This limitation is due to the frequency doubler circuit used at Out 2";
        private readonly ComboBox ui_outAEnable;
        private readonly ComboBox ui_outBEnable;
        private readonly ComboBox ui_outAPwr;
        private readonly ComboBox ui_outBPwr;
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
            outAPwr = 0;
            outBPwr = 0;

            UpdateUiElements();
        }

        #region Setters
        public void SetOutAEnable(OutEnState value)
        {
            this.outAEn = value;

            UpdateUiElements();
        }

        public void SetOutBEnable(OutEnState value)
        {
            this.outBEn = value;

            UpdateUiElements();
        }

        public void SetOutAPwr(int value)
        {
            this.outAPwr = value;

            UpdateUiElements();
        }

        public bool SetOutBPwr(int value)
        {
            bool state;
            if (value == 3)
            {
                value = outBPwr;
                ConsoleController.Console().Write(wrongBPwrMessage);
                state = false;
            }
            else
            {
                state = true;
            }

            this.outBPwr = value;

            UpdateUiElements();

            return state;
        }
        #endregion

        #region Getters
        public int GetOutBPwrIndex()
        {
            return outBPwr;
        }
        #endregion

        public void UpdateUiElements()
        {
            this.ui_outAEnable.SelectedIndex = (int)outAEn;
            this.ui_outBEnable.SelectedIndex = (int)outBEn;
            this.ui_outAPwr.SelectedIndex = outAPwr;
            this.ui_outBPwr.SelectedIndex = outBPwr;
        }
    }
}