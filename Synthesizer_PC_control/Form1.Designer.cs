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
            this.genericControlsGroupBox = new System.Windows.Forms.GroupBox();
            this.MuxPinModeCombobox = new System.Windows.Forms.ComboBox();
            this.MuxPinModeLabel = new System.Windows.Forms.Label();
            this.ShutDownGroupBox = new System.Windows.Forms.GroupBox();
            this.VcoSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.PhaseDetectorGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LDPrecisionLabel = new System.Windows.Forms.Label();
            this.SDNoiseModeLabel = new System.Windows.Forms.Label();
            this.PfdPolarity = new System.Windows.Forms.ComboBox();
            this.LDPrecisionComboBox = new System.Windows.Forms.ComboBox();
            this.SigmaDeltaNoiseModeComboBox = new System.Windows.Forms.ComboBox();
            this.RegistersControlsGroupBox = new System.Windows.Forms.GroupBox();
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
            this.RFoutBPathLabel = new System.Windows.Forms.Label();
            this.LDfuncLabel = new System.Windows.Forms.Label();
            this.ADivComboBox = new System.Windows.Forms.ComboBox();
            this.FracNLabel = new System.Windows.Forms.Label();
            this.ModeIntFracComboBox = new System.Windows.Forms.ComboBox();
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
            this.ImportMem4Button = new System.Windows.Forms.Button();
            this.ImportMem3Button = new System.Windows.Forms.Button();
            this.ImportMem2Button = new System.Windows.Forms.Button();
            this.ImportMem1Button = new System.Windows.Forms.Button();
            this.SavReg3Label = new System.Windows.Forms.Label();
            this.R0M4 = new System.Windows.Forms.TextBox();
            this.R0M3 = new System.Windows.Forms.TextBox();
            this.LoadRegMemory = new System.Windows.Forms.Button();
            this.SaveRegMemory = new System.Windows.Forms.Button();
            this.R0M2 = new System.Windows.Forms.TextBox();
            this.R0M1 = new System.Windows.Forms.TextBox();
            this.Mem4Label = new System.Windows.Forms.Label();
            this.Mem3Label = new System.Windows.Forms.Label();
            this.Mem2Label = new System.Windows.Forms.Label();
            this.Mem1Label = new System.Windows.Forms.Label();
            this.SavReg0Label = new System.Windows.Forms.Label();
            this.SavReg1Label = new System.Windows.Forms.Label();
            this.R1M4 = new System.Windows.Forms.TextBox();
            this.R1M3 = new System.Windows.Forms.TextBox();
            this.R1M2 = new System.Windows.Forms.TextBox();
            this.R1M1 = new System.Windows.Forms.TextBox();
            this.SavReg2Label = new System.Windows.Forms.Label();
            this.R2M4 = new System.Windows.Forms.TextBox();
            this.R2M3 = new System.Windows.Forms.TextBox();
            this.R2M2 = new System.Windows.Forms.TextBox();
            this.R2M1 = new System.Windows.Forms.TextBox();
            this.R3M4 = new System.Windows.Forms.TextBox();
            this.R3M3 = new System.Windows.Forms.TextBox();
            this.R3M2 = new System.Windows.Forms.TextBox();
            this.R3M1 = new System.Windows.Forms.TextBox();
            this.SavReg4Label = new System.Windows.Forms.Label();
            this.R4M4 = new System.Windows.Forms.TextBox();
            this.R4M3 = new System.Windows.Forms.TextBox();
            this.R5M4 = new System.Windows.Forms.TextBox();
            this.R4M2 = new System.Windows.Forms.TextBox();
            this.R5M3 = new System.Windows.Forms.TextBox();
            this.R4M1 = new System.Windows.Forms.TextBox();
            this.R5M2 = new System.Windows.Forms.TextBox();
            this.SavReg5Label = new System.Windows.Forms.Label();
            this.R5M1 = new System.Windows.Forms.TextBox();
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
            this.MHzLabel9 = new System.Windows.Forms.Label();
            this.MHzLabel8 = new System.Windows.Forms.Label();
            this.MHzLabel7 = new System.Windows.Forms.Label();
            this.FreqAtOut2ShowLabel = new System.Windows.Forms.Label();
            this.FreqAtOut1ShowLabel = new System.Windows.Forms.Label();
            this.CalcFreqShowLabel = new System.Windows.Forms.Label();
            this.ActOut2ShowLabel = new System.Windows.Forms.Label();
            this.FreqAtOut2Label = new System.Windows.Forms.Label();
            this.ActOut1ShowLabel = new System.Windows.Forms.Label();
            this.FreqAtOut1Label = new System.Windows.Forms.Label();
            this.CalcFreqLabel = new System.Windows.Forms.Label();
            this.ActiveOut2Label = new System.Windows.Forms.Label();
            this.ActiveOut1Label = new System.Windows.Forms.Label();
            this.ConsoleRichTextBox = new System.Windows.Forms.RichTextBox();
            this.SynthModuleInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.RegistersTabControl.SuspendLayout();
            this.RegistersPage.SuspendLayout();
            this.genericControlsGroupBox.SuspendLayout();
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
            this.statusStrip1.SuspendLayout();
            this.DirectFreqContrGroupBox.SuspendLayout();
            this.SynthModuleInfoGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // PortButton
            // 
            this.PortButton.Location = new System.Drawing.Point(22, 11);
            this.PortButton.Margin = new System.Windows.Forms.Padding(4);
            this.PortButton.Name = "PortButton";
            this.PortButton.Size = new System.Drawing.Size(100, 28);
            this.PortButton.TabIndex = 0;
            this.PortButton.Text = "Open Port";
            this.PortButton.UseVisualStyleBackColor = true;
            this.PortButton.Click += new System.EventHandler(this.PortButton_Click);
            // 
            // Out1Button
            // 
            this.Out1Button.Location = new System.Drawing.Point(22, 48);
            this.Out1Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Out1Button.Name = "Out1Button";
            this.Out1Button.Size = new System.Drawing.Size(100, 28);
            this.Out1Button.TabIndex = 1;
            this.Out1Button.Text = "Out 1 Off";
            this.Out1Button.UseVisualStyleBackColor = true;
            this.Out1Button.Click += new System.EventHandler(this.Out1Button_Click);
            // 
            // Out2Button
            // 
            this.Out2Button.Location = new System.Drawing.Point(128, 48);
            this.Out2Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Out2Button.Name = "Out2Button";
            this.Out2Button.Size = new System.Drawing.Size(100, 28);
            this.Out2Button.TabIndex = 1;
            this.Out2Button.Text = "Out 2 Off";
            this.Out2Button.UseVisualStyleBackColor = true;
            this.Out2Button.Click += new System.EventHandler(this.Out2Button_Click);
            // 
            // PloInitButton
            // 
            this.PloInitButton.Location = new System.Drawing.Point(234, 11);
            this.PloInitButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PloInitButton.Name = "PloInitButton";
            this.PloInitButton.Size = new System.Drawing.Size(100, 28);
            this.PloInitButton.TabIndex = 2;
            this.PloInitButton.Text = "PLO Init";
            this.PloInitButton.UseVisualStyleBackColor = true;
            this.PloInitButton.Click += new System.EventHandler(this.PloInitButton_Click);
            // 
            // Reg0TextBox
            // 
            this.Reg0TextBox.BackColor = System.Drawing.Color.White;
            this.Reg0TextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Reg0TextBox.Location = new System.Drawing.Point(88, 20);
            this.Reg0TextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Reg0TextBox.MaxLength = 8;
            this.Reg0TextBox.Name = "Reg0TextBox";
            this.Reg0TextBox.Size = new System.Drawing.Size(100, 22);
            this.Reg0TextBox.TabIndex = 3;
            this.Reg0TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Reg0TextBox.TextChanged += new System.EventHandler(this.RegisterTextBox_TextChanged);
            this.Reg0TextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RegisterTextBox_KeyDown);
            this.Reg0TextBox.LostFocus += new System.EventHandler(this.RegisterTextBox_LostFocus);
            // 
            // Reg0Label
            // 
            this.Reg0Label.AutoSize = true;
            this.Reg0Label.Location = new System.Drawing.Point(9, 23);
            this.Reg0Label.Name = "Reg0Label";
            this.Reg0Label.Size = new System.Drawing.Size(77, 17);
            this.Reg0Label.TabIndex = 4;
            this.Reg0Label.Text = "Register 0:";
            // 
            // Reg1Label
            // 
            this.Reg1Label.AutoSize = true;
            this.Reg1Label.Location = new System.Drawing.Point(9, 52);
            this.Reg1Label.Name = "Reg1Label";
            this.Reg1Label.Size = new System.Drawing.Size(77, 17);
            this.Reg1Label.TabIndex = 5;
            this.Reg1Label.Text = "Register 1:";
            // 
            // Reg1TextBox
            // 
            this.Reg1TextBox.BackColor = System.Drawing.Color.White;
            this.Reg1TextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Reg1TextBox.Location = new System.Drawing.Point(88, 48);
            this.Reg1TextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Reg1TextBox.MaxLength = 8;
            this.Reg1TextBox.Name = "Reg1TextBox";
            this.Reg1TextBox.Size = new System.Drawing.Size(100, 22);
            this.Reg1TextBox.TabIndex = 6;
            this.Reg1TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Reg1TextBox.TextChanged += new System.EventHandler(this.RegisterTextBox_TextChanged);
            this.Reg1TextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RegisterTextBox_KeyDown);
            this.Reg1TextBox.LostFocus += new System.EventHandler(this.RegisterTextBox_LostFocus);
            // 
            // Reg2Label
            // 
            this.Reg2Label.AutoSize = true;
            this.Reg2Label.Location = new System.Drawing.Point(9, 79);
            this.Reg2Label.Name = "Reg2Label";
            this.Reg2Label.Size = new System.Drawing.Size(77, 17);
            this.Reg2Label.TabIndex = 7;
            this.Reg2Label.Text = "Register 2:";
            // 
            // Reg2TextBox
            // 
            this.Reg2TextBox.BackColor = System.Drawing.Color.White;
            this.Reg2TextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Reg2TextBox.Location = new System.Drawing.Point(88, 76);
            this.Reg2TextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Reg2TextBox.MaxLength = 8;
            this.Reg2TextBox.Name = "Reg2TextBox";
            this.Reg2TextBox.Size = new System.Drawing.Size(100, 22);
            this.Reg2TextBox.TabIndex = 8;
            this.Reg2TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Reg2TextBox.TextChanged += new System.EventHandler(this.RegisterTextBox_TextChanged);
            this.Reg2TextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RegisterTextBox_KeyDown);
            this.Reg2TextBox.LostFocus += new System.EventHandler(this.RegisterTextBox_LostFocus);
            // 
            // Reg3Label
            // 
            this.Reg3Label.AutoSize = true;
            this.Reg3Label.Location = new System.Drawing.Point(9, 107);
            this.Reg3Label.Name = "Reg3Label";
            this.Reg3Label.Size = new System.Drawing.Size(77, 17);
            this.Reg3Label.TabIndex = 7;
            this.Reg3Label.Text = "Register 3:";
            // 
            // Reg3TextBox
            // 
            this.Reg3TextBox.BackColor = System.Drawing.Color.White;
            this.Reg3TextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Reg3TextBox.Location = new System.Drawing.Point(88, 104);
            this.Reg3TextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Reg3TextBox.MaxLength = 8;
            this.Reg3TextBox.Name = "Reg3TextBox";
            this.Reg3TextBox.Size = new System.Drawing.Size(100, 22);
            this.Reg3TextBox.TabIndex = 8;
            this.Reg3TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Reg3TextBox.TextChanged += new System.EventHandler(this.RegisterTextBox_TextChanged);
            this.Reg3TextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RegisterTextBox_KeyDown);
            this.Reg3TextBox.LostFocus += new System.EventHandler(this.RegisterTextBox_LostFocus);
            // 
            // Reg4Label
            // 
            this.Reg4Label.AutoSize = true;
            this.Reg4Label.Location = new System.Drawing.Point(9, 133);
            this.Reg4Label.Name = "Reg4Label";
            this.Reg4Label.Size = new System.Drawing.Size(77, 17);
            this.Reg4Label.TabIndex = 7;
            this.Reg4Label.Text = "Register 4:";
            // 
            // Reg4TextBox
            // 
            this.Reg4TextBox.BackColor = System.Drawing.Color.White;
            this.Reg4TextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Reg4TextBox.Location = new System.Drawing.Point(88, 130);
            this.Reg4TextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Reg4TextBox.MaxLength = 8;
            this.Reg4TextBox.Name = "Reg4TextBox";
            this.Reg4TextBox.Size = new System.Drawing.Size(100, 22);
            this.Reg4TextBox.TabIndex = 8;
            this.Reg4TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Reg4TextBox.TextChanged += new System.EventHandler(this.RegisterTextBox_TextChanged);
            this.Reg4TextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RegisterTextBox_KeyDown);
            this.Reg4TextBox.LostFocus += new System.EventHandler(this.RegisterTextBox_LostFocus);
            // 
            // Reg5Label
            // 
            this.Reg5Label.AutoSize = true;
            this.Reg5Label.Location = new System.Drawing.Point(9, 161);
            this.Reg5Label.Name = "Reg5Label";
            this.Reg5Label.Size = new System.Drawing.Size(77, 17);
            this.Reg5Label.TabIndex = 7;
            this.Reg5Label.Text = "Register 5:";
            // 
            // Reg5TextBox
            // 
            this.Reg5TextBox.BackColor = System.Drawing.Color.White;
            this.Reg5TextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Reg5TextBox.Location = new System.Drawing.Point(88, 159);
            this.Reg5TextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Reg5TextBox.MaxLength = 8;
            this.Reg5TextBox.Name = "Reg5TextBox";
            this.Reg5TextBox.Size = new System.Drawing.Size(100, 22);
            this.Reg5TextBox.TabIndex = 8;
            this.Reg5TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Reg5TextBox.TextChanged += new System.EventHandler(this.RegisterTextBox_TextChanged);
            this.Reg5TextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RegisterTextBox_KeyDown);
            this.Reg5TextBox.LostFocus += new System.EventHandler(this.RegisterTextBox_LostFocus);
            // 
            // RefButton
            // 
            this.RefButton.Location = new System.Drawing.Point(234, 48);
            this.RefButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RefButton.Name = "RefButton";
            this.RefButton.Size = new System.Drawing.Size(100, 28);
            this.RefButton.TabIndex = 1;
            this.RefButton.Text = "Ext Ref";
            this.RefButton.UseVisualStyleBackColor = true;
            this.RefButton.Click += new System.EventHandler(this.RefButton_Click);
            // 
            // SetAsDefaultRegButton
            // 
            this.SetAsDefaultRegButton.Location = new System.Drawing.Point(295, 21);
            this.SetAsDefaultRegButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SetAsDefaultRegButton.Name = "SetAsDefaultRegButton";
            this.SetAsDefaultRegButton.Size = new System.Drawing.Size(99, 23);
            this.SetAsDefaultRegButton.TabIndex = 9;
            this.SetAsDefaultRegButton.Text = "Set As Def";
            this.SetAsDefaultRegButton.UseVisualStyleBackColor = true;
            this.SetAsDefaultRegButton.Click += new System.EventHandler(this.SetAsDefaultRegButton_Click);
            // 
            // ForceLoadRegButton
            // 
            this.ForceLoadRegButton.Location = new System.Drawing.Point(295, 78);
            this.ForceLoadRegButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ForceLoadRegButton.Name = "ForceLoadRegButton";
            this.ForceLoadRegButton.Size = new System.Drawing.Size(99, 23);
            this.ForceLoadRegButton.TabIndex = 9;
            this.ForceLoadRegButton.Text = "Force Load ";
            this.ForceLoadRegButton.UseVisualStyleBackColor = true;
            this.ForceLoadRegButton.Click += new System.EventHandler(this.ForceLoadRegButton_Click);
            // 
            // LoadDefRegButton
            // 
            this.LoadDefRegButton.Location = new System.Drawing.Point(295, 49);
            this.LoadDefRegButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LoadDefRegButton.Name = "LoadDefRegButton";
            this.LoadDefRegButton.Size = new System.Drawing.Size(99, 23);
            this.LoadDefRegButton.TabIndex = 9;
            this.LoadDefRegButton.Text = "Load Def";
            this.LoadDefRegButton.UseVisualStyleBackColor = true;
            this.LoadDefRegButton.Click += new System.EventHandler(this.LoadDefRegButton_Click);
            // 
            // AvaibleCOMsComBox
            // 
            this.AvaibleCOMsComBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AvaibleCOMsComBox.FormattingEnabled = true;
            this.AvaibleCOMsComBox.Location = new System.Drawing.Point(129, 11);
            this.AvaibleCOMsComBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AvaibleCOMsComBox.Name = "AvaibleCOMsComBox";
            this.AvaibleCOMsComBox.Size = new System.Drawing.Size(99, 24);
            this.AvaibleCOMsComBox.TabIndex = 10;
            this.AvaibleCOMsComBox.DropDown += new System.EventHandler(this.AvaibleCOMsComBox_DropDown);
            this.AvaibleCOMsComBox.SelectedIndexChanged += new System.EventHandler(this.AvaibleCOMsComBox_SelectedIndexChanged);
            // 
            // WriteR0Button
            // 
            this.WriteR0Button.Location = new System.Drawing.Point(194, 20);
            this.WriteR0Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.WriteR0Button.Name = "WriteR0Button";
            this.WriteR0Button.Size = new System.Drawing.Size(84, 23);
            this.WriteR0Button.TabIndex = 11;
            this.WriteR0Button.Text = "Write R0";
            this.WriteR0Button.UseVisualStyleBackColor = true;
            this.WriteR0Button.Click += new System.EventHandler(this.WriteRegisterButton_Click);
            // 
            // WriteR1Button
            // 
            this.WriteR1Button.Location = new System.Drawing.Point(194, 48);
            this.WriteR1Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.WriteR1Button.Name = "WriteR1Button";
            this.WriteR1Button.Size = new System.Drawing.Size(84, 23);
            this.WriteR1Button.TabIndex = 11;
            this.WriteR1Button.Text = "Write R1";
            this.WriteR1Button.UseVisualStyleBackColor = true;
            this.WriteR1Button.Click += new System.EventHandler(this.WriteRegisterButton_Click);
            // 
            // WriteR2Button
            // 
            this.WriteR2Button.Location = new System.Drawing.Point(194, 76);
            this.WriteR2Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.WriteR2Button.Name = "WriteR2Button";
            this.WriteR2Button.Size = new System.Drawing.Size(84, 23);
            this.WriteR2Button.TabIndex = 11;
            this.WriteR2Button.Text = "Write R2";
            this.WriteR2Button.UseVisualStyleBackColor = true;
            this.WriteR2Button.Click += new System.EventHandler(this.WriteRegisterButton_Click);
            // 
            // WriteR3Button
            // 
            this.WriteR3Button.Location = new System.Drawing.Point(194, 104);
            this.WriteR3Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.WriteR3Button.Name = "WriteR3Button";
            this.WriteR3Button.Size = new System.Drawing.Size(84, 23);
            this.WriteR3Button.TabIndex = 11;
            this.WriteR3Button.Text = "Write R3";
            this.WriteR3Button.UseVisualStyleBackColor = true;
            this.WriteR3Button.Click += new System.EventHandler(this.WriteRegisterButton_Click);
            // 
            // WriteR4Button
            // 
            this.WriteR4Button.Location = new System.Drawing.Point(194, 130);
            this.WriteR4Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.WriteR4Button.Name = "WriteR4Button";
            this.WriteR4Button.Size = new System.Drawing.Size(84, 23);
            this.WriteR4Button.TabIndex = 11;
            this.WriteR4Button.Text = "Write R4";
            this.WriteR4Button.UseVisualStyleBackColor = true;
            this.WriteR4Button.Click += new System.EventHandler(this.WriteRegisterButton_Click);
            // 
            // WriteR5Button
            // 
            this.WriteR5Button.Location = new System.Drawing.Point(194, 159);
            this.WriteR5Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.WriteR5Button.Name = "WriteR5Button";
            this.WriteR5Button.Size = new System.Drawing.Size(84, 23);
            this.WriteR5Button.TabIndex = 11;
            this.WriteR5Button.Text = "Write R5";
            this.WriteR5Button.UseVisualStyleBackColor = true;
            this.WriteR5Button.Click += new System.EventHandler(this.WriteRegisterButton_Click);
            // 
            // RegistersTabControl
            // 
            this.RegistersTabControl.Controls.Add(this.RegistersPage);
            this.RegistersTabControl.Controls.Add(this.RegistersMemoryPage);
            this.RegistersTabControl.Location = new System.Drawing.Point(352, 23);
            this.RegistersTabControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RegistersTabControl.Name = "RegistersTabControl";
            this.RegistersTabControl.SelectedIndex = 0;
            this.RegistersTabControl.Size = new System.Drawing.Size(717, 847);
            this.RegistersTabControl.TabIndex = 12;
            // 
            // RegistersPage
            // 
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
            this.RegistersPage.Location = new System.Drawing.Point(4, 25);
            this.RegistersPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RegistersPage.Name = "RegistersPage";
            this.RegistersPage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RegistersPage.Size = new System.Drawing.Size(709, 818);
            this.RegistersPage.TabIndex = 0;
            this.RegistersPage.Text = "Direct Control Of Registers";
            this.RegistersPage.UseVisualStyleBackColor = true;
            this.RegistersPage.Click += new System.EventHandler(this.RegistersPage_Click);
            // 
            // genericControlsGroupBox
            // 
            this.genericControlsGroupBox.Controls.Add(this.MuxPinModeCombobox);
            this.genericControlsGroupBox.Controls.Add(this.MuxPinModeLabel);
            this.genericControlsGroupBox.Location = new System.Drawing.Point(7, 595);
            this.genericControlsGroupBox.Name = "genericControlsGroupBox";
            this.genericControlsGroupBox.Size = new System.Drawing.Size(341, 118);
            this.genericControlsGroupBox.TabIndex = 31;
            this.genericControlsGroupBox.TabStop = false;
            this.genericControlsGroupBox.Text = "Generic Controls";
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
            this.MuxPinModeCombobox.Location = new System.Drawing.Point(116, 20);
            this.MuxPinModeCombobox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MuxPinModeCombobox.Name = "MuxPinModeCombobox";
            this.MuxPinModeCombobox.Size = new System.Drawing.Size(160, 24);
            this.MuxPinModeCombobox.TabIndex = 16;
            this.MuxPinModeCombobox.SelectedIndexChanged += new System.EventHandler(this.MuxPinModeCombobox_SelectedIndexChanged);
            // 
            // MuxPinModeLabel
            // 
            this.MuxPinModeLabel.Location = new System.Drawing.Point(-10, 23);
            this.MuxPinModeLabel.Name = "MuxPinModeLabel";
            this.MuxPinModeLabel.Size = new System.Drawing.Size(120, 17);
            this.MuxPinModeLabel.TabIndex = 17;
            this.MuxPinModeLabel.Text = "Mux Pin Mode:";
            this.MuxPinModeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ShutDownGroupBox
            // 
            this.ShutDownGroupBox.Location = new System.Drawing.Point(356, 503);
            this.ShutDownGroupBox.Name = "ShutDownGroupBox";
            this.ShutDownGroupBox.Size = new System.Drawing.Size(341, 86);
            this.ShutDownGroupBox.TabIndex = 30;
            this.ShutDownGroupBox.TabStop = false;
            this.ShutDownGroupBox.Text = "Shutdown Controls";
            // 
            // VcoSettingsGroupBox
            // 
            this.VcoSettingsGroupBox.Location = new System.Drawing.Point(356, 198);
            this.VcoSettingsGroupBox.Name = "VcoSettingsGroupBox";
            this.VcoSettingsGroupBox.Size = new System.Drawing.Size(341, 144);
            this.VcoSettingsGroupBox.TabIndex = 29;
            this.VcoSettingsGroupBox.TabStop = false;
            this.VcoSettingsGroupBox.Text = "VCO settings";
            // 
            // PhaseDetectorGroupBox
            // 
            this.PhaseDetectorGroupBox.Controls.Add(this.label1);
            this.PhaseDetectorGroupBox.Controls.Add(this.LDPrecisionLabel);
            this.PhaseDetectorGroupBox.Controls.Add(this.SDNoiseModeLabel);
            this.PhaseDetectorGroupBox.Controls.Add(this.PfdPolarity);
            this.PhaseDetectorGroupBox.Controls.Add(this.LDPrecisionComboBox);
            this.PhaseDetectorGroupBox.Controls.Add(this.SigmaDeltaNoiseModeComboBox);
            this.PhaseDetectorGroupBox.Location = new System.Drawing.Point(7, 503);
            this.PhaseDetectorGroupBox.Name = "PhaseDetectorGroupBox";
            this.PhaseDetectorGroupBox.Size = new System.Drawing.Size(341, 86);
            this.PhaseDetectorGroupBox.TabIndex = 28;
            this.PhaseDetectorGroupBox.TabStop = false;
            this.PhaseDetectorGroupBox.Text = "Phase Detector";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(172, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "PFD polarity:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LDPrecisionLabel
            // 
            this.LDPrecisionLabel.Location = new System.Drawing.Point(1, 55);
            this.LDPrecisionLabel.Name = "LDPrecisionLabel";
            this.LDPrecisionLabel.Size = new System.Drawing.Size(96, 17);
            this.LDPrecisionLabel.TabIndex = 17;
            this.LDPrecisionLabel.Text = "LD precision:";
            this.LDPrecisionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SDNoiseModeLabel
            // 
            this.SDNoiseModeLabel.Location = new System.Drawing.Point(6, 24);
            this.SDNoiseModeLabel.Name = "SDNoiseModeLabel";
            this.SDNoiseModeLabel.Size = new System.Drawing.Size(120, 17);
            this.SDNoiseModeLabel.TabIndex = 17;
            this.SDNoiseModeLabel.Text = "S-D Noise Mode:";
            this.SDNoiseModeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PfdPolarity
            // 
            this.PfdPolarity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.PfdPolarity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PfdPolarity.FormattingEnabled = true;
            this.PfdPolarity.Items.AddRange(new object[] {
            "neg",
            "pos"});
            this.PfdPolarity.Location = new System.Drawing.Point(274, 52);
            this.PfdPolarity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PfdPolarity.Name = "PfdPolarity";
            this.PfdPolarity.Size = new System.Drawing.Size(61, 24);
            this.PfdPolarity.TabIndex = 16;
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
            this.LDPrecisionComboBox.Location = new System.Drawing.Point(103, 52);
            this.LDPrecisionComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LDPrecisionComboBox.Name = "LDPrecisionComboBox";
            this.LDPrecisionComboBox.Size = new System.Drawing.Size(67, 24);
            this.LDPrecisionComboBox.TabIndex = 16;
            this.LDPrecisionComboBox.SelectedIndexChanged += new System.EventHandler(this.LDPrecisionComboBox_SelectedIndexChanged);
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
            this.SigmaDeltaNoiseModeComboBox.Location = new System.Drawing.Point(132, 21);
            this.SigmaDeltaNoiseModeComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SigmaDeltaNoiseModeComboBox.Name = "SigmaDeltaNoiseModeComboBox";
            this.SigmaDeltaNoiseModeComboBox.Size = new System.Drawing.Size(144, 24);
            this.SigmaDeltaNoiseModeComboBox.TabIndex = 16;
            this.SigmaDeltaNoiseModeComboBox.SelectedIndexChanged += new System.EventHandler(this.SDNoiseModeComboBox_SelectedIndexChanged);
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
            this.RegistersControlsGroupBox.Location = new System.Drawing.Point(7, 5);
            this.RegistersControlsGroupBox.Name = "RegistersControlsGroupBox";
            this.RegistersControlsGroupBox.Size = new System.Drawing.Size(400, 187);
            this.RegistersControlsGroupBox.TabIndex = 22;
            this.RegistersControlsGroupBox.TabStop = false;
            this.RegistersControlsGroupBox.Text = "Registers controls";
            // 
            // MoveRegsIntoMemsGroupBox
            // 
            this.MoveRegsIntoMemsGroupBox.Controls.Add(this.ExportIntoMem1Button);
            this.MoveRegsIntoMemsGroupBox.Controls.Add(this.ExportIntoMem2Button);
            this.MoveRegsIntoMemsGroupBox.Controls.Add(this.ExportIntoMem3Button);
            this.MoveRegsIntoMemsGroupBox.Controls.Add(this.ExportIntoMem4Button);
            this.MoveRegsIntoMemsGroupBox.Location = new System.Drawing.Point(413, 5);
            this.MoveRegsIntoMemsGroupBox.Name = "MoveRegsIntoMemsGroupBox";
            this.MoveRegsIntoMemsGroupBox.Size = new System.Drawing.Size(175, 187);
            this.MoveRegsIntoMemsGroupBox.TabIndex = 27;
            this.MoveRegsIntoMemsGroupBox.TabStop = false;
            this.MoveRegsIntoMemsGroupBox.Text = "Move the currently set registers to the register memory tab:";
            // 
            // ExportIntoMem1Button
            // 
            this.ExportIntoMem1Button.Location = new System.Drawing.Point(39, 63);
            this.ExportIntoMem1Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ExportIntoMem1Button.Name = "ExportIntoMem1Button";
            this.ExportIntoMem1Button.Size = new System.Drawing.Size(99, 23);
            this.ExportIntoMem1Button.TabIndex = 9;
            this.ExportIntoMem1Button.Text = "Memory 1";
            this.ExportIntoMem1Button.UseVisualStyleBackColor = true;
            this.ExportIntoMem1Button.Click += new System.EventHandler(this.ExportIntoMememoryButton_Click);
            // 
            // ExportIntoMem2Button
            // 
            this.ExportIntoMem2Button.Location = new System.Drawing.Point(39, 91);
            this.ExportIntoMem2Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ExportIntoMem2Button.Name = "ExportIntoMem2Button";
            this.ExportIntoMem2Button.Size = new System.Drawing.Size(99, 23);
            this.ExportIntoMem2Button.TabIndex = 9;
            this.ExportIntoMem2Button.Text = "Memory 2";
            this.ExportIntoMem2Button.UseVisualStyleBackColor = true;
            this.ExportIntoMem2Button.Click += new System.EventHandler(this.ExportIntoMememoryButton_Click);
            // 
            // ExportIntoMem3Button
            // 
            this.ExportIntoMem3Button.Location = new System.Drawing.Point(39, 119);
            this.ExportIntoMem3Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ExportIntoMem3Button.Name = "ExportIntoMem3Button";
            this.ExportIntoMem3Button.Size = new System.Drawing.Size(99, 23);
            this.ExportIntoMem3Button.TabIndex = 9;
            this.ExportIntoMem3Button.Text = "Memory 3";
            this.ExportIntoMem3Button.UseVisualStyleBackColor = true;
            this.ExportIntoMem3Button.Click += new System.EventHandler(this.ExportIntoMememoryButton_Click);
            // 
            // ExportIntoMem4Button
            // 
            this.ExportIntoMem4Button.Location = new System.Drawing.Point(39, 147);
            this.ExportIntoMem4Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ExportIntoMem4Button.Name = "ExportIntoMem4Button";
            this.ExportIntoMem4Button.Size = new System.Drawing.Size(99, 23);
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
            this.ChargePumpGroupBox.Location = new System.Drawing.Point(356, 349);
            this.ChargePumpGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.ChargePumpGroupBox.Name = "ChargePumpGroupBox";
            this.ChargePumpGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.ChargePumpGroupBox.Size = new System.Drawing.Size(341, 147);
            this.ChargePumpGroupBox.TabIndex = 26;
            this.ChargePumpGroupBox.TabStop = false;
            this.ChargePumpGroupBox.Text = "Charge Pump";
            // 
            // PhaseAdjustmentModeCheckbox
            // 
            this.PhaseAdjustmentModeCheckbox.AutoSize = true;
            this.PhaseAdjustmentModeCheckbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.PhaseAdjustmentModeCheckbox.Location = new System.Drawing.Point(208, 57);
            this.PhaseAdjustmentModeCheckbox.Margin = new System.Windows.Forms.Padding(4);
            this.PhaseAdjustmentModeCheckbox.Name = "PhaseAdjustmentModeCheckbox";
            this.PhaseAdjustmentModeCheckbox.Size = new System.Drawing.Size(121, 21);
            this.PhaseAdjustmentModeCheckbox.TabIndex = 18;
            this.PhaseAdjustmentModeCheckbox.Text = "Phase Adjust.:";
            this.PhaseAdjustmentModeCheckbox.UseVisualStyleBackColor = true;
            this.PhaseAdjustmentModeCheckbox.CheckedChanged += new System.EventHandler(this.PhaseAdjustmentModeCheckbox_CheckedChanged);
            // 
            // CPCycleSlipCheckBox
            // 
            this.CPCycleSlipCheckBox.AutoSize = true;
            this.CPCycleSlipCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CPCycleSlipCheckBox.Location = new System.Drawing.Point(194, 115);
            this.CPCycleSlipCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.CPCycleSlipCheckBox.Name = "CPCycleSlipCheckBox";
            this.CPCycleSlipCheckBox.Size = new System.Drawing.Size(134, 21);
            this.CPCycleSlipCheckBox.TabIndex = 18;
            this.CPCycleSlipCheckBox.Text = "Cycle Slip Mode:";
            this.CPCycleSlipCheckBox.UseVisualStyleBackColor = true;
            this.CPCycleSlipCheckBox.CheckedChanged += new System.EventHandler(this.CPCycleSlipCheckBox_CheckedChanged);
            // 
            // CPTriStateOutCheckBox
            // 
            this.CPTriStateOutCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.CPTriStateOutCheckBox.AutoSize = true;
            this.CPTriStateOutCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CPTriStateOutCheckBox.Location = new System.Drawing.Point(205, 86);
            this.CPTriStateOutCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.CPTriStateOutCheckBox.Name = "CPTriStateOutCheckBox";
            this.CPTriStateOutCheckBox.Size = new System.Drawing.Size(129, 21);
            this.CPTriStateOutCheckBox.TabIndex = 18;
            this.CPTriStateOutCheckBox.Text = "Tristate Output:";
            this.CPTriStateOutCheckBox.UseVisualStyleBackColor = true;
            this.CPTriStateOutCheckBox.CheckedChanged += new System.EventHandler(this.CPTriStateOutCheckBox_CheckedChanged);
            // 
            // CPFastLockCheckBox
            // 
            this.CPFastLockCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CPFastLockCheckBox.AutoSize = true;
            this.CPFastLockCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CPFastLockCheckBox.Location = new System.Drawing.Point(239, 30);
            this.CPFastLockCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.CPFastLockCheckBox.Name = "CPFastLockCheckBox";
            this.CPFastLockCheckBox.Size = new System.Drawing.Size(95, 21);
            this.CPFastLockCheckBox.TabIndex = 18;
            this.CPFastLockCheckBox.Text = "Fast Lock:";
            this.CPFastLockCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CPFastLockCheckBox.UseVisualStyleBackColor = true;
            this.CPFastLockCheckBox.CheckedChanged += new System.EventHandler(this.CPFastLockCheckBox_CheckedChanged);
            // 
            // RSetTextBox
            // 
            this.RSetTextBox.BackColor = System.Drawing.Color.White;
            this.RSetTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.RSetTextBox.Location = new System.Drawing.Point(73, 22);
            this.RSetTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RSetTextBox.MaxLength = 5;
            this.RSetTextBox.Name = "RSetTextBox";
            this.RSetTextBox.Size = new System.Drawing.Size(53, 22);
            this.RSetTextBox.TabIndex = 3;
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
            this.CPTestComboBox.Location = new System.Drawing.Point(73, 113);
            this.CPTestComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CPTestComboBox.Name = "CPTestComboBox";
            this.CPTestComboBox.Size = new System.Drawing.Size(116, 24);
            this.CPTestComboBox.TabIndex = 16;
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
            this.CPLinearityComboBox.Location = new System.Drawing.Point(73, 82);
            this.CPLinearityComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CPLinearityComboBox.Name = "CPLinearityComboBox";
            this.CPLinearityComboBox.Size = new System.Drawing.Size(116, 24);
            this.CPLinearityComboBox.TabIndex = 16;
            this.CPLinearityComboBox.SelectedIndexChanged += new System.EventHandler(this.CPLinearityComboBox_SelectedIndexChanged);
            // 
            // CPTestLabel
            // 
            this.CPTestLabel.Location = new System.Drawing.Point(0, 117);
            this.CPTestLabel.Name = "CPTestLabel";
            this.CPTestLabel.Size = new System.Drawing.Size(68, 17);
            this.CPTestLabel.TabIndex = 17;
            this.CPTestLabel.Text = "CP Test:";
            this.CPTestLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CPCurrentComboBox
            // 
            this.CPCurrentComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CPCurrentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CPCurrentComboBox.FormattingEnabled = true;
            this.CPCurrentComboBox.Location = new System.Drawing.Point(73, 52);
            this.CPCurrentComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CPCurrentComboBox.Name = "CPCurrentComboBox";
            this.CPCurrentComboBox.Size = new System.Drawing.Size(116, 24);
            this.CPCurrentComboBox.TabIndex = 16;
            this.CPCurrentComboBox.SelectedIndexChanged += new System.EventHandler(this.CPCurrentComboBox_SelectedIndexChanged);
            // 
            // CPLinearityLabel
            // 
            this.CPLinearityLabel.Location = new System.Drawing.Point(0, 86);
            this.CPLinearityLabel.Name = "CPLinearityLabel";
            this.CPLinearityLabel.Size = new System.Drawing.Size(68, 17);
            this.CPLinearityLabel.TabIndex = 17;
            this.CPLinearityLabel.Text = "Linearity:";
            this.CPLinearityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RSetLabel
            // 
            this.RSetLabel.Location = new System.Drawing.Point(0, 26);
            this.RSetLabel.Name = "RSetLabel";
            this.RSetLabel.Size = new System.Drawing.Size(68, 17);
            this.RSetLabel.TabIndex = 17;
            this.RSetLabel.Text = "R set:";
            this.RSetLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CPCurrentLabel
            // 
            this.CPCurrentLabel.Location = new System.Drawing.Point(4, 55);
            this.CPCurrentLabel.Name = "CPCurrentLabel";
            this.CPCurrentLabel.Size = new System.Drawing.Size(64, 17);
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
            this.OutputControlsGroupBox.Location = new System.Drawing.Point(231, 720);
            this.OutputControlsGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.OutputControlsGroupBox.Name = "OutputControlsGroupBox";
            this.OutputControlsGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.OutputControlsGroupBox.Size = new System.Drawing.Size(459, 75);
            this.OutputControlsGroupBox.TabIndex = 25;
            this.OutputControlsGroupBox.TabStop = false;
            this.OutputControlsGroupBox.Text = "Output Controls";
            // 
            // RF_A_EN_Label
            // 
            this.RF_A_EN_Label.Location = new System.Drawing.Point(7, 21);
            this.RF_A_EN_Label.Name = "RF_A_EN_Label";
            this.RF_A_EN_Label.Size = new System.Drawing.Size(113, 17);
            this.RF_A_EN_Label.TabIndex = 7;
            this.RF_A_EN_Label.Text = "RFoutA Enable:";
            this.RF_A_EN_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RF_A_PWR_Label
            // 
            this.RF_A_PWR_Label.Location = new System.Drawing.Point(7, 50);
            this.RF_A_PWR_Label.Name = "RF_A_PWR_Label";
            this.RF_A_PWR_Label.Size = new System.Drawing.Size(113, 17);
            this.RF_A_PWR_Label.TabIndex = 7;
            this.RF_A_PWR_Label.Text = "RFoutA Power:";
            this.RF_A_PWR_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RF_B_EN_Label
            // 
            this.RF_B_EN_Label.Location = new System.Drawing.Point(232, 21);
            this.RF_B_EN_Label.Name = "RF_B_EN_Label";
            this.RF_B_EN_Label.Size = new System.Drawing.Size(113, 17);
            this.RF_B_EN_Label.TabIndex = 7;
            this.RF_B_EN_Label.Text = "RFoutB Enable:";
            this.RF_B_EN_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RF_B_PWR_Label
            // 
            this.RF_B_PWR_Label.Location = new System.Drawing.Point(232, 50);
            this.RF_B_PWR_Label.Name = "RF_B_PWR_Label";
            this.RF_B_PWR_Label.Size = new System.Drawing.Size(113, 17);
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
            this.OutBPwr_ComboBox.Location = new System.Drawing.Point(352, 47);
            this.OutBPwr_ComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OutBPwr_ComboBox.Name = "OutBPwr_ComboBox";
            this.OutBPwr_ComboBox.Size = new System.Drawing.Size(100, 23);
            this.OutBPwr_ComboBox.TabIndex = 16;
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
            this.OutAEn_ComboBox.Location = new System.Drawing.Point(127, 18);
            this.OutAEn_ComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OutAEn_ComboBox.Name = "OutAEn_ComboBox";
            this.OutAEn_ComboBox.Size = new System.Drawing.Size(100, 24);
            this.OutAEn_ComboBox.TabIndex = 16;
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
            this.OutAPwr_ComboBox.Location = new System.Drawing.Point(127, 47);
            this.OutAPwr_ComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OutAPwr_ComboBox.Name = "OutAPwr_ComboBox";
            this.OutAPwr_ComboBox.Size = new System.Drawing.Size(100, 23);
            this.OutAPwr_ComboBox.TabIndex = 16;
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
            this.OutBEn_ComboBox.Location = new System.Drawing.Point(352, 18);
            this.OutBEn_ComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OutBEn_ComboBox.Name = "OutBEn_ComboBox";
            this.OutBEn_ComboBox.Size = new System.Drawing.Size(100, 24);
            this.OutBEn_ComboBox.TabIndex = 16;
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
            this.OutInfoGroupBox.Location = new System.Drawing.Point(7, 720);
            this.OutInfoGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.OutInfoGroupBox.Name = "OutInfoGroupBox";
            this.OutInfoGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.OutInfoGroupBox.Size = new System.Drawing.Size(216, 75);
            this.OutInfoGroupBox.TabIndex = 24;
            this.OutInfoGroupBox.TabStop = false;
            this.OutInfoGroupBox.Text = "Output Frequency Info";
            // 
            // fOutALabel
            // 
            this.fOutALabel.Location = new System.Drawing.Point(8, 36);
            this.fOutALabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fOutALabel.Name = "fOutALabel";
            this.fOutALabel.Size = new System.Drawing.Size(61, 16);
            this.fOutALabel.TabIndex = 20;
            this.fOutALabel.Text = "fOUT A:";
            this.fOutALabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MHzLabel1
            // 
            this.MHzLabel1.Location = new System.Drawing.Point(175, 34);
            this.MHzLabel1.Name = "MHzLabel1";
            this.MHzLabel1.Size = new System.Drawing.Size(40, 17);
            this.MHzLabel1.TabIndex = 17;
            this.MHzLabel1.Text = "MHz";
            this.MHzLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MHzLabel5
            // 
            this.MHzLabel5.Location = new System.Drawing.Point(175, 52);
            this.MHzLabel5.Name = "MHzLabel5";
            this.MHzLabel5.Size = new System.Drawing.Size(40, 17);
            this.MHzLabel5.TabIndex = 17;
            this.MHzLabel5.Text = "MHz";
            this.MHzLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fVcoLabel
            // 
            this.fVcoLabel.Location = new System.Drawing.Point(8, 18);
            this.fVcoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fVcoLabel.Name = "fVcoLabel";
            this.fVcoLabel.Size = new System.Drawing.Size(61, 16);
            this.fVcoLabel.TabIndex = 20;
            this.fVcoLabel.Text = "fVCO:";
            this.fVcoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MHzLabel2
            // 
            this.MHzLabel2.Location = new System.Drawing.Point(175, 17);
            this.MHzLabel2.Name = "MHzLabel2";
            this.MHzLabel2.Size = new System.Drawing.Size(40, 17);
            this.MHzLabel2.TabIndex = 17;
            this.MHzLabel2.Text = "MHz";
            this.MHzLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fOutBLabel
            // 
            this.fOutBLabel.Location = new System.Drawing.Point(8, 53);
            this.fOutBLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fOutBLabel.Name = "fOutBLabel";
            this.fOutBLabel.Size = new System.Drawing.Size(61, 16);
            this.fOutBLabel.TabIndex = 20;
            this.fOutBLabel.Text = "fOUT B:";
            this.fOutBLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // fOutAScreenLabel
            // 
            this.fOutAScreenLabel.Location = new System.Drawing.Point(71, 36);
            this.fOutAScreenLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fOutAScreenLabel.Name = "fOutAScreenLabel";
            this.fOutAScreenLabel.Size = new System.Drawing.Size(109, 16);
            this.fOutAScreenLabel.TabIndex = 20;
            this.fOutAScreenLabel.Text = "6000.000 000 0";
            this.fOutAScreenLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // fOutBScreenLabel
            // 
            this.fOutBScreenLabel.Location = new System.Drawing.Point(71, 53);
            this.fOutBScreenLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fOutBScreenLabel.Name = "fOutBScreenLabel";
            this.fOutBScreenLabel.Size = new System.Drawing.Size(109, 16);
            this.fOutBScreenLabel.TabIndex = 20;
            this.fOutBScreenLabel.Text = "6000.000 000 0";
            this.fOutBScreenLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // fVcoScreenLabel
            // 
            this.fVcoScreenLabel.Location = new System.Drawing.Point(71, 18);
            this.fVcoScreenLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fVcoScreenLabel.Name = "fVcoScreenLabel";
            this.fVcoScreenLabel.Size = new System.Drawing.Size(109, 16);
            this.fVcoScreenLabel.TabIndex = 20;
            this.fVcoScreenLabel.Text = "6000.000 000 0";
            this.fVcoScreenLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FreqControlGroupBox
            // 
            this.FreqControlGroupBox.Controls.Add(this.RFoutBPathLabel);
            this.FreqControlGroupBox.Controls.Add(this.LDfuncLabel);
            this.FreqControlGroupBox.Controls.Add(this.ADivComboBox);
            this.FreqControlGroupBox.Controls.Add(this.FracNLabel);
            this.FreqControlGroupBox.Controls.Add(this.ModeIntFracComboBox);
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
            this.FreqControlGroupBox.Location = new System.Drawing.Point(7, 327);
            this.FreqControlGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.FreqControlGroupBox.Name = "FreqControlGroupBox";
            this.FreqControlGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.FreqControlGroupBox.Size = new System.Drawing.Size(341, 169);
            this.FreqControlGroupBox.TabIndex = 23;
            this.FreqControlGroupBox.TabStop = false;
            this.FreqControlGroupBox.Text = "Output Frequency Control";
            // 
            // RFoutBPathLabel
            // 
            this.RFoutBPathLabel.Location = new System.Drawing.Point(-3, 140);
            this.RFoutBPathLabel.Name = "RFoutBPathLabel";
            this.RFoutBPathLabel.Size = new System.Drawing.Size(100, 17);
            this.RFoutBPathLabel.TabIndex = 17;
            this.RFoutBPathLabel.Text = "RFoutB path:";
            this.RFoutBPathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LDfuncLabel
            // 
            this.LDfuncLabel.Location = new System.Drawing.Point(10, 110);
            this.LDfuncLabel.Name = "LDfuncLabel";
            this.LDfuncLabel.Size = new System.Drawing.Size(87, 17);
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
            this.ADivComboBox.Location = new System.Drawing.Point(226, 50);
            this.ADivComboBox.Name = "ADivComboBox";
            this.ADivComboBox.Size = new System.Drawing.Size(106, 24);
            this.ADivComboBox.TabIndex = 20;
            this.ADivComboBox.SelectedIndexChanged += new System.EventHandler(this.ADivComboBox_SelectedIndexChanged);
            // 
            // FracNLabel
            // 
            this.FracNLabel.Location = new System.Drawing.Point(7, 53);
            this.FracNLabel.Name = "FracNLabel";
            this.FracNLabel.Size = new System.Drawing.Size(52, 17);
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
            this.ModeIntFracComboBox.Location = new System.Drawing.Point(226, 21);
            this.ModeIntFracComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ModeIntFracComboBox.Name = "ModeIntFracComboBox";
            this.ModeIntFracComboBox.Size = new System.Drawing.Size(106, 24);
            this.ModeIntFracComboBox.TabIndex = 16;
            this.ModeIntFracComboBox.SelectedIndexChanged += new System.EventHandler(this.ModeIntFracComboBox_SelectedIndexChanged);
            // 
            // RFoutBPathComboBox
            // 
            this.RFoutBPathComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.RFoutBPathComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RFoutBPathComboBox.FormattingEnabled = true;
            this.RFoutBPathComboBox.Items.AddRange(new object[] {
            "VCO divided",
            "VCO fundamental"});
            this.RFoutBPathComboBox.Location = new System.Drawing.Point(103, 137);
            this.RFoutBPathComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RFoutBPathComboBox.Name = "RFoutBPathComboBox";
            this.RFoutBPathComboBox.Size = new System.Drawing.Size(150, 24);
            this.RFoutBPathComboBox.TabIndex = 16;
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
            this.LDFuncComboBox.Location = new System.Drawing.Point(103, 107);
            this.LDFuncComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LDFuncComboBox.Name = "LDFuncComboBox";
            this.LDFuncComboBox.Size = new System.Drawing.Size(150, 24);
            this.LDFuncComboBox.TabIndex = 16;
            this.LDFuncComboBox.SelectedIndexChanged += new System.EventHandler(this.LDFuncComboBox_SelectedIndexChanged);
            // 
            // AutoLDFuncCheckBox
            // 
            this.AutoLDFuncCheckBox.AutoSize = true;
            this.AutoLDFuncCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AutoLDFuncCheckBox.Location = new System.Drawing.Point(260, 109);
            this.AutoLDFuncCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.AutoLDFuncCheckBox.Name = "AutoLDFuncCheckBox";
            this.AutoLDFuncCheckBox.Size = new System.Drawing.Size(58, 21);
            this.AutoLDFuncCheckBox.TabIndex = 21;
            this.AutoLDFuncCheckBox.Text = "auto";
            this.AutoLDFuncCheckBox.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.AutoLDFuncCheckBox.UseVisualStyleBackColor = true;
            this.AutoLDFuncCheckBox.CheckedChanged += new System.EventHandler(this.AutoLDFuncCheckBox_CheckedChanged);
            // 
            // IntNLabel
            // 
            this.IntNLabel.Location = new System.Drawing.Point(7, 25);
            this.IntNLabel.Name = "IntNLabel";
            this.IntNLabel.Size = new System.Drawing.Size(52, 17);
            this.IntNLabel.TabIndex = 17;
            this.IntNLabel.Text = "IntN:";
            this.IntNLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ModeIntFracLabel
            // 
            this.ModeIntFracLabel.Location = new System.Drawing.Point(170, 24);
            this.ModeIntFracLabel.Name = "ModeIntFracLabel";
            this.ModeIntFracLabel.Size = new System.Drawing.Size(52, 17);
            this.ModeIntFracLabel.TabIndex = 17;
            this.ModeIntFracLabel.Text = "Mode:";
            this.ModeIntFracLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ModLabel
            // 
            this.ModLabel.Location = new System.Drawing.Point(7, 81);
            this.ModLabel.Name = "ModLabel";
            this.ModLabel.Size = new System.Drawing.Size(52, 17);
            this.ModLabel.TabIndex = 17;
            this.ModLabel.Text = "MOD:";
            this.ModLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ADivLabel
            // 
            this.ADivLabel.Location = new System.Drawing.Point(151, 53);
            this.ADivLabel.Name = "ADivLabel";
            this.ADivLabel.Size = new System.Drawing.Size(71, 17);
            this.ADivLabel.TabIndex = 17;
            this.ADivLabel.Text = "A Divider:";
            this.ADivLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PhasePLabel
            // 
            this.PhasePLabel.Location = new System.Drawing.Point(151, 81);
            this.PhasePLabel.Name = "PhasePLabel";
            this.PhasePLabel.Size = new System.Drawing.Size(71, 17);
            this.PhasePLabel.TabIndex = 17;
            this.PhasePLabel.Text = "Phase P:";
            this.PhasePLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // IntNNumUpDown
            // 
            this.IntNNumUpDown.Location = new System.Drawing.Point(64, 22);
            this.IntNNumUpDown.Margin = new System.Windows.Forms.Padding(4);
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
            this.IntNNumUpDown.Size = new System.Drawing.Size(83, 22);
            this.IntNNumUpDown.TabIndex = 19;
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
            this.ModNumUpDown.Location = new System.Drawing.Point(64, 79);
            this.ModNumUpDown.Margin = new System.Windows.Forms.Padding(4);
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
            this.ModNumUpDown.Size = new System.Drawing.Size(83, 22);
            this.ModNumUpDown.TabIndex = 19;
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
            this.FracNNumUpDown.Location = new System.Drawing.Point(64, 50);
            this.FracNNumUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.FracNNumUpDown.Maximum = new decimal(new int[] {
            4095,
            0,
            0,
            0});
            this.FracNNumUpDown.Name = "FracNNumUpDown";
            this.FracNNumUpDown.Size = new System.Drawing.Size(83, 22);
            this.FracNNumUpDown.TabIndex = 19;
            this.FracNNumUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.FracNNumUpDown.ValueChanged += new System.EventHandler(this.FracNNumUpDown_ValueChanged);
            this.FracNNumUpDown.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.NumericUpDwScrollHandlerFunction);
            // 
            // PhasePNumericUpDown
            // 
            this.PhasePNumericUpDown.Location = new System.Drawing.Point(226, 79);
            this.PhasePNumericUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.PhasePNumericUpDown.Maximum = new decimal(new int[] {
            4095,
            0,
            0,
            0});
            this.PhasePNumericUpDown.Name = "PhasePNumericUpDown";
            this.PhasePNumericUpDown.Size = new System.Drawing.Size(83, 22);
            this.PhasePNumericUpDown.TabIndex = 19;
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
            this.RefFreqGroupBox.Location = new System.Drawing.Point(7, 197);
            this.RefFreqGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.RefFreqGroupBox.Name = "RefFreqGroupBox";
            this.RefFreqGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.RefFreqGroupBox.Size = new System.Drawing.Size(341, 122);
            this.RefFreqGroupBox.TabIndex = 22;
            this.RefFreqGroupBox.TabStop = false;
            this.RefFreqGroupBox.Text = "Reference Frequency";
            // 
            // LDSpeedAdjLabel
            // 
            this.LDSpeedAdjLabel.Location = new System.Drawing.Point(1, 90);
            this.LDSpeedAdjLabel.Name = "LDSpeedAdjLabel";
            this.LDSpeedAdjLabel.Size = new System.Drawing.Size(148, 17);
            this.LDSpeedAdjLabel.TabIndex = 17;
            this.LDSpeedAdjLabel.Text = "LD speed adjustment:";
            this.LDSpeedAdjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RDivUpDown
            // 
            this.RDivUpDown.Location = new System.Drawing.Point(87, 55);
            this.RDivUpDown.Margin = new System.Windows.Forms.Padding(4);
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
            this.RDivUpDown.Size = new System.Drawing.Size(83, 22);
            this.RDivUpDown.TabIndex = 19;
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
            this.LDSpeedAdjComboBox.Location = new System.Drawing.Point(154, 87);
            this.LDSpeedAdjComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LDSpeedAdjComboBox.Name = "LDSpeedAdjComboBox";
            this.LDSpeedAdjComboBox.Size = new System.Drawing.Size(144, 24);
            this.LDSpeedAdjComboBox.TabIndex = 16;
            this.LDSpeedAdjComboBox.SelectedIndexChanged += new System.EventHandler(this.LDSpeedAdjComboBox_SelectedIndexChanged);
            // 
            // RefFTextBox
            // 
            this.RefFTextBox.BackColor = System.Drawing.Color.White;
            this.RefFTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.RefFTextBox.Location = new System.Drawing.Point(87, 26);
            this.RefFTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RefFTextBox.MaxLength = 10;
            this.RefFTextBox.Name = "RefFTextBox";
            this.RefFTextBox.Size = new System.Drawing.Size(89, 22);
            this.RefFTextBox.TabIndex = 3;
            this.RefFTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RefFTextBox.TextChanged += new System.EventHandler(this.RefFTextBox_TextChanged);
            this.RefFTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RefFTextBox_KeyDown);
            this.RefFTextBox.LostFocus += new System.EventHandler(this.RefFTextBox_LostFocus);
            this.RefFTextBox.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.TextBoxScrollHandlerFunction);
            // 
            // DivideBy2CheckBox
            // 
            this.DivideBy2CheckBox.AutoSize = true;
            this.DivideBy2CheckBox.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.DivideBy2CheckBox.Location = new System.Drawing.Point(292, 14);
            this.DivideBy2CheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.DivideBy2CheckBox.Name = "DivideBy2CheckBox";
            this.DivideBy2CheckBox.Size = new System.Drawing.Size(28, 38);
            this.DivideBy2CheckBox.TabIndex = 21;
            this.DivideBy2CheckBox.Text = "÷2";
            this.DivideBy2CheckBox.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.DivideBy2CheckBox.UseVisualStyleBackColor = true;
            this.DivideBy2CheckBox.CheckedChanged += new System.EventHandler(this.DivideBy2CheckBox_CheckedChanged);
            // 
            // AutoLDSpeedAdjCheckBox
            // 
            this.AutoLDSpeedAdjCheckBox.AutoSize = true;
            this.AutoLDSpeedAdjCheckBox.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.AutoLDSpeedAdjCheckBox.Location = new System.Drawing.Point(302, 81);
            this.AutoLDSpeedAdjCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.AutoLDSpeedAdjCheckBox.Name = "AutoLDSpeedAdjCheckBox";
            this.AutoLDSpeedAdjCheckBox.Size = new System.Drawing.Size(40, 38);
            this.AutoLDSpeedAdjCheckBox.TabIndex = 21;
            this.AutoLDSpeedAdjCheckBox.Text = "auto";
            this.AutoLDSpeedAdjCheckBox.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.AutoLDSpeedAdjCheckBox.UseVisualStyleBackColor = true;
            this.AutoLDSpeedAdjCheckBox.CheckedChanged += new System.EventHandler(this.AutoLDSpeedAdjCheckBox_CheckedChanged);
            // 
            // RefDoublerCheckBox
            // 
            this.RefDoublerCheckBox.AutoSize = true;
            this.RefDoublerCheckBox.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.RefDoublerCheckBox.Location = new System.Drawing.Point(254, 14);
            this.RefDoublerCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.RefDoublerCheckBox.Name = "RefDoublerCheckBox";
            this.RefDoublerCheckBox.Size = new System.Drawing.Size(26, 38);
            this.RefDoublerCheckBox.TabIndex = 21;
            this.RefDoublerCheckBox.Text = "x2";
            this.RefDoublerCheckBox.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RefDoublerCheckBox.UseVisualStyleBackColor = true;
            this.RefDoublerCheckBox.CheckedChanged += new System.EventHandler(this.DoubleRefFCheckBox_CheckedChanged);
            // 
            // InternalLabel
            // 
            this.InternalLabel.Location = new System.Drawing.Point(12, 15);
            this.InternalLabel.Name = "InternalLabel";
            this.InternalLabel.Size = new System.Drawing.Size(69, 17);
            this.InternalLabel.TabIndex = 17;
            this.InternalLabel.Text = "Internal";
            this.InternalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RefFLabel
            // 
            this.RefFLabel.Location = new System.Drawing.Point(12, 30);
            this.RefFLabel.Name = "RefFLabel";
            this.RefFLabel.Size = new System.Drawing.Size(69, 17);
            this.RefFLabel.TabIndex = 17;
            this.RefFLabel.Text = "Ref. freq:";
            this.RefFLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // fPfdLabel
            // 
            this.fPfdLabel.Location = new System.Drawing.Point(180, 58);
            this.fPfdLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fPfdLabel.Name = "fPfdLabel";
            this.fPfdLabel.Size = new System.Drawing.Size(43, 16);
            this.fPfdLabel.TabIndex = 20;
            this.fPfdLabel.Text = "fPFD:";
            this.fPfdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RDivLabel
            // 
            this.RDivLabel.Location = new System.Drawing.Point(7, 58);
            this.RDivLabel.Name = "RDivLabel";
            this.RDivLabel.Size = new System.Drawing.Size(75, 17);
            this.RDivLabel.TabIndex = 17;
            this.RDivLabel.Text = "R Divider:";
            this.RDivLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MHzLabel4
            // 
            this.MHzLabel4.Location = new System.Drawing.Point(301, 58);
            this.MHzLabel4.Name = "MHzLabel4";
            this.MHzLabel4.Size = new System.Drawing.Size(40, 17);
            this.MHzLabel4.TabIndex = 17;
            this.MHzLabel4.Text = "MHz";
            this.MHzLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MHzLabel3
            // 
            this.MHzLabel3.Location = new System.Drawing.Point(183, 28);
            this.MHzLabel3.Name = "MHzLabel3";
            this.MHzLabel3.Size = new System.Drawing.Size(40, 17);
            this.MHzLabel3.TabIndex = 17;
            this.MHzLabel3.Text = "MHz";
            this.MHzLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pfdFreqLabel
            // 
            this.pfdFreqLabel.Location = new System.Drawing.Point(221, 58);
            this.pfdFreqLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pfdFreqLabel.Name = "pfdFreqLabel";
            this.pfdFreqLabel.Size = new System.Drawing.Size(83, 16);
            this.pfdFreqLabel.TabIndex = 20;
            this.pfdFreqLabel.Text = "10.000 000";
            this.pfdFreqLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RegistersMemoryPage
            // 
            this.RegistersMemoryPage.Controls.Add(this.ImportMem4Button);
            this.RegistersMemoryPage.Controls.Add(this.ImportMem3Button);
            this.RegistersMemoryPage.Controls.Add(this.ImportMem2Button);
            this.RegistersMemoryPage.Controls.Add(this.ImportMem1Button);
            this.RegistersMemoryPage.Controls.Add(this.SavReg3Label);
            this.RegistersMemoryPage.Controls.Add(this.R0M4);
            this.RegistersMemoryPage.Controls.Add(this.R0M3);
            this.RegistersMemoryPage.Controls.Add(this.LoadRegMemory);
            this.RegistersMemoryPage.Controls.Add(this.SaveRegMemory);
            this.RegistersMemoryPage.Controls.Add(this.R0M2);
            this.RegistersMemoryPage.Controls.Add(this.R0M1);
            this.RegistersMemoryPage.Controls.Add(this.Mem4Label);
            this.RegistersMemoryPage.Controls.Add(this.Mem3Label);
            this.RegistersMemoryPage.Controls.Add(this.Mem2Label);
            this.RegistersMemoryPage.Controls.Add(this.Mem1Label);
            this.RegistersMemoryPage.Controls.Add(this.SavReg0Label);
            this.RegistersMemoryPage.Controls.Add(this.SavReg1Label);
            this.RegistersMemoryPage.Controls.Add(this.R1M4);
            this.RegistersMemoryPage.Controls.Add(this.R1M3);
            this.RegistersMemoryPage.Controls.Add(this.R1M2);
            this.RegistersMemoryPage.Controls.Add(this.R1M1);
            this.RegistersMemoryPage.Controls.Add(this.SavReg2Label);
            this.RegistersMemoryPage.Controls.Add(this.R2M4);
            this.RegistersMemoryPage.Controls.Add(this.R2M3);
            this.RegistersMemoryPage.Controls.Add(this.R2M2);
            this.RegistersMemoryPage.Controls.Add(this.R2M1);
            this.RegistersMemoryPage.Controls.Add(this.R3M4);
            this.RegistersMemoryPage.Controls.Add(this.R3M3);
            this.RegistersMemoryPage.Controls.Add(this.R3M2);
            this.RegistersMemoryPage.Controls.Add(this.R3M1);
            this.RegistersMemoryPage.Controls.Add(this.SavReg4Label);
            this.RegistersMemoryPage.Controls.Add(this.R4M4);
            this.RegistersMemoryPage.Controls.Add(this.R4M3);
            this.RegistersMemoryPage.Controls.Add(this.R5M4);
            this.RegistersMemoryPage.Controls.Add(this.R4M2);
            this.RegistersMemoryPage.Controls.Add(this.R5M3);
            this.RegistersMemoryPage.Controls.Add(this.R4M1);
            this.RegistersMemoryPage.Controls.Add(this.R5M2);
            this.RegistersMemoryPage.Controls.Add(this.SavReg5Label);
            this.RegistersMemoryPage.Controls.Add(this.R5M1);
            this.RegistersMemoryPage.Location = new System.Drawing.Point(4, 25);
            this.RegistersMemoryPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RegistersMemoryPage.Name = "RegistersMemoryPage";
            this.RegistersMemoryPage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RegistersMemoryPage.Size = new System.Drawing.Size(709, 818);
            this.RegistersMemoryPage.TabIndex = 1;
            this.RegistersMemoryPage.Text = "Registers Memory";
            this.RegistersMemoryPage.UseVisualStyleBackColor = true;
            // 
            // ImportMem4Button
            // 
            this.ImportMem4Button.Location = new System.Drawing.Point(365, 203);
            this.ImportMem4Button.Name = "ImportMem4Button";
            this.ImportMem4Button.Size = new System.Drawing.Size(84, 49);
            this.ImportMem4Button.TabIndex = 21;
            this.ImportMem4Button.Text = "Import Memory 4";
            this.ImportMem4Button.UseVisualStyleBackColor = true;
            this.ImportMem4Button.Click += new System.EventHandler(this.ImportMememoryButton_Click);
            // 
            // ImportMem3Button
            // 
            this.ImportMem3Button.Location = new System.Drawing.Point(275, 203);
            this.ImportMem3Button.Name = "ImportMem3Button";
            this.ImportMem3Button.Size = new System.Drawing.Size(84, 49);
            this.ImportMem3Button.TabIndex = 21;
            this.ImportMem3Button.Text = "Import Memory 3";
            this.ImportMem3Button.UseVisualStyleBackColor = true;
            this.ImportMem3Button.Click += new System.EventHandler(this.ImportMememoryButton_Click);
            // 
            // ImportMem2Button
            // 
            this.ImportMem2Button.Location = new System.Drawing.Point(185, 203);
            this.ImportMem2Button.Name = "ImportMem2Button";
            this.ImportMem2Button.Size = new System.Drawing.Size(84, 49);
            this.ImportMem2Button.TabIndex = 21;
            this.ImportMem2Button.Text = "Import Memory 2";
            this.ImportMem2Button.UseVisualStyleBackColor = true;
            this.ImportMem2Button.Click += new System.EventHandler(this.ImportMememoryButton_Click);
            // 
            // ImportMem1Button
            // 
            this.ImportMem1Button.Location = new System.Drawing.Point(95, 203);
            this.ImportMem1Button.Name = "ImportMem1Button";
            this.ImportMem1Button.Size = new System.Drawing.Size(84, 49);
            this.ImportMem1Button.TabIndex = 21;
            this.ImportMem1Button.Text = "Import Memory 1";
            this.ImportMem1Button.UseVisualStyleBackColor = true;
            this.ImportMem1Button.Click += new System.EventHandler(this.ImportMememoryButton_Click);
            // 
            // SavReg3Label
            // 
            this.SavReg3Label.AutoSize = true;
            this.SavReg3Label.Location = new System.Drawing.Point(16, 124);
            this.SavReg3Label.Name = "SavReg3Label";
            this.SavReg3Label.Size = new System.Drawing.Size(73, 17);
            this.SavReg3Label.TabIndex = 13;
            this.SavReg3Label.Text = "Register 3";
            // 
            // R0M4
            // 
            this.R0M4.BackColor = System.Drawing.Color.White;
            this.R0M4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R0M4.Location = new System.Drawing.Point(365, 37);
            this.R0M4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.R0M4.MaxLength = 8;
            this.R0M4.Name = "R0M4";
            this.R0M4.Size = new System.Drawing.Size(84, 22);
            this.R0M4.TabIndex = 9;
            this.R0M4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.R0M4.TextChanged += new System.EventHandler(this.MemoryRegister_TextChanged);
            // 
            // R0M3
            // 
            this.R0M3.BackColor = System.Drawing.Color.White;
            this.R0M3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R0M3.Location = new System.Drawing.Point(275, 37);
            this.R0M3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.R0M3.MaxLength = 8;
            this.R0M3.Name = "R0M3";
            this.R0M3.Size = new System.Drawing.Size(84, 22);
            this.R0M3.TabIndex = 9;
            this.R0M3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.R0M3.TextChanged += new System.EventHandler(this.MemoryRegister_TextChanged);
            // 
            // LoadRegMemory
            // 
            this.LoadRegMemory.Location = new System.Drawing.Point(489, 86);
            this.LoadRegMemory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LoadRegMemory.Name = "LoadRegMemory";
            this.LoadRegMemory.Size = new System.Drawing.Size(174, 43);
            this.LoadRegMemory.TabIndex = 2;
            this.LoadRegMemory.Text = "Read stored registers from synthesizer memory";
            this.LoadRegMemory.UseVisualStyleBackColor = true;
            this.LoadRegMemory.Click += new System.EventHandler(this.LoadRegMemory_Click);
            // 
            // SaveRegMemory
            // 
            this.SaveRegMemory.Location = new System.Drawing.Point(489, 37);
            this.SaveRegMemory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SaveRegMemory.Name = "SaveRegMemory";
            this.SaveRegMemory.Size = new System.Drawing.Size(174, 43);
            this.SaveRegMemory.TabIndex = 2;
            this.SaveRegMemory.Text = "Load the registers into the synthesizer memory";
            this.SaveRegMemory.UseVisualStyleBackColor = true;
            this.SaveRegMemory.Click += new System.EventHandler(this.SaveRegMemory_Click);
            // 
            // R0M2
            // 
            this.R0M2.BackColor = System.Drawing.Color.White;
            this.R0M2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R0M2.Location = new System.Drawing.Point(185, 37);
            this.R0M2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.R0M2.MaxLength = 8;
            this.R0M2.Name = "R0M2";
            this.R0M2.Size = new System.Drawing.Size(84, 22);
            this.R0M2.TabIndex = 9;
            this.R0M2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.R0M2.TextChanged += new System.EventHandler(this.MemoryRegister_TextChanged);
            // 
            // R0M1
            // 
            this.R0M1.BackColor = System.Drawing.Color.White;
            this.R0M1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R0M1.Location = new System.Drawing.Point(95, 37);
            this.R0M1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.R0M1.MaxLength = 8;
            this.R0M1.Name = "R0M1";
            this.R0M1.Size = new System.Drawing.Size(84, 22);
            this.R0M1.TabIndex = 9;
            this.R0M1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.R0M1.TextChanged += new System.EventHandler(this.MemoryRegister_TextChanged);
            // 
            // Mem4Label
            // 
            this.Mem4Label.Location = new System.Drawing.Point(365, 15);
            this.Mem4Label.Name = "Mem4Label";
            this.Mem4Label.Size = new System.Drawing.Size(84, 17);
            this.Mem4Label.TabIndex = 10;
            this.Mem4Label.Text = "Memory 4";
            this.Mem4Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Mem3Label
            // 
            this.Mem3Label.Location = new System.Drawing.Point(275, 15);
            this.Mem3Label.Name = "Mem3Label";
            this.Mem3Label.Size = new System.Drawing.Size(84, 17);
            this.Mem3Label.TabIndex = 10;
            this.Mem3Label.Text = "Memory 3";
            this.Mem3Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Mem2Label
            // 
            this.Mem2Label.Location = new System.Drawing.Point(185, 15);
            this.Mem2Label.Name = "Mem2Label";
            this.Mem2Label.Size = new System.Drawing.Size(84, 17);
            this.Mem2Label.TabIndex = 10;
            this.Mem2Label.Text = "Memory 2";
            this.Mem2Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Mem1Label
            // 
            this.Mem1Label.Location = new System.Drawing.Point(95, 15);
            this.Mem1Label.Name = "Mem1Label";
            this.Mem1Label.Size = new System.Drawing.Size(84, 17);
            this.Mem1Label.TabIndex = 10;
            this.Mem1Label.Text = "Memory 1";
            this.Mem1Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SavReg0Label
            // 
            this.SavReg0Label.AutoSize = true;
            this.SavReg0Label.Location = new System.Drawing.Point(16, 39);
            this.SavReg0Label.Name = "SavReg0Label";
            this.SavReg0Label.Size = new System.Drawing.Size(73, 17);
            this.SavReg0Label.TabIndex = 10;
            this.SavReg0Label.Text = "Register 0";
            // 
            // SavReg1Label
            // 
            this.SavReg1Label.AutoSize = true;
            this.SavReg1Label.Location = new System.Drawing.Point(16, 68);
            this.SavReg1Label.Name = "SavReg1Label";
            this.SavReg1Label.Size = new System.Drawing.Size(73, 17);
            this.SavReg1Label.TabIndex = 11;
            this.SavReg1Label.Text = "Register 1";
            // 
            // R1M4
            // 
            this.R1M4.BackColor = System.Drawing.Color.White;
            this.R1M4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R1M4.Location = new System.Drawing.Point(365, 65);
            this.R1M4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.R1M4.MaxLength = 8;
            this.R1M4.Name = "R1M4";
            this.R1M4.Size = new System.Drawing.Size(84, 22);
            this.R1M4.TabIndex = 12;
            this.R1M4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.R1M4.TextChanged += new System.EventHandler(this.MemoryRegister_TextChanged);
            // 
            // R1M3
            // 
            this.R1M3.BackColor = System.Drawing.Color.White;
            this.R1M3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R1M3.Location = new System.Drawing.Point(275, 65);
            this.R1M3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.R1M3.MaxLength = 8;
            this.R1M3.Name = "R1M3";
            this.R1M3.Size = new System.Drawing.Size(84, 22);
            this.R1M3.TabIndex = 12;
            this.R1M3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.R1M3.TextChanged += new System.EventHandler(this.MemoryRegister_TextChanged);
            // 
            // R1M2
            // 
            this.R1M2.BackColor = System.Drawing.Color.White;
            this.R1M2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R1M2.Location = new System.Drawing.Point(185, 65);
            this.R1M2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.R1M2.MaxLength = 8;
            this.R1M2.Name = "R1M2";
            this.R1M2.Size = new System.Drawing.Size(84, 22);
            this.R1M2.TabIndex = 12;
            this.R1M2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.R1M2.TextChanged += new System.EventHandler(this.MemoryRegister_TextChanged);
            // 
            // R1M1
            // 
            this.R1M1.BackColor = System.Drawing.Color.White;
            this.R1M1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R1M1.Location = new System.Drawing.Point(95, 65);
            this.R1M1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.R1M1.MaxLength = 8;
            this.R1M1.Name = "R1M1";
            this.R1M1.Size = new System.Drawing.Size(84, 22);
            this.R1M1.TabIndex = 12;
            this.R1M1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.R1M1.TextChanged += new System.EventHandler(this.MemoryRegister_TextChanged);
            // 
            // SavReg2Label
            // 
            this.SavReg2Label.AutoSize = true;
            this.SavReg2Label.Location = new System.Drawing.Point(16, 96);
            this.SavReg2Label.Name = "SavReg2Label";
            this.SavReg2Label.Size = new System.Drawing.Size(73, 17);
            this.SavReg2Label.TabIndex = 14;
            this.SavReg2Label.Text = "Register 2";
            // 
            // R2M4
            // 
            this.R2M4.BackColor = System.Drawing.Color.White;
            this.R2M4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R2M4.Location = new System.Drawing.Point(365, 94);
            this.R2M4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.R2M4.MaxLength = 8;
            this.R2M4.Name = "R2M4";
            this.R2M4.Size = new System.Drawing.Size(84, 22);
            this.R2M4.TabIndex = 17;
            this.R2M4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.R2M4.TextChanged += new System.EventHandler(this.MemoryRegister_TextChanged);
            // 
            // R2M3
            // 
            this.R2M3.BackColor = System.Drawing.Color.White;
            this.R2M3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R2M3.Location = new System.Drawing.Point(275, 94);
            this.R2M3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.R2M3.MaxLength = 8;
            this.R2M3.Name = "R2M3";
            this.R2M3.Size = new System.Drawing.Size(84, 22);
            this.R2M3.TabIndex = 17;
            this.R2M3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.R2M3.TextChanged += new System.EventHandler(this.MemoryRegister_TextChanged);
            // 
            // R2M2
            // 
            this.R2M2.BackColor = System.Drawing.Color.White;
            this.R2M2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R2M2.Location = new System.Drawing.Point(185, 94);
            this.R2M2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.R2M2.MaxLength = 8;
            this.R2M2.Name = "R2M2";
            this.R2M2.Size = new System.Drawing.Size(84, 22);
            this.R2M2.TabIndex = 17;
            this.R2M2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.R2M2.TextChanged += new System.EventHandler(this.MemoryRegister_TextChanged);
            // 
            // R2M1
            // 
            this.R2M1.BackColor = System.Drawing.Color.White;
            this.R2M1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R2M1.Location = new System.Drawing.Point(95, 94);
            this.R2M1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.R2M1.MaxLength = 8;
            this.R2M1.Name = "R2M1";
            this.R2M1.Size = new System.Drawing.Size(84, 22);
            this.R2M1.TabIndex = 17;
            this.R2M1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.R2M1.TextChanged += new System.EventHandler(this.MemoryRegister_TextChanged);
            // 
            // R3M4
            // 
            this.R3M4.BackColor = System.Drawing.Color.White;
            this.R3M4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R3M4.Location = new System.Drawing.Point(365, 121);
            this.R3M4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.R3M4.MaxLength = 8;
            this.R3M4.Name = "R3M4";
            this.R3M4.Size = new System.Drawing.Size(84, 22);
            this.R3M4.TabIndex = 18;
            this.R3M4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.R3M4.TextChanged += new System.EventHandler(this.MemoryRegister_TextChanged);
            // 
            // R3M3
            // 
            this.R3M3.BackColor = System.Drawing.Color.White;
            this.R3M3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R3M3.Location = new System.Drawing.Point(275, 121);
            this.R3M3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.R3M3.MaxLength = 8;
            this.R3M3.Name = "R3M3";
            this.R3M3.Size = new System.Drawing.Size(84, 22);
            this.R3M3.TabIndex = 18;
            this.R3M3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.R3M3.TextChanged += new System.EventHandler(this.MemoryRegister_TextChanged);
            // 
            // R3M2
            // 
            this.R3M2.BackColor = System.Drawing.Color.White;
            this.R3M2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R3M2.Location = new System.Drawing.Point(185, 121);
            this.R3M2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.R3M2.MaxLength = 8;
            this.R3M2.Name = "R3M2";
            this.R3M2.Size = new System.Drawing.Size(84, 22);
            this.R3M2.TabIndex = 18;
            this.R3M2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.R3M2.TextChanged += new System.EventHandler(this.MemoryRegister_TextChanged);
            // 
            // R3M1
            // 
            this.R3M1.BackColor = System.Drawing.Color.White;
            this.R3M1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R3M1.Location = new System.Drawing.Point(95, 121);
            this.R3M1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.R3M1.MaxLength = 8;
            this.R3M1.Name = "R3M1";
            this.R3M1.Size = new System.Drawing.Size(84, 22);
            this.R3M1.TabIndex = 18;
            this.R3M1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.R3M1.TextChanged += new System.EventHandler(this.MemoryRegister_TextChanged);
            // 
            // SavReg4Label
            // 
            this.SavReg4Label.AutoSize = true;
            this.SavReg4Label.Location = new System.Drawing.Point(16, 150);
            this.SavReg4Label.Name = "SavReg4Label";
            this.SavReg4Label.Size = new System.Drawing.Size(73, 17);
            this.SavReg4Label.TabIndex = 15;
            this.SavReg4Label.Text = "Register 4";
            // 
            // R4M4
            // 
            this.R4M4.BackColor = System.Drawing.Color.White;
            this.R4M4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R4M4.Location = new System.Drawing.Point(365, 146);
            this.R4M4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.R4M4.MaxLength = 8;
            this.R4M4.Name = "R4M4";
            this.R4M4.Size = new System.Drawing.Size(84, 22);
            this.R4M4.TabIndex = 19;
            this.R4M4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.R4M4.TextChanged += new System.EventHandler(this.MemoryRegister_TextChanged);
            // 
            // R4M3
            // 
            this.R4M3.BackColor = System.Drawing.Color.White;
            this.R4M3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R4M3.Location = new System.Drawing.Point(275, 146);
            this.R4M3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.R4M3.MaxLength = 8;
            this.R4M3.Name = "R4M3";
            this.R4M3.Size = new System.Drawing.Size(84, 22);
            this.R4M3.TabIndex = 19;
            this.R4M3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.R4M3.TextChanged += new System.EventHandler(this.MemoryRegister_TextChanged);
            // 
            // R5M4
            // 
            this.R5M4.BackColor = System.Drawing.Color.White;
            this.R5M4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R5M4.Location = new System.Drawing.Point(365, 175);
            this.R5M4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.R5M4.MaxLength = 8;
            this.R5M4.Name = "R5M4";
            this.R5M4.Size = new System.Drawing.Size(84, 22);
            this.R5M4.TabIndex = 20;
            this.R5M4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.R5M4.TextChanged += new System.EventHandler(this.MemoryRegister_TextChanged);
            // 
            // R4M2
            // 
            this.R4M2.BackColor = System.Drawing.Color.White;
            this.R4M2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R4M2.Location = new System.Drawing.Point(185, 146);
            this.R4M2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.R4M2.MaxLength = 8;
            this.R4M2.Name = "R4M2";
            this.R4M2.Size = new System.Drawing.Size(84, 22);
            this.R4M2.TabIndex = 19;
            this.R4M2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.R4M2.TextChanged += new System.EventHandler(this.MemoryRegister_TextChanged);
            // 
            // R5M3
            // 
            this.R5M3.BackColor = System.Drawing.Color.White;
            this.R5M3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R5M3.Location = new System.Drawing.Point(275, 175);
            this.R5M3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.R5M3.MaxLength = 8;
            this.R5M3.Name = "R5M3";
            this.R5M3.Size = new System.Drawing.Size(84, 22);
            this.R5M3.TabIndex = 20;
            this.R5M3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.R5M3.TextChanged += new System.EventHandler(this.MemoryRegister_TextChanged);
            // 
            // R4M1
            // 
            this.R4M1.BackColor = System.Drawing.Color.White;
            this.R4M1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R4M1.Location = new System.Drawing.Point(95, 146);
            this.R4M1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.R4M1.MaxLength = 8;
            this.R4M1.Name = "R4M1";
            this.R4M1.Size = new System.Drawing.Size(84, 22);
            this.R4M1.TabIndex = 19;
            this.R4M1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.R4M1.TextChanged += new System.EventHandler(this.MemoryRegister_TextChanged);
            // 
            // R5M2
            // 
            this.R5M2.BackColor = System.Drawing.Color.White;
            this.R5M2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R5M2.Location = new System.Drawing.Point(185, 175);
            this.R5M2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.R5M2.MaxLength = 8;
            this.R5M2.Name = "R5M2";
            this.R5M2.Size = new System.Drawing.Size(84, 22);
            this.R5M2.TabIndex = 20;
            this.R5M2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.R5M2.TextChanged += new System.EventHandler(this.MemoryRegister_TextChanged);
            // 
            // SavReg5Label
            // 
            this.SavReg5Label.AutoSize = true;
            this.SavReg5Label.Location = new System.Drawing.Point(16, 178);
            this.SavReg5Label.Name = "SavReg5Label";
            this.SavReg5Label.Size = new System.Drawing.Size(73, 17);
            this.SavReg5Label.TabIndex = 16;
            this.SavReg5Label.Text = "Register 5";
            // 
            // R5M1
            // 
            this.R5M1.BackColor = System.Drawing.Color.White;
            this.R5M1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R5M1.Location = new System.Drawing.Point(95, 175);
            this.R5M1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.R5M1.MaxLength = 8;
            this.R5M1.Name = "R5M1";
            this.R5M1.Size = new System.Drawing.Size(84, 22);
            this.R5M1.TabIndex = 20;
            this.R5M1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.R5M1.TextChanged += new System.EventHandler(this.MemoryRegister_TextChanged);
            // 
            // RegistersGroupBox
            // 
            this.RegistersGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RegistersGroupBox.Location = new System.Drawing.Point(352, 4);
            this.RegistersGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RegistersGroupBox.Name = "RegistersGroupBox";
            this.RegistersGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RegistersGroupBox.Size = new System.Drawing.Size(717, 780);
            this.RegistersGroupBox.TabIndex = 13;
            this.RegistersGroupBox.TabStop = false;
            this.RegistersGroupBox.Text = "PLO MAX2871 Registers Settings";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 873);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 13, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1071, 22);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 16);
            // 
            // InputFreqTextBox
            // 
            this.InputFreqTextBox.BackColor = System.Drawing.Color.White;
            this.InputFreqTextBox.Location = new System.Drawing.Point(147, 20);
            this.InputFreqTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.InputFreqTextBox.MaxLength = 17;
            this.InputFreqTextBox.Name = "InputFreqTextBox";
            this.InputFreqTextBox.Size = new System.Drawing.Size(109, 22);
            this.InputFreqTextBox.TabIndex = 3;
            this.InputFreqTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.InputFreqTextBox.TextChanged += new System.EventHandler(this.InputFreqTextBox_TextChanged);
            this.InputFreqTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InputFreqTextBox_KeyDown);
            this.InputFreqTextBox.LostFocus += new System.EventHandler(this.RefFTextBox_LostFocus);
            this.InputFreqTextBox.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.TextBoxScrollHandlerFunction);
            // 
            // MHzLabel6
            // 
            this.MHzLabel6.Location = new System.Drawing.Point(262, 23);
            this.MHzLabel6.Name = "MHzLabel6";
            this.MHzLabel6.Size = new System.Drawing.Size(40, 17);
            this.MHzLabel6.TabIndex = 17;
            this.MHzLabel6.Text = "MHz";
            this.MHzLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DeltaShowLabel
            // 
            this.DeltaShowLabel.Location = new System.Drawing.Point(147, 70);
            this.DeltaShowLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DeltaShowLabel.Name = "DeltaShowLabel";
            this.DeltaShowLabel.Size = new System.Drawing.Size(109, 16);
            this.DeltaShowLabel.TabIndex = 20;
            this.DeltaShowLabel.Text = "0";
            this.DeltaShowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HzLabel
            // 
            this.HzLabel.Location = new System.Drawing.Point(262, 70);
            this.HzLabel.Name = "HzLabel";
            this.HzLabel.Size = new System.Drawing.Size(40, 17);
            this.HzLabel.TabIndex = 17;
            this.HzLabel.Text = "Hz";
            this.HzLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DeltaLabel
            // 
            this.DeltaLabel.Location = new System.Drawing.Point(2, 69);
            this.DeltaLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DeltaLabel.Name = "DeltaLabel";
            this.DeltaLabel.Size = new System.Drawing.Size(138, 18);
            this.DeltaLabel.TabIndex = 20;
            this.DeltaLabel.Text = "Delta frequency:";
            this.DeltaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // InputFreqLabel
            // 
            this.InputFreqLabel.Location = new System.Drawing.Point(2, 23);
            this.InputFreqLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.InputFreqLabel.Name = "InputFreqLabel";
            this.InputFreqLabel.Size = new System.Drawing.Size(138, 16);
            this.InputFreqLabel.TabIndex = 20;
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
            this.DirectFreqContrGroupBox.Location = new System.Drawing.Point(11, 81);
            this.DirectFreqContrGroupBox.Name = "DirectFreqContrGroupBox";
            this.DirectFreqContrGroupBox.Size = new System.Drawing.Size(334, 95);
            this.DirectFreqContrGroupBox.TabIndex = 22;
            this.DirectFreqContrGroupBox.TabStop = false;
            this.DirectFreqContrGroupBox.Text = "Direct output frequency control";
            // 
            // MHzLabel9
            // 
            this.MHzLabel9.Location = new System.Drawing.Point(266, 65);
            this.MHzLabel9.Name = "MHzLabel9";
            this.MHzLabel9.Size = new System.Drawing.Size(40, 17);
            this.MHzLabel9.TabIndex = 17;
            this.MHzLabel9.Text = "MHz";
            this.MHzLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MHzLabel8
            // 
            this.MHzLabel8.Location = new System.Drawing.Point(266, 43);
            this.MHzLabel8.Name = "MHzLabel8";
            this.MHzLabel8.Size = new System.Drawing.Size(40, 17);
            this.MHzLabel8.TabIndex = 17;
            this.MHzLabel8.Text = "MHz";
            this.MHzLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MHzLabel7
            // 
            this.MHzLabel7.Location = new System.Drawing.Point(263, 47);
            this.MHzLabel7.Name = "MHzLabel7";
            this.MHzLabel7.Size = new System.Drawing.Size(40, 17);
            this.MHzLabel7.TabIndex = 17;
            this.MHzLabel7.Text = "MHz";
            this.MHzLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FreqAtOut2ShowLabel
            // 
            this.FreqAtOut2ShowLabel.Location = new System.Drawing.Point(150, 66);
            this.FreqAtOut2ShowLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FreqAtOut2ShowLabel.Name = "FreqAtOut2ShowLabel";
            this.FreqAtOut2ShowLabel.Size = new System.Drawing.Size(109, 16);
            this.FreqAtOut2ShowLabel.TabIndex = 20;
            this.FreqAtOut2ShowLabel.Text = "0";
            this.FreqAtOut2ShowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FreqAtOut1ShowLabel
            // 
            this.FreqAtOut1ShowLabel.Location = new System.Drawing.Point(150, 44);
            this.FreqAtOut1ShowLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FreqAtOut1ShowLabel.Name = "FreqAtOut1ShowLabel";
            this.FreqAtOut1ShowLabel.Size = new System.Drawing.Size(109, 16);
            this.FreqAtOut1ShowLabel.TabIndex = 20;
            this.FreqAtOut1ShowLabel.Text = "0";
            this.FreqAtOut1ShowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CalcFreqShowLabel
            // 
            this.CalcFreqShowLabel.Location = new System.Drawing.Point(147, 48);
            this.CalcFreqShowLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CalcFreqShowLabel.Name = "CalcFreqShowLabel";
            this.CalcFreqShowLabel.Size = new System.Drawing.Size(109, 16);
            this.CalcFreqShowLabel.TabIndex = 20;
            this.CalcFreqShowLabel.Text = "0";
            this.CalcFreqShowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ActOut2ShowLabel
            // 
            this.ActOut2ShowLabel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ActOut2ShowLabel.Location = new System.Drawing.Point(291, 23);
            this.ActOut2ShowLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ActOut2ShowLabel.Name = "ActOut2ShowLabel";
            this.ActOut2ShowLabel.Size = new System.Drawing.Size(39, 16);
            this.ActOut2ShowLabel.TabIndex = 20;
            this.ActOut2ShowLabel.Text = "OFF";
            this.ActOut2ShowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ActOut2ShowLabel.Click += new System.EventHandler(this.ActOut2ShowLabel_Click);
            // 
            // FreqAtOut2Label
            // 
            this.FreqAtOut2Label.Location = new System.Drawing.Point(5, 64);
            this.FreqAtOut2Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FreqAtOut2Label.Name = "FreqAtOut2Label";
            this.FreqAtOut2Label.Size = new System.Drawing.Size(138, 18);
            this.FreqAtOut2Label.TabIndex = 20;
            this.FreqAtOut2Label.Text = "Frequency at Out 2:";
            this.FreqAtOut2Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ActOut1ShowLabel
            // 
            this.ActOut1ShowLabel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ActOut1ShowLabel.Location = new System.Drawing.Point(127, 22);
            this.ActOut1ShowLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ActOut1ShowLabel.Name = "ActOut1ShowLabel";
            this.ActOut1ShowLabel.Size = new System.Drawing.Size(39, 16);
            this.ActOut1ShowLabel.TabIndex = 20;
            this.ActOut1ShowLabel.Text = "OFF";
            this.ActOut1ShowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ActOut1ShowLabel.Click += new System.EventHandler(this.ActOut1ShowLabel_Click);
            // 
            // FreqAtOut1Label
            // 
            this.FreqAtOut1Label.Location = new System.Drawing.Point(5, 42);
            this.FreqAtOut1Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FreqAtOut1Label.Name = "FreqAtOut1Label";
            this.FreqAtOut1Label.Size = new System.Drawing.Size(138, 18);
            this.FreqAtOut1Label.TabIndex = 20;
            this.FreqAtOut1Label.Text = "Frequency at Out 1:";
            this.FreqAtOut1Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CalcFreqLabel
            // 
            this.CalcFreqLabel.Location = new System.Drawing.Point(2, 46);
            this.CalcFreqLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CalcFreqLabel.Name = "CalcFreqLabel";
            this.CalcFreqLabel.Size = new System.Drawing.Size(138, 18);
            this.CalcFreqLabel.TabIndex = 20;
            this.CalcFreqLabel.Text = "Calculated freq.:";
            this.CalcFreqLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ActiveOut2Label
            // 
            this.ActiveOut2Label.Location = new System.Drawing.Point(170, 21);
            this.ActiveOut2Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ActiveOut2Label.Name = "ActiveOut2Label";
            this.ActiveOut2Label.Size = new System.Drawing.Size(116, 18);
            this.ActiveOut2Label.TabIndex = 20;
            this.ActiveOut2Label.Text = "Active Output 2:";
            this.ActiveOut2Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ActiveOut1Label
            // 
            this.ActiveOut1Label.Location = new System.Drawing.Point(7, 20);
            this.ActiveOut1Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ActiveOut1Label.Name = "ActiveOut1Label";
            this.ActiveOut1Label.Size = new System.Drawing.Size(113, 18);
            this.ActiveOut1Label.TabIndex = 20;
            this.ActiveOut1Label.Text = "Active Output 1:";
            this.ActiveOut1Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ConsoleRichTextBox
            // 
            this.ConsoleRichTextBox.HideSelection = false;
            this.ConsoleRichTextBox.Location = new System.Drawing.Point(11, 283);
            this.ConsoleRichTextBox.Name = "ConsoleRichTextBox";
            this.ConsoleRichTextBox.ReadOnly = true;
            this.ConsoleRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.ConsoleRichTextBox.Size = new System.Drawing.Size(334, 583);
            this.ConsoleRichTextBox.TabIndex = 23;
            this.ConsoleRichTextBox.Text = "";
            // 
            // SynthModuleInfoGroupBox
            // 
            this.SynthModuleInfoGroupBox.Controls.Add(this.ActiveOut1Label);
            this.SynthModuleInfoGroupBox.Controls.Add(this.ActiveOut2Label);
            this.SynthModuleInfoGroupBox.Controls.Add(this.MHzLabel9);
            this.SynthModuleInfoGroupBox.Controls.Add(this.FreqAtOut1Label);
            this.SynthModuleInfoGroupBox.Controls.Add(this.ActOut1ShowLabel);
            this.SynthModuleInfoGroupBox.Controls.Add(this.MHzLabel8);
            this.SynthModuleInfoGroupBox.Controls.Add(this.FreqAtOut2Label);
            this.SynthModuleInfoGroupBox.Controls.Add(this.ActOut2ShowLabel);
            this.SynthModuleInfoGroupBox.Controls.Add(this.FreqAtOut1ShowLabel);
            this.SynthModuleInfoGroupBox.Controls.Add(this.FreqAtOut2ShowLabel);
            this.SynthModuleInfoGroupBox.Location = new System.Drawing.Point(11, 182);
            this.SynthModuleInfoGroupBox.Name = "SynthModuleInfoGroupBox";
            this.SynthModuleInfoGroupBox.Size = new System.Drawing.Size(334, 95);
            this.SynthModuleInfoGroupBox.TabIndex = 21;
            this.SynthModuleInfoGroupBox.TabStop = false;
            this.SynthModuleInfoGroupBox.Text = "Synthesizer module info";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 895);
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
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Synthesizer Control Program by OK2FKU";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Click += new System.EventHandler(this.CheckAndApllyChangesForm1_Click);
            this.RegistersTabControl.ResumeLayout(false);
            this.RegistersPage.ResumeLayout(false);
            this.genericControlsGroupBox.ResumeLayout(false);
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
            this.RegistersMemoryPage.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.DirectFreqContrGroupBox.ResumeLayout(false);
            this.DirectFreqContrGroupBox.PerformLayout();
            this.SynthModuleInfoGroupBox.ResumeLayout(false);
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
        private System.Windows.Forms.TabControl RegistersTabControl;
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
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
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
    }
}

