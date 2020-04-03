using System.Windows.Forms;

namespace Synthesizer_PC_control.Model
{   
    /// <summary>
    /// This class is used to handle the phase detector control. 
    /// (Phase detector noise mode, lock-detect precision and polarity)
    /// </summary>
    public class PhaseDetector : I_UiLinked
    {   
        /// <summary>
        /// Frac-N Sigma Delta Noise Mode
        /// </summary>
        private int noiseModeIndex;

        /// <summary>
        /// Lock-detect precision
        /// </summary>
        private int precisionIndex;

        /// <summary>
        /// Phase detector polarity
        /// </summary>
        private int pfdPolarity;

        // hold UI elements for direct frequency controls group
        private readonly ComboBox ui_NoiseMode;
        private readonly ComboBox ui_Precision;
        private readonly ComboBox ui_PfdPolarity;

        /// <summary>
        /// Constructor for the phase detector control. 
        /// (Phase detector noise mode, lock-detect precision and polarity)
        /// </summary>
        /// <param name="ui_NoiseMode"> ComboBox UI element for phase detector noise mode </param>
        /// <param name="ui_Precision"> ComboBox UI element for lock-detect precision </param>
        /// <param name="ui_PfdPolarity"> ComboBox UI element for phase detector polarity </param>
        public PhaseDetector(ComboBox ui_NoiseMode, ComboBox ui_Precision, 
                             ComboBox ui_PfdPolarity)
        {
            this.ui_NoiseMode = ui_NoiseMode;
            this.ui_Precision = ui_Precision;
            this.ui_PfdPolarity = ui_PfdPolarity;
        }

        /// <summary>
        /// Updates all graphic user elements
        /// </summary>
        public void UpdateUiElements()
        {
            ui_NoiseMode.SelectedIndex = noiseModeIndex;
            ui_Precision.SelectedIndex = precisionIndex;
            ui_PfdPolarity.SelectedIndex = pfdPolarity;
        }

        #region Setters

        /// <summary>
        /// This function set phase detector noise mode index
        /// </summary>
        /// <param name="value"> 
        ///     0 - Low-Noise mode, 
        ///     2 - Low-spur mode 1, 
        ///     3 - Low-spur mode 2 
        /// </param>
        public void SetNoiseMode(int value)
        {
            this.noiseModeIndex = value;

            UpdateUiElements();
        }

        /// <summary>
        /// This function set phase detector precision
        /// </summary>
        /// <param name="value"> 
        ///     0 - 10ns, 
        ///     1 - 6ns
        /// </param>
        public void SetPrecisionIndex(int value)
        {
            this.precisionIndex = value;

            UpdateUiElements();
        }

        /// <summary>
        /// This function set PFD polarity
        /// </summary>
        /// <param name="value"> 
        ///     0 - negative, 
        ///     1 - positive (default) 
        /// </param>
        public void SetPfdPolarity(int value)
        {
            this.pfdPolarity = value;

            UpdateUiElements();
        }
        #endregion
    }
}