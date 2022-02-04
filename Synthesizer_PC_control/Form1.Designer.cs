using System.Windows.Forms;

namespace Synthesizer_PC_control
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.PortButton = new System.Windows.Forms.Button();
            this.Out1Button = new System.Windows.Forms.Button();
            this.Out2Button = new System.Windows.Forms.Button();
            this.PloInitButton = new System.Windows.Forms.Button();
            this.Reg0TextBox = new System.Windows.Forms.TextBox();
            this.Reg0Label = new System.Windows.Forms.Label();
            this.Reg1Label = new System.Windows.Forms.Label();
            this.Reg1TextBox = new System.Windows.Forms.TextBox();
            this.Reg2Label = new System.Windows.Forms.Label();
            this.Reg2TextBox = new System.Windows.Forms.TextBox();
            this.Reg3Label = new System.Windows.Forms.Label();
            this.Reg3TextBox = new System.Windows.Forms.TextBox();
            this.Reg4Label = new System.Windows.Forms.Label();
            this.Reg4TextBox = new System.Windows.Forms.TextBox();
            this.Reg5Label = new System.Windows.Forms.Label();
            this.Reg5TextBox = new System.Windows.Forms.TextBox();
            this.RefButton = new System.Windows.Forms.Button();
            this.SetAsDefaultRegButton = new System.Windows.Forms.Button();
            this.ForceLoadRegButton = new System.Windows.Forms.Button();
            this.LoadDefRegButton = new System.Windows.Forms.Button();
            this.AvaibleCOMsComBox = new System.Windows.Forms.ComboBox();
            this.WriteR0Button = new System.Windows.Forms.Button();
            this.WriteR1Button = new System.Windows.Forms.Button();
            this.WriteR2Button = new System.Windows.Forms.Button();
            this.WriteR3Button = new System.Windows.Forms.Button();
            this.WriteR4Button = new System.Windows.Forms.Button();
            this.WriteR5Button = new System.Windows.Forms.Button();
            this.RegistersTabControl = new System.Windows.Forms.TabControl();
            this.RegistersPage = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ReadedVCOValueTextBox = new System.Windows.Forms.TextBox();
            this.ReadedADCValueTextBox = new System.Windows.Forms.TextBox();
            this.GetCurrentVCOButton = new System.Windows.Forms.Button();
            this.GetADCValueButton = new System.Windows.Forms.Button();
            this.ADCModeComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.genericControlsGroupBox = new System.Windows.Forms.GroupBox();
            this.MuxPinModeCombobox = new System.Windows.Forms.ComboBox();
            this.MuxPinModeLabel = new System.Windows.Forms.Label();
            this.Reg4DoubleBufferedCheckBox = new System.Windows.Forms.CheckBox();
            this.CalcCDIVCheckBox = new System.Windows.Forms.CheckBox();
            this.RandNCountersResetCheckBox = new System.Windows.Forms.CheckBox();
            this.IntNAutoModeWhenF0CheckBox = new System.Windows.Forms.CheckBox();
            this.ShutDownGroupBox = new System.Windows.Forms.GroupBox();
            this.PllShutDownCheckBox = new System.Windows.Forms.CheckBox();
            this.VcoShutDownCheckBox = new System.Windows.Forms.CheckBox();
            this.PloPowerDownCheckBox = new System.Windows.Forms.CheckBox();
            this.VcoLdoShutDownCheckBox = new System.Windows.Forms.CheckBox();
            this.VcoDividerShutdownCheckBox = new System.Windows.Forms.CheckBox();
            this.RefInputShutdownCheckBox = new System.Windows.Forms.CheckBox();
            this.VcoSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.ShowDelayLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.delayLabel = new System.Windows.Forms.Label();
            this.AutoCDIVCalcCheckBox = new System.Windows.Forms.CheckBox();
            this.DelayToPreventFlickeringCheckBox = new System.Windows.Forms.CheckBox();
            this.MuteUntilLockDetectCheckBox = new System.Windows.Forms.CheckBox();
            this.VASTempCompCheckBox = new System.Windows.Forms.CheckBox();
            this.AutoVcoSelectionCheckBox = new System.Windows.Forms.CheckBox();
            this.BandSelClockDivNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.DelayInputNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.ClockDividerNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.ManualVCOSelectNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.BandSelectClockDivLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ManualVcoLabel = new System.Windows.Forms.Label();
            this.PhaseDetectorGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LDPrecisionLabel = new System.Windows.Forms.Label();
            this.PfdPolarity = new System.Windows.Forms.ComboBox();
            this.LDPrecisionComboBox = new System.Windows.Forms.ComboBox();
            this.RegistersControlsGroupBox = new System.Windows.Forms.GroupBox();
            this.LoadFromFileButton = new System.Windows.Forms.Button();
            this.SaveIntoFileButton = new System.Windows.Forms.Button();
            this.MoveRegsIntoMemsGroupBox = new System.Windows.Forms.GroupBox();
            this.ExportIntoMem1Button = new System.Windows.Forms.Button();
            this.ExportIntoMem2Button = new System.Windows.Forms.Button();
            this.ExportIntoMem3Button = new System.Windows.Forms.Button();
            this.ExportIntoMem4Button = new System.Windows.Forms.Button();
            this.ChargePumpGroupBox = new System.Windows.Forms.GroupBox();
            this.PhaseAdjustmentModeCheckbox = new System.Windows.Forms.CheckBox();
            this.CPCycleSlipCheckBox = new System.Windows.Forms.CheckBox();
            this.CPTriStateOutCheckBox = new System.Windows.Forms.CheckBox();
            this.CPFastLockCheckBox = new System.Windows.Forms.CheckBox();
            this.RSetTextBox = new System.Windows.Forms.TextBox();
            this.CPTestComboBox = new System.Windows.Forms.ComboBox();
            this.CPLinearityComboBox = new System.Windows.Forms.ComboBox();
            this.CPTestLabel = new System.Windows.Forms.Label();
            this.CPCurrentComboBox = new System.Windows.Forms.ComboBox();
            this.CPLinearityLabel = new System.Windows.Forms.Label();
            this.RSetLabel = new System.Windows.Forms.Label();
            this.CPCurrentLabel = new System.Windows.Forms.Label();
            this.OutputControlsGroupBox = new System.Windows.Forms.GroupBox();
            this.RF_A_EN_Label = new System.Windows.Forms.Label();
            this.RF_A_PWR_Label = new System.Windows.Forms.Label();
            this.RF_B_EN_Label = new System.Windows.Forms.Label();
            this.RF_B_PWR_Label = new System.Windows.Forms.Label();
            this.OutBPwr_ComboBox = new System.Windows.Forms.ComboBox();
            this.OutAEn_ComboBox = new System.Windows.Forms.ComboBox();
            this.OutAPwr_ComboBox = new System.Windows.Forms.ComboBox();
            this.OutBEn_ComboBox = new System.Windows.Forms.ComboBox();
            this.OutInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.fOutALabel = new System.Windows.Forms.Label();
            this.MHzLabel1 = new System.Windows.Forms.Label();
            this.MHzLabel5 = new System.Windows.Forms.Label();
            this.fVcoLabel = new System.Windows.Forms.Label();
            this.MHzLabel2 = new System.Windows.Forms.Label();
            this.fOutBLabel = new System.Windows.Forms.Label();
            this.fOutAScreenLabel = new System.Windows.Forms.Label();
            this.fOutBScreenLabel = new System.Windows.Forms.Label();
            this.fVcoScreenLabel = new System.Windows.Forms.Label();
            this.FreqControlGroupBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.RFoutBPathLabel = new System.Windows.Forms.Label();
            this.SDNoiseModeLabel = new System.Windows.Forms.Label();
            this.LDfuncLabel = new System.Windows.Forms.Label();
            this.ADivComboBox = new System.Windows.Forms.ComboBox();
            this.FracNLabel = new System.Windows.Forms.Label();
            this.ModeIntFracComboBox = new System.Windows.Forms.ComboBox();
            this.SigmaDeltaNoiseModeComboBox = new System.Windows.Forms.ComboBox();
            this.FBPathComboBox = new System.Windows.Forms.ComboBox();
            this.RFoutBPathComboBox = new System.Windows.Forms.ComboBox();
            this.LDFuncComboBox = new System.Windows.Forms.ComboBox();
            this.AutoLDFuncCheckBox = new System.Windows.Forms.CheckBox();
            this.IntNLabel = new System.Windows.Forms.Label();
            this.ModeIntFracLabel = new System.Windows.Forms.Label();
            this.ModLabel = new System.Windows.Forms.Label();
            this.ADivLabel = new System.Windows.Forms.Label();
            this.PhasePLabel = new System.Windows.Forms.Label();
            this.IntNNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.ModNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.FracNNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.PhasePNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.RefFreqGroupBox = new System.Windows.Forms.GroupBox();
            this.LDSpeedAdjLabel = new System.Windows.Forms.Label();
            this.RDivUpDown = new System.Windows.Forms.NumericUpDown();
            this.LDSpeedAdjComboBox = new System.Windows.Forms.ComboBox();
            this.RefFTextBox = new System.Windows.Forms.TextBox();
            this.DivideBy2CheckBox = new System.Windows.Forms.CheckBox();
            this.AutoLDSpeedAdjCheckBox = new System.Windows.Forms.CheckBox();
            this.RefDoublerCheckBox = new System.Windows.Forms.CheckBox();
            this.InternalLabel = new System.Windows.Forms.Label();
            this.RefFLabel = new System.Windows.Forms.Label();
            this.fPfdLabel = new System.Windows.Forms.Label();
            this.RDivLabel = new System.Windows.Forms.Label();
            this.MHzLabel4 = new System.Windows.Forms.Label();
            this.MHzLabel3 = new System.Windows.Forms.Label();
            this.pfdFreqLabel = new System.Windows.Forms.Label();
            this.RegistersMemoryPage = new System.Windows.Forms.TabPage();
            this.SynthOutputsInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Mem1Freq2ShowLabel = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.Mem1Freq1ShowLabel = new System.Windows.Forms.Label();
            this.FreqOut2MemLabel = new System.Windows.Forms.Label();
            this.Mem4Freq2ShowLabel = new System.Windows.Forms.Label();
            this.FreqOut1MemLabel = new System.Windows.Forms.Label();
            this.Mem4Freq1ShowLabel = new System.Windows.Forms.Label();
            this.MemPwrALabel = new System.Windows.Forms.Label();
            this.Mem3Freq2ShowLabel = new System.Windows.Forms.Label();
            this.Mem1PwrAShowLabel = new System.Windows.Forms.Label();
            this.Mem3Freq1ShowLabel = new System.Windows.Forms.Label();
            this.Mem1PwrBShowLabel = new System.Windows.Forms.Label();
            this.Mem2Freq2ShowLabel = new System.Windows.Forms.Label();
            this.Mem2PwrAShowLabel = new System.Windows.Forms.Label();
            this.Mem2Freq1ShowLabel = new System.Windows.Forms.Label();
            this.Mem3PwrAShowLabel = new System.Windows.Forms.Label();
            this.Mem4PwrAShowLabel = new System.Windows.Forms.Label();
            this.Mem2PwrBShowLabel = new System.Windows.Forms.Label();
            this.Mem3PwrBShowLabel = new System.Windows.Forms.Label();
            this.Mem4PwrBShowLabel = new System.Windows.Forms.Label();
            this.MemPwrBLabel = new System.Windows.Forms.Label();
            this.SyntModuleControlsGroupBox = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Mem4ActOut1ShowLabel = new System.Windows.Forms.Label();
            this.MemoryOutput1Label = new System.Windows.Forms.Label();
            this.MemoryOutput2Label = new System.Windows.Forms.Label();
            this.MemoryRefLabel = new System.Windows.Forms.Label();
            this.Mem1ActOut1ShowLabel = new System.Windows.Forms.Label();
            this.Mem1ActOut2ShowLabel = new System.Windows.Forms.Label();
            this.Mem2ActOut1ShowLabel = new System.Windows.Forms.Label();
            this.Mem3ActOut1ShowLabel = new System.Windows.Forms.Label();
            this.Mem2ActOut2ShowLabel = new System.Windows.Forms.Label();
            this.Mem4RefShowLabel = new System.Windows.Forms.Label();
            this.Mem3ActOut2ShowLabel = new System.Windows.Forms.Label();
            this.Mem3RefShowLabel = new System.Windows.Forms.Label();
            this.Mem4ActOut2ShowLabel = new System.Windows.Forms.Label();
            this.Mem2RefShowLabel = new System.Windows.Forms.Label();
            this.Mem1RefShowLabel = new System.Windows.Forms.Label();
            this.RegMemoryGroupBox = new System.Windows.Forms.GroupBox();
            this.SavReg0Label = new System.Windows.Forms.Label();
            this.R5M1 = new System.Windows.Forms.TextBox();
            this.SavReg5Label = new System.Windows.Forms.Label();
            this.R5M2 = new System.Windows.Forms.TextBox();
            this.R4M1 = new System.Windows.Forms.TextBox();
            this.R5M3 = new System.Windows.Forms.TextBox();
            this.R4M2 = new System.Windows.Forms.TextBox();
            this.R5M4 = new System.Windows.Forms.TextBox();
            this.R4M3 = new System.Windows.Forms.TextBox();
            this.R4M4 = new System.Windows.Forms.TextBox();
            this.SavReg4Label = new System.Windows.Forms.Label();
            this.R3M1 = new System.Windows.Forms.TextBox();
            this.R3M2 = new System.Windows.Forms.TextBox();
            this.R3M3 = new System.Windows.Forms.TextBox();
            this.R3M4 = new System.Windows.Forms.TextBox();
            this.R2M1 = new System.Windows.Forms.TextBox();
            this.R2M2 = new System.Windows.Forms.TextBox();
            this.R2M3 = new System.Windows.Forms.TextBox();
            this.R2M4 = new System.Windows.Forms.TextBox();
            this.SavReg2Label = new System.Windows.Forms.Label();
            this.R1M1 = new System.Windows.Forms.TextBox();
            this.SavReg3Label = new System.Windows.Forms.Label();
            this.R1M2 = new System.Windows.Forms.TextBox();
            this.R1M3 = new System.Windows.Forms.TextBox();
            this.R1M4 = new System.Windows.Forms.TextBox();
            this.SavReg1Label = new System.Windows.Forms.Label();
            this.R0M4 = new System.Windows.Forms.TextBox();
            this.Mem1Label = new System.Windows.Forms.Label();
            this.Mem2Label = new System.Windows.Forms.Label();
            this.Mem3Label = new System.Windows.Forms.Label();
            this.Mem4Label = new System.Windows.Forms.Label();
            this.R0M3 = new System.Windows.Forms.TextBox();
            this.R0M1 = new System.Windows.Forms.TextBox();
            this.R0M2 = new System.Windows.Forms.TextBox();
            this.ImportMem4Button = new System.Windows.Forms.Button();
            this.ImportMem3Button = new System.Windows.Forms.Button();
            this.ImportMem2Button = new System.Windows.Forms.Button();
            this.ImportMem1Button = new System.Windows.Forms.Button();
            this.MemLoadFromFileButton = new System.Windows.Forms.Button();
            this.MemSaveIntoFileButton = new System.Windows.Forms.Button();
            this.LoadRegMemory = new System.Windows.Forms.Button();
            this.SaveRegMemory = new System.Windows.Forms.Button();
            this.VcoCalibrationTabPage = new System.Windows.Forms.TabPage();
            this.CurrentVcoShowLabel = new System.Windows.Forms.Label();
            this.ActFreqShowLabel = new System.Windows.Forms.Label();
            this.VcoFreqMaxTextBox = new System.Windows.Forms.TextBox();
            this.CurrentVcoLabel = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.ActFreqLabel = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.VcoFreqMaxLabel = new System.Windows.Forms.Label();
            this.VcoFreqMinTextBox = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.VcoFreqMinLabel = new System.Windows.Forms.Label();
            this.AbortCallibrationButton = new System.Windows.Forms.Button();
            this.PerformVcoCalibrationButton = new System.Windows.Forms.Button();
            this.FreqStepTextBox = new System.Windows.Forms.TextBox();
            this.MHzLable = new System.Windows.Forms.Label();
            this.FreqStepLabel = new System.Windows.Forms.Label();
            this.RegistersGroupBox = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.InputFreqTextBox = new System.Windows.Forms.TextBox();
            this.MHzLabel6 = new System.Windows.Forms.Label();
            this.DeltaShowLabel = new System.Windows.Forms.Label();
            this.HzLabel = new System.Windows.Forms.Label();
            this.DeltaLabel = new System.Windows.Forms.Label();
            this.InputFreqLabel = new System.Windows.Forms.Label();
            this.DirectFreqContrGroupBox = new System.Windows.Forms.GroupBox();
            this.MHzLabel7 = new System.Windows.Forms.Label();
            this.CalcFreqShowLabel = new System.Windows.Forms.Label();
            this.CalcFreqLabel = new System.Windows.Forms.Label();
            this.MHzLabel9 = new System.Windows.Forms.Label();
            this.MHzLabel8 = new System.Windows.Forms.Label();
            this.FreqAtOut2ShowLabel = new System.Windows.Forms.Label();
            this.FreqAtOut1ShowLabel = new System.Windows.Forms.Label();
            this.ActOut2ShowLabel = new System.Windows.Forms.Label();
            this.FreqAtOut2Label = new System.Windows.Forms.Label();
            this.ActOut1ShowLabel = new System.Windows.Forms.Label();
            this.FreqAtOut1Label = new System.Windows.Forms.Label();
            this.ActiveOut2Label = new System.Windows.Forms.Label();
            this.ActiveOut1Label = new System.Windows.Forms.Label();
            this.ConsoleRichTextBox = new System.Windows.Forms.RichTextBox();
            this.SynthModuleInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.IntExtShowLabel = new System.Windows.Forms.Label();
            this.RefSignalLabel = new System.Windows.Forms.Label();
            this.LedOffPicBox = new System.Windows.Forms.PictureBox();
            this.LedOnPicBox = new System.Windows.Forms.PictureBox();
            this.RegistersTabControl.SuspendLayout();
            this.RegistersPage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.genericControlsGroupBox.SuspendLayout();
            this.ShutDownGroupBox.SuspendLayout();
            this.VcoSettingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BandSelClockDivNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DelayInputNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClockDividerNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ManualVCOSelectNumericUpDown)).BeginInit();
            this.PhaseDetectorGroupBox.SuspendLayout();
            this.RegistersControlsGroupBox.SuspendLayout();
            this.MoveRegsIntoMemsGroupBox.SuspendLayout();
            this.ChargePumpGroupBox.SuspendLayout();
            this.OutputControlsGroupBox.SuspendLayout();
            this.OutInfoGroupBox.SuspendLayout();
            this.FreqControlGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IntNNumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModNumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FracNNumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PhasePNumericUpDown)).BeginInit();
            this.RefFreqGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RDivUpDown)).BeginInit();
            this.RegistersMemoryPage.SuspendLayout();
            this.SynthOutputsInfoGroupBox.SuspendLayout();
            this.SyntModuleControlsGroupBox.SuspendLayout();
            this.RegMemoryGroupBox.SuspendLayout();
            this.VcoCalibrationTabPage.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.DirectFreqContrGroupBox.SuspendLayout();
            this.SynthModuleInfoGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LedOffPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LedOnPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // PortButton
            // 
            this.PortButton.AccessibleDescription = "";
            this.PortButton.Location = new System.Drawing.Point(16, 9);
            this.PortButton.Name = "PortButton";
            this.PortButton.Size = new System.Drawing.Size(75, 23);
            this.PortButton.TabIndex = 0;
            this.PortButton.Text = "Open Port";
            this.PortButton.UseVisualStyleBackColor = true;
            this.PortButton.Click += new System.EventHandler(this.PortButton_Click);
            // 
            // Out1Button
            // 
            this.Out1Button.Location = new System.Drawing.Point(16, 39);
            this.Out1Button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Out1Button.Name = "Out1Button";
            this.Out1Button.Size = new System.Drawing.Size(75, 23);
            this.Out1Button.TabIndex = 3;
            this.Out1Button.Text = "Out 1 Off";
            this.Out1Button.UseVisualStyleBackColor = true;
            this.Out1Button.Click += new System.EventHandler(this.Out1Button_Click);
            // 
            // Out2Button
            // 
            this.Out2Button.Location = new System.Drawing.Point(96, 39);
            this.Out2Button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Out2Button.Name = "Out2Button";
            this.Out2Button.Size = new System.Drawing.Size(75, 23);
            this.Out2Button.TabIndex = 4;
            this.Out2Button.Text = "Out 2 Off";
            this.Out2Button.UseVisualStyleBackColor = true;
            this.Out2Button.Click += new System.EventHandler(this.Out2Button_Click);
            // 
            // PloInitButton
            // 
            this.PloInitButton.Location = new System.Drawing.Point(176, 9);
            this.PloInitButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PloInitButton.Name = "PloInitButton";
            this.PloInitButton.Size = new System.Drawing.Size(75, 23);
            this.PloInitButton.TabIndex = 2;
            this.PloInitButton.Text = "PLO Init";
            this.PloInitButton.UseVisualStyleBackColor = true;
            this.PloInitButton.Click += new System.EventHandler(this.PloInitButton_Click);
            // 
            // Reg0TextBox
            // 
            this.Reg0TextBox.BackColor = System.Drawing.Color.White;
            this.Reg0TextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Reg0TextBox.Location = new System.Drawing.Point(66, 16);
            this.Reg0TextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Reg0TextBox.MaxLength = 8;
            this.Reg0TextBox.Name = "Reg0TextBox";
            this.Reg0TextBox.Size = new System.Drawing.Size(67, 20);
            this.Reg0TextBox.TabIndex = 0;
            this.Reg0TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Reg0TextBox.TextChanged += new System.EventHandler(this.RegisterTextBox_TextChanged);
            this.Reg0TextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RegisterTextBox_KeyDown);
            this.Reg0TextBox.LostFocus += new System.EventHandler(this.RegisterTextBox_LostFocus);
            // 
            // Reg0Label
            // 
            this.Reg0Label.AutoSize = true;
            this.Reg0Label.Location = new System.Drawing.Point(7, 19);
            this.Reg0Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Reg0Label.Name = "Reg0Label";
            this.Reg0Label.Size = new System.Drawing.Size(58, 13);
            this.Reg0Label.TabIndex = 4;
            this.Reg0Label.Text = "Register 0:";
            // 
            // Reg1Label
            // 
            this.Reg1Label.AutoSize = true;
            this.Reg1Label.Location = new System.Drawing.Point(7, 42);
            this.Reg1Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Reg1Label.Name = "Reg1Label";
            this.Reg1Label.Size = new System.Drawing.Size(58, 13);
            this.Reg1Label.TabIndex = 5;
            this.Reg1Label.Text = "Register 1:";
            // 
            // Reg1TextBox
            // 
            this.Reg1TextBox.BackColor = System.Drawing.Color.White;
            this.Reg1TextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Reg1TextBox.Location = new System.Drawing.Point(66, 39);
            this.Reg1TextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Reg1TextBox.MaxLength = 8;
            this.Reg1TextBox.Name = "Reg1TextBox";
            this.Reg1TextBox.Size = new System.Drawing.Size(67, 20);
            this.Reg1TextBox.TabIndex = 2;
            this.Reg1TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Reg1TextBox.TextChanged += new System.EventHandler(this.RegisterTextBox_TextChanged);
            this.Reg1TextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RegisterTextBox_KeyDown);
            this.Reg1TextBox.LostFocus += new System.EventHandler(this.RegisterTextBox_LostFocus);
            // 
            // Reg2Label
            // 
            this.Reg2Label.AutoSize = true;
            this.Reg2Label.Location = new System.Drawing.Point(7, 64);
            this.Reg2Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Reg2Label.Name = "Reg2Label";
            this.Reg2Label.Size = new System.Drawing.Size(58, 13);
            this.Reg2Label.TabIndex = 7;
            this.Reg2Label.Text = "Register 2:";
            // 
            // Reg2TextBox
            // 
            this.Reg2TextBox.BackColor = System.Drawing.Color.White;
            this.Reg2TextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Reg2TextBox.Location = new System.Drawing.Point(66, 62);
            this.Reg2TextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Reg2TextBox.MaxLength = 8;
            this.Reg2TextBox.Name = "Reg2TextBox";
            this.Reg2TextBox.Size = new System.Drawing.Size(67, 20);
            this.Reg2TextBox.TabIndex = 4;
            this.Reg2TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Reg2TextBox.TextChanged += new System.EventHandler(this.RegisterTextBox_TextChanged);
            this.Reg2TextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RegisterTextBox_KeyDown);
            this.Reg2TextBox.LostFocus += new System.EventHandler(this.RegisterTextBox_LostFocus);
            // 
            // Reg3Label
            // 
            this.Reg3Label.AutoSize = true;
            this.Reg3Label.Location = new System.Drawing.Point(7, 87);
            this.Reg3Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Reg3Label.Name = "Reg3Label";
            this.Reg3Label.Size = new System.Drawing.Size(58, 13);
            this.Reg3Label.TabIndex = 7;
            this.Reg3Label.Text = "Register 3:";
            // 
            // Reg3TextBox
            // 
            this.Reg3TextBox.BackColor = System.Drawing.Color.White;
            this.Reg3TextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Reg3TextBox.Location = new System.Drawing.Point(66, 84);
            this.Reg3TextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Reg3TextBox.MaxLength = 8;
            this.Reg3TextBox.Name = "Reg3TextBox";
            this.Reg3TextBox.Size = new System.Drawing.Size(67, 20);
            this.Reg3TextBox.TabIndex = 6;
            this.Reg3TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Reg3TextBox.TextChanged += new System.EventHandler(this.RegisterTextBox_TextChanged);
            this.Reg3TextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RegisterTextBox_KeyDown);
            this.Reg3TextBox.LostFocus += new System.EventHandler(this.RegisterTextBox_LostFocus);
            // 
            // Reg4Label
            // 
            this.Reg4Label.AutoSize = true;
            this.Reg4Label.Location = new System.Drawing.Point(7, 108);
            this.Reg4Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Reg4Label.Name = "Reg4Label";
            this.Reg4Label.Size = new System.Drawing.Size(58, 13);
            this.Reg4Label.TabIndex = 7;
            this.Reg4Label.Text = "Register 4:";
            // 
            // Reg4TextBox
            // 
            this.Reg4TextBox.BackColor = System.Drawing.Color.White;
            this.Reg4TextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Reg4TextBox.Location = new System.Drawing.Point(66, 106);
            this.Reg4TextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Reg4TextBox.MaxLength = 8;
            this.Reg4TextBox.Name = "Reg4TextBox";
            this.Reg4TextBox.Size = new System.Drawing.Size(67, 20);
            this.Reg4TextBox.TabIndex = 8;
            this.Reg4TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Reg4TextBox.TextChanged += new System.EventHandler(this.RegisterTextBox_TextChanged);
            this.Reg4TextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RegisterTextBox_KeyDown);
            this.Reg4TextBox.LostFocus += new System.EventHandler(this.RegisterTextBox_LostFocus);
            // 
            // Reg5Label
            // 
            this.Reg5Label.AutoSize = true;
            this.Reg5Label.Location = new System.Drawing.Point(7, 131);
            this.Reg5Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Reg5Label.Name = "Reg5Label";
            this.Reg5Label.Size = new System.Drawing.Size(58, 13);
            this.Reg5Label.TabIndex = 7;
            this.Reg5Label.Text = "Register 5:";
            // 
            // Reg5TextBox
            // 
            this.Reg5TextBox.BackColor = System.Drawing.Color.White;
            this.Reg5TextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Reg5TextBox.Location = new System.Drawing.Point(66, 129);
            this.Reg5TextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Reg5TextBox.MaxLength = 8;
            this.Reg5TextBox.Name = "Reg5TextBox";
            this.Reg5TextBox.Size = new System.Drawing.Size(67, 20);
            this.Reg5TextBox.TabIndex = 10;
            this.Reg5TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Reg5TextBox.TextChanged += new System.EventHandler(this.RegisterTextBox_TextChanged);
            this.Reg5TextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RegisterTextBox_KeyDown);
            this.Reg5TextBox.LostFocus += new System.EventHandler(this.RegisterTextBox_LostFocus);
            // 
            // RefButton
            // 
            this.RefButton.Location = new System.Drawing.Point(176, 39);
            this.RefButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RefButton.Name = "RefButton";
            this.RefButton.Size = new System.Drawing.Size(75, 23);
            this.RefButton.TabIndex = 5;
            this.RefButton.Text = "Ext Ref";
            this.RefButton.UseVisualStyleBackColor = true;
            this.RefButton.Click += new System.EventHandler(this.RefButton_Click);
            // 
            // SetAsDefaultRegButton
            // 
            this.SetAsDefaultRegButton.Location = new System.Drawing.Point(206, 17);
            this.SetAsDefaultRegButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SetAsDefaultRegButton.Name = "SetAsDefaultRegButton";
            this.SetAsDefaultRegButton.Size = new System.Drawing.Size(89, 19);
            this.SetAsDefaultRegButton.TabIndex = 12;
            this.SetAsDefaultRegButton.Text = "Set As Def";
            this.SetAsDefaultRegButton.UseVisualStyleBackColor = true;
            this.SetAsDefaultRegButton.Click += new System.EventHandler(this.SetAsDefaultRegButton_Click);
            // 
            // ForceLoadRegButton
            // 
            this.ForceLoadRegButton.Location = new System.Drawing.Point(206, 128);
            this.ForceLoadRegButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ForceLoadRegButton.Name = "ForceLoadRegButton";
            this.ForceLoadRegButton.Size = new System.Drawing.Size(89, 19);
            this.ForceLoadRegButton.TabIndex = 16;
            this.ForceLoadRegButton.Text = "Force Load All";
            this.ForceLoadRegButton.UseVisualStyleBackColor = true;
            this.ForceLoadRegButton.Click += new System.EventHandler(this.ForceLoadRegButton_Click);
            // 
            // LoadDefRegButton
            // 
            this.LoadDefRegButton.Location = new System.Drawing.Point(206, 40);
            this.LoadDefRegButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LoadDefRegButton.Name = "LoadDefRegButton";
            this.LoadDefRegButton.Size = new System.Drawing.Size(89, 19);
            this.LoadDefRegButton.TabIndex = 13;
            this.LoadDefRegButton.Text = "Load Def";
            this.LoadDefRegButton.UseVisualStyleBackColor = true;
            this.LoadDefRegButton.Click += new System.EventHandler(this.LoadDefRegButton_Click);
            // 
            // AvaibleCOMsComBox
            // 
            this.AvaibleCOMsComBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AvaibleCOMsComBox.FormattingEnabled = true;
            this.AvaibleCOMsComBox.Location = new System.Drawing.Point(97, 9);
            this.AvaibleCOMsComBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AvaibleCOMsComBox.Name = "AvaibleCOMsComBox";
            this.AvaibleCOMsComBox.Size = new System.Drawing.Size(75, 21);
            this.AvaibleCOMsComBox.TabIndex = 1;
            this.AvaibleCOMsComBox.DropDown += new System.EventHandler(this.AvaibleCOMsComBox_DropDown);
            this.AvaibleCOMsComBox.SelectedValueChanged += new System.EventHandler(this.AvaibleCOMsComBox_SelectedIndexChanged);
            // 
            // WriteR0Button
            // 
            this.WriteR0Button.Location = new System.Drawing.Point(137, 16);
            this.WriteR0Button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.WriteR0Button.Name = "WriteR0Button";
            this.WriteR0Button.Size = new System.Drawing.Size(60, 19);
            this.WriteR0Button.TabIndex = 1;
            this.WriteR0Button.Text = "Write R0";
            this.WriteR0Button.UseVisualStyleBackColor = true;
            this.WriteR0Button.Click += new System.EventHandler(this.WriteRegisterButton_Click);
            // 
            // WriteR1Button
            // 
            this.WriteR1Button.Location = new System.Drawing.Point(137, 39);
            this.WriteR1Button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.WriteR1Button.Name = "WriteR1Button";
            this.WriteR1Button.Size = new System.Drawing.Size(60, 19);
            this.WriteR1Button.TabIndex = 3;
            this.WriteR1Button.Text = "Write R1";
            this.WriteR1Button.UseVisualStyleBackColor = true;
            this.WriteR1Button.Click += new System.EventHandler(this.WriteRegisterButton_Click);
            // 
            // WriteR2Button
            // 
            this.WriteR2Button.Location = new System.Drawing.Point(137, 62);
            this.WriteR2Button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.WriteR2Button.Name = "WriteR2Button";
            this.WriteR2Button.Size = new System.Drawing.Size(60, 19);
            this.WriteR2Button.TabIndex = 5;
            this.WriteR2Button.Text = "Write R2";
            this.WriteR2Button.UseVisualStyleBackColor = true;
            this.WriteR2Button.Click += new System.EventHandler(this.WriteRegisterButton_Click);
            // 
            // WriteR3Button
            // 
            this.WriteR3Button.Location = new System.Drawing.Point(137, 84);
            this.WriteR3Button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.WriteR3Button.Name = "WriteR3Button";
            this.WriteR3Button.Size = new System.Drawing.Size(60, 19);
            this.WriteR3Button.TabIndex = 7;
            this.WriteR3Button.Text = "Write R3";
            this.WriteR3Button.UseVisualStyleBackColor = true;
            this.WriteR3Button.Click += new System.EventHandler(this.WriteRegisterButton_Click);
            // 
            // WriteR4Button
            // 
            this.WriteR4Button.Location = new System.Drawing.Point(137, 106);
            this.WriteR4Button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.WriteR4Button.Name = "WriteR4Button";
            this.WriteR4Button.Size = new System.Drawing.Size(60, 19);
            this.WriteR4Button.TabIndex = 9;
            this.WriteR4Button.Text = "Write R4";
            this.WriteR4Button.UseVisualStyleBackColor = true;
            this.WriteR4Button.Click += new System.EventHandler(this.WriteRegisterButton_Click);
            // 
            // WriteR5Button
            // 
            this.WriteR5Button.Location = new System.Drawing.Point(137, 129);
            this.WriteR5Button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.WriteR5Button.Name = "WriteR5Button";
            this.WriteR5Button.Size = new System.Drawing.Size(60, 19);
            this.WriteR5Button.TabIndex = 11;
            this.WriteR5Button.Text = "Write R5";
            this.WriteR5Button.UseVisualStyleBackColor = true;
            this.WriteR5Button.Click += new System.EventHandler(this.WriteRegisterButton_Click);
            // 
            // RegistersTabControl
            // 
            this.RegistersTabControl.Controls.Add(this.RegistersPage);
            this.RegistersTabControl.Controls.Add(this.RegistersMemoryPage);
            this.RegistersTabControl.Controls.Add(this.VcoCalibrationTabPage);
            this.RegistersTabControl.Location = new System.Drawing.Point(264, 19);
            this.RegistersTabControl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RegistersTabControl.Name = "RegistersTabControl";
            this.RegistersTabControl.SelectedIndex = 0;
            this.RegistersTabControl.Size = new System.Drawing.Size(538, 688);
            this.RegistersTabControl.TabIndex = 8;
            // 
            // RegistersPage
            // 
            this.RegistersPage.Controls.Add(this.groupBox1);
            this.RegistersPage.Controls.Add(this.genericControlsGroupBox);
            this.RegistersPage.Controls.Add(this.ShutDownGroupBox);
            this.RegistersPage.Controls.Add(this.VcoSettingsGroupBox);
            this.RegistersPage.Controls.Add(this.PhaseDetectorGroupBox);
            this.RegistersPage.Controls.Add(this.RegistersControlsGroupBox);
            this.RegistersPage.Controls.Add(this.MoveRegsIntoMemsGroupBox);
            this.RegistersPage.Controls.Add(this.ChargePumpGroupBox);
            this.RegistersPage.Controls.Add(this.OutputControlsGroupBox);
            this.RegistersPage.Controls.Add(this.OutInfoGroupBox);
            this.RegistersPage.Controls.Add(this.FreqControlGroupBox);
            this.RegistersPage.Controls.Add(this.RefFreqGroupBox);
            this.RegistersPage.Location = new System.Drawing.Point(4, 22);
            this.RegistersPage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RegistersPage.Name = "RegistersPage";
            this.RegistersPage.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RegistersPage.Size = new System.Drawing.Size(530, 662);
            this.RegistersPage.TabIndex = 0;
            this.RegistersPage.Text = "Direct control of registers";
            this.RegistersPage.UseVisualStyleBackColor = true;
            this.RegistersPage.Click += new System.EventHandler(this.RegistersPage_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ReadedVCOValueTextBox);
            this.groupBox1.Controls.Add(this.ReadedADCValueTextBox);
            this.groupBox1.Controls.Add(this.GetCurrentVCOButton);
            this.groupBox1.Controls.Add(this.GetADCValueButton);
            this.groupBox1.Controls.Add(this.ADCModeComboBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(403, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(120, 152);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Register 6 control";
            // 
            // ReadedVCOValueTextBox
            // 
            this.ReadedVCOValueTextBox.BackColor = System.Drawing.Color.White;
            this.ReadedVCOValueTextBox.Location = new System.Drawing.Point(10, 131);
            this.ReadedVCOValueTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ReadedVCOValueTextBox.MaxLength = 17;
            this.ReadedVCOValueTextBox.Name = "ReadedVCOValueTextBox";
            this.ReadedVCOValueTextBox.Size = new System.Drawing.Size(106, 20);
            this.ReadedVCOValueTextBox.TabIndex = 4;
            this.ReadedVCOValueTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ReadedADCValueTextBox
            // 
            this.ReadedADCValueTextBox.BackColor = System.Drawing.Color.White;
            this.ReadedADCValueTextBox.Location = new System.Drawing.Point(10, 87);
            this.ReadedADCValueTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ReadedADCValueTextBox.MaxLength = 17;
            this.ReadedADCValueTextBox.Name = "ReadedADCValueTextBox";
            this.ReadedADCValueTextBox.Size = new System.Drawing.Size(106, 20);
            this.ReadedADCValueTextBox.TabIndex = 2;
            this.ReadedADCValueTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GetCurrentVCOButton
            // 
            this.GetCurrentVCOButton.Location = new System.Drawing.Point(10, 108);
            this.GetCurrentVCOButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.GetCurrentVCOButton.Name = "GetCurrentVCOButton";
            this.GetCurrentVCOButton.Size = new System.Drawing.Size(106, 19);
            this.GetCurrentVCOButton.TabIndex = 3;
            this.GetCurrentVCOButton.Text = "Get current VCO";
            this.GetCurrentVCOButton.UseVisualStyleBackColor = true;
            this.GetCurrentVCOButton.Click += new System.EventHandler(this.GetCurrentVCOButton_Click);
            // 
            // GetADCValueButton
            // 
            this.GetADCValueButton.Location = new System.Drawing.Point(10, 64);
            this.GetADCValueButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.GetADCValueButton.Name = "GetADCValueButton";
            this.GetADCValueButton.Size = new System.Drawing.Size(105, 19);
            this.GetADCValueButton.TabIndex = 1;
            this.GetADCValueButton.Text = "Get ADC Value";
            this.GetADCValueButton.UseVisualStyleBackColor = true;
            this.GetADCValueButton.Click += new System.EventHandler(this.GetADCValueButton_Click);
            // 
            // ADCModeComboBox
            // 
            this.ADCModeComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ADCModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ADCModeComboBox.FormattingEnabled = true;
            this.ADCModeComboBox.Items.AddRange(new object[] {
            "Temperature",
            "Tune pin"});
            this.ADCModeComboBox.Location = new System.Drawing.Point(10, 37);
            this.ADCModeComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ADCModeComboBox.Name = "ADCModeComboBox";
            this.ADCModeComboBox.Size = new System.Drawing.Size(106, 21);
            this.ADCModeComboBox.TabIndex = 0;
            this.ADCModeComboBox.SelectedIndexChanged += new System.EventHandler(this.ADCModeComboBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(3, 21);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 14);
            this.label6.TabIndex = 17;
            this.label6.Text = "ADC Mode:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // genericControlsGroupBox
            // 
            this.genericControlsGroupBox.Controls.Add(this.MuxPinModeCombobox);
            this.genericControlsGroupBox.Controls.Add(this.MuxPinModeLabel);
            this.genericControlsGroupBox.Controls.Add(this.Reg4DoubleBufferedCheckBox);
            this.genericControlsGroupBox.Controls.Add(this.CalcCDIVCheckBox);
            this.genericControlsGroupBox.Controls.Add(this.RandNCountersResetCheckBox);
            this.genericControlsGroupBox.Controls.Add(this.IntNAutoModeWhenF0CheckBox);
            this.genericControlsGroupBox.Location = new System.Drawing.Point(266, 484);
            this.genericControlsGroupBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.genericControlsGroupBox.Name = "genericControlsGroupBox";
            this.genericControlsGroupBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.genericControlsGroupBox.Size = new System.Drawing.Size(256, 102);
            this.genericControlsGroupBox.TabIndex = 9;
            this.genericControlsGroupBox.TabStop = false;
            this.genericControlsGroupBox.Text = "Generic controls";
            // 
            // MuxPinModeCombobox
            // 
            this.MuxPinModeCombobox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.MuxPinModeCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MuxPinModeCombobox.FormattingEnabled = true;
            this.MuxPinModeCombobox.Items.AddRange(new object[] {
            "Three-state output",
            "D_VDD",
            "D_GND",
            "R-divider output",
            "N-divider output/2",
            "Analog lock detect",
            "Digital lock detect",
            "Sync Input"});
            this.MuxPinModeCombobox.Location = new System.Drawing.Point(87, 16);
            this.MuxPinModeCombobox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MuxPinModeCombobox.Name = "MuxPinModeCombobox";
            this.MuxPinModeCombobox.Size = new System.Drawing.Size(121, 21);
            this.MuxPinModeCombobox.TabIndex = 0;
            this.MuxPinModeCombobox.SelectedIndexChanged += new System.EventHandler(this.MuxPinModeCombobox_SelectedIndexChanged);
            // 
            // MuxPinModeLabel
            // 
            this.MuxPinModeLabel.Location = new System.Drawing.Point(-8, 19);
            this.MuxPinModeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MuxPinModeLabel.Name = "MuxPinModeLabel";
            this.MuxPinModeLabel.Size = new System.Drawing.Size(90, 14);
            this.MuxPinModeLabel.TabIndex = 17;
            this.MuxPinModeLabel.Text = "Mux Pin Mode:";
            this.MuxPinModeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Reg4DoubleBufferedCheckBox
            // 
            this.Reg4DoubleBufferedCheckBox.AutoSize = true;
            this.Reg4DoubleBufferedCheckBox.Location = new System.Drawing.Point(9, 40);
            this.Reg4DoubleBufferedCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Reg4DoubleBufferedCheckBox.Name = "Reg4DoubleBufferedCheckBox";
            this.Reg4DoubleBufferedCheckBox.Size = new System.Drawing.Size(200, 17);
            this.Reg4DoubleBufferedCheckBox.TabIndex = 1;
            this.Reg4DoubleBufferedCheckBox.Text = "Register 4 double bufered with reg. 0";
            this.Reg4DoubleBufferedCheckBox.UseVisualStyleBackColor = true;
            this.Reg4DoubleBufferedCheckBox.CheckedChanged += new System.EventHandler(this.Reg4DoubleBufferedCheckBox_CheckedChanged);
            // 
            // CalcCDIVCheckBox
            // 
            this.CalcCDIVCheckBox.AutoSize = true;
            this.CalcCDIVCheckBox.Location = new System.Drawing.Point(10, 40);
            this.CalcCDIVCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CalcCDIVCheckBox.Name = "CalcCDIVCheckBox";
            this.CalcCDIVCheckBox.Size = new System.Drawing.Size(136, 17);
            this.CalcCDIVCheckBox.TabIndex = 0;
            this.CalcCDIVCheckBox.Text = "R and N counters reset";
            this.CalcCDIVCheckBox.UseVisualStyleBackColor = true;
            // 
            // RandNCountersResetCheckBox
            // 
            this.RandNCountersResetCheckBox.AutoSize = true;
            this.RandNCountersResetCheckBox.Location = new System.Drawing.Point(9, 84);
            this.RandNCountersResetCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RandNCountersResetCheckBox.Name = "RandNCountersResetCheckBox";
            this.RandNCountersResetCheckBox.Size = new System.Drawing.Size(136, 17);
            this.RandNCountersResetCheckBox.TabIndex = 3;
            this.RandNCountersResetCheckBox.Text = "R and N counters reset";
            this.RandNCountersResetCheckBox.UseVisualStyleBackColor = true;
            this.RandNCountersResetCheckBox.CheckedChanged += new System.EventHandler(this.RandNCountersResetCheckBox_CheckedChanged);
            // 
            // IntNAutoModeWhenF0CheckBox
            // 
            this.IntNAutoModeWhenF0CheckBox.AutoSize = true;
            this.IntNAutoModeWhenF0CheckBox.Location = new System.Drawing.Point(9, 62);
            this.IntNAutoModeWhenF0CheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.IntNAutoModeWhenF0CheckBox.Name = "IntNAutoModeWhenF0CheckBox";
            this.IntNAutoModeWhenF0CheckBox.Size = new System.Drawing.Size(201, 17);
            this.IntNAutoModeWhenF0CheckBox.TabIndex = 2;
            this.IntNAutoModeWhenF0CheckBox.Text = "Integer-N mode auto set, if FracN = 0";
            this.IntNAutoModeWhenF0CheckBox.UseVisualStyleBackColor = true;
            this.IntNAutoModeWhenF0CheckBox.CheckedChanged += new System.EventHandler(this.IntNAutoModeWhenF0CheckBox_CheckedChanged);
            // 
            // ShutDownGroupBox
            // 
            this.ShutDownGroupBox.Controls.Add(this.PllShutDownCheckBox);
            this.ShutDownGroupBox.Controls.Add(this.VcoShutDownCheckBox);
            this.ShutDownGroupBox.Controls.Add(this.PloPowerDownCheckBox);
            this.ShutDownGroupBox.Controls.Add(this.VcoLdoShutDownCheckBox);
            this.ShutDownGroupBox.Controls.Add(this.VcoDividerShutdownCheckBox);
            this.ShutDownGroupBox.Controls.Add(this.RefInputShutdownCheckBox);
            this.ShutDownGroupBox.Location = new System.Drawing.Point(6, 505);
            this.ShutDownGroupBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ShutDownGroupBox.Name = "ShutDownGroupBox";
            this.ShutDownGroupBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ShutDownGroupBox.Size = new System.Drawing.Size(256, 81);
            this.ShutDownGroupBox.TabIndex = 5;
            this.ShutDownGroupBox.TabStop = false;
            this.ShutDownGroupBox.Text = "Shutdown controls";
            // 
            // PllShutDownCheckBox
            // 
            this.PllShutDownCheckBox.AutoSize = true;
            this.PllShutDownCheckBox.Location = new System.Drawing.Point(9, 60);
            this.PllShutDownCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PllShutDownCheckBox.Name = "PllShutDownCheckBox";
            this.PllShutDownCheckBox.Size = new System.Drawing.Size(45, 17);
            this.PllShutDownCheckBox.TabIndex = 4;
            this.PllShutDownCheckBox.Text = "PLL";
            this.PllShutDownCheckBox.UseVisualStyleBackColor = true;
            this.PllShutDownCheckBox.CheckedChanged += new System.EventHandler(this.PllShutDownCheckBox_CheckedChanged);
            // 
            // VcoShutDownCheckBox
            // 
            this.VcoShutDownCheckBox.AutoSize = true;
            this.VcoShutDownCheckBox.Location = new System.Drawing.Point(146, 60);
            this.VcoShutDownCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.VcoShutDownCheckBox.Name = "VcoShutDownCheckBox";
            this.VcoShutDownCheckBox.Size = new System.Drawing.Size(48, 17);
            this.VcoShutDownCheckBox.TabIndex = 5;
            this.VcoShutDownCheckBox.Text = "VCO";
            this.VcoShutDownCheckBox.UseVisualStyleBackColor = true;
            this.VcoShutDownCheckBox.CheckedChanged += new System.EventHandler(this.VcoShutDownCheckBox_CheckedChanged);
            // 
            // PloPowerDownCheckBox
            // 
            this.PloPowerDownCheckBox.AutoSize = true;
            this.PloPowerDownCheckBox.Location = new System.Drawing.Point(9, 16);
            this.PloPowerDownCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PloPowerDownCheckBox.Name = "PloPowerDownCheckBox";
            this.PloPowerDownCheckBox.Size = new System.Drawing.Size(109, 17);
            this.PloPowerDownCheckBox.TabIndex = 0;
            this.PloPowerDownCheckBox.Text = "PLO Power down";
            this.PloPowerDownCheckBox.UseVisualStyleBackColor = true;
            this.PloPowerDownCheckBox.CheckedChanged += new System.EventHandler(this.PloPowerDownCheckBox_CheckedChanged);
            // 
            // VcoLdoShutDownCheckBox
            // 
            this.VcoLdoShutDownCheckBox.AutoSize = true;
            this.VcoLdoShutDownCheckBox.Location = new System.Drawing.Point(146, 38);
            this.VcoLdoShutDownCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.VcoLdoShutDownCheckBox.Name = "VcoLdoShutDownCheckBox";
            this.VcoLdoShutDownCheckBox.Size = new System.Drawing.Size(73, 17);
            this.VcoLdoShutDownCheckBox.TabIndex = 3;
            this.VcoLdoShutDownCheckBox.Text = "VCO LDO";
            this.VcoLdoShutDownCheckBox.UseVisualStyleBackColor = true;
            this.VcoLdoShutDownCheckBox.CheckedChanged += new System.EventHandler(this.VcoLdoShutDownCheckBox_CheckedChanged);
            // 
            // VcoDividerShutdownCheckBox
            // 
            this.VcoDividerShutdownCheckBox.AutoSize = true;
            this.VcoDividerShutdownCheckBox.Location = new System.Drawing.Point(146, 16);
            this.VcoDividerShutdownCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.VcoDividerShutdownCheckBox.Name = "VcoDividerShutdownCheckBox";
            this.VcoDividerShutdownCheckBox.Size = new System.Drawing.Size(82, 17);
            this.VcoDividerShutdownCheckBox.TabIndex = 1;
            this.VcoDividerShutdownCheckBox.Text = "VCO divider";
            this.VcoDividerShutdownCheckBox.UseVisualStyleBackColor = true;
            this.VcoDividerShutdownCheckBox.CheckedChanged += new System.EventHandler(this.VcoDividerShutdownCheckBox_CheckedChanged);
            // 
            // RefInputShutdownCheckBox
            // 
            this.RefInputShutdownCheckBox.AutoSize = true;
            this.RefInputShutdownCheckBox.Location = new System.Drawing.Point(9, 38);
            this.RefInputShutdownCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RefInputShutdownCheckBox.Name = "RefInputShutdownCheckBox";
            this.RefInputShutdownCheckBox.Size = new System.Drawing.Size(102, 17);
            this.RefInputShutdownCheckBox.TabIndex = 2;
            this.RefInputShutdownCheckBox.Text = "Reference input";
            this.RefInputShutdownCheckBox.UseVisualStyleBackColor = true;
            this.RefInputShutdownCheckBox.CheckedChanged += new System.EventHandler(this.RefInputShutdownCheckBox_CheckedChanged);
            // 
            // VcoSettingsGroupBox
            // 
            this.VcoSettingsGroupBox.Controls.Add(this.ShowDelayLabel);
            this.VcoSettingsGroupBox.Controls.Add(this.label7);
            this.VcoSettingsGroupBox.Controls.Add(this.delayLabel);
            this.VcoSettingsGroupBox.Controls.Add(this.AutoCDIVCalcCheckBox);
            this.VcoSettingsGroupBox.Controls.Add(this.DelayToPreventFlickeringCheckBox);
            this.VcoSettingsGroupBox.Controls.Add(this.MuteUntilLockDetectCheckBox);
            this.VcoSettingsGroupBox.Controls.Add(this.VASTempCompCheckBox);
            this.VcoSettingsGroupBox.Controls.Add(this.AutoVcoSelectionCheckBox);
            this.VcoSettingsGroupBox.Controls.Add(this.BandSelClockDivNumericUpDown);
            this.VcoSettingsGroupBox.Controls.Add(this.DelayInputNumericUpDown);
            this.VcoSettingsGroupBox.Controls.Add(this.ClockDividerNumericUpDown);
            this.VcoSettingsGroupBox.Controls.Add(this.ManualVCOSelectNumericUpDown);
            this.VcoSettingsGroupBox.Controls.Add(this.BandSelectClockDivLabel);
            this.VcoSettingsGroupBox.Controls.Add(this.label5);
            this.VcoSettingsGroupBox.Controls.Add(this.ManualVcoLabel);
            this.VcoSettingsGroupBox.Location = new System.Drawing.Point(267, 161);
            this.VcoSettingsGroupBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.VcoSettingsGroupBox.Name = "VcoSettingsGroupBox";
            this.VcoSettingsGroupBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.VcoSettingsGroupBox.Size = new System.Drawing.Size(256, 193);
            this.VcoSettingsGroupBox.TabIndex = 6;
            this.VcoSettingsGroupBox.TabStop = false;
            this.VcoSettingsGroupBox.Text = "VCO settings";
            // 
            // ShowDelayLabel
            // 
            this.ShowDelayLabel.AutoSize = true;
            this.ShowDelayLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ShowDelayLabel.Location = new System.Drawing.Point(207, 152);
            this.ShowDelayLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ShowDelayLabel.Name = "ShowDelayLabel";
            this.ShowDelayLabel.Size = new System.Drawing.Size(47, 13);
            this.ShowDelayLabel.TabIndex = 20;
            this.ShowDelayLabel.Text = "1000 ms";
            this.ShowDelayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(214, 173);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "ms";
            // 
            // delayLabel
            // 
            this.delayLabel.AutoSize = true;
            this.delayLabel.Location = new System.Drawing.Point(172, 151);
            this.delayLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.delayLabel.Name = "delayLabel";
            this.delayLabel.Size = new System.Drawing.Size(37, 13);
            this.delayLabel.TabIndex = 20;
            this.delayLabel.Text = "Delay:";
            // 
            // AutoCDIVCalcCheckBox
            // 
            this.AutoCDIVCalcCheckBox.AutoSize = true;
            this.AutoCDIVCalcCheckBox.Location = new System.Drawing.Point(9, 171);
            this.AutoCDIVCalcCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AutoCDIVCalcCheckBox.Name = "AutoCDIVCalcCheckBox";
            this.AutoCDIVCalcCheckBox.Size = new System.Drawing.Size(147, 17);
            this.AutoCDIVCalcCheckBox.TabIndex = 7;
            this.AutoCDIVCalcCheckBox.Text = "Calc CDIV to spec. delay:";
            this.AutoCDIVCalcCheckBox.UseVisualStyleBackColor = true;
            this.AutoCDIVCalcCheckBox.CheckedChanged += new System.EventHandler(this.AutoCDIVCalcCheckBox_CheckedChanged);
            // 
            // DelayToPreventFlickeringCheckBox
            // 
            this.DelayToPreventFlickeringCheckBox.AutoSize = true;
            this.DelayToPreventFlickeringCheckBox.Location = new System.Drawing.Point(9, 131);
            this.DelayToPreventFlickeringCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DelayToPreventFlickeringCheckBox.Name = "DelayToPreventFlickeringCheckBox";
            this.DelayToPreventFlickeringCheckBox.Size = new System.Drawing.Size(252, 17);
            this.DelayToPreventFlickeringCheckBox.TabIndex = 5;
            this.DelayToPreventFlickeringCheckBox.Text = "Delay LD to MTLD function to prevent flickering";
            this.DelayToPreventFlickeringCheckBox.UseVisualStyleBackColor = true;
            this.DelayToPreventFlickeringCheckBox.CheckedChanged += new System.EventHandler(this.DelayToPreventFlickeringCheckBox_CheckedChanged);
            // 
            // MuteUntilLockDetectCheckBox
            // 
            this.MuteUntilLockDetectCheckBox.AutoSize = true;
            this.MuteUntilLockDetectCheckBox.Location = new System.Drawing.Point(9, 109);
            this.MuteUntilLockDetectCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MuteUntilLockDetectCheckBox.Name = "MuteUntilLockDetectCheckBox";
            this.MuteUntilLockDetectCheckBox.Size = new System.Drawing.Size(204, 17);
            this.MuteUntilLockDetectCheckBox.TabIndex = 4;
            this.MuteUntilLockDetectCheckBox.Text = "RFOUT Mute until Lock Detect Mode";
            this.MuteUntilLockDetectCheckBox.UseVisualStyleBackColor = true;
            this.MuteUntilLockDetectCheckBox.CheckedChanged += new System.EventHandler(this.MuteUntilLockDetectCheckBox_CheckedChanged);
            // 
            // VASTempCompCheckBox
            // 
            this.VASTempCompCheckBox.AutoSize = true;
            this.VASTempCompCheckBox.Location = new System.Drawing.Point(9, 44);
            this.VASTempCompCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.VASTempCompCheckBox.Name = "VASTempCompCheckBox";
            this.VASTempCompCheckBox.Size = new System.Drawing.Size(175, 17);
            this.VASTempCompCheckBox.TabIndex = 1;
            this.VASTempCompCheckBox.Text = "VAS temperature compensation";
            this.VASTempCompCheckBox.UseVisualStyleBackColor = true;
            this.VASTempCompCheckBox.CheckedChanged += new System.EventHandler(this.VASTempCompCheckBox_CheckedChanged);
            // 
            // AutoVcoSelectionCheckBox
            // 
            this.AutoVcoSelectionCheckBox.AutoSize = true;
            this.AutoVcoSelectionCheckBox.Location = new System.Drawing.Point(9, 22);
            this.AutoVcoSelectionCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AutoVcoSelectionCheckBox.Name = "AutoVcoSelectionCheckBox";
            this.AutoVcoSelectionCheckBox.Size = new System.Drawing.Size(143, 17);
            this.AutoVcoSelectionCheckBox.TabIndex = 0;
            this.AutoVcoSelectionCheckBox.Text = "Automatic VCO selection";
            this.AutoVcoSelectionCheckBox.UseVisualStyleBackColor = true;
            this.AutoVcoSelectionCheckBox.CheckedChanged += new System.EventHandler(this.AutoVcoSelectionCheckBox_CheckedChanged);
            // 
            // BandSelClockDivNumericUpDown
            // 
            this.BandSelClockDivNumericUpDown.Location = new System.Drawing.Point(116, 85);
            this.BandSelClockDivNumericUpDown.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.BandSelClockDivNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.BandSelClockDivNumericUpDown.Name = "BandSelClockDivNumericUpDown";
            this.BandSelClockDivNumericUpDown.Size = new System.Drawing.Size(62, 20);
            this.BandSelClockDivNumericUpDown.TabIndex = 3;
            this.BandSelClockDivNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BandSelClockDivNumericUpDown.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.BandSelClockDivNumericUpDown.ValueChanged += new System.EventHandler(this.BandSelClockDivNumericUpDown_ValueChanged);
            this.BandSelClockDivNumericUpDown.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.NumericUpDwScrollHandlerFunction);
            // 
            // DelayInputNumericUpDown
            // 
            this.DelayInputNumericUpDown.Location = new System.Drawing.Point(159, 171);
            this.DelayInputNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.DelayInputNumericUpDown.Name = "DelayInputNumericUpDown";
            this.DelayInputNumericUpDown.Size = new System.Drawing.Size(52, 20);
            this.DelayInputNumericUpDown.TabIndex = 8;
            this.DelayInputNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DelayInputNumericUpDown.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.DelayInputNumericUpDown.ValueChanged += new System.EventHandler(this.DelayInputNumericUpDown_ValueChanged);
            this.DelayInputNumericUpDown.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.NumericUpDwScrollHandlerFunction);
            // 
            // ClockDividerNumericUpDown
            // 
            this.ClockDividerNumericUpDown.Location = new System.Drawing.Point(104, 150);
            this.ClockDividerNumericUpDown.Maximum = new decimal(new int[] {
            4095,
            0,
            0,
            0});
            this.ClockDividerNumericUpDown.Name = "ClockDividerNumericUpDown";
            this.ClockDividerNumericUpDown.Size = new System.Drawing.Size(62, 20);
            this.ClockDividerNumericUpDown.TabIndex = 6;
            this.ClockDividerNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ClockDividerNumericUpDown.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.ClockDividerNumericUpDown.ValueChanged += new System.EventHandler(this.ClockDividerNumericUpDown_ValueChanged);
            this.ClockDividerNumericUpDown.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.NumericUpDwScrollHandlerFunction);
            // 
            // ManualVCOSelectNumericUpDown
            // 
            this.ManualVCOSelectNumericUpDown.Location = new System.Drawing.Point(116, 64);
            this.ManualVCOSelectNumericUpDown.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.ManualVCOSelectNumericUpDown.Name = "ManualVCOSelectNumericUpDown";
            this.ManualVCOSelectNumericUpDown.Size = new System.Drawing.Size(62, 20);
            this.ManualVCOSelectNumericUpDown.TabIndex = 2;
            this.ManualVCOSelectNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ManualVCOSelectNumericUpDown.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.ManualVCOSelectNumericUpDown.ValueChanged += new System.EventHandler(this.ManualVCOSelectNumericUpDown_ValueChanged);
            this.ManualVCOSelectNumericUpDown.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.NumericUpDwScrollHandlerFunction);
            // 
            // BandSelectClockDivLabel
            // 
            this.BandSelectClockDivLabel.Location = new System.Drawing.Point(-4, 88);
            this.BandSelectClockDivLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BandSelectClockDivLabel.Name = "BandSelectClockDivLabel";
            this.BandSelectClockDivLabel.Size = new System.Drawing.Size(117, 14);
            this.BandSelectClockDivLabel.TabIndex = 17;
            this.BandSelectClockDivLabel.Text = "Band-Select clock div:";
            this.BandSelectClockDivLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(-3, 152);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 14);
            this.label5.TabIndex = 17;
            this.label5.Text = "Clock divider value:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ManualVcoLabel
            // 
            this.ManualVcoLabel.Location = new System.Drawing.Point(9, 66);
            this.ManualVcoLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ManualVcoLabel.Name = "ManualVcoLabel";
            this.ManualVcoLabel.Size = new System.Drawing.Size(104, 14);
            this.ManualVcoLabel.TabIndex = 17;
            this.ManualVcoLabel.Text = "Manual VCO select:";
            this.ManualVcoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PhaseDetectorGroupBox
            // 
            this.PhaseDetectorGroupBox.Controls.Add(this.label1);
            this.PhaseDetectorGroupBox.Controls.Add(this.LDPrecisionLabel);
            this.PhaseDetectorGroupBox.Controls.Add(this.PfdPolarity);
            this.PhaseDetectorGroupBox.Controls.Add(this.LDPrecisionComboBox);
            this.PhaseDetectorGroupBox.Location = new System.Drawing.Point(6, 453);
            this.PhaseDetectorGroupBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PhaseDetectorGroupBox.Name = "PhaseDetectorGroupBox";
            this.PhaseDetectorGroupBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PhaseDetectorGroupBox.Size = new System.Drawing.Size(256, 47);
            this.PhaseDetectorGroupBox.TabIndex = 4;
            this.PhaseDetectorGroupBox.TabStop = false;
            this.PhaseDetectorGroupBox.Text = "Phase detector";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(129, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 14);
            this.label1.TabIndex = 17;
            this.label1.Text = "PFD polarity:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LDPrecisionLabel
            // 
            this.LDPrecisionLabel.Location = new System.Drawing.Point(1, 20);
            this.LDPrecisionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LDPrecisionLabel.Name = "LDPrecisionLabel";
            this.LDPrecisionLabel.Size = new System.Drawing.Size(72, 14);
            this.LDPrecisionLabel.TabIndex = 17;
            this.LDPrecisionLabel.Text = "LD precision:";
            this.LDPrecisionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PfdPolarity
            // 
            this.PfdPolarity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.PfdPolarity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PfdPolarity.FormattingEnabled = true;
            this.PfdPolarity.Items.AddRange(new object[] {
            "neg",
            "pos"});
            this.PfdPolarity.Location = new System.Drawing.Point(206, 18);
            this.PfdPolarity.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PfdPolarity.Name = "PfdPolarity";
            this.PfdPolarity.Size = new System.Drawing.Size(47, 21);
            this.PfdPolarity.TabIndex = 1;
            this.PfdPolarity.SelectedIndexChanged += new System.EventHandler(this.PfdPolarity_SelectedIndexChanged);
            // 
            // LDPrecisionComboBox
            // 
            this.LDPrecisionComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.LDPrecisionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LDPrecisionComboBox.FormattingEnabled = true;
            this.LDPrecisionComboBox.Items.AddRange(new object[] {
            "10 ns",
            " 6  ns"});
            this.LDPrecisionComboBox.Location = new System.Drawing.Point(77, 18);
            this.LDPrecisionComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LDPrecisionComboBox.Name = "LDPrecisionComboBox";
            this.LDPrecisionComboBox.Size = new System.Drawing.Size(51, 21);
            this.LDPrecisionComboBox.TabIndex = 0;
            this.LDPrecisionComboBox.SelectedIndexChanged += new System.EventHandler(this.LDPrecisionComboBox_SelectedIndexChanged);
            // 
            // RegistersControlsGroupBox
            // 
            this.RegistersControlsGroupBox.Controls.Add(this.WriteR0Button);
            this.RegistersControlsGroupBox.Controls.Add(this.Reg5TextBox);
            this.RegistersControlsGroupBox.Controls.Add(this.Reg5Label);
            this.RegistersControlsGroupBox.Controls.Add(this.SetAsDefaultRegButton);
            this.RegistersControlsGroupBox.Controls.Add(this.Reg4TextBox);
            this.RegistersControlsGroupBox.Controls.Add(this.Reg3Label);
            this.RegistersControlsGroupBox.Controls.Add(this.LoadDefRegButton);
            this.RegistersControlsGroupBox.Controls.Add(this.WriteR5Button);
            this.RegistersControlsGroupBox.Controls.Add(this.Reg4Label);
            this.RegistersControlsGroupBox.Controls.Add(this.Reg0TextBox);
            this.RegistersControlsGroupBox.Controls.Add(this.LoadFromFileButton);
            this.RegistersControlsGroupBox.Controls.Add(this.SaveIntoFileButton);
            this.RegistersControlsGroupBox.Controls.Add(this.ForceLoadRegButton);
            this.RegistersControlsGroupBox.Controls.Add(this.WriteR4Button);
            this.RegistersControlsGroupBox.Controls.Add(this.Reg3TextBox);
            this.RegistersControlsGroupBox.Controls.Add(this.Reg0Label);
            this.RegistersControlsGroupBox.Controls.Add(this.Reg2TextBox);
            this.RegistersControlsGroupBox.Controls.Add(this.WriteR3Button);
            this.RegistersControlsGroupBox.Controls.Add(this.Reg2Label);
            this.RegistersControlsGroupBox.Controls.Add(this.Reg1Label);
            this.RegistersControlsGroupBox.Controls.Add(this.WriteR2Button);
            this.RegistersControlsGroupBox.Controls.Add(this.WriteR1Button);
            this.RegistersControlsGroupBox.Controls.Add(this.Reg1TextBox);
            this.RegistersControlsGroupBox.Location = new System.Drawing.Point(5, 4);
            this.RegistersControlsGroupBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RegistersControlsGroupBox.Name = "RegistersControlsGroupBox";
            this.RegistersControlsGroupBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RegistersControlsGroupBox.Size = new System.Drawing.Size(300, 152);
            this.RegistersControlsGroupBox.TabIndex = 0;
            this.RegistersControlsGroupBox.TabStop = false;
            this.RegistersControlsGroupBox.Text = "Registers controls";
            // 
            // LoadFromFileButton
            // 
            this.LoadFromFileButton.Location = new System.Drawing.Point(206, 84);
            this.LoadFromFileButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LoadFromFileButton.Name = "LoadFromFileButton";
            this.LoadFromFileButton.Size = new System.Drawing.Size(89, 19);
            this.LoadFromFileButton.TabIndex = 15;
            this.LoadFromFileButton.Text = "Load From File";
            this.LoadFromFileButton.UseVisualStyleBackColor = true;
            this.LoadFromFileButton.Click += new System.EventHandler(this.LoadFromFileButton_Click);
            // 
            // SaveIntoFileButton
            // 
            this.SaveIntoFileButton.Location = new System.Drawing.Point(206, 62);
            this.SaveIntoFileButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SaveIntoFileButton.Name = "SaveIntoFileButton";
            this.SaveIntoFileButton.Size = new System.Drawing.Size(89, 19);
            this.SaveIntoFileButton.TabIndex = 14;
            this.SaveIntoFileButton.Text = "Save Into File";
            this.SaveIntoFileButton.UseVisualStyleBackColor = true;
            this.SaveIntoFileButton.Click += new System.EventHandler(this.SaveIntoFileButton_Click);
            // 
            // MoveRegsIntoMemsGroupBox
            // 
            this.MoveRegsIntoMemsGroupBox.Controls.Add(this.ExportIntoMem1Button);
            this.MoveRegsIntoMemsGroupBox.Controls.Add(this.ExportIntoMem2Button);
            this.MoveRegsIntoMemsGroupBox.Controls.Add(this.ExportIntoMem3Button);
            this.MoveRegsIntoMemsGroupBox.Controls.Add(this.ExportIntoMem4Button);
            this.MoveRegsIntoMemsGroupBox.Location = new System.Drawing.Point(310, 4);
            this.MoveRegsIntoMemsGroupBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MoveRegsIntoMemsGroupBox.Name = "MoveRegsIntoMemsGroupBox";
            this.MoveRegsIntoMemsGroupBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MoveRegsIntoMemsGroupBox.Size = new System.Drawing.Size(90, 152);
            this.MoveRegsIntoMemsGroupBox.TabIndex = 1;
            this.MoveRegsIntoMemsGroupBox.TabStop = false;
            this.MoveRegsIntoMemsGroupBox.Text = "Export currently set registers into Memory tab";
            // 
            // ExportIntoMem1Button
            // 
            this.ExportIntoMem1Button.Location = new System.Drawing.Point(8, 58);
            this.ExportIntoMem1Button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ExportIntoMem1Button.Name = "ExportIntoMem1Button";
            this.ExportIntoMem1Button.Size = new System.Drawing.Size(74, 19);
            this.ExportIntoMem1Button.TabIndex = 9;
            this.ExportIntoMem1Button.Text = "Memory 1";
            this.ExportIntoMem1Button.UseVisualStyleBackColor = true;
            this.ExportIntoMem1Button.Click += new System.EventHandler(this.ExportIntoMememoryButton_Click);
            // 
            // ExportIntoMem2Button
            // 
            this.ExportIntoMem2Button.Location = new System.Drawing.Point(8, 81);
            this.ExportIntoMem2Button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ExportIntoMem2Button.Name = "ExportIntoMem2Button";
            this.ExportIntoMem2Button.Size = new System.Drawing.Size(74, 19);
            this.ExportIntoMem2Button.TabIndex = 9;
            this.ExportIntoMem2Button.Text = "Memory 2";
            this.ExportIntoMem2Button.UseVisualStyleBackColor = true;
            this.ExportIntoMem2Button.Click += new System.EventHandler(this.ExportIntoMememoryButton_Click);
            // 
            // ExportIntoMem3Button
            // 
            this.ExportIntoMem3Button.Location = new System.Drawing.Point(8, 104);
            this.ExportIntoMem3Button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ExportIntoMem3Button.Name = "ExportIntoMem3Button";
            this.ExportIntoMem3Button.Size = new System.Drawing.Size(74, 19);
            this.ExportIntoMem3Button.TabIndex = 9;
            this.ExportIntoMem3Button.Text = "Memory 3";
            this.ExportIntoMem3Button.UseVisualStyleBackColor = true;
            this.ExportIntoMem3Button.Click += new System.EventHandler(this.ExportIntoMememoryButton_Click);
            // 
            // ExportIntoMem4Button
            // 
            this.ExportIntoMem4Button.Location = new System.Drawing.Point(8, 127);
            this.ExportIntoMem4Button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ExportIntoMem4Button.Name = "ExportIntoMem4Button";
            this.ExportIntoMem4Button.Size = new System.Drawing.Size(74, 19);
            this.ExportIntoMem4Button.TabIndex = 9;
            this.ExportIntoMem4Button.Text = "Memory 4";
            this.ExportIntoMem4Button.UseVisualStyleBackColor = true;
            this.ExportIntoMem4Button.Click += new System.EventHandler(this.ExportIntoMememoryButton_Click);
            // 
            // ChargePumpGroupBox
            // 
            this.ChargePumpGroupBox.Controls.Add(this.PhaseAdjustmentModeCheckbox);
            this.ChargePumpGroupBox.Controls.Add(this.CPCycleSlipCheckBox);
            this.ChargePumpGroupBox.Controls.Add(this.CPTriStateOutCheckBox);
            this.ChargePumpGroupBox.Controls.Add(this.CPFastLockCheckBox);
            this.ChargePumpGroupBox.Controls.Add(this.RSetTextBox);
            this.ChargePumpGroupBox.Controls.Add(this.CPTestComboBox);
            this.ChargePumpGroupBox.Controls.Add(this.CPLinearityComboBox);
            this.ChargePumpGroupBox.Controls.Add(this.CPTestLabel);
            this.ChargePumpGroupBox.Controls.Add(this.CPCurrentComboBox);
            this.ChargePumpGroupBox.Controls.Add(this.CPLinearityLabel);
            this.ChargePumpGroupBox.Controls.Add(this.RSetLabel);
            this.ChargePumpGroupBox.Controls.Add(this.CPCurrentLabel);
            this.ChargePumpGroupBox.Location = new System.Drawing.Point(267, 359);
            this.ChargePumpGroupBox.Name = "ChargePumpGroupBox";
            this.ChargePumpGroupBox.Size = new System.Drawing.Size(256, 119);
            this.ChargePumpGroupBox.TabIndex = 7;
            this.ChargePumpGroupBox.TabStop = false;
            this.ChargePumpGroupBox.Text = "Charge pump";
            // 
            // PhaseAdjustmentModeCheckbox
            // 
            this.PhaseAdjustmentModeCheckbox.AutoSize = true;
            this.PhaseAdjustmentModeCheckbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.PhaseAdjustmentModeCheckbox.Location = new System.Drawing.Point(156, 46);
            this.PhaseAdjustmentModeCheckbox.Name = "PhaseAdjustmentModeCheckbox";
            this.PhaseAdjustmentModeCheckbox.Size = new System.Drawing.Size(94, 17);
            this.PhaseAdjustmentModeCheckbox.TabIndex = 5;
            this.PhaseAdjustmentModeCheckbox.Text = "Phase Adjust.:";
            this.PhaseAdjustmentModeCheckbox.UseVisualStyleBackColor = true;
            this.PhaseAdjustmentModeCheckbox.CheckedChanged += new System.EventHandler(this.PhaseAdjustmentModeCheckbox_CheckedChanged);
            // 
            // CPCycleSlipCheckBox
            // 
            this.CPCycleSlipCheckBox.AutoSize = true;
            this.CPCycleSlipCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CPCycleSlipCheckBox.Location = new System.Drawing.Point(146, 93);
            this.CPCycleSlipCheckBox.Name = "CPCycleSlipCheckBox";
            this.CPCycleSlipCheckBox.Size = new System.Drawing.Size(105, 17);
            this.CPCycleSlipCheckBox.TabIndex = 7;
            this.CPCycleSlipCheckBox.Text = "Cycle Slip Mode:";
            this.CPCycleSlipCheckBox.UseVisualStyleBackColor = true;
            this.CPCycleSlipCheckBox.CheckedChanged += new System.EventHandler(this.CPCycleSlipCheckBox_CheckedChanged);
            // 
            // CPTriStateOutCheckBox
            // 
            this.CPTriStateOutCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.CPTriStateOutCheckBox.AutoSize = true;
            this.CPTriStateOutCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CPTriStateOutCheckBox.Location = new System.Drawing.Point(151, 70);
            this.CPTriStateOutCheckBox.Name = "CPTriStateOutCheckBox";
            this.CPTriStateOutCheckBox.Size = new System.Drawing.Size(99, 17);
            this.CPTriStateOutCheckBox.TabIndex = 6;
            this.CPTriStateOutCheckBox.Text = "Tristate Output:";
            this.CPTriStateOutCheckBox.UseVisualStyleBackColor = true;
            this.CPTriStateOutCheckBox.CheckedChanged += new System.EventHandler(this.CPTriStateOutCheckBox_CheckedChanged);
            // 
            // CPFastLockCheckBox
            // 
            this.CPFastLockCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CPFastLockCheckBox.AutoSize = true;
            this.CPFastLockCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CPFastLockCheckBox.Location = new System.Drawing.Point(175, 24);
            this.CPFastLockCheckBox.Name = "CPFastLockCheckBox";
            this.CPFastLockCheckBox.Size = new System.Drawing.Size(76, 17);
            this.CPFastLockCheckBox.TabIndex = 4;
            this.CPFastLockCheckBox.Text = "Fast Lock:";
            this.CPFastLockCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CPFastLockCheckBox.UseVisualStyleBackColor = true;
            this.CPFastLockCheckBox.CheckedChanged += new System.EventHandler(this.CPFastLockCheckBox_CheckedChanged);
            // 
            // RSetTextBox
            // 
            this.RSetTextBox.BackColor = System.Drawing.Color.White;
            this.RSetTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.RSetTextBox.Location = new System.Drawing.Point(55, 18);
            this.RSetTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RSetTextBox.MaxLength = 5;
            this.RSetTextBox.Name = "RSetTextBox";
            this.RSetTextBox.Size = new System.Drawing.Size(41, 20);
            this.RSetTextBox.TabIndex = 0;
            this.RSetTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RSetTextBox.TextChanged += new System.EventHandler(this.RSetTextBox_TextChanged);
            this.RSetTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RSetTextBox_KeyDown);
            this.RSetTextBox.LostFocus += new System.EventHandler(this.RSetTextBox_LostFocus);
            // 
            // CPTestComboBox
            // 
            this.CPTestComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CPTestComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CPTestComboBox.FormattingEnabled = true;
            this.CPTestComboBox.Items.AddRange(new object[] {
            "Normal",
            "Long Reset",
            "Force Source",
            "Force Sink"});
            this.CPTestComboBox.Location = new System.Drawing.Point(55, 92);
            this.CPTestComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CPTestComboBox.Name = "CPTestComboBox";
            this.CPTestComboBox.Size = new System.Drawing.Size(88, 21);
            this.CPTestComboBox.TabIndex = 3;
            this.CPTestComboBox.SelectedIndexChanged += new System.EventHandler(this.CPTestComboBox_SelectedIndexChanged);
            // 
            // CPLinearityComboBox
            // 
            this.CPLinearityComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CPLinearityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CPLinearityComboBox.FormattingEnabled = true;
            this.CPLinearityComboBox.Items.AddRange(new object[] {
            "0% extra",
            "10% extra",
            "20% extra",
            "30% extra"});
            this.CPLinearityComboBox.Location = new System.Drawing.Point(55, 67);
            this.CPLinearityComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CPLinearityComboBox.Name = "CPLinearityComboBox";
            this.CPLinearityComboBox.Size = new System.Drawing.Size(88, 21);
            this.CPLinearityComboBox.TabIndex = 2;
            this.CPLinearityComboBox.SelectedIndexChanged += new System.EventHandler(this.CPLinearityComboBox_SelectedIndexChanged);
            // 
            // CPTestLabel
            // 
            this.CPTestLabel.Location = new System.Drawing.Point(0, 95);
            this.CPTestLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CPTestLabel.Name = "CPTestLabel";
            this.CPTestLabel.Size = new System.Drawing.Size(51, 14);
            this.CPTestLabel.TabIndex = 17;
            this.CPTestLabel.Text = "CP Test:";
            this.CPTestLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CPCurrentComboBox
            // 
            this.CPCurrentComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CPCurrentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CPCurrentComboBox.FormattingEnabled = true;
            this.CPCurrentComboBox.Location = new System.Drawing.Point(55, 42);
            this.CPCurrentComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CPCurrentComboBox.Name = "CPCurrentComboBox";
            this.CPCurrentComboBox.Size = new System.Drawing.Size(88, 21);
            this.CPCurrentComboBox.TabIndex = 1;
            this.CPCurrentComboBox.SelectedIndexChanged += new System.EventHandler(this.CPCurrentComboBox_SelectedIndexChanged);
            // 
            // CPLinearityLabel
            // 
            this.CPLinearityLabel.Location = new System.Drawing.Point(0, 70);
            this.CPLinearityLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CPLinearityLabel.Name = "CPLinearityLabel";
            this.CPLinearityLabel.Size = new System.Drawing.Size(51, 14);
            this.CPLinearityLabel.TabIndex = 17;
            this.CPLinearityLabel.Text = "Linearity:";
            this.CPLinearityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RSetLabel
            // 
            this.RSetLabel.Location = new System.Drawing.Point(0, 21);
            this.RSetLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RSetLabel.Name = "RSetLabel";
            this.RSetLabel.Size = new System.Drawing.Size(51, 14);
            this.RSetLabel.TabIndex = 17;
            this.RSetLabel.Text = "R set:";
            this.RSetLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CPCurrentLabel
            // 
            this.CPCurrentLabel.Location = new System.Drawing.Point(3, 45);
            this.CPCurrentLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CPCurrentLabel.Name = "CPCurrentLabel";
            this.CPCurrentLabel.Size = new System.Drawing.Size(48, 14);
            this.CPCurrentLabel.TabIndex = 17;
            this.CPCurrentLabel.Text = "Current:";
            this.CPCurrentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // OutputControlsGroupBox
            // 
            this.OutputControlsGroupBox.Controls.Add(this.RF_A_EN_Label);
            this.OutputControlsGroupBox.Controls.Add(this.RF_A_PWR_Label);
            this.OutputControlsGroupBox.Controls.Add(this.RF_B_EN_Label);
            this.OutputControlsGroupBox.Controls.Add(this.RF_B_PWR_Label);
            this.OutputControlsGroupBox.Controls.Add(this.OutBPwr_ComboBox);
            this.OutputControlsGroupBox.Controls.Add(this.OutAEn_ComboBox);
            this.OutputControlsGroupBox.Controls.Add(this.OutAPwr_ComboBox);
            this.OutputControlsGroupBox.Controls.Add(this.OutBEn_ComboBox);
            this.OutputControlsGroupBox.Location = new System.Drawing.Point(173, 585);
            this.OutputControlsGroupBox.Name = "OutputControlsGroupBox";
            this.OutputControlsGroupBox.Size = new System.Drawing.Size(344, 61);
            this.OutputControlsGroupBox.TabIndex = 10;
            this.OutputControlsGroupBox.TabStop = false;
            this.OutputControlsGroupBox.Text = "Output Controls";
            // 
            // RF_A_EN_Label
            // 
            this.RF_A_EN_Label.Location = new System.Drawing.Point(5, 17);
            this.RF_A_EN_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RF_A_EN_Label.Name = "RF_A_EN_Label";
            this.RF_A_EN_Label.Size = new System.Drawing.Size(85, 14);
            this.RF_A_EN_Label.TabIndex = 7;
            this.RF_A_EN_Label.Text = "RFoutA Enable:";
            this.RF_A_EN_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RF_A_PWR_Label
            // 
            this.RF_A_PWR_Label.Location = new System.Drawing.Point(5, 41);
            this.RF_A_PWR_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RF_A_PWR_Label.Name = "RF_A_PWR_Label";
            this.RF_A_PWR_Label.Size = new System.Drawing.Size(85, 14);
            this.RF_A_PWR_Label.TabIndex = 7;
            this.RF_A_PWR_Label.Text = "RFoutA Power:";
            this.RF_A_PWR_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RF_B_EN_Label
            // 
            this.RF_B_EN_Label.Location = new System.Drawing.Point(174, 17);
            this.RF_B_EN_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RF_B_EN_Label.Name = "RF_B_EN_Label";
            this.RF_B_EN_Label.Size = new System.Drawing.Size(85, 14);
            this.RF_B_EN_Label.TabIndex = 7;
            this.RF_B_EN_Label.Text = "RFoutB Enable:";
            this.RF_B_EN_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RF_B_PWR_Label
            // 
            this.RF_B_PWR_Label.Location = new System.Drawing.Point(174, 41);
            this.RF_B_PWR_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RF_B_PWR_Label.Name = "RF_B_PWR_Label";
            this.RF_B_PWR_Label.Size = new System.Drawing.Size(85, 14);
            this.RF_B_PWR_Label.TabIndex = 7;
            this.RF_B_PWR_Label.Text = "RFoutB Power:";
            this.RF_B_PWR_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // OutBPwr_ComboBox
            // 
            this.OutBPwr_ComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.OutBPwr_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OutBPwr_ComboBox.FormattingEnabled = true;
            this.OutBPwr_ComboBox.Items.AddRange(new object[] {
            "-4 dBm",
            "-1 dBm",
            "+2 dBm",
            "+5 dBm"});
            this.OutBPwr_ComboBox.Location = new System.Drawing.Point(264, 38);
            this.OutBPwr_ComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.OutBPwr_ComboBox.Name = "OutBPwr_ComboBox";
            this.OutBPwr_ComboBox.Size = new System.Drawing.Size(76, 21);
            this.OutBPwr_ComboBox.TabIndex = 3;
            this.OutBPwr_ComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.OutBPwr_ComboBox_DrawItem);
            this.OutBPwr_ComboBox.SelectedIndexChanged += new System.EventHandler(this.OutBPwr_ComboBox_SelectedIndexChanged);
            // 
            // OutAEn_ComboBox
            // 
            this.OutAEn_ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.OutAEn_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OutAEn_ComboBox.FormattingEnabled = true;
            this.OutAEn_ComboBox.Items.AddRange(new object[] {
            "0. Disabled",
            "1. Enabled"});
            this.OutAEn_ComboBox.Location = new System.Drawing.Point(95, 15);
            this.OutAEn_ComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.OutAEn_ComboBox.Name = "OutAEn_ComboBox";
            this.OutAEn_ComboBox.Size = new System.Drawing.Size(76, 21);
            this.OutAEn_ComboBox.TabIndex = 0;
            this.OutAEn_ComboBox.SelectedIndexChanged += new System.EventHandler(this.OutAEn_ComboBox_SelectedIndexChanged);
            // 
            // OutAPwr_ComboBox
            // 
            this.OutAPwr_ComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.OutAPwr_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OutAPwr_ComboBox.FormattingEnabled = true;
            this.OutAPwr_ComboBox.Items.AddRange(new object[] {
            "-4 dBm",
            "-1 dBm",
            "+2 dBm",
            "+5 dBm"});
            this.OutAPwr_ComboBox.Location = new System.Drawing.Point(95, 38);
            this.OutAPwr_ComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.OutAPwr_ComboBox.Name = "OutAPwr_ComboBox";
            this.OutAPwr_ComboBox.Size = new System.Drawing.Size(76, 21);
            this.OutAPwr_ComboBox.TabIndex = 1;
            this.OutAPwr_ComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.OutAPwr_ComboBox_DrawItem);
            this.OutAPwr_ComboBox.SelectedIndexChanged += new System.EventHandler(this.OutAPwr_ComboBox_SelectedIndexChanged);
            // 
            // OutBEn_ComboBox
            // 
            this.OutBEn_ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.OutBEn_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OutBEn_ComboBox.FormattingEnabled = true;
            this.OutBEn_ComboBox.Items.AddRange(new object[] {
            "0. Disabled",
            "1. Enabled"});
            this.OutBEn_ComboBox.Location = new System.Drawing.Point(264, 15);
            this.OutBEn_ComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.OutBEn_ComboBox.Name = "OutBEn_ComboBox";
            this.OutBEn_ComboBox.Size = new System.Drawing.Size(76, 21);
            this.OutBEn_ComboBox.TabIndex = 2;
            this.OutBEn_ComboBox.SelectedIndexChanged += new System.EventHandler(this.OutBEn_ComboBox_SelectedIndexChanged);
            // 
            // OutInfoGroupBox
            // 
            this.OutInfoGroupBox.Controls.Add(this.fOutALabel);
            this.OutInfoGroupBox.Controls.Add(this.MHzLabel1);
            this.OutInfoGroupBox.Controls.Add(this.MHzLabel5);
            this.OutInfoGroupBox.Controls.Add(this.fVcoLabel);
            this.OutInfoGroupBox.Controls.Add(this.MHzLabel2);
            this.OutInfoGroupBox.Controls.Add(this.fOutBLabel);
            this.OutInfoGroupBox.Controls.Add(this.fOutAScreenLabel);
            this.OutInfoGroupBox.Controls.Add(this.fOutBScreenLabel);
            this.OutInfoGroupBox.Controls.Add(this.fVcoScreenLabel);
            this.OutInfoGroupBox.Location = new System.Drawing.Point(5, 585);
            this.OutInfoGroupBox.Name = "OutInfoGroupBox";
            this.OutInfoGroupBox.Size = new System.Drawing.Size(162, 61);
            this.OutInfoGroupBox.TabIndex = 24;
            this.OutInfoGroupBox.TabStop = false;
            this.OutInfoGroupBox.Text = "Output frequency info";
            // 
            // fOutALabel
            // 
            this.fOutALabel.Location = new System.Drawing.Point(6, 29);
            this.fOutALabel.Name = "fOutALabel";
            this.fOutALabel.Size = new System.Drawing.Size(46, 13);
            this.fOutALabel.TabIndex = 20;
            this.fOutALabel.Text = "fOUT A:";
            this.fOutALabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MHzLabel1
            // 
            this.MHzLabel1.Location = new System.Drawing.Point(131, 28);
            this.MHzLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MHzLabel1.Name = "MHzLabel1";
            this.MHzLabel1.Size = new System.Drawing.Size(30, 14);
            this.MHzLabel1.TabIndex = 17;
            this.MHzLabel1.Text = "MHz";
            this.MHzLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MHzLabel5
            // 
            this.MHzLabel5.Location = new System.Drawing.Point(131, 42);
            this.MHzLabel5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MHzLabel5.Name = "MHzLabel5";
            this.MHzLabel5.Size = new System.Drawing.Size(30, 14);
            this.MHzLabel5.TabIndex = 17;
            this.MHzLabel5.Text = "MHz";
            this.MHzLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fVcoLabel
            // 
            this.fVcoLabel.Location = new System.Drawing.Point(6, 15);
            this.fVcoLabel.Name = "fVcoLabel";
            this.fVcoLabel.Size = new System.Drawing.Size(46, 13);
            this.fVcoLabel.TabIndex = 20;
            this.fVcoLabel.Text = "fVCO:";
            this.fVcoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MHzLabel2
            // 
            this.MHzLabel2.Location = new System.Drawing.Point(131, 14);
            this.MHzLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MHzLabel2.Name = "MHzLabel2";
            this.MHzLabel2.Size = new System.Drawing.Size(30, 14);
            this.MHzLabel2.TabIndex = 17;
            this.MHzLabel2.Text = "MHz";
            this.MHzLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fOutBLabel
            // 
            this.fOutBLabel.Location = new System.Drawing.Point(6, 43);
            this.fOutBLabel.Name = "fOutBLabel";
            this.fOutBLabel.Size = new System.Drawing.Size(46, 13);
            this.fOutBLabel.TabIndex = 20;
            this.fOutBLabel.Text = "fOUT B:";
            this.fOutBLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // fOutAScreenLabel
            // 
            this.fOutAScreenLabel.Location = new System.Drawing.Point(53, 29);
            this.fOutAScreenLabel.Name = "fOutAScreenLabel";
            this.fOutAScreenLabel.Size = new System.Drawing.Size(82, 13);
            this.fOutAScreenLabel.TabIndex = 20;
            this.fOutAScreenLabel.Text = "6000.000 000 0";
            this.fOutAScreenLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // fOutBScreenLabel
            // 
            this.fOutBScreenLabel.Location = new System.Drawing.Point(53, 43);
            this.fOutBScreenLabel.Name = "fOutBScreenLabel";
            this.fOutBScreenLabel.Size = new System.Drawing.Size(82, 13);
            this.fOutBScreenLabel.TabIndex = 20;
            this.fOutBScreenLabel.Text = "6000.000 000 0";
            this.fOutBScreenLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // fVcoScreenLabel
            // 
            this.fVcoScreenLabel.Location = new System.Drawing.Point(53, 15);
            this.fVcoScreenLabel.Name = "fVcoScreenLabel";
            this.fVcoScreenLabel.Size = new System.Drawing.Size(82, 13);
            this.fVcoScreenLabel.TabIndex = 20;
            this.fVcoScreenLabel.Text = "6000.000 000 0";
            this.fVcoScreenLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FreqControlGroupBox
            // 
            this.FreqControlGroupBox.Controls.Add(this.label2);
            this.FreqControlGroupBox.Controls.Add(this.RFoutBPathLabel);
            this.FreqControlGroupBox.Controls.Add(this.SDNoiseModeLabel);
            this.FreqControlGroupBox.Controls.Add(this.LDfuncLabel);
            this.FreqControlGroupBox.Controls.Add(this.ADivComboBox);
            this.FreqControlGroupBox.Controls.Add(this.FracNLabel);
            this.FreqControlGroupBox.Controls.Add(this.ModeIntFracComboBox);
            this.FreqControlGroupBox.Controls.Add(this.SigmaDeltaNoiseModeComboBox);
            this.FreqControlGroupBox.Controls.Add(this.FBPathComboBox);
            this.FreqControlGroupBox.Controls.Add(this.RFoutBPathComboBox);
            this.FreqControlGroupBox.Controls.Add(this.LDFuncComboBox);
            this.FreqControlGroupBox.Controls.Add(this.AutoLDFuncCheckBox);
            this.FreqControlGroupBox.Controls.Add(this.IntNLabel);
            this.FreqControlGroupBox.Controls.Add(this.ModeIntFracLabel);
            this.FreqControlGroupBox.Controls.Add(this.ModLabel);
            this.FreqControlGroupBox.Controls.Add(this.ADivLabel);
            this.FreqControlGroupBox.Controls.Add(this.PhasePLabel);
            this.FreqControlGroupBox.Controls.Add(this.IntNNumUpDown);
            this.FreqControlGroupBox.Controls.Add(this.ModNumUpDown);
            this.FreqControlGroupBox.Controls.Add(this.FracNNumUpDown);
            this.FreqControlGroupBox.Controls.Add(this.PhasePNumericUpDown);
            this.FreqControlGroupBox.Location = new System.Drawing.Point(5, 266);
            this.FreqControlGroupBox.Name = "FreqControlGroupBox";
            this.FreqControlGroupBox.Size = new System.Drawing.Size(256, 181);
            this.FreqControlGroupBox.TabIndex = 3;
            this.FreqControlGroupBox.TabStop = false;
            this.FreqControlGroupBox.Text = "Output frequency control";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(20, 135);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 14);
            this.label2.TabIndex = 17;
            this.label2.Text = "VCO to N FB:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RFoutBPathLabel
            // 
            this.RFoutBPathLabel.Location = new System.Drawing.Point(20, 112);
            this.RFoutBPathLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RFoutBPathLabel.Name = "RFoutBPathLabel";
            this.RFoutBPathLabel.Size = new System.Drawing.Size(75, 14);
            this.RFoutBPathLabel.TabIndex = 17;
            this.RFoutBPathLabel.Text = "RFoutB path:";
            this.RFoutBPathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SDNoiseModeLabel
            // 
            this.SDNoiseModeLabel.Location = new System.Drawing.Point(4, 158);
            this.SDNoiseModeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SDNoiseModeLabel.Name = "SDNoiseModeLabel";
            this.SDNoiseModeLabel.Size = new System.Drawing.Size(90, 14);
            this.SDNoiseModeLabel.TabIndex = 17;
            this.SDNoiseModeLabel.Text = "S-D noise mode:";
            this.SDNoiseModeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LDfuncLabel
            // 
            this.LDfuncLabel.Location = new System.Drawing.Point(29, 89);
            this.LDfuncLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LDfuncLabel.Name = "LDfuncLabel";
            this.LDfuncLabel.Size = new System.Drawing.Size(65, 14);
            this.LDfuncLabel.TabIndex = 17;
            this.LDfuncLabel.Text = "LD function:";
            this.LDfuncLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ADivComboBox
            // 
            this.ADivComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ADivComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ADivComboBox.FormattingEnabled = true;
            this.ADivComboBox.Items.AddRange(new object[] {
            "OUTA/1",
            "OUTA/2",
            "OUTA/4",
            "OUTA/8",
            "OUTA/16",
            "OUTA/32",
            "OUTA/64",
            "OUTA/128"});
            this.ADivComboBox.Location = new System.Drawing.Point(170, 41);
            this.ADivComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ADivComboBox.Name = "ADivComboBox";
            this.ADivComboBox.Size = new System.Drawing.Size(80, 21);
            this.ADivComboBox.TabIndex = 4;
            this.ADivComboBox.SelectedIndexChanged += new System.EventHandler(this.ADivComboBox_SelectedIndexChanged);
            // 
            // FracNLabel
            // 
            this.FracNLabel.Location = new System.Drawing.Point(5, 43);
            this.FracNLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.FracNLabel.Name = "FracNLabel";
            this.FracNLabel.Size = new System.Drawing.Size(39, 14);
            this.FracNLabel.TabIndex = 17;
            this.FracNLabel.Text = "FracN:";
            this.FracNLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ModeIntFracComboBox
            // 
            this.ModeIntFracComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ModeIntFracComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ModeIntFracComboBox.FormattingEnabled = true;
            this.ModeIntFracComboBox.Items.AddRange(new object[] {
            "Fractional",
            "Integer"});
            this.ModeIntFracComboBox.Location = new System.Drawing.Point(170, 17);
            this.ModeIntFracComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ModeIntFracComboBox.Name = "ModeIntFracComboBox";
            this.ModeIntFracComboBox.Size = new System.Drawing.Size(80, 21);
            this.ModeIntFracComboBox.TabIndex = 3;
            this.ModeIntFracComboBox.SelectedIndexChanged += new System.EventHandler(this.ModeIntFracComboBox_SelectedIndexChanged);
            // 
            // SigmaDeltaNoiseModeComboBox
            // 
            this.SigmaDeltaNoiseModeComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.SigmaDeltaNoiseModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SigmaDeltaNoiseModeComboBox.FormattingEnabled = true;
            this.SigmaDeltaNoiseModeComboBox.Items.AddRange(new object[] {
            "Low-noise Mode",
            "Low-spur Mode 1",
            "Low-spur Mode 2"});
            this.SigmaDeltaNoiseModeComboBox.Location = new System.Drawing.Point(99, 155);
            this.SigmaDeltaNoiseModeComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SigmaDeltaNoiseModeComboBox.Name = "SigmaDeltaNoiseModeComboBox";
            this.SigmaDeltaNoiseModeComboBox.Size = new System.Drawing.Size(114, 21);
            this.SigmaDeltaNoiseModeComboBox.TabIndex = 10;
            this.SigmaDeltaNoiseModeComboBox.SelectedIndexChanged += new System.EventHandler(this.SDNoiseModeComboBox_SelectedIndexChanged);
            // 
            // FBPathComboBox
            // 
            this.FBPathComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.FBPathComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FBPathComboBox.FormattingEnabled = true;
            this.FBPathComboBox.Items.AddRange(new object[] {
            "VCO divided",
            "VCO fundamental"});
            this.FBPathComboBox.Location = new System.Drawing.Point(99, 132);
            this.FBPathComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FBPathComboBox.Name = "FBPathComboBox";
            this.FBPathComboBox.Size = new System.Drawing.Size(114, 21);
            this.FBPathComboBox.TabIndex = 9;
            this.FBPathComboBox.SelectedIndexChanged += new System.EventHandler(this.FBPathComboBox_SelectedIndexChanged);
            // 
            // RFoutBPathComboBox
            // 
            this.RFoutBPathComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.RFoutBPathComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RFoutBPathComboBox.FormattingEnabled = true;
            this.RFoutBPathComboBox.Items.AddRange(new object[] {
            "VCO divided",
            "VCO fundamental"});
            this.RFoutBPathComboBox.Location = new System.Drawing.Point(99, 110);
            this.RFoutBPathComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RFoutBPathComboBox.Name = "RFoutBPathComboBox";
            this.RFoutBPathComboBox.Size = new System.Drawing.Size(114, 21);
            this.RFoutBPathComboBox.TabIndex = 8;
            this.RFoutBPathComboBox.SelectedIndexChanged += new System.EventHandler(this.RFoutBPathComboBox_SelectedIndexChanged);
            // 
            // LDFuncComboBox
            // 
            this.LDFuncComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.LDFuncComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LDFuncComboBox.FormattingEnabled = true;
            this.LDFuncComboBox.Items.AddRange(new object[] {
            "Frac-N Lock-det.",
            "Int-N Lock-det."});
            this.LDFuncComboBox.Location = new System.Drawing.Point(99, 87);
            this.LDFuncComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LDFuncComboBox.Name = "LDFuncComboBox";
            this.LDFuncComboBox.Size = new System.Drawing.Size(114, 21);
            this.LDFuncComboBox.TabIndex = 6;
            this.LDFuncComboBox.SelectedIndexChanged += new System.EventHandler(this.LDFuncComboBox_SelectedIndexChanged);
            // 
            // AutoLDFuncCheckBox
            // 
            this.AutoLDFuncCheckBox.AutoSize = true;
            this.AutoLDFuncCheckBox.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.AutoLDFuncCheckBox.Location = new System.Drawing.Point(2, 84);
            this.AutoLDFuncCheckBox.Name = "AutoLDFuncCheckBox";
            this.AutoLDFuncCheckBox.Size = new System.Drawing.Size(32, 31);
            this.AutoLDFuncCheckBox.TabIndex = 7;
            this.AutoLDFuncCheckBox.Text = "auto";
            this.AutoLDFuncCheckBox.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.AutoLDFuncCheckBox.UseVisualStyleBackColor = true;
            this.AutoLDFuncCheckBox.CheckedChanged += new System.EventHandler(this.AutoLDFuncCheckBox_CheckedChanged);
            // 
            // IntNLabel
            // 
            this.IntNLabel.Location = new System.Drawing.Point(5, 20);
            this.IntNLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.IntNLabel.Name = "IntNLabel";
            this.IntNLabel.Size = new System.Drawing.Size(39, 14);
            this.IntNLabel.TabIndex = 17;
            this.IntNLabel.Text = "IntN:";
            this.IntNLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ModeIntFracLabel
            // 
            this.ModeIntFracLabel.Location = new System.Drawing.Point(128, 20);
            this.ModeIntFracLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ModeIntFracLabel.Name = "ModeIntFracLabel";
            this.ModeIntFracLabel.Size = new System.Drawing.Size(39, 14);
            this.ModeIntFracLabel.TabIndex = 17;
            this.ModeIntFracLabel.Text = "Mode:";
            this.ModeIntFracLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ModLabel
            // 
            this.ModLabel.Location = new System.Drawing.Point(5, 66);
            this.ModLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ModLabel.Name = "ModLabel";
            this.ModLabel.Size = new System.Drawing.Size(39, 14);
            this.ModLabel.TabIndex = 17;
            this.ModLabel.Text = "MOD:";
            this.ModLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ADivLabel
            // 
            this.ADivLabel.Location = new System.Drawing.Point(113, 43);
            this.ADivLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ADivLabel.Name = "ADivLabel";
            this.ADivLabel.Size = new System.Drawing.Size(53, 14);
            this.ADivLabel.TabIndex = 17;
            this.ADivLabel.Text = "A Divider:";
            this.ADivLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PhasePLabel
            // 
            this.PhasePLabel.Location = new System.Drawing.Point(113, 66);
            this.PhasePLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PhasePLabel.Name = "PhasePLabel";
            this.PhasePLabel.Size = new System.Drawing.Size(53, 14);
            this.PhasePLabel.TabIndex = 17;
            this.PhasePLabel.Text = "Phase P:";
            this.PhasePLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // IntNNumUpDown
            // 
            this.IntNNumUpDown.Location = new System.Drawing.Point(48, 18);
            this.IntNNumUpDown.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.IntNNumUpDown.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.IntNNumUpDown.Name = "IntNNumUpDown";
            this.IntNNumUpDown.Size = new System.Drawing.Size(62, 20);
            this.IntNNumUpDown.TabIndex = 0;
            this.IntNNumUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.IntNNumUpDown.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.IntNNumUpDown.ValueChanged += new System.EventHandler(this.IntNNumericUpDown_ValueChanged);
            this.IntNNumUpDown.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.NumericUpDwScrollHandlerFunction);
            // 
            // ModNumUpDown
            // 
            this.ModNumUpDown.Location = new System.Drawing.Point(48, 64);
            this.ModNumUpDown.Maximum = new decimal(new int[] {
            4095,
            0,
            0,
            0});
            this.ModNumUpDown.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.ModNumUpDown.Name = "ModNumUpDown";
            this.ModNumUpDown.Size = new System.Drawing.Size(62, 20);
            this.ModNumUpDown.TabIndex = 2;
            this.ModNumUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ModNumUpDown.Value = new decimal(new int[] {
            125,
            0,
            0,
            0});
            this.ModNumUpDown.ValueChanged += new System.EventHandler(this.ModNumUpDown_ValueChanged);
            this.ModNumUpDown.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.NumericUpDwScrollHandlerFunction);
            // 
            // FracNNumUpDown
            // 
            this.FracNNumUpDown.Location = new System.Drawing.Point(48, 41);
            this.FracNNumUpDown.Maximum = new decimal(new int[] {
            4095,
            0,
            0,
            0});
            this.FracNNumUpDown.Name = "FracNNumUpDown";
            this.FracNNumUpDown.Size = new System.Drawing.Size(62, 20);
            this.FracNNumUpDown.TabIndex = 1;
            this.FracNNumUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.FracNNumUpDown.ValueChanged += new System.EventHandler(this.FracNNumUpDown_ValueChanged);
            this.FracNNumUpDown.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.NumericUpDwScrollHandlerFunction);
            // 
            // PhasePNumericUpDown
            // 
            this.PhasePNumericUpDown.Location = new System.Drawing.Point(170, 64);
            this.PhasePNumericUpDown.Maximum = new decimal(new int[] {
            4095,
            0,
            0,
            0});
            this.PhasePNumericUpDown.Name = "PhasePNumericUpDown";
            this.PhasePNumericUpDown.Size = new System.Drawing.Size(62, 20);
            this.PhasePNumericUpDown.TabIndex = 5;
            this.PhasePNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PhasePNumericUpDown.ValueChanged += new System.EventHandler(this.PhasePNumUpDown_ValueChanged);
            this.PhasePNumericUpDown.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.NumericUpDwScrollHandlerFunction);
            // 
            // RefFreqGroupBox
            // 
            this.RefFreqGroupBox.Controls.Add(this.LDSpeedAdjLabel);
            this.RefFreqGroupBox.Controls.Add(this.RDivUpDown);
            this.RefFreqGroupBox.Controls.Add(this.LDSpeedAdjComboBox);
            this.RefFreqGroupBox.Controls.Add(this.RefFTextBox);
            this.RefFreqGroupBox.Controls.Add(this.DivideBy2CheckBox);
            this.RefFreqGroupBox.Controls.Add(this.AutoLDSpeedAdjCheckBox);
            this.RefFreqGroupBox.Controls.Add(this.RefDoublerCheckBox);
            this.RefFreqGroupBox.Controls.Add(this.InternalLabel);
            this.RefFreqGroupBox.Controls.Add(this.RefFLabel);
            this.RefFreqGroupBox.Controls.Add(this.fPfdLabel);
            this.RefFreqGroupBox.Controls.Add(this.RDivLabel);
            this.RefFreqGroupBox.Controls.Add(this.MHzLabel4);
            this.RefFreqGroupBox.Controls.Add(this.MHzLabel3);
            this.RefFreqGroupBox.Controls.Add(this.pfdFreqLabel);
            this.RefFreqGroupBox.Location = new System.Drawing.Point(5, 160);
            this.RefFreqGroupBox.Name = "RefFreqGroupBox";
            this.RefFreqGroupBox.Size = new System.Drawing.Size(256, 99);
            this.RefFreqGroupBox.TabIndex = 2;
            this.RefFreqGroupBox.TabStop = false;
            this.RefFreqGroupBox.Text = "Reference frequency";
            // 
            // LDSpeedAdjLabel
            // 
            this.LDSpeedAdjLabel.Location = new System.Drawing.Point(28, 73);
            this.LDSpeedAdjLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LDSpeedAdjLabel.Name = "LDSpeedAdjLabel";
            this.LDSpeedAdjLabel.Size = new System.Drawing.Size(111, 14);
            this.LDSpeedAdjLabel.TabIndex = 17;
            this.LDSpeedAdjLabel.Text = "LD speed adjustment:";
            this.LDSpeedAdjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RDivUpDown
            // 
            this.RDivUpDown.Location = new System.Drawing.Point(65, 45);
            this.RDivUpDown.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.RDivUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RDivUpDown.Name = "RDivUpDown";
            this.RDivUpDown.Size = new System.Drawing.Size(62, 20);
            this.RDivUpDown.TabIndex = 1;
            this.RDivUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RDivUpDown.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.RDivUpDown.ValueChanged += new System.EventHandler(this.RDivUpDown_ValueChanged);
            this.RDivUpDown.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.NumericUpDwScrollHandlerFunction);
            // 
            // LDSpeedAdjComboBox
            // 
            this.LDSpeedAdjComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.LDSpeedAdjComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LDSpeedAdjComboBox.FormattingEnabled = true;
            this.LDSpeedAdjComboBox.Items.AddRange(new object[] {
            "fPFD <= 32 MHz",
            "fPFD  >  32 MHz"});
            this.LDSpeedAdjComboBox.Location = new System.Drawing.Point(143, 71);
            this.LDSpeedAdjComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LDSpeedAdjComboBox.Name = "LDSpeedAdjComboBox";
            this.LDSpeedAdjComboBox.Size = new System.Drawing.Size(109, 21);
            this.LDSpeedAdjComboBox.TabIndex = 4;
            this.LDSpeedAdjComboBox.SelectedIndexChanged += new System.EventHandler(this.LDSpeedAdjComboBox_SelectedIndexChanged);
            // 
            // RefFTextBox
            // 
            this.RefFTextBox.BackColor = System.Drawing.Color.White;
            this.RefFTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.RefFTextBox.Location = new System.Drawing.Point(65, 21);
            this.RefFTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RefFTextBox.MaxLength = 10;
            this.RefFTextBox.Name = "RefFTextBox";
            this.RefFTextBox.Size = new System.Drawing.Size(68, 20);
            this.RefFTextBox.TabIndex = 0;
            this.RefFTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RefFTextBox.TextChanged += new System.EventHandler(this.RefFTextBox_TextChanged);
            this.RefFTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RefFTextBox_KeyDown);
            this.RefFTextBox.LostFocus += new System.EventHandler(this.RefFTextBox_LostFocus);
            this.RefFTextBox.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.FrequencyTextBox_MouseWheel);
            // 
            // DivideBy2CheckBox
            // 
            this.DivideBy2CheckBox.AutoSize = true;
            this.DivideBy2CheckBox.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.DivideBy2CheckBox.Location = new System.Drawing.Point(219, 11);
            this.DivideBy2CheckBox.Name = "DivideBy2CheckBox";
            this.DivideBy2CheckBox.Size = new System.Drawing.Size(23, 31);
            this.DivideBy2CheckBox.TabIndex = 3;
            this.DivideBy2CheckBox.Text = "÷2";
            this.DivideBy2CheckBox.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.DivideBy2CheckBox.UseVisualStyleBackColor = true;
            this.DivideBy2CheckBox.CheckedChanged += new System.EventHandler(this.DivideBy2CheckBox_CheckedChanged);
            // 
            // AutoLDSpeedAdjCheckBox
            // 
            this.AutoLDSpeedAdjCheckBox.AutoSize = true;
            this.AutoLDSpeedAdjCheckBox.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.AutoLDSpeedAdjCheckBox.Location = new System.Drawing.Point(2, 66);
            this.AutoLDSpeedAdjCheckBox.Name = "AutoLDSpeedAdjCheckBox";
            this.AutoLDSpeedAdjCheckBox.Size = new System.Drawing.Size(32, 31);
            this.AutoLDSpeedAdjCheckBox.TabIndex = 5;
            this.AutoLDSpeedAdjCheckBox.Text = "auto";
            this.AutoLDSpeedAdjCheckBox.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.AutoLDSpeedAdjCheckBox.UseVisualStyleBackColor = true;
            this.AutoLDSpeedAdjCheckBox.CheckedChanged += new System.EventHandler(this.AutoLDSpeedAdjCheckBox_CheckedChanged);
            // 
            // RefDoublerCheckBox
            // 
            this.RefDoublerCheckBox.AutoSize = true;
            this.RefDoublerCheckBox.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.RefDoublerCheckBox.Location = new System.Drawing.Point(190, 11);
            this.RefDoublerCheckBox.Name = "RefDoublerCheckBox";
            this.RefDoublerCheckBox.Size = new System.Drawing.Size(22, 31);
            this.RefDoublerCheckBox.TabIndex = 2;
            this.RefDoublerCheckBox.Text = "x2";
            this.RefDoublerCheckBox.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RefDoublerCheckBox.UseVisualStyleBackColor = true;
            this.RefDoublerCheckBox.CheckedChanged += new System.EventHandler(this.DoubleRefFCheckBox_CheckedChanged);
            // 
            // InternalLabel
            // 
            this.InternalLabel.Location = new System.Drawing.Point(9, 12);
            this.InternalLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.InternalLabel.Name = "InternalLabel";
            this.InternalLabel.Size = new System.Drawing.Size(52, 14);
            this.InternalLabel.TabIndex = 17;
            this.InternalLabel.Text = "Internal";
            this.InternalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RefFLabel
            // 
            this.RefFLabel.Location = new System.Drawing.Point(9, 24);
            this.RefFLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RefFLabel.Name = "RefFLabel";
            this.RefFLabel.Size = new System.Drawing.Size(52, 14);
            this.RefFLabel.TabIndex = 17;
            this.RefFLabel.Text = "Ref. freq:";
            this.RefFLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // fPfdLabel
            // 
            this.fPfdLabel.Location = new System.Drawing.Point(135, 47);
            this.fPfdLabel.Name = "fPfdLabel";
            this.fPfdLabel.Size = new System.Drawing.Size(32, 13);
            this.fPfdLabel.TabIndex = 20;
            this.fPfdLabel.Text = "fPFD:";
            this.fPfdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RDivLabel
            // 
            this.RDivLabel.Location = new System.Drawing.Point(5, 47);
            this.RDivLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RDivLabel.Name = "RDivLabel";
            this.RDivLabel.Size = new System.Drawing.Size(56, 14);
            this.RDivLabel.TabIndex = 17;
            this.RDivLabel.Text = "R Divider:";
            this.RDivLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MHzLabel4
            // 
            this.MHzLabel4.Location = new System.Drawing.Point(226, 47);
            this.MHzLabel4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MHzLabel4.Name = "MHzLabel4";
            this.MHzLabel4.Size = new System.Drawing.Size(30, 14);
            this.MHzLabel4.TabIndex = 17;
            this.MHzLabel4.Text = "MHz";
            this.MHzLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MHzLabel3
            // 
            this.MHzLabel3.Location = new System.Drawing.Point(137, 23);
            this.MHzLabel3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MHzLabel3.Name = "MHzLabel3";
            this.MHzLabel3.Size = new System.Drawing.Size(30, 14);
            this.MHzLabel3.TabIndex = 17;
            this.MHzLabel3.Text = "MHz";
            this.MHzLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pfdFreqLabel
            // 
            this.pfdFreqLabel.Location = new System.Drawing.Point(166, 47);
            this.pfdFreqLabel.Name = "pfdFreqLabel";
            this.pfdFreqLabel.Size = new System.Drawing.Size(62, 13);
            this.pfdFreqLabel.TabIndex = 20;
            this.pfdFreqLabel.Text = "10.000 000";
            this.pfdFreqLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RegistersMemoryPage
            // 
            this.RegistersMemoryPage.Controls.Add(this.SynthOutputsInfoGroupBox);
            this.RegistersMemoryPage.Controls.Add(this.SyntModuleControlsGroupBox);
            this.RegistersMemoryPage.Controls.Add(this.RegMemoryGroupBox);
            this.RegistersMemoryPage.Controls.Add(this.ImportMem4Button);
            this.RegistersMemoryPage.Controls.Add(this.ImportMem3Button);
            this.RegistersMemoryPage.Controls.Add(this.ImportMem2Button);
            this.RegistersMemoryPage.Controls.Add(this.ImportMem1Button);
            this.RegistersMemoryPage.Controls.Add(this.MemLoadFromFileButton);
            this.RegistersMemoryPage.Controls.Add(this.MemSaveIntoFileButton);
            this.RegistersMemoryPage.Controls.Add(this.LoadRegMemory);
            this.RegistersMemoryPage.Controls.Add(this.SaveRegMemory);
            this.RegistersMemoryPage.Location = new System.Drawing.Point(4, 22);
            this.RegistersMemoryPage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RegistersMemoryPage.Name = "RegistersMemoryPage";
            this.RegistersMemoryPage.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RegistersMemoryPage.Size = new System.Drawing.Size(530, 662);
            this.RegistersMemoryPage.TabIndex = 1;
            this.RegistersMemoryPage.Text = "Registers memory";
            this.RegistersMemoryPage.UseVisualStyleBackColor = true;
            // 
            // SynthOutputsInfoGroupBox
            // 
            this.SynthOutputsInfoGroupBox.Controls.Add(this.label13);
            this.SynthOutputsInfoGroupBox.Controls.Add(this.label12);
            this.SynthOutputsInfoGroupBox.Controls.Add(this.label10);
            this.SynthOutputsInfoGroupBox.Controls.Add(this.Mem1Freq2ShowLabel);
            this.SynthOutputsInfoGroupBox.Controls.Add(this.label11);
            this.SynthOutputsInfoGroupBox.Controls.Add(this.Mem1Freq1ShowLabel);
            this.SynthOutputsInfoGroupBox.Controls.Add(this.FreqOut2MemLabel);
            this.SynthOutputsInfoGroupBox.Controls.Add(this.Mem4Freq2ShowLabel);
            this.SynthOutputsInfoGroupBox.Controls.Add(this.FreqOut1MemLabel);
            this.SynthOutputsInfoGroupBox.Controls.Add(this.Mem4Freq1ShowLabel);
            this.SynthOutputsInfoGroupBox.Controls.Add(this.MemPwrALabel);
            this.SynthOutputsInfoGroupBox.Controls.Add(this.Mem3Freq2ShowLabel);
            this.SynthOutputsInfoGroupBox.Controls.Add(this.Mem1PwrAShowLabel);
            this.SynthOutputsInfoGroupBox.Controls.Add(this.Mem3Freq1ShowLabel);
            this.SynthOutputsInfoGroupBox.Controls.Add(this.Mem1PwrBShowLabel);
            this.SynthOutputsInfoGroupBox.Controls.Add(this.Mem2Freq2ShowLabel);
            this.SynthOutputsInfoGroupBox.Controls.Add(this.Mem2PwrAShowLabel);
            this.SynthOutputsInfoGroupBox.Controls.Add(this.Mem2Freq1ShowLabel);
            this.SynthOutputsInfoGroupBox.Controls.Add(this.Mem3PwrAShowLabel);
            this.SynthOutputsInfoGroupBox.Controls.Add(this.Mem4PwrAShowLabel);
            this.SynthOutputsInfoGroupBox.Controls.Add(this.Mem2PwrBShowLabel);
            this.SynthOutputsInfoGroupBox.Controls.Add(this.Mem3PwrBShowLabel);
            this.SynthOutputsInfoGroupBox.Controls.Add(this.Mem4PwrBShowLabel);
            this.SynthOutputsInfoGroupBox.Controls.Add(this.MemPwrBLabel);
            this.SynthOutputsInfoGroupBox.Location = new System.Drawing.Point(2, 304);
            this.SynthOutputsInfoGroupBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SynthOutputsInfoGroupBox.Name = "SynthOutputsInfoGroupBox";
            this.SynthOutputsInfoGroupBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SynthOutputsInfoGroupBox.Size = new System.Drawing.Size(390, 141);
            this.SynthOutputsInfoGroupBox.TabIndex = 1;
            this.SynthOutputsInfoGroupBox.TabStop = false;
            this.SynthOutputsInfoGroupBox.Text = "Synthesizer outputs info for each memory";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(314, 24);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 14);
            this.label13.TabIndex = 10;
            this.label13.Text = "Memory 4";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(233, 24);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 14);
            this.label12.TabIndex = 10;
            this.label12.Text = "Memory 3";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(73, 24);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 14);
            this.label10.TabIndex = 10;
            this.label10.Text = "Memory 1";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Mem1Freq2ShowLabel
            // 
            this.Mem1Freq2ShowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Mem1Freq2ShowLabel.Location = new System.Drawing.Point(63, 69);
            this.Mem1Freq2ShowLabel.Name = "Mem1Freq2ShowLabel";
            this.Mem1Freq2ShowLabel.Size = new System.Drawing.Size(83, 13);
            this.Mem1Freq2ShowLabel.TabIndex = 22;
            this.Mem1Freq2ShowLabel.Text = "12000.000 000";
            this.Mem1Freq2ShowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(153, 24);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 14);
            this.label11.TabIndex = 10;
            this.label11.Text = "Memory 2";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Mem1Freq1ShowLabel
            // 
            this.Mem1Freq1ShowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Mem1Freq1ShowLabel.Location = new System.Drawing.Point(63, 46);
            this.Mem1Freq1ShowLabel.Name = "Mem1Freq1ShowLabel";
            this.Mem1Freq1ShowLabel.Size = new System.Drawing.Size(83, 13);
            this.Mem1Freq1ShowLabel.TabIndex = 0;
            this.Mem1Freq1ShowLabel.Text = "6000.000 000";
            this.Mem1Freq1ShowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FreqOut2MemLabel
            // 
            this.FreqOut2MemLabel.AutoSize = true;
            this.FreqOut2MemLabel.Location = new System.Drawing.Point(4, 69);
            this.FreqOut2MemLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.FreqOut2MemLabel.Name = "FreqOut2MemLabel";
            this.FreqOut2MemLabel.Size = new System.Drawing.Size(61, 13);
            this.FreqOut2MemLabel.TabIndex = 16;
            this.FreqOut2MemLabel.Text = "Freq. out 2:";
            // 
            // Mem4Freq2ShowLabel
            // 
            this.Mem4Freq2ShowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Mem4Freq2ShowLabel.Location = new System.Drawing.Point(304, 69);
            this.Mem4Freq2ShowLabel.Name = "Mem4Freq2ShowLabel";
            this.Mem4Freq2ShowLabel.Size = new System.Drawing.Size(83, 13);
            this.Mem4Freq2ShowLabel.TabIndex = 22;
            this.Mem4Freq2ShowLabel.Text = "12000.000 000";
            this.Mem4Freq2ShowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FreqOut1MemLabel
            // 
            this.FreqOut1MemLabel.AutoSize = true;
            this.FreqOut1MemLabel.Location = new System.Drawing.Point(4, 46);
            this.FreqOut1MemLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.FreqOut1MemLabel.Name = "FreqOut1MemLabel";
            this.FreqOut1MemLabel.Size = new System.Drawing.Size(61, 13);
            this.FreqOut1MemLabel.TabIndex = 16;
            this.FreqOut1MemLabel.Text = "Freq. out 1:";
            // 
            // Mem4Freq1ShowLabel
            // 
            this.Mem4Freq1ShowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Mem4Freq1ShowLabel.Location = new System.Drawing.Point(304, 46);
            this.Mem4Freq1ShowLabel.Name = "Mem4Freq1ShowLabel";
            this.Mem4Freq1ShowLabel.Size = new System.Drawing.Size(83, 13);
            this.Mem4Freq1ShowLabel.TabIndex = 22;
            this.Mem4Freq1ShowLabel.Text = "6000.000 000";
            this.Mem4Freq1ShowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MemPwrALabel
            // 
            this.MemPwrALabel.AutoSize = true;
            this.MemPwrALabel.Location = new System.Drawing.Point(8, 92);
            this.MemPwrALabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MemPwrALabel.Name = "MemPwrALabel";
            this.MemPwrALabel.Size = new System.Drawing.Size(59, 13);
            this.MemPwrALabel.TabIndex = 16;
            this.MemPwrALabel.Text = "Pwr. out A:";
            // 
            // Mem3Freq2ShowLabel
            // 
            this.Mem3Freq2ShowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Mem3Freq2ShowLabel.Location = new System.Drawing.Point(224, 69);
            this.Mem3Freq2ShowLabel.Name = "Mem3Freq2ShowLabel";
            this.Mem3Freq2ShowLabel.Size = new System.Drawing.Size(83, 13);
            this.Mem3Freq2ShowLabel.TabIndex = 22;
            this.Mem3Freq2ShowLabel.Text = "12000.000 000";
            this.Mem3Freq2ShowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Mem1PwrAShowLabel
            // 
            this.Mem1PwrAShowLabel.Location = new System.Drawing.Point(68, 92);
            this.Mem1PwrAShowLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Mem1PwrAShowLabel.Name = "Mem1PwrAShowLabel";
            this.Mem1PwrAShowLabel.Size = new System.Drawing.Size(72, 14);
            this.Mem1PwrAShowLabel.TabIndex = 16;
            this.Mem1PwrAShowLabel.Text = "+ 5 dBm";
            this.Mem1PwrAShowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Mem3Freq1ShowLabel
            // 
            this.Mem3Freq1ShowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Mem3Freq1ShowLabel.Location = new System.Drawing.Point(224, 46);
            this.Mem3Freq1ShowLabel.Name = "Mem3Freq1ShowLabel";
            this.Mem3Freq1ShowLabel.Size = new System.Drawing.Size(83, 13);
            this.Mem3Freq1ShowLabel.TabIndex = 22;
            this.Mem3Freq1ShowLabel.Text = "6000.000 000";
            this.Mem3Freq1ShowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Mem1PwrBShowLabel
            // 
            this.Mem1PwrBShowLabel.Location = new System.Drawing.Point(68, 115);
            this.Mem1PwrBShowLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Mem1PwrBShowLabel.Name = "Mem1PwrBShowLabel";
            this.Mem1PwrBShowLabel.Size = new System.Drawing.Size(72, 14);
            this.Mem1PwrBShowLabel.TabIndex = 16;
            this.Mem1PwrBShowLabel.Text = "+ 2 dBm";
            this.Mem1PwrBShowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Mem2Freq2ShowLabel
            // 
            this.Mem2Freq2ShowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Mem2Freq2ShowLabel.Location = new System.Drawing.Point(143, 69);
            this.Mem2Freq2ShowLabel.Name = "Mem2Freq2ShowLabel";
            this.Mem2Freq2ShowLabel.Size = new System.Drawing.Size(83, 13);
            this.Mem2Freq2ShowLabel.TabIndex = 22;
            this.Mem2Freq2ShowLabel.Text = "12000.000 000";
            this.Mem2Freq2ShowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Mem2PwrAShowLabel
            // 
            this.Mem2PwrAShowLabel.Location = new System.Drawing.Point(148, 92);
            this.Mem2PwrAShowLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Mem2PwrAShowLabel.Name = "Mem2PwrAShowLabel";
            this.Mem2PwrAShowLabel.Size = new System.Drawing.Size(72, 14);
            this.Mem2PwrAShowLabel.TabIndex = 16;
            this.Mem2PwrAShowLabel.Text = "+ 5 dBm";
            this.Mem2PwrAShowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Mem2Freq1ShowLabel
            // 
            this.Mem2Freq1ShowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Mem2Freq1ShowLabel.Location = new System.Drawing.Point(143, 46);
            this.Mem2Freq1ShowLabel.Name = "Mem2Freq1ShowLabel";
            this.Mem2Freq1ShowLabel.Size = new System.Drawing.Size(83, 13);
            this.Mem2Freq1ShowLabel.TabIndex = 22;
            this.Mem2Freq1ShowLabel.Text = "6000.000 000";
            this.Mem2Freq1ShowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Mem3PwrAShowLabel
            // 
            this.Mem3PwrAShowLabel.Location = new System.Drawing.Point(229, 92);
            this.Mem3PwrAShowLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Mem3PwrAShowLabel.Name = "Mem3PwrAShowLabel";
            this.Mem3PwrAShowLabel.Size = new System.Drawing.Size(72, 14);
            this.Mem3PwrAShowLabel.TabIndex = 16;
            this.Mem3PwrAShowLabel.Text = "+ 5 dBm";
            this.Mem3PwrAShowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Mem4PwrAShowLabel
            // 
            this.Mem4PwrAShowLabel.Location = new System.Drawing.Point(309, 92);
            this.Mem4PwrAShowLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Mem4PwrAShowLabel.Name = "Mem4PwrAShowLabel";
            this.Mem4PwrAShowLabel.Size = new System.Drawing.Size(72, 14);
            this.Mem4PwrAShowLabel.TabIndex = 16;
            this.Mem4PwrAShowLabel.Text = "+ 5 dBm";
            this.Mem4PwrAShowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Mem2PwrBShowLabel
            // 
            this.Mem2PwrBShowLabel.Location = new System.Drawing.Point(148, 115);
            this.Mem2PwrBShowLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Mem2PwrBShowLabel.Name = "Mem2PwrBShowLabel";
            this.Mem2PwrBShowLabel.Size = new System.Drawing.Size(72, 14);
            this.Mem2PwrBShowLabel.TabIndex = 16;
            this.Mem2PwrBShowLabel.Text = "+ 2 dBm";
            this.Mem2PwrBShowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Mem3PwrBShowLabel
            // 
            this.Mem3PwrBShowLabel.Location = new System.Drawing.Point(229, 115);
            this.Mem3PwrBShowLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Mem3PwrBShowLabel.Name = "Mem3PwrBShowLabel";
            this.Mem3PwrBShowLabel.Size = new System.Drawing.Size(72, 14);
            this.Mem3PwrBShowLabel.TabIndex = 16;
            this.Mem3PwrBShowLabel.Text = "!!!+5 dBm!!!";
            this.Mem3PwrBShowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Mem4PwrBShowLabel
            // 
            this.Mem4PwrBShowLabel.Location = new System.Drawing.Point(309, 115);
            this.Mem4PwrBShowLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Mem4PwrBShowLabel.Name = "Mem4PwrBShowLabel";
            this.Mem4PwrBShowLabel.Size = new System.Drawing.Size(72, 14);
            this.Mem4PwrBShowLabel.TabIndex = 16;
            this.Mem4PwrBShowLabel.Text = "+ 2 dBm";
            this.Mem4PwrBShowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MemPwrBLabel
            // 
            this.MemPwrBLabel.AutoSize = true;
            this.MemPwrBLabel.Location = new System.Drawing.Point(8, 115);
            this.MemPwrBLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MemPwrBLabel.Name = "MemPwrBLabel";
            this.MemPwrBLabel.Size = new System.Drawing.Size(59, 13);
            this.MemPwrBLabel.TabIndex = 16;
            this.MemPwrBLabel.Text = "Pwr. out B:";
            // 
            // SyntModuleControlsGroupBox
            // 
            this.SyntModuleControlsGroupBox.Controls.Add(this.label3);
            this.SyntModuleControlsGroupBox.Controls.Add(this.label4);
            this.SyntModuleControlsGroupBox.Controls.Add(this.label8);
            this.SyntModuleControlsGroupBox.Controls.Add(this.label9);
            this.SyntModuleControlsGroupBox.Controls.Add(this.Mem4ActOut1ShowLabel);
            this.SyntModuleControlsGroupBox.Controls.Add(this.MemoryOutput1Label);
            this.SyntModuleControlsGroupBox.Controls.Add(this.MemoryOutput2Label);
            this.SyntModuleControlsGroupBox.Controls.Add(this.MemoryRefLabel);
            this.SyntModuleControlsGroupBox.Controls.Add(this.Mem1ActOut1ShowLabel);
            this.SyntModuleControlsGroupBox.Controls.Add(this.Mem1ActOut2ShowLabel);
            this.SyntModuleControlsGroupBox.Controls.Add(this.Mem2ActOut1ShowLabel);
            this.SyntModuleControlsGroupBox.Controls.Add(this.Mem3ActOut1ShowLabel);
            this.SyntModuleControlsGroupBox.Controls.Add(this.Mem2ActOut2ShowLabel);
            this.SyntModuleControlsGroupBox.Controls.Add(this.Mem4RefShowLabel);
            this.SyntModuleControlsGroupBox.Controls.Add(this.Mem3ActOut2ShowLabel);
            this.SyntModuleControlsGroupBox.Controls.Add(this.Mem3RefShowLabel);
            this.SyntModuleControlsGroupBox.Controls.Add(this.Mem4ActOut2ShowLabel);
            this.SyntModuleControlsGroupBox.Controls.Add(this.Mem2RefShowLabel);
            this.SyntModuleControlsGroupBox.Controls.Add(this.Mem1RefShowLabel);
            this.SyntModuleControlsGroupBox.Location = new System.Drawing.Point(2, 188);
            this.SyntModuleControlsGroupBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SyntModuleControlsGroupBox.Name = "SyntModuleControlsGroupBox";
            this.SyntModuleControlsGroupBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SyntModuleControlsGroupBox.Size = new System.Drawing.Size(390, 110);
            this.SyntModuleControlsGroupBox.TabIndex = 24;
            this.SyntModuleControlsGroupBox.TabStop = false;
            this.SyntModuleControlsGroupBox.Text = "Synthesizer module controls for each memory";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(314, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 10;
            this.label3.Text = "Memory 4";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(233, 22);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 10;
            this.label4.Text = "Memory 3";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(153, 22);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 14);
            this.label8.TabIndex = 10;
            this.label8.Text = "Memory 2";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(73, 22);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 14);
            this.label9.TabIndex = 10;
            this.label9.Text = "Memory 1";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Mem4ActOut1ShowLabel
            // 
            this.Mem4ActOut1ShowLabel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Mem4ActOut1ShowLabel.Location = new System.Drawing.Point(331, 45);
            this.Mem4ActOut1ShowLabel.Name = "Mem4ActOut1ShowLabel";
            this.Mem4ActOut1ShowLabel.Size = new System.Drawing.Size(29, 13);
            this.Mem4ActOut1ShowLabel.TabIndex = 20;
            this.Mem4ActOut1ShowLabel.Text = "OFF";
            this.Mem4ActOut1ShowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Mem4ActOut1ShowLabel.Click += new System.EventHandler(this.MemActOutShowLabel_Click);
            // 
            // MemoryOutput1Label
            // 
            this.MemoryOutput1Label.AutoSize = true;
            this.MemoryOutput1Label.Location = new System.Drawing.Point(15, 45);
            this.MemoryOutput1Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MemoryOutput1Label.Name = "MemoryOutput1Label";
            this.MemoryOutput1Label.Size = new System.Drawing.Size(51, 13);
            this.MemoryOutput1Label.TabIndex = 16;
            this.MemoryOutput1Label.Text = "Output 1:";
            // 
            // MemoryOutput2Label
            // 
            this.MemoryOutput2Label.AutoSize = true;
            this.MemoryOutput2Label.Location = new System.Drawing.Point(15, 67);
            this.MemoryOutput2Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MemoryOutput2Label.Name = "MemoryOutput2Label";
            this.MemoryOutput2Label.Size = new System.Drawing.Size(51, 13);
            this.MemoryOutput2Label.TabIndex = 16;
            this.MemoryOutput2Label.Text = "Output 2:";
            // 
            // MemoryRefLabel
            // 
            this.MemoryRefLabel.AutoSize = true;
            this.MemoryRefLabel.Location = new System.Drawing.Point(7, 89);
            this.MemoryRefLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MemoryRefLabel.Name = "MemoryRefLabel";
            this.MemoryRefLabel.Size = new System.Drawing.Size(60, 13);
            this.MemoryRefLabel.TabIndex = 16;
            this.MemoryRefLabel.Text = "Reference:";
            // 
            // Mem1ActOut1ShowLabel
            // 
            this.Mem1ActOut1ShowLabel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Mem1ActOut1ShowLabel.Location = new System.Drawing.Point(90, 45);
            this.Mem1ActOut1ShowLabel.Name = "Mem1ActOut1ShowLabel";
            this.Mem1ActOut1ShowLabel.Size = new System.Drawing.Size(29, 13);
            this.Mem1ActOut1ShowLabel.TabIndex = 0;
            this.Mem1ActOut1ShowLabel.Text = "OFF";
            this.Mem1ActOut1ShowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Mem1ActOut1ShowLabel.Click += new System.EventHandler(this.MemActOutShowLabel_Click);
            // 
            // Mem1ActOut2ShowLabel
            // 
            this.Mem1ActOut2ShowLabel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Mem1ActOut2ShowLabel.Location = new System.Drawing.Point(90, 68);
            this.Mem1ActOut2ShowLabel.Name = "Mem1ActOut2ShowLabel";
            this.Mem1ActOut2ShowLabel.Size = new System.Drawing.Size(29, 13);
            this.Mem1ActOut2ShowLabel.TabIndex = 1;
            this.Mem1ActOut2ShowLabel.Text = "OFF";
            this.Mem1ActOut2ShowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Mem1ActOut2ShowLabel.Click += new System.EventHandler(this.MemActOutShowLabel_Click);
            // 
            // Mem2ActOut1ShowLabel
            // 
            this.Mem2ActOut1ShowLabel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Mem2ActOut1ShowLabel.Location = new System.Drawing.Point(170, 45);
            this.Mem2ActOut1ShowLabel.Name = "Mem2ActOut1ShowLabel";
            this.Mem2ActOut1ShowLabel.Size = new System.Drawing.Size(29, 13);
            this.Mem2ActOut1ShowLabel.TabIndex = 20;
            this.Mem2ActOut1ShowLabel.Text = "OFF";
            this.Mem2ActOut1ShowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Mem2ActOut1ShowLabel.Click += new System.EventHandler(this.MemActOutShowLabel_Click);
            // 
            // Mem3ActOut1ShowLabel
            // 
            this.Mem3ActOut1ShowLabel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Mem3ActOut1ShowLabel.Location = new System.Drawing.Point(250, 45);
            this.Mem3ActOut1ShowLabel.Name = "Mem3ActOut1ShowLabel";
            this.Mem3ActOut1ShowLabel.Size = new System.Drawing.Size(29, 13);
            this.Mem3ActOut1ShowLabel.TabIndex = 20;
            this.Mem3ActOut1ShowLabel.Text = "OFF";
            this.Mem3ActOut1ShowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Mem3ActOut1ShowLabel.Click += new System.EventHandler(this.MemActOutShowLabel_Click);
            // 
            // Mem2ActOut2ShowLabel
            // 
            this.Mem2ActOut2ShowLabel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Mem2ActOut2ShowLabel.Location = new System.Drawing.Point(170, 68);
            this.Mem2ActOut2ShowLabel.Name = "Mem2ActOut2ShowLabel";
            this.Mem2ActOut2ShowLabel.Size = new System.Drawing.Size(29, 13);
            this.Mem2ActOut2ShowLabel.TabIndex = 20;
            this.Mem2ActOut2ShowLabel.Text = "OFF";
            this.Mem2ActOut2ShowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Mem2ActOut2ShowLabel.Click += new System.EventHandler(this.MemActOutShowLabel_Click);
            // 
            // Mem4RefShowLabel
            // 
            this.Mem4RefShowLabel.Location = new System.Drawing.Point(317, 88);
            this.Mem4RefShowLabel.Name = "Mem4RefShowLabel";
            this.Mem4RefShowLabel.Size = new System.Drawing.Size(56, 15);
            this.Mem4RefShowLabel.TabIndex = 20;
            this.Mem4RefShowLabel.Text = "External";
            this.Mem4RefShowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Mem4RefShowLabel.Click += new System.EventHandler(this.MemRefShowLabel_Click);
            // 
            // Mem3ActOut2ShowLabel
            // 
            this.Mem3ActOut2ShowLabel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Mem3ActOut2ShowLabel.Location = new System.Drawing.Point(250, 68);
            this.Mem3ActOut2ShowLabel.Name = "Mem3ActOut2ShowLabel";
            this.Mem3ActOut2ShowLabel.Size = new System.Drawing.Size(29, 13);
            this.Mem3ActOut2ShowLabel.TabIndex = 20;
            this.Mem3ActOut2ShowLabel.Text = "OFF";
            this.Mem3ActOut2ShowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Mem3ActOut2ShowLabel.Click += new System.EventHandler(this.MemActOutShowLabel_Click);
            // 
            // Mem3RefShowLabel
            // 
            this.Mem3RefShowLabel.Location = new System.Drawing.Point(237, 88);
            this.Mem3RefShowLabel.Name = "Mem3RefShowLabel";
            this.Mem3RefShowLabel.Size = new System.Drawing.Size(56, 15);
            this.Mem3RefShowLabel.TabIndex = 20;
            this.Mem3RefShowLabel.Text = "External";
            this.Mem3RefShowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Mem3RefShowLabel.Click += new System.EventHandler(this.MemRefShowLabel_Click);
            // 
            // Mem4ActOut2ShowLabel
            // 
            this.Mem4ActOut2ShowLabel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Mem4ActOut2ShowLabel.Location = new System.Drawing.Point(331, 68);
            this.Mem4ActOut2ShowLabel.Name = "Mem4ActOut2ShowLabel";
            this.Mem4ActOut2ShowLabel.Size = new System.Drawing.Size(29, 13);
            this.Mem4ActOut2ShowLabel.TabIndex = 20;
            this.Mem4ActOut2ShowLabel.Text = "OFF";
            this.Mem4ActOut2ShowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Mem4ActOut2ShowLabel.Click += new System.EventHandler(this.MemActOutShowLabel_Click);
            // 
            // Mem2RefShowLabel
            // 
            this.Mem2RefShowLabel.Location = new System.Drawing.Point(157, 88);
            this.Mem2RefShowLabel.Name = "Mem2RefShowLabel";
            this.Mem2RefShowLabel.Size = new System.Drawing.Size(56, 15);
            this.Mem2RefShowLabel.TabIndex = 20;
            this.Mem2RefShowLabel.Text = "External";
            this.Mem2RefShowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Mem2RefShowLabel.Click += new System.EventHandler(this.MemRefShowLabel_Click);
            // 
            // Mem1RefShowLabel
            // 
            this.Mem1RefShowLabel.Location = new System.Drawing.Point(76, 88);
            this.Mem1RefShowLabel.Name = "Mem1RefShowLabel";
            this.Mem1RefShowLabel.Size = new System.Drawing.Size(56, 15);
            this.Mem1RefShowLabel.TabIndex = 2;
            this.Mem1RefShowLabel.Text = "External";
            this.Mem1RefShowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Mem1RefShowLabel.Click += new System.EventHandler(this.MemRefShowLabel_Click);
            // 
            // RegMemoryGroupBox
            // 
            this.RegMemoryGroupBox.Controls.Add(this.SavReg0Label);
            this.RegMemoryGroupBox.Controls.Add(this.R5M1);
            this.RegMemoryGroupBox.Controls.Add(this.SavReg5Label);
            this.RegMemoryGroupBox.Controls.Add(this.R5M2);
            this.RegMemoryGroupBox.Controls.Add(this.R4M1);
            this.RegMemoryGroupBox.Controls.Add(this.R5M3);
            this.RegMemoryGroupBox.Controls.Add(this.R4M2);
            this.RegMemoryGroupBox.Controls.Add(this.R5M4);
            this.RegMemoryGroupBox.Controls.Add(this.R4M3);
            this.RegMemoryGroupBox.Controls.Add(this.R4M4);
            this.RegMemoryGroupBox.Controls.Add(this.SavReg4Label);
            this.RegMemoryGroupBox.Controls.Add(this.R3M1);
            this.RegMemoryGroupBox.Controls.Add(this.R3M2);
            this.RegMemoryGroupBox.Controls.Add(this.R3M3);
            this.RegMemoryGroupBox.Controls.Add(this.R3M4);
            this.RegMemoryGroupBox.Controls.Add(this.R2M1);
            this.RegMemoryGroupBox.Controls.Add(this.R2M2);
            this.RegMemoryGroupBox.Controls.Add(this.R2M3);
            this.RegMemoryGroupBox.Controls.Add(this.R2M4);
            this.RegMemoryGroupBox.Controls.Add(this.SavReg2Label);
            this.RegMemoryGroupBox.Controls.Add(this.R1M1);
            this.RegMemoryGroupBox.Controls.Add(this.SavReg3Label);
            this.RegMemoryGroupBox.Controls.Add(this.R1M2);
            this.RegMemoryGroupBox.Controls.Add(this.R1M3);
            this.RegMemoryGroupBox.Controls.Add(this.R1M4);
            this.RegMemoryGroupBox.Controls.Add(this.SavReg1Label);
            this.RegMemoryGroupBox.Controls.Add(this.R0M4);
            this.RegMemoryGroupBox.Controls.Add(this.Mem1Label);
            this.RegMemoryGroupBox.Controls.Add(this.Mem2Label);
            this.RegMemoryGroupBox.Controls.Add(this.Mem3Label);
            this.RegMemoryGroupBox.Controls.Add(this.Mem4Label);
            this.RegMemoryGroupBox.Controls.Add(this.R0M3);
            this.RegMemoryGroupBox.Controls.Add(this.R0M1);
            this.RegMemoryGroupBox.Controls.Add(this.R0M2);
            this.RegMemoryGroupBox.Location = new System.Drawing.Point(2, 4);
            this.RegMemoryGroupBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RegMemoryGroupBox.Name = "RegMemoryGroupBox";
            this.RegMemoryGroupBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RegMemoryGroupBox.Size = new System.Drawing.Size(390, 180);
            this.RegMemoryGroupBox.TabIndex = 0;
            this.RegMemoryGroupBox.TabStop = false;
            this.RegMemoryGroupBox.Text = "Register controls for each memory";
            // 
            // SavReg0Label
            // 
            this.SavReg0Label.AutoSize = true;
            this.SavReg0Label.Location = new System.Drawing.Point(8, 41);
            this.SavReg0Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SavReg0Label.Name = "SavReg0Label";
            this.SavReg0Label.Size = new System.Drawing.Size(58, 13);
            this.SavReg0Label.TabIndex = 10;
            this.SavReg0Label.Text = "Register 0:";
            // 
            // R5M1
            // 
            this.R5M1.BackColor = System.Drawing.Color.White;
            this.R5M1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R5M1.Location = new System.Drawing.Point(73, 153);
            this.R5M1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.R5M1.MaxLength = 8;
            this.R5M1.Name = "R5M1";
            this.R5M1.Size = new System.Drawing.Size(64, 20);
            this.R5M1.TabIndex = 5;
            this.R5M1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.R5M1.TextChanged += new System.EventHandler(this.MemoryRegister_TextChanged);
            // 
            // SavReg5Label
            // 
            this.SavReg5Label.AutoSize = true;
            this.SavReg5Label.Location = new System.Drawing.Point(8, 155);
            this.SavReg5Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SavReg5Label.Name = "SavReg5Label";
            this.SavReg5Label.Size = new System.Drawing.Size(58, 13);
            this.SavReg5Label.TabIndex = 16;
            this.SavReg5Label.Text = "Register 5:";
            // 
            // R5M2
            // 
            this.R5M2.BackColor = System.Drawing.Color.White;
            this.R5M2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R5M2.Location = new System.Drawing.Point(153, 153);
            this.R5M2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.R5M2.MaxLength = 8;
            this.R5M2.Name = "R5M2";
            this.R5M2.Size = new System.Drawing.Size(64, 20);
            this.R5M2.TabIndex = 11;
            this.R5M2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.R5M2.TextChanged += new System.EventHandler(this.MemoryRegister_TextChanged);
            // 
            // R4M1
            // 
            this.R4M1.BackColor = System.Drawing.Color.White;
            this.R4M1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R4M1.Location = new System.Drawing.Point(73, 130);
            this.R4M1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.R4M1.MaxLength = 8;
            this.R4M1.Name = "R4M1";
            this.R4M1.Size = new System.Drawing.Size(64, 20);
            this.R4M1.TabIndex = 4;
            this.R4M1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.R4M1.TextChanged += new System.EventHandler(this.MemoryRegister_TextChanged);
            // 
            // R5M3
            // 
            this.R5M3.BackColor = System.Drawing.Color.White;
            this.R5M3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R5M3.Location = new System.Drawing.Point(233, 153);
            this.R5M3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.R5M3.MaxLength = 8;
            this.R5M3.Name = "R5M3";
            this.R5M3.Size = new System.Drawing.Size(64, 20);
            this.R5M3.TabIndex = 17;
            this.R5M3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.R5M3.TextChanged += new System.EventHandler(this.MemoryRegister_TextChanged);
            // 
            // R4M2
            // 
            this.R4M2.BackColor = System.Drawing.Color.White;
            this.R4M2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R4M2.Location = new System.Drawing.Point(153, 130);
            this.R4M2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.R4M2.MaxLength = 8;
            this.R4M2.Name = "R4M2";
            this.R4M2.Size = new System.Drawing.Size(64, 20);
            this.R4M2.TabIndex = 10;
            this.R4M2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.R4M2.TextChanged += new System.EventHandler(this.MemoryRegister_TextChanged);
            // 
            // R5M4
            // 
            this.R5M4.BackColor = System.Drawing.Color.White;
            this.R5M4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R5M4.Location = new System.Drawing.Point(314, 153);
            this.R5M4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.R5M4.MaxLength = 8;
            this.R5M4.Name = "R5M4";
            this.R5M4.Size = new System.Drawing.Size(64, 20);
            this.R5M4.TabIndex = 23;
            this.R5M4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.R5M4.TextChanged += new System.EventHandler(this.MemoryRegister_TextChanged);
            // 
            // R4M3
            // 
            this.R4M3.BackColor = System.Drawing.Color.White;
            this.R4M3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R4M3.Location = new System.Drawing.Point(233, 130);
            this.R4M3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.R4M3.MaxLength = 8;
            this.R4M3.Name = "R4M3";
            this.R4M3.Size = new System.Drawing.Size(64, 20);
            this.R4M3.TabIndex = 16;
            this.R4M3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.R4M3.TextChanged += new System.EventHandler(this.MemoryRegister_TextChanged);
            // 
            // R4M4
            // 
            this.R4M4.BackColor = System.Drawing.Color.White;
            this.R4M4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R4M4.Location = new System.Drawing.Point(314, 130);
            this.R4M4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.R4M4.MaxLength = 8;
            this.R4M4.Name = "R4M4";
            this.R4M4.Size = new System.Drawing.Size(64, 20);
            this.R4M4.TabIndex = 22;
            this.R4M4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.R4M4.TextChanged += new System.EventHandler(this.MemoryRegister_TextChanged);
            // 
            // SavReg4Label
            // 
            this.SavReg4Label.AutoSize = true;
            this.SavReg4Label.Location = new System.Drawing.Point(8, 132);
            this.SavReg4Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SavReg4Label.Name = "SavReg4Label";
            this.SavReg4Label.Size = new System.Drawing.Size(58, 13);
            this.SavReg4Label.TabIndex = 15;
            this.SavReg4Label.Text = "Register 4:";
            // 
            // R3M1
            // 
            this.R3M1.BackColor = System.Drawing.Color.White;
            this.R3M1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R3M1.Location = new System.Drawing.Point(73, 107);
            this.R3M1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.R3M1.MaxLength = 8;
            this.R3M1.Name = "R3M1";
            this.R3M1.Size = new System.Drawing.Size(64, 20);
            this.R3M1.TabIndex = 3;
            this.R3M1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.R3M1.TextChanged += new System.EventHandler(this.MemoryRegister_TextChanged);
            // 
            // R3M2
            // 
            this.R3M2.BackColor = System.Drawing.Color.White;
            this.R3M2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R3M2.Location = new System.Drawing.Point(153, 107);
            this.R3M2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.R3M2.MaxLength = 8;
            this.R3M2.Name = "R3M2";
            this.R3M2.Size = new System.Drawing.Size(64, 20);
            this.R3M2.TabIndex = 9;
            this.R3M2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.R3M2.TextChanged += new System.EventHandler(this.MemoryRegister_TextChanged);
            // 
            // R3M3
            // 
            this.R3M3.BackColor = System.Drawing.Color.White;
            this.R3M3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R3M3.Location = new System.Drawing.Point(233, 107);
            this.R3M3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.R3M3.MaxLength = 8;
            this.R3M3.Name = "R3M3";
            this.R3M3.Size = new System.Drawing.Size(64, 20);
            this.R3M3.TabIndex = 15;
            this.R3M3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.R3M3.TextChanged += new System.EventHandler(this.MemoryRegister_TextChanged);
            // 
            // R3M4
            // 
            this.R3M4.BackColor = System.Drawing.Color.White;
            this.R3M4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R3M4.Location = new System.Drawing.Point(314, 107);
            this.R3M4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.R3M4.MaxLength = 8;
            this.R3M4.Name = "R3M4";
            this.R3M4.Size = new System.Drawing.Size(64, 20);
            this.R3M4.TabIndex = 21;
            this.R3M4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.R3M4.TextChanged += new System.EventHandler(this.MemoryRegister_TextChanged);
            // 
            // R2M1
            // 
            this.R2M1.BackColor = System.Drawing.Color.White;
            this.R2M1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R2M1.Location = new System.Drawing.Point(73, 84);
            this.R2M1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.R2M1.MaxLength = 8;
            this.R2M1.Name = "R2M1";
            this.R2M1.Size = new System.Drawing.Size(64, 20);
            this.R2M1.TabIndex = 2;
            this.R2M1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.R2M1.TextChanged += new System.EventHandler(this.MemoryRegister_TextChanged);
            // 
            // R2M2
            // 
            this.R2M2.BackColor = System.Drawing.Color.White;
            this.R2M2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R2M2.Location = new System.Drawing.Point(153, 84);
            this.R2M2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.R2M2.MaxLength = 8;
            this.R2M2.Name = "R2M2";
            this.R2M2.Size = new System.Drawing.Size(64, 20);
            this.R2M2.TabIndex = 8;
            this.R2M2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.R2M2.TextChanged += new System.EventHandler(this.MemoryRegister_TextChanged);
            // 
            // R2M3
            // 
            this.R2M3.BackColor = System.Drawing.Color.White;
            this.R2M3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R2M3.Location = new System.Drawing.Point(233, 84);
            this.R2M3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.R2M3.MaxLength = 8;
            this.R2M3.Name = "R2M3";
            this.R2M3.Size = new System.Drawing.Size(64, 20);
            this.R2M3.TabIndex = 14;
            this.R2M3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.R2M3.TextChanged += new System.EventHandler(this.MemoryRegister_TextChanged);
            // 
            // R2M4
            // 
            this.R2M4.BackColor = System.Drawing.Color.White;
            this.R2M4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R2M4.Location = new System.Drawing.Point(314, 84);
            this.R2M4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.R2M4.MaxLength = 8;
            this.R2M4.Name = "R2M4";
            this.R2M4.Size = new System.Drawing.Size(64, 20);
            this.R2M4.TabIndex = 20;
            this.R2M4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.R2M4.TextChanged += new System.EventHandler(this.MemoryRegister_TextChanged);
            // 
            // SavReg2Label
            // 
            this.SavReg2Label.AutoSize = true;
            this.SavReg2Label.Location = new System.Drawing.Point(8, 87);
            this.SavReg2Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SavReg2Label.Name = "SavReg2Label";
            this.SavReg2Label.Size = new System.Drawing.Size(58, 13);
            this.SavReg2Label.TabIndex = 14;
            this.SavReg2Label.Text = "Register 2:";
            // 
            // R1M1
            // 
            this.R1M1.BackColor = System.Drawing.Color.White;
            this.R1M1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R1M1.Location = new System.Drawing.Point(73, 62);
            this.R1M1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.R1M1.MaxLength = 8;
            this.R1M1.Name = "R1M1";
            this.R1M1.Size = new System.Drawing.Size(64, 20);
            this.R1M1.TabIndex = 1;
            this.R1M1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.R1M1.TextChanged += new System.EventHandler(this.MemoryRegister_TextChanged);
            // 
            // SavReg3Label
            // 
            this.SavReg3Label.AutoSize = true;
            this.SavReg3Label.Location = new System.Drawing.Point(8, 110);
            this.SavReg3Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SavReg3Label.Name = "SavReg3Label";
            this.SavReg3Label.Size = new System.Drawing.Size(58, 13);
            this.SavReg3Label.TabIndex = 13;
            this.SavReg3Label.Text = "Register 3:";
            // 
            // R1M2
            // 
            this.R1M2.BackColor = System.Drawing.Color.White;
            this.R1M2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R1M2.Location = new System.Drawing.Point(153, 62);
            this.R1M2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.R1M2.MaxLength = 8;
            this.R1M2.Name = "R1M2";
            this.R1M2.Size = new System.Drawing.Size(64, 20);
            this.R1M2.TabIndex = 7;
            this.R1M2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.R1M2.TextChanged += new System.EventHandler(this.MemoryRegister_TextChanged);
            // 
            // R1M3
            // 
            this.R1M3.BackColor = System.Drawing.Color.White;
            this.R1M3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R1M3.Location = new System.Drawing.Point(233, 62);
            this.R1M3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.R1M3.MaxLength = 8;
            this.R1M3.Name = "R1M3";
            this.R1M3.Size = new System.Drawing.Size(64, 20);
            this.R1M3.TabIndex = 13;
            this.R1M3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.R1M3.TextChanged += new System.EventHandler(this.MemoryRegister_TextChanged);
            // 
            // R1M4
            // 
            this.R1M4.BackColor = System.Drawing.Color.White;
            this.R1M4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R1M4.Location = new System.Drawing.Point(314, 62);
            this.R1M4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.R1M4.MaxLength = 8;
            this.R1M4.Name = "R1M4";
            this.R1M4.Size = new System.Drawing.Size(64, 20);
            this.R1M4.TabIndex = 19;
            this.R1M4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.R1M4.TextChanged += new System.EventHandler(this.MemoryRegister_TextChanged);
            // 
            // SavReg1Label
            // 
            this.SavReg1Label.AutoSize = true;
            this.SavReg1Label.Location = new System.Drawing.Point(8, 64);
            this.SavReg1Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SavReg1Label.Name = "SavReg1Label";
            this.SavReg1Label.Size = new System.Drawing.Size(58, 13);
            this.SavReg1Label.TabIndex = 11;
            this.SavReg1Label.Text = "Register 1:";
            // 
            // R0M4
            // 
            this.R0M4.BackColor = System.Drawing.Color.White;
            this.R0M4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R0M4.Location = new System.Drawing.Point(314, 39);
            this.R0M4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.R0M4.MaxLength = 8;
            this.R0M4.Name = "R0M4";
            this.R0M4.Size = new System.Drawing.Size(64, 20);
            this.R0M4.TabIndex = 18;
            this.R0M4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.R0M4.TextChanged += new System.EventHandler(this.MemoryRegister_TextChanged);
            // 
            // Mem1Label
            // 
            this.Mem1Label.Location = new System.Drawing.Point(73, 20);
            this.Mem1Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Mem1Label.Name = "Mem1Label";
            this.Mem1Label.Size = new System.Drawing.Size(63, 14);
            this.Mem1Label.TabIndex = 10;
            this.Mem1Label.Text = "Memory 1";
            this.Mem1Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Mem2Label
            // 
            this.Mem2Label.Location = new System.Drawing.Point(153, 20);
            this.Mem2Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Mem2Label.Name = "Mem2Label";
            this.Mem2Label.Size = new System.Drawing.Size(63, 14);
            this.Mem2Label.TabIndex = 10;
            this.Mem2Label.Text = "Memory 2";
            this.Mem2Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Mem3Label
            // 
            this.Mem3Label.Location = new System.Drawing.Point(233, 20);
            this.Mem3Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Mem3Label.Name = "Mem3Label";
            this.Mem3Label.Size = new System.Drawing.Size(63, 14);
            this.Mem3Label.TabIndex = 10;
            this.Mem3Label.Text = "Memory 3";
            this.Mem3Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Mem4Label
            // 
            this.Mem4Label.Location = new System.Drawing.Point(314, 20);
            this.Mem4Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Mem4Label.Name = "Mem4Label";
            this.Mem4Label.Size = new System.Drawing.Size(63, 14);
            this.Mem4Label.TabIndex = 10;
            this.Mem4Label.Text = "Memory 4";
            this.Mem4Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // R0M3
            // 
            this.R0M3.BackColor = System.Drawing.Color.White;
            this.R0M3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R0M3.Location = new System.Drawing.Point(233, 39);
            this.R0M3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.R0M3.MaxLength = 8;
            this.R0M3.Name = "R0M3";
            this.R0M3.Size = new System.Drawing.Size(64, 20);
            this.R0M3.TabIndex = 12;
            this.R0M3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.R0M3.TextChanged += new System.EventHandler(this.MemoryRegister_TextChanged);
            // 
            // R0M1
            // 
            this.R0M1.BackColor = System.Drawing.Color.White;
            this.R0M1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R0M1.Location = new System.Drawing.Point(73, 39);
            this.R0M1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.R0M1.MaxLength = 8;
            this.R0M1.Name = "R0M1";
            this.R0M1.Size = new System.Drawing.Size(64, 20);
            this.R0M1.TabIndex = 0;
            this.R0M1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.R0M1.TextChanged += new System.EventHandler(this.MemoryRegister_TextChanged);
            // 
            // R0M2
            // 
            this.R0M2.BackColor = System.Drawing.Color.White;
            this.R0M2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R0M2.Location = new System.Drawing.Point(153, 39);
            this.R0M2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.R0M2.MaxLength = 8;
            this.R0M2.Name = "R0M2";
            this.R0M2.Size = new System.Drawing.Size(64, 20);
            this.R0M2.TabIndex = 6;
            this.R0M2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.R0M2.TextChanged += new System.EventHandler(this.MemoryRegister_TextChanged);
            // 
            // ImportMem4Button
            // 
            this.ImportMem4Button.Location = new System.Drawing.Point(315, 449);
            this.ImportMem4Button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ImportMem4Button.Name = "ImportMem4Button";
            this.ImportMem4Button.Size = new System.Drawing.Size(63, 40);
            this.ImportMem4Button.TabIndex = 7;
            this.ImportMem4Button.Text = "Import Memory 4";
            this.ImportMem4Button.UseVisualStyleBackColor = true;
            this.ImportMem4Button.Click += new System.EventHandler(this.ImportMememoryButton_Click);
            // 
            // ImportMem3Button
            // 
            this.ImportMem3Button.Location = new System.Drawing.Point(235, 449);
            this.ImportMem3Button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ImportMem3Button.Name = "ImportMem3Button";
            this.ImportMem3Button.Size = new System.Drawing.Size(63, 40);
            this.ImportMem3Button.TabIndex = 6;
            this.ImportMem3Button.Text = "Import Memory 3";
            this.ImportMem3Button.UseVisualStyleBackColor = true;
            this.ImportMem3Button.Click += new System.EventHandler(this.ImportMememoryButton_Click);
            // 
            // ImportMem2Button
            // 
            this.ImportMem2Button.Location = new System.Drawing.Point(154, 449);
            this.ImportMem2Button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ImportMem2Button.Name = "ImportMem2Button";
            this.ImportMem2Button.Size = new System.Drawing.Size(63, 40);
            this.ImportMem2Button.TabIndex = 5;
            this.ImportMem2Button.Text = "Import Memory 2";
            this.ImportMem2Button.UseVisualStyleBackColor = true;
            this.ImportMem2Button.Click += new System.EventHandler(this.ImportMememoryButton_Click);
            // 
            // ImportMem1Button
            // 
            this.ImportMem1Button.Location = new System.Drawing.Point(74, 449);
            this.ImportMem1Button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ImportMem1Button.Name = "ImportMem1Button";
            this.ImportMem1Button.Size = new System.Drawing.Size(63, 40);
            this.ImportMem1Button.TabIndex = 4;
            this.ImportMem1Button.Text = "Import Memory 1";
            this.ImportMem1Button.UseVisualStyleBackColor = true;
            this.ImportMem1Button.Click += new System.EventHandler(this.ImportMememoryButton_Click);
            // 
            // MemLoadFromFileButton
            // 
            this.MemLoadFromFileButton.Location = new System.Drawing.Point(395, 168);
            this.MemLoadFromFileButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MemLoadFromFileButton.Name = "MemLoadFromFileButton";
            this.MemLoadFromFileButton.Size = new System.Drawing.Size(130, 37);
            this.MemLoadFromFileButton.TabIndex = 3;
            this.MemLoadFromFileButton.Text = "Load From File";
            this.MemLoadFromFileButton.UseVisualStyleBackColor = true;
            this.MemLoadFromFileButton.Click += new System.EventHandler(this.MemLoadFromFileButton_Click);
            // 
            // MemSaveIntoFileButton
            // 
            this.MemSaveIntoFileButton.Location = new System.Drawing.Point(395, 128);
            this.MemSaveIntoFileButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MemSaveIntoFileButton.Name = "MemSaveIntoFileButton";
            this.MemSaveIntoFileButton.Size = new System.Drawing.Size(130, 37);
            this.MemSaveIntoFileButton.TabIndex = 2;
            this.MemSaveIntoFileButton.Text = "Save Into File";
            this.MemSaveIntoFileButton.UseVisualStyleBackColor = true;
            this.MemSaveIntoFileButton.Click += new System.EventHandler(this.MemSaveIntoFileButton_Click);
            // 
            // LoadRegMemory
            // 
            this.LoadRegMemory.Location = new System.Drawing.Point(395, 71);
            this.LoadRegMemory.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LoadRegMemory.Name = "LoadRegMemory";
            this.LoadRegMemory.Size = new System.Drawing.Size(130, 37);
            this.LoadRegMemory.TabIndex = 1;
            this.LoadRegMemory.Text = "Download Memory Data From Synthesizer Memory";
            this.LoadRegMemory.UseVisualStyleBackColor = true;
            this.LoadRegMemory.Click += new System.EventHandler(this.LoadRegMemory_Click);
            // 
            // SaveRegMemory
            // 
            this.SaveRegMemory.Location = new System.Drawing.Point(395, 30);
            this.SaveRegMemory.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SaveRegMemory.Name = "SaveRegMemory";
            this.SaveRegMemory.Size = new System.Drawing.Size(130, 37);
            this.SaveRegMemory.TabIndex = 0;
            this.SaveRegMemory.Text = "Upload Memory Data Into Synthesizer";
            this.SaveRegMemory.UseVisualStyleBackColor = true;
            this.SaveRegMemory.Click += new System.EventHandler(this.SaveRegMemory_Click);
            // 
            // VcoCalibrationTabPage
            // 
            this.VcoCalibrationTabPage.Controls.Add(this.CurrentVcoShowLabel);
            this.VcoCalibrationTabPage.Controls.Add(this.ActFreqShowLabel);
            this.VcoCalibrationTabPage.Controls.Add(this.VcoFreqMaxTextBox);
            this.VcoCalibrationTabPage.Controls.Add(this.CurrentVcoLabel);
            this.VcoCalibrationTabPage.Controls.Add(this.label14);
            this.VcoCalibrationTabPage.Controls.Add(this.ActFreqLabel);
            this.VcoCalibrationTabPage.Controls.Add(this.label15);
            this.VcoCalibrationTabPage.Controls.Add(this.VcoFreqMaxLabel);
            this.VcoCalibrationTabPage.Controls.Add(this.VcoFreqMinTextBox);
            this.VcoCalibrationTabPage.Controls.Add(this.label16);
            this.VcoCalibrationTabPage.Controls.Add(this.VcoFreqMinLabel);
            this.VcoCalibrationTabPage.Controls.Add(this.AbortCallibrationButton);
            this.VcoCalibrationTabPage.Controls.Add(this.PerformVcoCalibrationButton);
            this.VcoCalibrationTabPage.Controls.Add(this.FreqStepTextBox);
            this.VcoCalibrationTabPage.Controls.Add(this.MHzLable);
            this.VcoCalibrationTabPage.Controls.Add(this.FreqStepLabel);
            this.VcoCalibrationTabPage.Location = new System.Drawing.Point(4, 22);
            this.VcoCalibrationTabPage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.VcoCalibrationTabPage.Name = "VcoCalibrationTabPage";
            this.VcoCalibrationTabPage.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.VcoCalibrationTabPage.Size = new System.Drawing.Size(530, 662);
            this.VcoCalibrationTabPage.TabIndex = 2;
            this.VcoCalibrationTabPage.Text = "VCO Calibration";
            this.VcoCalibrationTabPage.UseVisualStyleBackColor = true;
            // 
            // CurrentVcoShowLabel
            // 
            this.CurrentVcoShowLabel.Location = new System.Drawing.Point(286, 347);
            this.CurrentVcoShowLabel.Name = "CurrentVcoShowLabel";
            this.CurrentVcoShowLabel.Size = new System.Drawing.Size(84, 13);
            this.CurrentVcoShowLabel.TabIndex = 32;
            this.CurrentVcoShowLabel.Text = "-";
            this.CurrentVcoShowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ActFreqShowLabel
            // 
            this.ActFreqShowLabel.Location = new System.Drawing.Point(286, 328);
            this.ActFreqShowLabel.Name = "ActFreqShowLabel";
            this.ActFreqShowLabel.Size = new System.Drawing.Size(84, 13);
            this.ActFreqShowLabel.TabIndex = 33;
            this.ActFreqShowLabel.Text = "-";
            this.ActFreqShowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // VcoFreqMaxTextBox
            // 
            this.VcoFreqMaxTextBox.BackColor = System.Drawing.Color.White;
            this.VcoFreqMaxTextBox.Enabled = false;
            this.VcoFreqMaxTextBox.Location = new System.Drawing.Point(289, 291);
            this.VcoFreqMaxTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.VcoFreqMaxTextBox.MaxLength = 17;
            this.VcoFreqMaxTextBox.Name = "VcoFreqMaxTextBox";
            this.VcoFreqMaxTextBox.ReadOnly = true;
            this.VcoFreqMaxTextBox.Size = new System.Drawing.Size(83, 20);
            this.VcoFreqMaxTextBox.TabIndex = 26;
            this.VcoFreqMaxTextBox.Text = "6000";
            this.VcoFreqMaxTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CurrentVcoLabel
            // 
            this.CurrentVcoLabel.Location = new System.Drawing.Point(127, 346);
            this.CurrentVcoLabel.Name = "CurrentVcoLabel";
            this.CurrentVcoLabel.Size = new System.Drawing.Size(157, 13);
            this.CurrentVcoLabel.TabIndex = 29;
            this.CurrentVcoLabel.Text = "Current VCO:";
            this.CurrentVcoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(375, 327);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(30, 14);
            this.label14.TabIndex = 27;
            this.label14.Text = "MHz";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ActFreqLabel
            // 
            this.ActFreqLabel.Location = new System.Drawing.Point(127, 327);
            this.ActFreqLabel.Name = "ActFreqLabel";
            this.ActFreqLabel.Size = new System.Drawing.Size(157, 13);
            this.ActFreqLabel.TabIndex = 30;
            this.ActFreqLabel.Text = "Actual Frequency:";
            this.ActFreqLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(375, 293);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(30, 14);
            this.label15.TabIndex = 28;
            this.label15.Text = "MHz";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // VcoFreqMaxLabel
            // 
            this.VcoFreqMaxLabel.Location = new System.Drawing.Point(74, 293);
            this.VcoFreqMaxLabel.Name = "VcoFreqMaxLabel";
            this.VcoFreqMaxLabel.Size = new System.Drawing.Size(210, 13);
            this.VcoFreqMaxLabel.TabIndex = 31;
            this.VcoFreqMaxLabel.Text = "MAX2871 VCO Frequency Max:";
            this.VcoFreqMaxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // VcoFreqMinTextBox
            // 
            this.VcoFreqMinTextBox.BackColor = System.Drawing.Color.White;
            this.VcoFreqMinTextBox.Enabled = false;
            this.VcoFreqMinTextBox.Location = new System.Drawing.Point(289, 270);
            this.VcoFreqMinTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.VcoFreqMinTextBox.MaxLength = 17;
            this.VcoFreqMinTextBox.Name = "VcoFreqMinTextBox";
            this.VcoFreqMinTextBox.ReadOnly = true;
            this.VcoFreqMinTextBox.Size = new System.Drawing.Size(83, 20);
            this.VcoFreqMinTextBox.TabIndex = 23;
            this.VcoFreqMinTextBox.Text = "3000";
            this.VcoFreqMinTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(375, 272);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(30, 14);
            this.label16.TabIndex = 24;
            this.label16.Text = "MHz";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // VcoFreqMinLabel
            // 
            this.VcoFreqMinLabel.Location = new System.Drawing.Point(71, 272);
            this.VcoFreqMinLabel.Name = "VcoFreqMinLabel";
            this.VcoFreqMinLabel.Size = new System.Drawing.Size(213, 13);
            this.VcoFreqMinLabel.TabIndex = 25;
            this.VcoFreqMinLabel.Text = "MAX 2871 VCO Frequency Min:";
            this.VcoFreqMinLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AbortCallibrationButton
            // 
            this.AbortCallibrationButton.Enabled = false;
            this.AbortCallibrationButton.Location = new System.Drawing.Point(289, 372);
            this.AbortCallibrationButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AbortCallibrationButton.Name = "AbortCallibrationButton";
            this.AbortCallibrationButton.Size = new System.Drawing.Size(94, 44);
            this.AbortCallibrationButton.TabIndex = 21;
            this.AbortCallibrationButton.Text = "Abort";
            this.AbortCallibrationButton.UseVisualStyleBackColor = true;
            this.AbortCallibrationButton.Click += new System.EventHandler(this.AbortCallibration_Click);
            // 
            // PerformVcoCalibrationButton
            // 
            this.PerformVcoCalibrationButton.Location = new System.Drawing.Point(153, 372);
            this.PerformVcoCalibrationButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PerformVcoCalibrationButton.Name = "PerformVcoCalibrationButton";
            this.PerformVcoCalibrationButton.Size = new System.Drawing.Size(94, 44);
            this.PerformVcoCalibrationButton.TabIndex = 22;
            this.PerformVcoCalibrationButton.Text = "Perform VCO calibration";
            this.PerformVcoCalibrationButton.UseVisualStyleBackColor = true;
            this.PerformVcoCalibrationButton.Click += new System.EventHandler(this.PerformVcoCalibrationButton_Click);
            // 
            // FreqStepTextBox
            // 
            this.FreqStepTextBox.BackColor = System.Drawing.Color.White;
            this.FreqStepTextBox.Location = new System.Drawing.Point(289, 249);
            this.FreqStepTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FreqStepTextBox.MaxLength = 17;
            this.FreqStepTextBox.Name = "FreqStepTextBox";
            this.FreqStepTextBox.Size = new System.Drawing.Size(83, 20);
            this.FreqStepTextBox.TabIndex = 18;
            this.FreqStepTextBox.Text = "1000";
            this.FreqStepTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.FreqStepTextBox.TextChanged += new System.EventHandler(this.FreqStepTextBox_TextChanged);
            // 
            // MHzLable
            // 
            this.MHzLable.Location = new System.Drawing.Point(375, 251);
            this.MHzLable.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MHzLable.Name = "MHzLable";
            this.MHzLable.Size = new System.Drawing.Size(30, 14);
            this.MHzLable.TabIndex = 19;
            this.MHzLable.Text = "MHz";
            this.MHzLable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FreqStepLabel
            // 
            this.FreqStepLabel.Location = new System.Drawing.Point(127, 251);
            this.FreqStepLabel.Name = "FreqStepLabel";
            this.FreqStepLabel.Size = new System.Drawing.Size(157, 13);
            this.FreqStepLabel.TabIndex = 20;
            this.FreqStepLabel.Text = "Frequency Calibration Step:";
            this.FreqStepLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RegistersGroupBox
            // 
            this.RegistersGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RegistersGroupBox.Location = new System.Drawing.Point(264, 3);
            this.RegistersGroupBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RegistersGroupBox.Name = "RegistersGroupBox";
            this.RegistersGroupBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RegistersGroupBox.Size = new System.Drawing.Size(538, 634);
            this.RegistersGroupBox.TabIndex = 9;
            this.RegistersGroupBox.TabStop = false;
            this.RegistersGroupBox.Text = "PLO MAX2871 Registers Settings";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 560);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(642, 22);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // InputFreqTextBox
            // 
            this.InputFreqTextBox.BackColor = System.Drawing.Color.White;
            this.InputFreqTextBox.Location = new System.Drawing.Point(110, 16);
            this.InputFreqTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.InputFreqTextBox.MaxLength = 17;
            this.InputFreqTextBox.Name = "InputFreqTextBox";
            this.InputFreqTextBox.Size = new System.Drawing.Size(83, 20);
            this.InputFreqTextBox.TabIndex = 0;
            this.InputFreqTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.InputFreqTextBox.TextChanged += new System.EventHandler(this.InputFreqTextBox_TextChanged);
            this.InputFreqTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InputFreqTextBox_KeyDown);
            this.InputFreqTextBox.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.FrequencyTextBox_MouseWheel);
            // 
            // MHzLabel6
            // 
            this.MHzLabel6.Location = new System.Drawing.Point(196, 19);
            this.MHzLabel6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MHzLabel6.Name = "MHzLabel6";
            this.MHzLabel6.Size = new System.Drawing.Size(30, 14);
            this.MHzLabel6.TabIndex = 1;
            this.MHzLabel6.Text = "MHz";
            this.MHzLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DeltaShowLabel
            // 
            this.DeltaShowLabel.Location = new System.Drawing.Point(110, 57);
            this.DeltaShowLabel.Name = "DeltaShowLabel";
            this.DeltaShowLabel.Size = new System.Drawing.Size(82, 13);
            this.DeltaShowLabel.TabIndex = 1;
            this.DeltaShowLabel.Text = "0";
            this.DeltaShowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HzLabel
            // 
            this.HzLabel.Location = new System.Drawing.Point(196, 57);
            this.HzLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.HzLabel.Name = "HzLabel";
            this.HzLabel.Size = new System.Drawing.Size(30, 14);
            this.HzLabel.TabIndex = 1;
            this.HzLabel.Text = "Hz";
            this.HzLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DeltaLabel
            // 
            this.DeltaLabel.Location = new System.Drawing.Point(2, 56);
            this.DeltaLabel.Name = "DeltaLabel";
            this.DeltaLabel.Size = new System.Drawing.Size(104, 15);
            this.DeltaLabel.TabIndex = 1;
            this.DeltaLabel.Text = "Delta frequency:";
            this.DeltaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // InputFreqLabel
            // 
            this.InputFreqLabel.Location = new System.Drawing.Point(2, 19);
            this.InputFreqLabel.Name = "InputFreqLabel";
            this.InputFreqLabel.Size = new System.Drawing.Size(104, 13);
            this.InputFreqLabel.TabIndex = 1;
            this.InputFreqLabel.Text = "Output frequency:";
            this.InputFreqLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DirectFreqContrGroupBox
            // 
            this.DirectFreqContrGroupBox.Controls.Add(this.InputFreqTextBox);
            this.DirectFreqContrGroupBox.Controls.Add(this.MHzLabel7);
            this.DirectFreqContrGroupBox.Controls.Add(this.MHzLabel6);
            this.DirectFreqContrGroupBox.Controls.Add(this.InputFreqLabel);
            this.DirectFreqContrGroupBox.Controls.Add(this.CalcFreqShowLabel);
            this.DirectFreqContrGroupBox.Controls.Add(this.DeltaShowLabel);
            this.DirectFreqContrGroupBox.Controls.Add(this.CalcFreqLabel);
            this.DirectFreqContrGroupBox.Controls.Add(this.DeltaLabel);
            this.DirectFreqContrGroupBox.Controls.Add(this.HzLabel);
            this.DirectFreqContrGroupBox.Location = new System.Drawing.Point(8, 66);
            this.DirectFreqContrGroupBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DirectFreqContrGroupBox.Name = "DirectFreqContrGroupBox";
            this.DirectFreqContrGroupBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DirectFreqContrGroupBox.Size = new System.Drawing.Size(250, 77);
            this.DirectFreqContrGroupBox.TabIndex = 6;
            this.DirectFreqContrGroupBox.TabStop = false;
            this.DirectFreqContrGroupBox.Text = "Direct output frequency control";
            // 
            // MHzLabel7
            // 
            this.MHzLabel7.Location = new System.Drawing.Point(197, 37);
            this.MHzLabel7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MHzLabel7.Name = "MHzLabel7";
            this.MHzLabel7.Size = new System.Drawing.Size(30, 14);
            this.MHzLabel7.TabIndex = 1;
            this.MHzLabel7.Text = "MHz";
            this.MHzLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CalcFreqShowLabel
            // 
            this.CalcFreqShowLabel.Location = new System.Drawing.Point(110, 37);
            this.CalcFreqShowLabel.Name = "CalcFreqShowLabel";
            this.CalcFreqShowLabel.Size = new System.Drawing.Size(82, 13);
            this.CalcFreqShowLabel.TabIndex = 1;
            this.CalcFreqShowLabel.Text = "0";
            this.CalcFreqShowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CalcFreqLabel
            // 
            this.CalcFreqLabel.Location = new System.Drawing.Point(2, 37);
            this.CalcFreqLabel.Name = "CalcFreqLabel";
            this.CalcFreqLabel.Size = new System.Drawing.Size(104, 15);
            this.CalcFreqLabel.TabIndex = 1;
            this.CalcFreqLabel.Text = "Calculated freq.:";
            this.CalcFreqLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MHzLabel9
            // 
            this.MHzLabel9.Location = new System.Drawing.Point(211, 72);
            this.MHzLabel9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MHzLabel9.Name = "MHzLabel9";
            this.MHzLabel9.Size = new System.Drawing.Size(30, 14);
            this.MHzLabel9.TabIndex = 17;
            this.MHzLabel9.Text = "MHz";
            this.MHzLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MHzLabel8
            // 
            this.MHzLabel8.Location = new System.Drawing.Point(210, 54);
            this.MHzLabel8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MHzLabel8.Name = "MHzLabel8";
            this.MHzLabel8.Size = new System.Drawing.Size(30, 14);
            this.MHzLabel8.TabIndex = 17;
            this.MHzLabel8.Text = "MHz";
            this.MHzLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FreqAtOut2ShowLabel
            // 
            this.FreqAtOut2ShowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FreqAtOut2ShowLabel.Location = new System.Drawing.Point(112, 72);
            this.FreqAtOut2ShowLabel.Name = "FreqAtOut2ShowLabel";
            this.FreqAtOut2ShowLabel.Size = new System.Drawing.Size(94, 13);
            this.FreqAtOut2ShowLabel.TabIndex = 20;
            this.FreqAtOut2ShowLabel.Text = "0";
            this.FreqAtOut2ShowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FreqAtOut1ShowLabel
            // 
            this.FreqAtOut1ShowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FreqAtOut1ShowLabel.Location = new System.Drawing.Point(112, 54);
            this.FreqAtOut1ShowLabel.Name = "FreqAtOut1ShowLabel";
            this.FreqAtOut1ShowLabel.Size = new System.Drawing.Size(94, 13);
            this.FreqAtOut1ShowLabel.TabIndex = 20;
            this.FreqAtOut1ShowLabel.Text = "0";
            this.FreqAtOut1ShowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ActOut2ShowLabel
            // 
            this.ActOut2ShowLabel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ActOut2ShowLabel.Location = new System.Drawing.Point(218, 19);
            this.ActOut2ShowLabel.Name = "ActOut2ShowLabel";
            this.ActOut2ShowLabel.Size = new System.Drawing.Size(29, 13);
            this.ActOut2ShowLabel.TabIndex = 1;
            this.ActOut2ShowLabel.Text = "OFF";
            this.ActOut2ShowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ActOut2ShowLabel.Click += new System.EventHandler(this.ActOut2ShowLabel_Click);
            // 
            // FreqAtOut2Label
            // 
            this.FreqAtOut2Label.Location = new System.Drawing.Point(4, 72);
            this.FreqAtOut2Label.Name = "FreqAtOut2Label";
            this.FreqAtOut2Label.Size = new System.Drawing.Size(104, 15);
            this.FreqAtOut2Label.TabIndex = 20;
            this.FreqAtOut2Label.Text = "Frequency at Out 2:";
            this.FreqAtOut2Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ActOut1ShowLabel
            // 
            this.ActOut1ShowLabel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ActOut1ShowLabel.Location = new System.Drawing.Point(95, 18);
            this.ActOut1ShowLabel.Name = "ActOut1ShowLabel";
            this.ActOut1ShowLabel.Size = new System.Drawing.Size(29, 13);
            this.ActOut1ShowLabel.TabIndex = 0;
            this.ActOut1ShowLabel.Text = "OFF";
            this.ActOut1ShowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ActOut1ShowLabel.Click += new System.EventHandler(this.ActOut1ShowLabel_Click);
            // 
            // FreqAtOut1Label
            // 
            this.FreqAtOut1Label.Location = new System.Drawing.Point(4, 54);
            this.FreqAtOut1Label.Name = "FreqAtOut1Label";
            this.FreqAtOut1Label.Size = new System.Drawing.Size(104, 15);
            this.FreqAtOut1Label.TabIndex = 20;
            this.FreqAtOut1Label.Text = "Frequency at Out 1:";
            this.FreqAtOut1Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ActiveOut2Label
            // 
            this.ActiveOut2Label.Location = new System.Drawing.Point(128, 17);
            this.ActiveOut2Label.Name = "ActiveOut2Label";
            this.ActiveOut2Label.Size = new System.Drawing.Size(87, 15);
            this.ActiveOut2Label.TabIndex = 20;
            this.ActiveOut2Label.Text = "Active Output 2:";
            this.ActiveOut2Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ActiveOut1Label
            // 
            this.ActiveOut1Label.Location = new System.Drawing.Point(5, 16);
            this.ActiveOut1Label.Name = "ActiveOut1Label";
            this.ActiveOut1Label.Size = new System.Drawing.Size(85, 15);
            this.ActiveOut1Label.TabIndex = 20;
            this.ActiveOut1Label.Text = "Active Output 1:";
            this.ActiveOut1Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ConsoleRichTextBox
            // 
            this.ConsoleRichTextBox.HideSelection = false;
            this.ConsoleRichTextBox.Location = new System.Drawing.Point(8, 246);
            this.ConsoleRichTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ConsoleRichTextBox.Name = "ConsoleRichTextBox";
            this.ConsoleRichTextBox.ReadOnly = true;
            this.ConsoleRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.ConsoleRichTextBox.Size = new System.Drawing.Size(252, 458);
            this.ConsoleRichTextBox.TabIndex = 8;
            this.ConsoleRichTextBox.Text = "";
            // 
            // SynthModuleInfoGroupBox
            // 
            this.SynthModuleInfoGroupBox.Controls.Add(this.ActiveOut1Label);
            this.SynthModuleInfoGroupBox.Controls.Add(this.ActiveOut2Label);
            this.SynthModuleInfoGroupBox.Controls.Add(this.MHzLabel9);
            this.SynthModuleInfoGroupBox.Controls.Add(this.IntExtShowLabel);
            this.SynthModuleInfoGroupBox.Controls.Add(this.RefSignalLabel);
            this.SynthModuleInfoGroupBox.Controls.Add(this.FreqAtOut1Label);
            this.SynthModuleInfoGroupBox.Controls.Add(this.ActOut1ShowLabel);
            this.SynthModuleInfoGroupBox.Controls.Add(this.MHzLabel8);
            this.SynthModuleInfoGroupBox.Controls.Add(this.FreqAtOut2Label);
            this.SynthModuleInfoGroupBox.Controls.Add(this.ActOut2ShowLabel);
            this.SynthModuleInfoGroupBox.Controls.Add(this.FreqAtOut1ShowLabel);
            this.SynthModuleInfoGroupBox.Controls.Add(this.FreqAtOut2ShowLabel);
            this.SynthModuleInfoGroupBox.Location = new System.Drawing.Point(8, 148);
            this.SynthModuleInfoGroupBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SynthModuleInfoGroupBox.Name = "SynthModuleInfoGroupBox";
            this.SynthModuleInfoGroupBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SynthModuleInfoGroupBox.Size = new System.Drawing.Size(250, 93);
            this.SynthModuleInfoGroupBox.TabIndex = 7;
            this.SynthModuleInfoGroupBox.TabStop = false;
            this.SynthModuleInfoGroupBox.Text = "Synthesizer module info";
            // 
            // IntExtShowLabel
            // 
            this.IntExtShowLabel.Location = new System.Drawing.Point(122, 35);
            this.IntExtShowLabel.Name = "IntExtShowLabel";
            this.IntExtShowLabel.Size = new System.Drawing.Size(80, 15);
            this.IntExtShowLabel.TabIndex = 2;
            this.IntExtShowLabel.Text = "External";
            this.IntExtShowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.IntExtShowLabel.Click += new System.EventHandler(this.IntExtShowLabel_Click);
            // 
            // RefSignalLabel
            // 
            this.RefSignalLabel.Location = new System.Drawing.Point(4, 35);
            this.RefSignalLabel.Name = "RefSignalLabel";
            this.RefSignalLabel.Size = new System.Drawing.Size(104, 15);
            this.RefSignalLabel.TabIndex = 20;
            this.RefSignalLabel.Text = "Reference Signal:";
            this.RefSignalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LedOffPicBox
            // 
            this.LedOffPicBox.Image = ((System.Drawing.Image)(resources.GetObject("LedOffPicBox.Image")));
            this.LedOffPicBox.Location = new System.Drawing.Point(5, 712);
            this.LedOffPicBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LedOffPicBox.Name = "LedOffPicBox";
            this.LedOffPicBox.Size = new System.Drawing.Size(16, 17);
            this.LedOffPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LedOffPicBox.TabIndex = 24;
            this.LedOffPicBox.TabStop = false;
            this.LedOffPicBox.Visible = false;
            // 
            // LedOnPicBox
            // 
            this.LedOnPicBox.Image = ((System.Drawing.Image)(resources.GetObject("LedOnPicBox.Image")));
            this.LedOnPicBox.Location = new System.Drawing.Point(5, 713);
            this.LedOnPicBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LedOnPicBox.Name = "LedOnPicBox";
            this.LedOnPicBox.Size = new System.Drawing.Size(16, 17);
            this.LedOnPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LedOnPicBox.TabIndex = 25;
            this.LedOnPicBox.TabStop = false;
            this.LedOnPicBox.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 582);
            this.Controls.Add(this.LedOnPicBox);
            this.Controls.Add(this.LedOffPicBox);
            this.Controls.Add(this.SynthModuleInfoGroupBox);
            this.Controls.Add(this.ConsoleRichTextBox);
            this.Controls.Add(this.DirectFreqContrGroupBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.RegistersTabControl);
            this.Controls.Add(this.RegistersGroupBox);
            this.Controls.Add(this.AvaibleCOMsComBox);
            this.Controls.Add(this.PloInitButton);
            this.Controls.Add(this.RefButton);
            this.Controls.Add(this.Out2Button);
            this.Controls.Add(this.Out1Button);
            this.Controls.Add(this.PortButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Synthesizer Control Program by OK2FKU";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Click += new System.EventHandler(this.CheckAndApllyChangesForm1_Click);
            this.RegistersTabControl.ResumeLayout(false);
            this.RegistersPage.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.genericControlsGroupBox.ResumeLayout(false);
            this.genericControlsGroupBox.PerformLayout();
            this.ShutDownGroupBox.ResumeLayout(false);
            this.ShutDownGroupBox.PerformLayout();
            this.VcoSettingsGroupBox.ResumeLayout(false);
            this.VcoSettingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BandSelClockDivNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DelayInputNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClockDividerNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ManualVCOSelectNumericUpDown)).EndInit();
            this.PhaseDetectorGroupBox.ResumeLayout(false);
            this.RegistersControlsGroupBox.ResumeLayout(false);
            this.RegistersControlsGroupBox.PerformLayout();
            this.MoveRegsIntoMemsGroupBox.ResumeLayout(false);
            this.ChargePumpGroupBox.ResumeLayout(false);
            this.ChargePumpGroupBox.PerformLayout();
            this.OutputControlsGroupBox.ResumeLayout(false);
            this.OutInfoGroupBox.ResumeLayout(false);
            this.FreqControlGroupBox.ResumeLayout(false);
            this.FreqControlGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IntNNumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModNumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FracNNumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PhasePNumericUpDown)).EndInit();
            this.RefFreqGroupBox.ResumeLayout(false);
            this.RefFreqGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RDivUpDown)).EndInit();
            this.RegistersMemoryPage.ResumeLayout(false);
            this.SynthOutputsInfoGroupBox.ResumeLayout(false);
            this.SynthOutputsInfoGroupBox.PerformLayout();
            this.SyntModuleControlsGroupBox.ResumeLayout(false);
            this.SyntModuleControlsGroupBox.PerformLayout();
            this.RegMemoryGroupBox.ResumeLayout(false);
            this.RegMemoryGroupBox.PerformLayout();
            this.VcoCalibrationTabPage.ResumeLayout(false);
            this.VcoCalibrationTabPage.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.DirectFreqContrGroupBox.ResumeLayout(false);
            this.DirectFreqContrGroupBox.PerformLayout();
            this.SynthModuleInfoGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LedOffPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LedOnPicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button PortButton;
        public System.Windows.Forms.Button Out1Button;
        public System.Windows.Forms.Button Out2Button;
        public System.Windows.Forms.Button PloInitButton;
        public System.Windows.Forms.TextBox Reg0TextBox;
        private System.Windows.Forms.Label Reg0Label;
        private System.Windows.Forms.Label Reg1Label;
        public System.Windows.Forms.TextBox Reg1TextBox;
        private System.Windows.Forms.Label Reg2Label;
        public System.Windows.Forms.TextBox Reg2TextBox;
        private System.Windows.Forms.Label Reg3Label;
        public System.Windows.Forms.TextBox Reg3TextBox;
        private System.Windows.Forms.Label Reg4Label;
        public System.Windows.Forms.TextBox Reg4TextBox;
        private System.Windows.Forms.Label Reg5Label;
        public System.Windows.Forms.TextBox Reg5TextBox;
        public System.Windows.Forms.Button RefButton;
        public System.Windows.Forms.Button SetAsDefaultRegButton;
        public System.Windows.Forms.Button ForceLoadRegButton;
        public System.Windows.Forms.Button LoadDefRegButton;
        public System.Windows.Forms.ComboBox AvaibleCOMsComBox;
        public System.Windows.Forms.Button WriteR0Button;
        public System.Windows.Forms.Button WriteR1Button;
        public System.Windows.Forms.Button WriteR2Button;
        public System.Windows.Forms.Button WriteR3Button;
        public System.Windows.Forms.Button WriteR4Button;
        public System.Windows.Forms.Button WriteR5Button;
        public System.Windows.Forms.TabControl RegistersTabControl;
        private System.Windows.Forms.TabPage RegistersPage;
        private System.Windows.Forms.TabPage RegistersMemoryPage;
        private System.Windows.Forms.Label SavReg3Label;
        public System.Windows.Forms.TextBox R0M4;
        public System.Windows.Forms.TextBox R0M3;
        public System.Windows.Forms.TextBox R0M2;
        public System.Windows.Forms.TextBox R0M1;
        private System.Windows.Forms.Label Mem1Label;
        private System.Windows.Forms.Label SavReg0Label;
        private System.Windows.Forms.Label SavReg1Label;
        public System.Windows.Forms.TextBox R1M4;
        public System.Windows.Forms.TextBox R1M3;
        public System.Windows.Forms.TextBox R1M2;
        public System.Windows.Forms.TextBox R1M1;
        private System.Windows.Forms.Label SavReg2Label;
        public System.Windows.Forms.TextBox R2M4;
        public System.Windows.Forms.TextBox R2M3;
        public System.Windows.Forms.TextBox R2M2;
        public System.Windows.Forms.TextBox R2M1;
        public System.Windows.Forms.TextBox R3M4;
        public System.Windows.Forms.TextBox R3M3;
        public System.Windows.Forms.TextBox R3M2;
        public System.Windows.Forms.TextBox R3M1;
        private System.Windows.Forms.Label SavReg4Label;
        public System.Windows.Forms.TextBox R4M4;
        public System.Windows.Forms.TextBox R4M3;
        public System.Windows.Forms.TextBox R5M4;
        public System.Windows.Forms.TextBox R4M2;
        public System.Windows.Forms.TextBox R5M3;
        public System.Windows.Forms.TextBox R4M1;
        public System.Windows.Forms.TextBox R5M2;
        private System.Windows.Forms.Label SavReg5Label;
        public System.Windows.Forms.TextBox R5M1;
        private System.Windows.Forms.Label Mem4Label;
        private System.Windows.Forms.Label Mem3Label;
        private System.Windows.Forms.Label Mem2Label;
        private System.Windows.Forms.GroupBox RegistersGroupBox;
        public System.Windows.Forms.Button SaveRegMemory;
        public System.Windows.Forms.Button LoadRegMemory;
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label RF_A_EN_Label;
        public System.Windows.Forms.ComboBox OutAEn_ComboBox;
        public System.Windows.Forms.Label RF_A_PWR_Label;
        public System.Windows.Forms.ComboBox OutAPwr_ComboBox;
        private System.Windows.Forms.Label ModLabel;
        private System.Windows.Forms.Label FracNLabel;
        private System.Windows.Forms.Label IntNLabel;
        private System.Windows.Forms.Label ModeIntFracLabel;
        public System.Windows.Forms.ComboBox ModeIntFracComboBox;
        public System.Windows.Forms.NumericUpDown IntNNumUpDown;
        public System.Windows.Forms.NumericUpDown ModNumUpDown;
        public System.Windows.Forms.NumericUpDown FracNNumUpDown;
        public System.Windows.Forms.Label fOutAScreenLabel;
        private System.Windows.Forms.Label fOutALabel;
        private System.Windows.Forms.Label MHzLabel1;
        private System.Windows.Forms.Label fVcoLabel;
        public System.Windows.Forms.Label fVcoScreenLabel;
        private System.Windows.Forms.Label MHzLabel2;
        public CheckBox DivideBy2CheckBox;
        public CheckBox RefDoublerCheckBox;
        private Label MHzLabel3;
        private Label RefFLabel;
        public TextBox RefFTextBox;
        public NumericUpDown RDivUpDown;
        private Label RDivLabel;
        private Label fPfdLabel;
        public Label pfdFreqLabel;
        public NumericUpDown PhasePNumericUpDown;
        private Label MHzLabel4;
        private Label PhasePLabel;
        private Label ADivLabel;
        public ComboBox OutBPwr_ComboBox;
        public ComboBox OutBEn_ComboBox;
        private Label RF_B_PWR_Label;
        private Label RF_B_EN_Label;
        private Label fOutBLabel;
        public Label fOutBScreenLabel;
        private Label MHzLabel5;
        private GroupBox RefFreqGroupBox;
        private GroupBox FreqControlGroupBox;
        private GroupBox OutInfoGroupBox;
        private GroupBox OutputControlsGroupBox;
        private GroupBox ChargePumpGroupBox;
        public TextBox RSetTextBox;
        private Label RSetLabel;
        public ComboBox CPCurrentComboBox;
        public Label CPCurrentLabel;
        public ComboBox CPTestComboBox;
        public ComboBox CPLinearityComboBox;
        private Label CPTestLabel;
        public Label CPLinearityLabel;
        public CheckBox CPTriStateOutCheckBox;
        public CheckBox CPFastLockCheckBox;
        public CheckBox CPCycleSlipCheckBox;
        public ComboBox ADivComboBox;
        public TextBox InputFreqTextBox;
        private Label MHzLabel6;
        public Label DeltaShowLabel;
        private Label HzLabel;
        private Label DeltaLabel;
        private Label InputFreqLabel;
        private GroupBox MoveRegsIntoMemsGroupBox;
        private Button ExportIntoMem1Button;
        private Button ExportIntoMem2Button;
        private Button ExportIntoMem3Button;
        private Button ExportIntoMem4Button;
        private Button ImportMem4Button;
        private Button ImportMem3Button;
        private Button ImportMem2Button;
        private Button ImportMem1Button;
        private GroupBox RegistersControlsGroupBox;
        private GroupBox DirectFreqContrGroupBox;
        public RichTextBox ConsoleRichTextBox;
        private Label MHzLabel7;
        public Label CalcFreqShowLabel;
        private Label CalcFreqLabel;
        private Label ActiveOut1Label;
        private Label MHzLabel9;
        private Label MHzLabel8;
        public Label FreqAtOut2ShowLabel;
        public Label FreqAtOut1ShowLabel;
        public Label ActOut2ShowLabel;
        private Label FreqAtOut2Label;
        public Label ActOut1ShowLabel;
        private Label FreqAtOut1Label;
        private Label ActiveOut2Label;
        private GroupBox PhaseDetectorGroupBox;
        public Label LDSpeedAdjLabel;
        public ComboBox LDSpeedAdjComboBox;
        public CheckBox AutoLDSpeedAdjCheckBox;
        private Label LDPrecisionLabel;
        private Label SDNoiseModeLabel;
        public ComboBox LDPrecisionComboBox;
        public ComboBox SigmaDeltaNoiseModeComboBox;
        public Label LDfuncLabel;
        public ComboBox LDFuncComboBox;
        private Label RFoutBPathLabel;
        public ComboBox RFoutBPathComboBox;
        public CheckBox AutoLDFuncCheckBox;
        private GroupBox VcoSettingsGroupBox;
        private GroupBox genericControlsGroupBox;
        private GroupBox ShutDownGroupBox;
        public Label InternalLabel;
        public CheckBox PhaseAdjustmentModeCheckbox;
        private Label label1;
        public ComboBox PfdPolarity;
        public ComboBox MuxPinModeCombobox;
        private Label MuxPinModeLabel;
        private GroupBox SynthModuleInfoGroupBox;
        public CheckBox IntNAutoModeWhenF0CheckBox;
        public CheckBox Reg4DoubleBufferedCheckBox;
        private CheckBox CalcCDIVCheckBox;
        private Label label2;
        public ComboBox FBPathComboBox;
        public NumericUpDown BandSelClockDivNumericUpDown;
        public NumericUpDown ManualVCOSelectNumericUpDown;
        private Label BandSelectClockDivLabel;
        private Label ManualVcoLabel;
        public NumericUpDown ClockDividerNumericUpDown;
        private Label label5;
        public CheckBox RandNCountersResetCheckBox;
        public Button SaveIntoFileButton;
        public Button LoadFromFileButton;
        private GroupBox groupBox1;
        public ComboBox ADCModeComboBox;
        private Label label6;
        public TextBox ReadedVCOValueTextBox;
        public TextBox ReadedADCValueTextBox;
        private Button GetCurrentVCOButton;
        private Button GetADCValueButton;
        public CheckBox PloPowerDownCheckBox;
        public CheckBox VcoShutDownCheckBox;
        public CheckBox VcoLdoShutDownCheckBox;
        public CheckBox VcoDividerShutdownCheckBox;
        public CheckBox RefInputShutdownCheckBox;
        public CheckBox PllShutDownCheckBox;
        public CheckBox AutoVcoSelectionCheckBox;
        public CheckBox VASTempCompCheckBox;
        public CheckBox DelayToPreventFlickeringCheckBox;
        public CheckBox MuteUntilLockDetectCheckBox;
        private Label delayLabel;
        public Label ShowDelayLabel;
        private Label label7;
        public CheckBox AutoCDIVCalcCheckBox;
        public NumericUpDown DelayInputNumericUpDown;
        private Label RefSignalLabel;
        public PictureBox LedOffPicBox;
        public PictureBox LedOnPicBox;
        public Label IntExtShowLabel;
        public Label Mem1RefShowLabel;
        public Label Mem1ActOut2ShowLabel;
        public Label Mem1ActOut1ShowLabel;
        private Label MemoryRefLabel;
        private Label MemoryOutput2Label;
        private Label MemoryOutput1Label;
        public Label Mem4RefShowLabel;
        public Label Mem3RefShowLabel;
        public Label Mem2RefShowLabel;
        public Label Mem4ActOut2ShowLabel;
        public Label Mem3ActOut2ShowLabel;
        public Label Mem4ActOut1ShowLabel;
        public Label Mem2ActOut2ShowLabel;
        public Label Mem3ActOut1ShowLabel;
        public Label Mem2ActOut1ShowLabel;
        public Button MemLoadFromFileButton;
        public Button MemSaveIntoFileButton;
        public Label Mem1Freq2ShowLabel;
        public Label Mem1Freq1ShowLabel;
        public Label Mem4Freq2ShowLabel;
        public Label Mem4Freq1ShowLabel;
        public Label Mem3Freq2ShowLabel;
        public Label Mem3Freq1ShowLabel;
        public Label Mem2Freq2ShowLabel;
        public Label Mem2Freq1ShowLabel;
        private Label FreqOut2MemLabel;
        private Label FreqOut1MemLabel;
        private Label MemPwrBLabel;
        private Label MemPwrALabel;
        private GroupBox RegMemoryGroupBox;
        private GroupBox SyntModuleControlsGroupBox;
        private Label label3;
        private Label label4;
        private Label label8;
        private Label label9;
        private GroupBox SynthOutputsInfoGroupBox;
        private Label label13;
        private Label label12;
        private Label label10;
        private Label label11;
        public Label Mem4PwrBShowLabel;
        public Label Mem3PwrBShowLabel;
        public Label Mem2PwrBShowLabel;
        public Label Mem4PwrAShowLabel;
        public Label Mem3PwrAShowLabel;
        public Label Mem2PwrAShowLabel;
        public Label Mem1PwrBShowLabel;
        public Label Mem1PwrAShowLabel;
        public TabPage VcoCalibrationTabPage;
        public Label CurrentVcoShowLabel;
        public Label ActFreqShowLabel;
        public TextBox VcoFreqMaxTextBox;
        private Label CurrentVcoLabel;
        private Label label14;
        private Label ActFreqLabel;
        private Label label15;
        private Label VcoFreqMaxLabel;
        public TextBox VcoFreqMinTextBox;
        private Label label16;
        private Label VcoFreqMinLabel;
        public Button AbortCallibrationButton;
        public Button PerformVcoCalibrationButton;
        public TextBox FreqStepTextBox;
        private Label MHzLable;
        public Label FreqStepLabel;
    }
}

