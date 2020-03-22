using System;
using System.Drawing;
using System.Windows.Forms;


using Synthesizer_PC_control.Controllers;
using Synthesizer_PC_control.Properties;


/* 
TODO CRITICAL
Jak updatovat element tak aby přepsal ui, ale nespůsobil event na view??
Otestovat jak funguje click?

Co potřebujeme:
view -textBox edit-> controller - upraví hodnotu-> MyModelObject (ten zavolá updateUiElements)
-edituje textBox2-> Zachytí text box edit událost na view?

controller lock?
view lock?

*/

namespace Synthesizer_PC_control
{
    public partial class Form1 : Form
        {
        //private MyRegister[] registers;
        private Controller controller;
        private bool isForm1Load;
        bool windowInitialized;

        public Form1()
        {
            isForm1Load = false;
            InitializeComponent();
            this.Load += Form1_Load;
        
            controller = new Controller(this);


            controller.LoadSavedWorkspaceData();
            isForm1Load = true;
            EnableControls(false);
        }

        void Form1_Load(object sender, EventArgs e)
        {
            // this is the default
            this.Visible = false;
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.WindowsDefaultBounds;

            // check if the saved bounds are nonzero and visible on any screen
            if (Settings.Default.WindowPosition != Rectangle.Empty &&
                IsVisibleOnAnyScreen(Settings.Default.WindowPosition))
            {
                // first set the bounds
                this.StartPosition = FormStartPosition.Manual;
                this.DesktopBounds = Settings.Default.WindowPosition;

                // afterwards set the window state to the saved value (which could be Maximized)
                this.WindowState = Settings.Default.WindowState;
            }
            else
            {
                // this resets the upper left corner of the window to windows standards
                this.StartPosition = FormStartPosition.WindowsDefaultLocation;

            }
            this.Size = new System.Drawing.Size(821, 771);
            this.Visible = true;
            windowInitialized = true;
        }

        private bool IsVisibleOnAnyScreen(Rectangle rect)
        {
            foreach (Screen screen in Screen.AllScreens)
            {
                if (screen.WorkingArea.IntersectsWith(rect))
                {
                    return true;
                }
            }

            return false;
        }

        protected override void OnClosed(EventArgs e)
        {
             base.OnClosed(e);

            // only save the WindowState if Normal or Maximized
            switch (this.WindowState)
            {
                case FormWindowState.Normal:
                case FormWindowState.Maximized:
                    Settings.Default.WindowState = this.WindowState;
                    break;

                default:
                    Settings.Default.WindowState = FormWindowState.Normal;
                    break;
            }

            # region msorens: this code does *not* handle minimized/maximized window.

            // reset window state to normal to get the correct bounds
            // also make the form invisible to prevent distracting the user
            //this.Visible = false;
            //this.WindowState = FormWindowState.Normal;
            //Settings.Default.WindowPosition = this.DesktopBounds;

            # endregion

            Settings.Default.Save();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            TrackWindowState();
        }

        protected override void OnMove(EventArgs e)
        {
            base.OnMove(e);
            TrackWindowState();
        }

        // On a move or resize in Normal state, record the new values as they occur.
        // This solves the problem of closing the app when minimized or maximized.
        private void TrackWindowState()
        {
            // Don't record the window setup, otherwise we lose the persistent values!
            if (!windowInitialized) { return; }

            if (WindowState == FormWindowState.Normal)
            {
                Settings.Default.WindowPosition = this.DesktopBounds;
            }
        }
        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            controller.SaveWorkspaceData();
        }

        public void EnableControls(bool command)
        {
            AvaibleCOMsComBox.Enabled       = !command;
            Out1Button.Enabled              = command;
            Out2Button.Enabled              = command;
            RefButton.Enabled               = command;
            PloInitButton.Enabled           = command;
            Reg0TextBox.Enabled             = command;
            Reg1TextBox.Enabled             = command;
            Reg2TextBox.Enabled             = command;
            Reg3TextBox.Enabled             = command;
            Reg4TextBox.Enabled             = command;
            Reg5TextBox.Enabled             = command;
            SetAsDefaultRegButton.Enabled   = command;
            ForceLoadRegButton.Enabled      = command;
            LoadDefRegButton.Enabled        = command;
            WriteR0Button.Enabled           = command;
            WriteR1Button.Enabled           = command;
            WriteR2Button.Enabled           = command;
            WriteR3Button.Enabled           = command;
            WriteR4Button.Enabled           = command;
            WriteR5Button.Enabled           = command;
            R0M1.Enabled                    = command;
            R1M1.Enabled                    = command;
            R2M1.Enabled                    = command;
            R3M1.Enabled                    = command;
            R4M1.Enabled                    = command;
            R5M1.Enabled                    = command;
            R0M2.Enabled                    = command;
            R1M2.Enabled                    = command;
            R2M2.Enabled                    = command;
            R3M2.Enabled                    = command;
            R4M2.Enabled                    = command;
            R5M2.Enabled                    = command;
            R0M3.Enabled                    = command;
            R1M3.Enabled                    = command;
            R2M3.Enabled                    = command;
            R3M3.Enabled                    = command;
            R4M3.Enabled                    = command;
            R5M3.Enabled                    = command;
            R0M4.Enabled                    = command;
            R1M4.Enabled                    = command;
            R2M4.Enabled                    = command;
            R3M4.Enabled                    = command;
            R4M4.Enabled                    = command;
            R5M4.Enabled                    = command;
            LoadRegMemory.Enabled           = command;
            SaveRegMemory.Enabled           = command;
            OutAEn_ComboBox.Enabled         = command;
            OutBEn_ComboBox.Enabled         = command;
            OutAPwr_ComboBox.Enabled        = command;
            OutBPwr_ComboBox.Enabled        = command;
            IntNNumUpDown.Enabled           = command;
            FracNNumUpDown.Enabled          = command;
            ModNumUpDown.Enabled            = command;
            ModeIntFracComboBox.Enabled     = command;
            RefFTextBox.Enabled             = command;
            RDivUpDown.Enabled              = command;
            RefDoublerCheckBox.Enabled      = command;
            DivideBy2CheckBox.Enabled       = command;
            pfdFreqLabel.Enabled            = command;
            fVcoScreenLabel.Enabled         = command;
            fOutAScreenLabel.Enabled        = command;
            fOutBScreenLabel.Enabled        = command;
            ADivComboBox.Enabled            = command;
            PhasePNumericUpDown.Enabled     = command;
            RSetTextBox.Enabled             = command;
            CPCurrentComboBox.Enabled       = command;
            CPLinearityComboBox.Enabled     = command;
            CPTestComboBox.Enabled          = command;
            CPFastLockCheckBox.Enabled      = command;
            CPTriStateOutCheckBox.Enabled   = command;
            CPCycleSlipCheckBox.Enabled     = command;
            PfdPolarity.Enabled             = command;
            InputFreqTextBox.Enabled        = command;
            DeltaShowLabel.Enabled          = command;
            ExportIntoMem1Button.Enabled    = command;
            ExportIntoMem2Button.Enabled    = command;
            ExportIntoMem3Button.Enabled    = command;
            ExportIntoMem4Button.Enabled    = command;
            ImportMem1Button.Enabled        = command;
            ImportMem2Button.Enabled        = command;
            ImportMem3Button.Enabled        = command;
            ImportMem4Button.Enabled        = command;
            CalcFreqShowLabel.Enabled       = command;
            ActOut1ShowLabel.Enabled        = command;
            if (!command)
            {
                ActOut1ShowLabel.BackColor      = SystemColors.ScrollBar;
                ActOut2ShowLabel.BackColor      = SystemColors.ScrollBar;
                Mem1ActOut1ShowLabel.BackColor  = SystemColors.ScrollBar;
                Mem2ActOut1ShowLabel.BackColor  = SystemColors.ScrollBar;
                Mem3ActOut1ShowLabel.BackColor  = SystemColors.ScrollBar;
                Mem4ActOut1ShowLabel.BackColor  = SystemColors.ScrollBar;
                Mem1ActOut2ShowLabel.BackColor  = SystemColors.ScrollBar;
                Mem2ActOut2ShowLabel.BackColor  = SystemColors.ScrollBar;
                Mem3ActOut2ShowLabel.BackColor  = SystemColors.ScrollBar;
                Mem4ActOut2ShowLabel.BackColor  = SystemColors.ScrollBar;
            }
            ActOut2ShowLabel.Enabled        = command;
            FreqAtOut1ShowLabel.Enabled     = command;
            FreqAtOut2ShowLabel.Enabled     = command;
            LDSpeedAdjComboBox.Enabled      = command;
            AutoLDSpeedAdjCheckBox.Enabled  = command;
            LDFuncComboBox.Enabled          = command;
            AutoLDFuncCheckBox.Enabled      = command;
            RFoutBPathComboBox.Enabled      = command;
            PhaseAdjustmentModeCheckbox.Enabled = command;
            SigmaDeltaNoiseModeComboBox.Enabled = command;
            LDPrecisionComboBox.Enabled     = command;
            MuxPinModeCombobox.Enabled      = command;
            FBPathComboBox.Enabled          = command;
            PloPowerDownCheckBox.Enabled    = command;
            RefInputShutdownCheckBox.Enabled = command;
            PllShutDownCheckBox.Enabled     = command;
            VcoDividerShutdownCheckBox.Enabled = command;
            VcoLdoShutDownCheckBox.Enabled  = command;
            VcoShutDownCheckBox.Enabled     = command;
            Reg4DoubleBufferedCheckBox.Enabled = command;
            IntNAutoModeWhenF0CheckBox.Enabled = command;
            RandNCountersResetCheckBox.Enabled = command;
            AutoVcoSelectionCheckBox.Enabled = command;
            VASTempCompCheckBox.Enabled     = command;
            ManualVCOSelectNumericUpDown.Enabled = command;
            BandSelClockDivNumericUpDown.Enabled = command;
            MuteUntilLockDetectCheckBox.Enabled   = command; 
            DelayToPreventFlickeringCheckBox.Enabled = command;
            ClockDividerNumericUpDown.Enabled    = command;
            AutoCDIVCalcCheckBox.Enabled         = command;
            DelayInputNumericUpDown.Enabled      = command;
            ADCModeComboBox.Enabled         = command;
            GetADCValueButton.Enabled       = command;
            ReadedADCValueTextBox.Enabled   = command;
            GetCurrentVCOButton.Enabled     = command;
            ReadedVCOValueTextBox.Enabled   = command;
            SaveIntoFileButton.Enabled      = command;
            LoadFromFileButton.Enabled      = command;
            Mem1ActOut1ShowLabel.Enabled    = command;
            Mem2ActOut1ShowLabel.Enabled    = command;
            Mem3ActOut1ShowLabel.Enabled    = command;
            Mem4ActOut1ShowLabel.Enabled    = command;
            Mem1ActOut2ShowLabel.Enabled    = command;
            Mem2ActOut2ShowLabel.Enabled    = command;
            Mem3ActOut2ShowLabel.Enabled    = command;
            Mem4ActOut2ShowLabel.Enabled    = command;
            Mem1RefShowLabel.Enabled    = command;
            Mem2RefShowLabel.Enabled    = command;
            Mem3RefShowLabel.Enabled    = command;
            Mem4RefShowLabel.Enabled    = command;
        }

        public void ProccesReceivedData(object Object)  // FIXME LUKAS need transform to OOD
        {
            try
            {
                string text = controller.serialPort.ReadLine();
                ConsoleController.Console().Write(text);
                if (text == "plo locked")
                {
                    toolStripStatusLabel1.Text = "        plo is locked";
                    LedOnPicBox.Visible = true;
                    LedOffPicBox.Visible = false;

                }
                else if (text == "plo isn't locked")
                {
                    toolStripStatusLabel1.Text = "        plo isn't locked!";
                    LedOnPicBox.Visible = false;
                    LedOffPicBox.Visible = true;
                }
                else if (text == "plo state is not known")
                {
                    toolStripStatusLabel1.Text = "        plo state is not known";
                    LedOnPicBox.Visible = false;
                    LedOffPicBox.Visible = true;
                }
                else
                {
                    string[] separrated = text.Split(' ');
                    switch (separrated[0])
                    {
                        case "stored_data_1":
                            for (int i = 0; i < 7; i++)
                            {
                                controller.memory.GetRegister(1, i).SetValue(separrated[i+1]);
                            }
                            controller.SetMemOutsAndRefFromControlReg(1);
                            break;
                        case "stored_data_2":
                            for (int i = 0; i < 7; i++)
                            {
                                controller.memory.GetRegister(2, i).SetValue(separrated[i+1]);
                            }
                            controller.SetMemOutsAndRefFromControlReg(2);
                            break;
                        case "stored_data_3":
                            for (int i = 0; i < 7; i++)
                            {
                                controller.memory.GetRegister(3, i).SetValue(separrated[i+1]);
                            }
                            controller.SetMemOutsAndRefFromControlReg(3);
                            break;
                        case "stored_data_4":
                            for (int i = 0; i < 7; i++)
                            {
                                controller.memory.GetRegister(4, i).SetValue(separrated[i+1]);
                            }
                            controller.SetMemOutsAndRefFromControlReg(4);
                            break;
                        case "register6_vco":
                            UInt32 reg6 = UInt32.Parse(separrated[1], System.Globalization.NumberStyles.HexNumber);
                            UInt16 currentVCO = (UInt16)Utilities.BitOperations.GetNBits(reg6, 6, 3);
                            controller.readRegister.SetReadedCurrentVCO(currentVCO.ToString());
                            break;
                        case "register6_temp":
                            UInt32 reg = UInt32.Parse(separrated[1], System.Globalization.NumberStyles.HexNumber);
                            UInt16 ADCvalue = (UInt16)Utilities.BitOperations.GetNBits(reg, 7, 16);
                            decimal temp = 95 - 1.14M * ADCvalue;
                            controller.readRegister.SetReadededADC(temp.ToString() + " °C");
                            break;
                        case "register6_tune":
                            UInt32 regSix = UInt32.Parse(separrated[1], System.Globalization.NumberStyles.HexNumber);
                            UInt16 ADCval = (UInt16)Utilities.BitOperations.GetNBits(regSix, 7, 16);
                            decimal tune = 0.315M + 0.0165M * ADCval;
                            controller.readRegister.SetReadededADC(tune.ToString() + " V");
                            break;
                    }
                }
            }
            catch
            {
                
            }
        }

        
        private void NumericUpDwScrollHandlerFunction(object sender, MouseEventArgs e)
        {
            MyFormat.ScrollHandlerFunction((NumericUpDown)sender, e);
        }

#region Synthesizer Module controls
        private void Out1Button_Click(object sender, EventArgs e)
        {
            controller.SwitchOut1();
        }

        private void Out2Button_Click(object sender, EventArgs e)
        {
            controller.SwitchOut2();
        }

        private void RefButton_Click(object sender, EventArgs e)
        {
            controller.SwitchRef();
        }

        private void PloInitButton_Click(object sender, EventArgs e)
        {
            controller.PloModuleInit();
        }

#endregion

#region Registers controls group
        private void RegisterTextBox_TextChanged(object sender, EventArgs e)
        {
            MyFormat.CheckIfHasHexInput((TextBox)sender);
        }
        
        private void RegisterTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                controller.CheckAndApplyRegChanges((((TextBox)(sender)).Name), ((TextBox)(sender)).Text);
            }
        }

        private void RegisterTextBox_LostFocus(object sender, EventArgs e)
        {
            controller.CheckAndApplyRegChanges((((TextBox)(sender)).Name), ((TextBox)(sender)).Text);
        }

        private void WriteRegisterButton_Click(object sender, EventArgs e)
        {
            controller.CheckAndApplyRegChanges(((Button)(sender)).Name);
        }

        private void RegistersPage_Click(object sender, EventArgs e)
        {
            Reg0Label.Focus();
        }

        private void CheckAndApllyChangesForm1_Click(object sender, EventArgs e)
        {
            Reg0Label.Focus();  // TODO pohlídat, k cemu toto sakra je
        }

        private void SetAsDefaultRegButton_Click(object sender, EventArgs e)
        {
            controller.SaveDefRegsData();
        }

        private void LoadDefRegButton_Click(object sender, EventArgs e)
        {
            controller.LoadDefRegsData();
        }

        private void SaveIntoFileButton_Click(object sender, EventArgs e)
        {
            controller.SaveRegistersIntoFile();
        }

        private void LoadFromFileButton_Click(object sender, EventArgs e)
        {
            controller.LoadRegistersFromFile();
        }
        public void ForceLoadRegButton_Click(object sender, EventArgs e)
        {
            controller.ForceLoadAllRegsIntoPlo();
        }

#endregion

#region Serial Port Controls group
        private void AvaibleCOMsComBox_DropDown(object sender, EventArgs e)
        {
            controller.serialPort.GetAvaliablePorts();
        }

        private void AvaibleCOMsComBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isForm1Load == true)
                controller.SelectedSerialPortChanged(AvaibleCOMsComBox.Text);
        }

        private void PortButton_Click(object sender, EventArgs e)
        {
            EnableControls(controller.SwitchPort());
            if (controller.moduleControls.GetIntRefState())
                RefFTextBox.Enabled = false;
            if (AutoLDSpeedAdjCheckBox.Checked)
                LDSpeedAdjComboBox.Enabled = false;
            if (AutoLDFuncCheckBox.Checked)
                LDFuncComboBox.Enabled = false;
            if (AutoVcoSelectionCheckBox.Checked)
                ManualVCOSelectNumericUpDown.Enabled = false;
            else 
                VASTempCompCheckBox.Enabled = false;
            if (!AutoCDIVCalcCheckBox.Checked)
                DelayInputNumericUpDown.Enabled = false;
            else
                ClockDividerNumericUpDown.Enabled = false;
        }

#endregion

#region Registers memory

        private void LoadRegMemory_Click(object sender, EventArgs e)
        {
            controller.LoadRegsFromPloMemory();
        }

        private void SaveRegMemory_Click(object sender, EventArgs e)
        {

            controller.SaveRegsIntoPloMemory();
        }

        private void ExportIntoMememoryButton_Click(object sender, EventArgs e)
        {
            controller.ExportMemory(((Button)(sender)).Name);
        }

        private void ImportMememoryButton_Click(object sender, EventArgs e)
        {
            controller.ImportMemory(((Button)(sender)).Name);
        }
        
        private void MemoryRegister_TextChanged(object sender, EventArgs e)
        {
            controller.SetMemoryRegisterValue(((TextBox)(sender)).Name, ((TextBox)(sender)).Text);
        }

        private void MemActOutShowLabel_Click(object sender, EventArgs e)
        {
            controller.MemActOutSwitch(((Label)(sender)).Name);
        }

        
        private void MemRefShowLabel_Click(object sender, EventArgs e)
        {
            controller.MemIntRefStateSwitch(((Label)(sender)).Name);
        }

        private void MemSaveIntoFileButton_Click(object sender, EventArgs e)
        {
            controller.SaveRegMemoriesIntoFile();
        }

        private void MemLoadFromFileButton_Click(object sender, EventArgs e)
        {
            controller.LoadRegMemoriesFromFile();
        }

        #endregion

        #region Output Controls group
        private void OutAEn_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isForm1Load)
                controller.OutAEnStateChanged(OutAEn_ComboBox.SelectedIndex);
        }

        private void OutBEn_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isForm1Load)
                controller.OutBEnStateChanged(OutBEn_ComboBox.SelectedIndex);
        }

        private void OutAPwr_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isForm1Load)
                controller.OutAPwrValueChanged(OutAPwr_ComboBox.SelectedIndex);
        }

        private void OutBPwr_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isForm1Load)
                controller.OutBPwrValueChanged(OutBPwr_ComboBox.SelectedIndex);
        }

        private void OutBPwr_ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {        
            ComboBox comboBox = (ComboBox)sender;

            if (e.Index == 3) //We are disabling item based on Index, you can have your logic here
            {
                e.Graphics.FillRectangle(SystemBrushes.Window, e.Bounds);
                e.Graphics.DrawString(comboBox.Items[e.Index].ToString(), comboBox.Font, SystemBrushes.GrayText, e.Bounds);            }
            else
            {
                e.DrawBackground();

                // Using winwaed's advice for selected items:
                // Set the brush according to whether the item is selected or not
                Brush brush = ( (e.State & DrawItemState.Selected) > 0) ? SystemBrushes.HighlightText : SystemBrushes.ControlText;
                e.Graphics.DrawString(comboBox.Items[e.Index].ToString(), comboBox.Font, brush, e.Bounds);

                e.DrawFocusRectangle();
            }
        }

        private void OutAPwr_ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {        
            ComboBox comboBox = (ComboBox)sender;

            e.DrawBackground();

            // Using winwaed's advice for selected items:
            // Set the brush according to whether the item is selected or not
            Brush brush = ( Convert.ToUInt16(e.State & DrawItemState.Selected) == 1 ) ? SystemBrushes.HighlightText : SystemBrushes.ControlText;
            e.Graphics.DrawString(comboBox.Items[e.Index].ToString(), comboBox.Font, brush, e.Bounds);

            e.DrawFocusRectangle();
        }

#endregion

#region Output Frequency Controls group
        private void IntNNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            controller.IntNValueChanged((UInt16)IntNNumUpDown.Value);
        }

        private void FracNNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            controller.FracNValueChanged((UInt16)FracNNumUpDown.Value);
        }

        private void ModNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            controller.ModValueChanged((UInt16)ModNumUpDown.Value);
        }

        private void ModeIntFracComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.SynthModeChanged(ModeIntFracComboBox.SelectedIndex);
        }
        
        private void ADivComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.ADivValueChanged((UInt16)ADivComboBox.SelectedIndex);
        }

        private void PhasePNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            controller.PhasePValueChanged((UInt16)PhasePNumericUpDown.Value);
        }
        
        private void LDFuncComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.LDFunctionIndexChanged(LDFuncComboBox.SelectedIndex);
        }
        
        private void AutoLDFuncCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            controller.AutoLDFuncCheckedChanged(AutoLDFuncCheckBox.Checked);
            LDFuncComboBox.Enabled = !AutoLDFuncCheckBox.Checked;
        }
        
        private void RFoutBPathComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.OutBPathIndexChanged(RFoutBPathComboBox.SelectedIndex);
        }

        
        private void FBPathComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.FBPathIndexChanged(FBPathComboBox.SelectedIndex);
        }
#endregion
        
#region Reference frequency control group
        private void RefFTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            controller.FreqTextBoxBehavior(((TextBox)(sender)), e);
        }

        private void RefFTextBox_LostFocus(object sender, EventArgs e)
        {
            controller.ReferenceFrequencyValueChanged(((TextBox)(sender)).Text);
        }

        private void RefFTextBox_TextChanged(object sender, EventArgs e)
        {
            if (isForm1Load == true)
                MyFormat.CheckIfHasDecimalInput(RefFTextBox);
        }

        private void DoubleRefFCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            controller.ReferenceDoublerStateChanged(RefDoublerCheckBox.Checked);
        }

        private void DivideBy2CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            controller.ReferenceDivBy2StateChanged(DivideBy2CheckBox.Checked);
        }

        private void RDivUpDown_ValueChanged(object sender, EventArgs e)
        {
            controller.ReferenceRDividerValueChanged((UInt16)RDivUpDown.Value);
        }

        private void LDSpeedAdjComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.LDSpeedAdjIndexChanged(LDSpeedAdjComboBox.SelectedIndex);
        }

        
        private void AutoLDSpeedAdjCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            controller.AutoLDSpeedAdjChanged(AutoLDSpeedAdjCheckBox.Checked);
            LDSpeedAdjComboBox.Enabled = !AutoLDSpeedAdjCheckBox.Checked;
        }

        #endregion

#region Charge Pump group

        private void RSetTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RSetTextBox_LostFocus(sender, e);
            }
        }

        private void RSetTextBox_LostFocus(object sender, EventArgs e)
        {
            controller.GetCPCurrentFromTextBox(RSetTextBox.Text);
        }

        private void RSetTextBox_TextChanged(object sender, EventArgs e)
        {
            MyFormat.CheckIfHasIntegerInput(RSetTextBox);
        }

        private void CPCurrentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.CPCurrentIndexChanged(CPCurrentComboBox.SelectedIndex);
        }

        private void CPLinearityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.CPLinearityIndexChanged(CPLinearityComboBox.SelectedIndex);
        }

        private void CPTestComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.CPTestModeIndexChanged(CPTestComboBox.SelectedIndex);
        }

        
        private void CPFastLockCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            controller.CPFastLockCheckedChanged(CPFastLockCheckBox.Checked);
        }
        
        private void PhaseAdjustmentModeCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            controller.PhaseAdjustmentCheckedChanged(PhaseAdjustmentModeCheckbox.Checked);
        }

        
        private void CPCycleSlipCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            controller.CPCycleSlipCheckedChanged(CPCycleSlipCheckBox.Checked);
        }

        
        private void CPTriStateOutCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            controller.CPTristateCheckedChanged(CPTriStateOutCheckBox.Checked);
        }

#endregion

#region Phase Detector group
        private void SDNoiseModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.SDNoiseModeIndexChanged(SigmaDeltaNoiseModeComboBox.SelectedIndex);
        }

        private void LDPrecisionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.LDPrecisionIndexChanged(LDPrecisionComboBox.SelectedIndex);
        }
        
        private void PfdPolarity_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.PositivePdfCheckedChanged(PfdPolarity.SelectedIndex);
        }

#endregion

#region Direct frequency controls
        private void InputFreqTextBox_TextChanged(object sender, EventArgs e)
        {
            if (isForm1Load == true)
                MyFormat.CheckIfHasDecimalInput(InputFreqTextBox);
        }

        private void InputFreqTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            controller.FreqTextBoxBehavior(((TextBox)(sender)), e);
        }

        private void TextBoxScrollHandlerFunction(object sender, MouseEventArgs e)
        {
            controller.TextBoxHandlerFunc((TextBox)(sender), e);
        }

        
        private void ActOut1ShowLabel_Click(object sender, EventArgs e)
        {
            controller.SwitchOut1();
        }

        private void ActOut2ShowLabel_Click(object sender, EventArgs e)
        {
            controller.SwitchOut2();
        }

        private void IntExtShowLabel_Click(object sender, EventArgs e)
        {
            controller.SwitchRef();
        }

        #endregion

#region Generic controls Group

        private void MuxPinModeCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isForm1Load)
                controller.MuxPinModeIndexChanged(MuxPinModeCombobox.SelectedIndex);
        }

        private void Reg4DoubleBufferedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isForm1Load)
                controller.Reg4DoubleBufferedStateChanged(Reg4DoubleBufferedCheckBox.Checked);
        }

        private void IntNAutoModeWhenF0CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isForm1Load)
                controller.IntNAutoModeWhenF0StateChanged(IntNAutoModeWhenF0CheckBox.Checked);
        }

        private void RandNCountersResetCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isForm1Load)
                controller.RandNCountersResetStateChanged(RandNCountersResetCheckBox.Checked);
        }

#endregion

#region VCO controls group
        
        private void AutoVcoSelectionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isForm1Load)
                controller.AutoVcoSelectionStateChanged(AutoVcoSelectionCheckBox.Checked);
        }

        private void VASTempCompCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isForm1Load)
                controller.VASTempComStateChanged(VASTempCompCheckBox.Checked);
        }
        
        private void ManualVCOSelectNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (isForm1Load)
                controller.ManualVCOSelectValueChanged((int)ManualVCOSelectNumericUpDown.Value);
        }
        
        private void BandSelClockDivNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (isForm1Load)
                controller.BandSelClockDivValueChanged((int)BandSelClockDivNumericUpDown.Value);
        }

        private void MuteUntilLockDetectCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isForm1Load)
                controller.MuteUntilLockDetectStateChanged(MuteUntilLockDetectCheckBox.Checked);
        }
        
        private void DelayToPreventFlickeringCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isForm1Load)
                controller.DelayToPreventFlickeringStateChanged(DelayToPreventFlickeringCheckBox.Checked);
        }

        private void ClockDividerNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (isForm1Load)
                controller.ClockDividerValueChanged((int)ClockDividerNumericUpDown.Value);
        }

        private void AutoCDIVCalcCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isForm1Load)
                controller.AutoCDIVCalcStateChanged(AutoCDIVCalcCheckBox.Checked);
        }
        
        private void DelayInputNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (isForm1Load)
                controller.DelayInputValueChanged((UInt16)DelayInputNumericUpDown.Value);
        }

        #endregion

#region Shutdown control group

        private void PloPowerDownCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isForm1Load)
                controller.PloPowerDownStateChanged(PloPowerDownCheckBox.Checked);
        }

        private void RefInputShutdownCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isForm1Load)
                controller.RefInputShutdownStateChanged(RefInputShutdownCheckBox.Checked);
        }

        private void PllShutDownCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isForm1Load)
                controller.PllShutDownStateChanged(PllShutDownCheckBox.Checked);
        }

        private void VcoDividerShutdownCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isForm1Load)
                controller.VcoDividerShutDownStateChanged(VcoDividerShutdownCheckBox.Checked);
        }

        private void VcoLdoShutDownCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isForm1Load)
                controller.VcoLdoShutDownStateChanged(VcoLdoShutDownCheckBox.Checked);
        }

        private void VcoShutDownCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isForm1Load)
                controller.VcoShutDownStateChanged(VcoShutDownCheckBox.Checked);
        }

#endregion

#region Read Register 6 Control group
        
        private void GetCurrentVCOButton_Click(object sender, EventArgs e)
        {
            controller.GetCurrentVCO();
        }

        private void GetADCValueButton_Click(object sender, EventArgs e)
        {
            controller.GetADCValue();
        }

        private void ADCModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.AdcModeIndexChanged(ADCModeComboBox.SelectedIndex);
        }

        #endregion

    }
}
