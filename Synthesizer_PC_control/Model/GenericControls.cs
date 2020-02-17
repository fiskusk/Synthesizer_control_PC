using System;
using System.Windows.Forms;

namespace Synthesizer_PC_control.Model
{
    public class GenericControls : I_UiLinked
    {
        private int muxPinModeIndex;
        private readonly ComboBox ui_MuxPinMode;
        public GenericControls(ComboBox ui_MuxPinMode)
        {
            this.ui_MuxPinMode = ui_MuxPinMode;
        }

        #region Setters
        public void SetMuxPinMode(int value)
        {
            this.muxPinModeIndex = value;

            UpdateUiElements();
        }
        #endregion

        #region Getters
        #endregion

        public void UpdateUiElements()
        {
            ui_MuxPinMode.SelectedIndex = muxPinModeIndex;
        }
    }
}