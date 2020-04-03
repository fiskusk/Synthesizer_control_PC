using System;
using System.Windows.Forms;

namespace Synthesizer_PC_control.Model
{
    /// <summary>
    /// This class is used to handle the shutdown controls. 
    /// (synthesizer power-down mode, shutdown reference input, PLL, 
    /// VCO Divider, VCO LDO, VCO) 
    /// </summary>
    public class Shutdowns : I_UiLinked
    {
        /// <summary>
        /// Synthesizer power-down mode
        /// </summary>
        private bool shutdownAllState;

        /// <summary>
        /// Shutdown Reference input mode
        /// </summary>
        private bool refInputShutdownState;

        /// <summary>
        /// Shutdown PLL mode
        /// </summary>
        private bool pllShutdownState;

        /// <summary>
        /// Shutdown VCO Divider mode
        /// </summary>
        private bool vcoDividerShutdownState;

        /// <summary>
        /// Shutdown VCO LDO mode
        /// </summary>
        private bool vcoLdoShutdownState;

        /// <summary>
        /// VCO Shutdown mode
        /// </summary>
        private bool vcoShutdownState;

        // hold UI elements for shutdown controls group
        private readonly CheckBox ui_ShutdownAll;
        private readonly CheckBox ui_ReferenceInputShutdown;
        private readonly CheckBox ui_PllShutdown;
        private readonly CheckBox ui_VcoDividerShutdown;
        private readonly CheckBox ui_VcoLdoShutdown;
        private readonly CheckBox ui_VcoShutdown;

        /// <summary>
        /// Constructor for the shutdown controls. 
        /// (synthesizer power-down mode, shutdown reference input, PLL, 
        /// VCO Divider, VCO LDO, VCO) 
        /// </summary>
        /// <param name="ui_ShutdownAll"> CheckBox UI element for synthesizer power-down mode </param>
        /// <param name="ui_ReferenceInputShutdown"> CheckBox UI element for shutdown reference input </param>
        /// <param name="ui_PllShutdown"> CheckBox UI element for shutdown PLL </param>
        /// <param name="ui_VcoDividerShutdown"> CheckBox UI element for shutdown VCO divider </param>
        /// <param name="ui_VcoLdoShutdown"> CheckBox UI element for shutdown VCO LDO </param>
        /// <param name="ui_VcoShutdown"> CheckBox UI element for shutdown VCO </param>
        public Shutdowns(CheckBox ui_ShutdownAll, CheckBox ui_ReferenceInputShutdown,
                         CheckBox ui_PllShutdown, CheckBox ui_VcoDividerShutdown,
                         CheckBox ui_VcoLdoShutdown, CheckBox ui_VcoShutdown)
        {
            this.ui_ShutdownAll             = ui_ShutdownAll;
            this.ui_ReferenceInputShutdown  = ui_ReferenceInputShutdown;
            this.ui_PllShutdown             = ui_PllShutdown;
            this.ui_VcoDividerShutdown      = ui_VcoDividerShutdown;
            this.ui_VcoLdoShutdown          = ui_VcoLdoShutdown;
            this.ui_VcoShutdown             = ui_VcoShutdown;
        }

        /// <summary>
        /// Updates all graphic user elements
        /// </summary>
        public void UpdateUiElements() 
        {
            ui_ShutdownAll.Checked = shutdownAllState;
            ui_ReferenceInputShutdown.Checked = refInputShutdownState;
            ui_PllShutdown.Checked = pllShutdownState;
            ui_VcoDividerShutdown.Checked = vcoDividerShutdownState;
            ui_VcoLdoShutdown.Checked = vcoLdoShutdownState;
            ui_VcoShutdown.Checked = vcoShutdownState;
        }

        #region Setters

        /// <summary>
        /// This sets synthesizer shutdown mode
        /// </summary>
        /// <param name="value">
        ///     false = Normal mode,
        ///     true = Device shutdown
        /// </param>
        public void SetShutdownAllState(bool value)
        {
            if (shutdownAllState != value)
            {
                this.shutdownAllState = value;

                UpdateUiElements();
            }
        }

        /// <summary>
        /// Sets Shutdown Reference input mode
        /// </summary>
        /// <param name="value">
        ///     false = Enables Reference Input,
        ///     true = Disables Reference Input
        /// </param>
        public void SetReferenceInputShutdownState(bool value)
        {
            if (refInputShutdownState != value)
            {
                this.refInputShutdownState = value;
                
                UpdateUiElements();
            }
        }

        /// <summary>
        /// Sets Shutdown PLL mode
        /// </summary>
        /// <param name="value">
        ///     false = Enables PLL,
        ///     true = Disables PLL
        /// </param>
        public void SetPllShutdownState(bool value)
        {
            if (pllShutdownState != value)
            {
                this.pllShutdownState = value;
                
                UpdateUiElements();
            }
        }

        /// <summary>
        /// Sets Shutdown VCO Divider mode.
        /// </summary>
        /// <param name="value">
        ///     false = Enables VCO Divider,
        ///     true = Disables VCO Divider
        /// </param>
        public void SetVcoDividerShutdownState(bool value)
        {
            if (vcoDividerShutdownState != value)
            {
                this.vcoDividerShutdownState = value;
                
                UpdateUiElements();
            }
        }

        /// <summary>
        /// Sets Shutdown VCO LDO mode.
        /// </summary>
        /// <param name="value">
        ///     false = Enables VCO LDO,
        ///     true = Disables VCO LDO
        /// </param>
        public void SetVcoLdoShutdownState(bool value)
        {
            if (vcoLdoShutdownState != value)
            {
                this.vcoLdoShutdownState = value;
                
                UpdateUiElements();
            }
        }

        /// <summary>
        /// Sets VCO Shutdown mode.
        /// </summary>
        /// <param name="value">
        ///     false = Enables VCO,
        ///     true = Disables VCO
        /// </param>
        public void SetVcoShutdownState(bool value)
        {
            if (vcoShutdownState != value)
            {
                this.vcoShutdownState = value;
                
                UpdateUiElements();
            }
        }
        #endregion

        #region Getters

        /// <summary>
        /// Gets synthesizer shutdown mode
        /// </summary>
        /// <returns>
        ///     false = Normal mode,
        ///     true = Device shutdown
        /// </returns>
        public bool GetShutdownAllState()
        {
            return shutdownAllState;
        }

        /// <summary>
        /// Gets Shutdown Reference input mode
        /// </summary>
        /// <returns>
        ///     false = Enables Reference Input,
        ///     true = Disables Reference Input
        /// </returns>
        public bool GetReferenceInputShutdownState()
        {
            return refInputShutdownState;
        }

        /// <summary>
        /// Gets Shutdown PLL mode.
        /// </summary>
        /// <returns>
        ///     false = Enables PLL,
        ///     true = Disables PLL
        /// </returns>
        public bool GetPllShutdownState()
        {
            return pllShutdownState;
        }

        /// <summary>
        /// Gets Shutdown VCO Divider mode.
        /// </summary>
        /// <returns>
        ///     false = Enables VCO Divider,
        ///     true = Disables VCO Divider
        /// </returns>
        public bool GetVcoDividerShutdownState()
        {
            return vcoDividerShutdownState;
        }

        /// <summary>
        /// Gets Shutdown VCO LDO mode.
        /// </summary>
        /// <returns>
        ///     false = Enables VCO LDO,
        ///     true = Disables VCO LDO
        /// </returns>
        public bool GetVcoLdoShutdownState()
        {
            return vcoLdoShutdownState;
        }

        /// <summary>
        /// Gets Shutdown VCO mode
        /// </summary>
        /// <returns>
        ///     false = Enables VCO,
        ///     true = Disables VCO
        /// </returns>
        public bool GetVcoShutdownState()
        {
            return vcoShutdownState;
        }
        
        #endregion
        
    }
}