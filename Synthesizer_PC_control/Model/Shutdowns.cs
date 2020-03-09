using System;
using System.Windows.Forms;

namespace Synthesizer_PC_control.Model
{
    public class Shutdowns : I_UiLinked
    {
        private bool shutdownAllState;
        private bool refInputShutdownState;
        private bool pllShutdownState;
        private bool vcoDividerShutdownState;
        private bool vcoLdoShutdownState;
        private bool vcoShutdownState;

        private readonly CheckBox ui_ShutdownAll;
        private readonly CheckBox ui_ReferenceInputShutdown;
        private readonly CheckBox ui_PllShutdown;
        private readonly CheckBox ui_VcoDividerShutdown;
        private readonly CheckBox ui_VcoLdoShutdown;
        private readonly CheckBox ui_VcoShutdown;

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

        public void SetShutdownAllState(bool value)
        {
            if (shutdownAllState != value)
            {
                this.shutdownAllState = value;

                UpdateUiElements();
            }
        }

        public void SetReferenceInputShutdownState(bool value)
        {
            if (refInputShutdownState != value)
            {
                this.refInputShutdownState = value;
                
                UpdateUiElements();
            }
        }

        public void SetPllShutdownState(bool value)
        {
            if (pllShutdownState != value)
            {
                this.pllShutdownState = value;
                
                UpdateUiElements();
            }
        }

        public void SetVcoDividerShutdownState(bool value)
        {
            if (vcoDividerShutdownState != value)
            {
                this.vcoDividerShutdownState = value;
                
                UpdateUiElements();
            }
        }

        public void SetVcoLdoShutdownState(bool value)
        {
            if (vcoLdoShutdownState != value)
            {
                this.vcoLdoShutdownState = value;
                
                UpdateUiElements();
            }
        }

        public void SetVcoShutdownState(bool value)
        {
            if (vcoShutdownState != value)
            {
                this.vcoShutdownState = value;
                
                UpdateUiElements();
            }
        }

        public bool GetShutdownAllState()
        {
            return shutdownAllState;
        }

        public bool GetReferenceInputShutdownState()
        {
            return refInputShutdownState;
        }

        public bool GetPllShutdownState()
        {
            return pllShutdownState;
        }

        public bool GetVcoDividerShutdownState()
        {
            return vcoDividerShutdownState;
        }

        public bool GetVcoLdoShutdownState()
        {
            return vcoLdoShutdownState;
        }

        public bool GetVcoShutdownState()
        {
            return vcoShutdownState;
        }
        
        public void UpdateUiElements() 
        {
            ui_ShutdownAll.Checked = shutdownAllState;
            ui_ReferenceInputShutdown.Checked = refInputShutdownState;
        }
    }
}