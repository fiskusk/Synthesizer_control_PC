using System.Windows.Forms;

namespace Synthesizer_PC_control.Model
{
    public class GenericControls : I_UiLinked
    {
        private int muxPinModeIndex;
        private bool reg4DoubleBuffered;
        private bool f0AutoIntNMode;
        private bool RandNCountersReset;
        private readonly ComboBox ui_MuxPinMode;
        private readonly CheckBox ui_Reg4DoubleBuffered;
        private readonly CheckBox ui_F0AutoIntNMode;
        private readonly CheckBox ui_RandNCountersReset;
        public GenericControls(ComboBox ui_MuxPinMode, CheckBox ui_Reg4DoubleBuffered,
                               CheckBox ui_F0AutoIntNMode, CheckBox ui_RandNCountersReset)
        {
            this.ui_MuxPinMode          = ui_MuxPinMode;
            this.ui_Reg4DoubleBuffered  = ui_Reg4DoubleBuffered;
            this.ui_F0AutoIntNMode      = ui_F0AutoIntNMode;
            this.ui_RandNCountersReset  = ui_RandNCountersReset;
        }

        #region Setters
        public void SetMuxPinMode(int value)
        {
            if (muxPinModeIndex != value)
            {
                this.muxPinModeIndex = value;

                UpdateUiElements();
            }
        }

        public void SetReg4DoubleBuffered(bool value)
        {
            if (reg4DoubleBuffered != value)
            {
                this.reg4DoubleBuffered = value;

                UpdateUiElements();
            }
        }

        public void SetF0AutoIntNMode(bool value)
        {
            if (f0AutoIntNMode != value)
            {
                this.f0AutoIntNMode = value;

                UpdateUiElements();
            }
        }

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
        public bool GetF0AutoIntNMode()
        {
            return this.f0AutoIntNMode;
        }

        public bool GetReg4DoubleBuffered()
        {
            return this.reg4DoubleBuffered;
        }
        #endregion

        public void UpdateUiElements()
        {
            ui_MuxPinMode.SelectedIndex = muxPinModeIndex;
            ui_Reg4DoubleBuffered.Checked = reg4DoubleBuffered;
            ui_F0AutoIntNMode.Checked = f0AutoIntNMode;
            ui_RandNCountersReset.Checked = RandNCountersReset;
        }
    }
}