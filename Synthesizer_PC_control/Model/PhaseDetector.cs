using System;
using System.Windows.Forms;

namespace Synthesizer_PC_control.Model
{
    public class PhaseDetector : I_UiLinked
    {
        private int noiseModeIndex;
        private int precisionIndex;
        private int pfdPolarity;
        private readonly ComboBox ui_NoiseMode;
        private readonly ComboBox ui_Precision;
        private readonly ComboBox ui_PfdPolarity;
        public PhaseDetector(ComboBox ui_NoiseMode, ComboBox ui_Precision, 
                             ComboBox ui_PfdPolarity)
        {
            this.ui_NoiseMode = ui_NoiseMode;
            this.ui_Precision = ui_Precision;
            this.ui_PfdPolarity = ui_PfdPolarity;
        }

        #region Setters
        public void SetNoiseMode(int value)
        {
            this.noiseModeIndex = value;

            UpdateUiElements();
        }

        public void SetPrecision(int value)
        {
            this.precisionIndex = value;

            UpdateUiElements();
        }

        public void SetPfdPolarity(int value)
        {
            this.pfdPolarity = value;

            UpdateUiElements();
        }
        #endregion

        #region Getters
        #endregion

        public void UpdateUiElements()
        {
            ui_NoiseMode.SelectedIndex = noiseModeIndex;
            ui_Precision.SelectedIndex = precisionIndex;
            ui_PfdPolarity.SelectedIndex = pfdPolarity;
        }
    }
}