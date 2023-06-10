using System;
using System.Windows.Forms;

namespace Synthesizer_PC_control.Model
{  
    /// <summary>
    /// This class is used to handle the VCO controls. 
    /// (VCO auto selection state, VAS response to temperature drift, 
    /// frequency and enabled state of output 1 and 2, internal or external ref state) 
    /// </summary>
    public class MyStatusStrip : I_UiLinked
    {
        public enum LockStatus
        {
            Locked,
            Unlocked,
            Unknown
        }

        private string toolstripText;
        private bool ledOnVisibleStatus;
        private bool ledOffVisibleStatus;
        private LockStatus lockStatus;
        private string temperature;


        // hold UI elements for VCO controls group
        private readonly ToolStripStatusLabel ui_ToolStripStatusLabel;
        private readonly PictureBox ui_LedOnPicBox;
        private readonly PictureBox ui_LedOffPicBox;

        public MyStatusStrip(ToolStripStatusLabel ui_ToolStripStatusLabel,
                             PictureBox ui_LedOnPicBox,
                             PictureBox ui_LedOffPicBox)
        {
            this.ui_ToolStripStatusLabel    = ui_ToolStripStatusLabel;
            this.ui_LedOnPicBox    = ui_LedOnPicBox;
            this.ui_LedOffPicBox    = ui_LedOffPicBox;

            temperature = "-";
        }

        /// <summary>
        /// Updates all graphic user elements
        /// </summary>
        public void UpdateUiElements()
        {
            this.ui_ToolStripStatusLabel.Text       = toolstripText;
            this.ui_LedOnPicBox.Visible             = ledOnVisibleStatus;
            this.ui_LedOffPicBox.Visible            = ledOffVisibleStatus;
        }

        #region Setters

        /// <summary>
        /// Sets automatic selection VCO
        /// </summary>
        /// <param name="value">
        ///     false = disabled automatic VCO selection,
        ///     true = enabled automatic VCO selection
        /// </param>
        public void SetToolStripStatusLabel(string text)
        {
            toolstripText = text;
            
            UpdateUiElements();
        }
        public void SetLedOnPicBox(bool status)
        {
            ledOnVisibleStatus = status;
            
            UpdateUiElements();
        }
        public void SetLedOffPicBox(bool status)
        {
            ledOffVisibleStatus = status;
            
            UpdateUiElements();
        }

        public void SetLockStatus(LockStatus status)
        {
            lockStatus = status;

            GenerateStatusLabel();
            UpdateUiElements();
            //ui_ToolStripStatusLabel.Invalidate();
            //ui_ToolStripStatusLabel.Update();
            //ui_ToolStripStatusLabel.Refresh();
            //Application.DoEvents();
        }

        public void SetTemperature(string temp)
        {
            this.temperature = temp;
            GenerateStatusLabel();
            UpdateUiElements();
        }

        public void GenerateStatusLabel()
        {
            if (lockStatus == LockStatus.Locked) {
                toolstripText = "        plo is locked";
                ledOnVisibleStatus = true;
                ledOffVisibleStatus = false;
            }
            else if (lockStatus == LockStatus.Unlocked) {
                toolstripText = "        plo isn't locked!";
                ledOnVisibleStatus = false;
                ledOffVisibleStatus = true;
            }
            else if (lockStatus == LockStatus.Unknown) {
                toolstripText = "        plo state is not known";
                ledOnVisibleStatus = false;
                ledOffVisibleStatus = true;
            }
            toolstripText += "; MCU temperature is " + temperature + " °C";
        }

        #endregion

        #region Getters

        #endregion
    }
}