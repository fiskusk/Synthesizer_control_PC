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
            this.MoveRegsIntoMemsGroupBox = new System.Windows.Forms.GroupBox();
            this.MoveRegsIntoMem1Button = new System.Windows.Forms.Button();
            this.MoveRegsIntoMem2Button = new System.Windows.Forms.Button();
            this.MoveRegsIntoMem3Button = new System.Windows.Forms.Button();
            this.MoveRegsIntoMem4Button = new System.Windows.Forms.Button();
            this.ChargePumpGroupBox = new System.Windows.Forms.GroupBox();
            this.PosPFDCheckBox = new System.Windows.Forms.CheckBox();
            this.CPCycleSlipCheckBox = new System.Windows.Forms.CheckBox();
            this.CPTriStateOutCheckBox = new System.Windows.Forms.CheckBox();
            this.CPFastLockCheckBox = new System.Windows.Forms.CheckBox();
            this.RSetTextBox = new System.Windows.Forms.TextBox();
            this.CPTestComboBox = new System.Windows.Forms.ComboBox();
            this.CPLinearityComboBox = new System.Windows.Forms.ComboBox();
            this.CPTestLabel = new System.Windows.Forms.Label();
            this.CPCurrentComboBox = new System.Windows.Forms.ComboBox();
            this.CPlinearityLabel = new System.Windows.Forms.Label();
            this.RSetLabel = new System.Windows.Forms.Label();
            this.CPCurrentLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RF_A_EN_Label = new System.Windows.Forms.Label();
            this.RF_A_PWR_Label = new System.Windows.Forms.Label();
            this.RF_B_EN_Label = new System.Windows.Forms.Label();
            this.RF_B_PWR_Label = new System.Windows.Forms.Label();
            this.RF_B_PWR_ComboBox = new System.Windows.Forms.ComboBox();
            this.RF_A_EN_ComboBox = new System.Windows.Forms.ComboBox();
            this.RF_A_PWR_ComboBox = new System.Windows.Forms.ComboBox();
            this.RF_B_EN_ComboBox = new System.Windows.Forms.ComboBox();
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
            this.ADivComboBox = new System.Windows.Forms.ComboBox();
            this.FracNLabel = new System.Windows.Forms.Label();
            this.ModeIntFracComboBox = new System.Windows.Forms.ComboBox();
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
            this.RDivUpDown = new System.Windows.Forms.NumericUpDown();
            this.RefFTextBox = new System.Windows.Forms.TextBox();
            this.DivideBy2CheckBox = new System.Windows.Forms.CheckBox();
            this.DoubleRefFCheckBox = new System.Windows.Forms.CheckBox();
            this.RefFLabel = new System.Windows.Forms.Label();
            this.fPfdLabel = new System.Windows.Forms.Label();
            this.RDivLabel = new System.Windows.Forms.Label();
            this.MHzLabel4 = new System.Windows.Forms.Label();
            this.MHzLabel3 = new System.Windows.Forms.Label();
            this.fPfdScreenLabel = new System.Windows.Forms.Label();
            this.SavedRegistersPage = new System.Windows.Forms.TabPage();
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
            this.textBox = new System.Windows.Forms.TextBox();
            this.RegistersTabControl.SuspendLayout();
            this.RegistersPage.SuspendLayout();
            this.MoveRegsIntoMemsGroupBox.SuspendLayout();
            this.ChargePumpGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.OutInfoGroupBox.SuspendLayout();
            this.FreqControlGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IntNNumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModNumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FracNNumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PhasePNumericUpDown)).BeginInit();
            this.RefFreqGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RDivUpDown)).BeginInit();
            this.SavedRegistersPage.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PortButton
            // 
            this.PortButton.Location = new System.Drawing.Point(16, 11);
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
            this.Out1Button.Location = new System.Drawing.Point(16, 72);
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
            this.Out2Button.Location = new System.Drawing.Point(16, 106);
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
            this.PloInitButton.Location = new System.Drawing.Point(161, 72);
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
            this.Reg0TextBox.Location = new System.Drawing.Point(95, 14);
            this.Reg0TextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Reg0TextBox.MaxLength = 8;
            this.Reg0TextBox.Name = "Reg0TextBox";
            this.Reg0TextBox.Size = new System.Drawing.Size(100, 22);
            this.Reg0TextBox.TabIndex = 3;
            this.Reg0TextBox.Text = "80C90000";
            this.Reg0TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Reg0TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Reg0TextBox_KeyPress);
            this.Reg0TextBox.LostFocus += new System.EventHandler(this.Reg0TextBox_LostFocus);
            // 
            // Reg0Label
            // 
            this.Reg0Label.AutoSize = true;
            this.Reg0Label.Location = new System.Drawing.Point(16, 17);
            this.Reg0Label.Name = "Reg0Label";
            this.Reg0Label.Size = new System.Drawing.Size(77, 17);
            this.Reg0Label.TabIndex = 4;
            this.Reg0Label.Text = "Register 0:";
            // 
            // Reg1Label
            // 
            this.Reg1Label.AutoSize = true;
            this.Reg1Label.Location = new System.Drawing.Point(16, 46);
            this.Reg1Label.Name = "Reg1Label";
            this.Reg1Label.Size = new System.Drawing.Size(77, 17);
            this.Reg1Label.TabIndex = 5;
            this.Reg1Label.Text = "Register 1:";
            // 
            // Reg1TextBox
            // 
            this.Reg1TextBox.BackColor = System.Drawing.Color.White;
            this.Reg1TextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Reg1TextBox.Location = new System.Drawing.Point(95, 42);
            this.Reg1TextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Reg1TextBox.MaxLength = 8;
            this.Reg1TextBox.Name = "Reg1TextBox";
            this.Reg1TextBox.Size = new System.Drawing.Size(100, 22);
            this.Reg1TextBox.TabIndex = 6;
            this.Reg1TextBox.Text = "800103E9";
            this.Reg1TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Reg1TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Reg1TextBox_KeyPress);
            this.Reg1TextBox.LostFocus += new System.EventHandler(this.Reg1TextBox_LostFocus);
            // 
            // Reg2Label
            // 
            this.Reg2Label.AutoSize = true;
            this.Reg2Label.Location = new System.Drawing.Point(16, 73);
            this.Reg2Label.Name = "Reg2Label";
            this.Reg2Label.Size = new System.Drawing.Size(77, 17);
            this.Reg2Label.TabIndex = 7;
            this.Reg2Label.Text = "Register 2:";
            // 
            // Reg2TextBox
            // 
            this.Reg2TextBox.BackColor = System.Drawing.Color.White;
            this.Reg2TextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Reg2TextBox.Location = new System.Drawing.Point(95, 70);
            this.Reg2TextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Reg2TextBox.MaxLength = 8;
            this.Reg2TextBox.Name = "Reg2TextBox";
            this.Reg2TextBox.Size = new System.Drawing.Size(100, 22);
            this.Reg2TextBox.TabIndex = 8;
            this.Reg2TextBox.Text = "00005F42";
            this.Reg2TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Reg2TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Reg2TextBox_KeyPress);
            this.Reg2TextBox.LostFocus += new System.EventHandler(this.Reg2TextBox_LostFocus);
            // 
            // Reg3Label
            // 
            this.Reg3Label.AutoSize = true;
            this.Reg3Label.Location = new System.Drawing.Point(16, 101);
            this.Reg3Label.Name = "Reg3Label";
            this.Reg3Label.Size = new System.Drawing.Size(77, 17);
            this.Reg3Label.TabIndex = 7;
            this.Reg3Label.Text = "Register 3:";
            // 
            // Reg3TextBox
            // 
            this.Reg3TextBox.BackColor = System.Drawing.Color.White;
            this.Reg3TextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Reg3TextBox.Location = new System.Drawing.Point(95, 98);
            this.Reg3TextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Reg3TextBox.MaxLength = 8;
            this.Reg3TextBox.Name = "Reg3TextBox";
            this.Reg3TextBox.Size = new System.Drawing.Size(100, 22);
            this.Reg3TextBox.TabIndex = 8;
            this.Reg3TextBox.Text = "00001F23";
            this.Reg3TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Reg3TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Reg3TextBox_KeyPress);
            this.Reg3TextBox.LostFocus += new System.EventHandler(this.Reg3TextBox_LostFocus);
            // 
            // Reg4Label
            // 
            this.Reg4Label.AutoSize = true;
            this.Reg4Label.Location = new System.Drawing.Point(16, 127);
            this.Reg4Label.Name = "Reg4Label";
            this.Reg4Label.Size = new System.Drawing.Size(77, 17);
            this.Reg4Label.TabIndex = 7;
            this.Reg4Label.Text = "Register 4:";
            // 
            // Reg4TextBox
            // 
            this.Reg4TextBox.BackColor = System.Drawing.Color.White;
            this.Reg4TextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Reg4TextBox.Location = new System.Drawing.Point(95, 124);
            this.Reg4TextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Reg4TextBox.MaxLength = 8;
            this.Reg4TextBox.Name = "Reg4TextBox";
            this.Reg4TextBox.Size = new System.Drawing.Size(100, 22);
            this.Reg4TextBox.TabIndex = 8;
            this.Reg4TextBox.Text = "63BE80E4";
            this.Reg4TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Reg4TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Reg4TextBox_KeyPress);
            this.Reg4TextBox.LostFocus += new System.EventHandler(this.Reg4TextBox_LostFocus);
            // 
            // Reg5Label
            // 
            this.Reg5Label.AutoSize = true;
            this.Reg5Label.Location = new System.Drawing.Point(16, 155);
            this.Reg5Label.Name = "Reg5Label";
            this.Reg5Label.Size = new System.Drawing.Size(77, 17);
            this.Reg5Label.TabIndex = 7;
            this.Reg5Label.Text = "Register 5:";
            // 
            // Reg5TextBox
            // 
            this.Reg5TextBox.BackColor = System.Drawing.Color.White;
            this.Reg5TextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Reg5TextBox.Location = new System.Drawing.Point(95, 153);
            this.Reg5TextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Reg5TextBox.MaxLength = 8;
            this.Reg5TextBox.Name = "Reg5TextBox";
            this.Reg5TextBox.Size = new System.Drawing.Size(100, 22);
            this.Reg5TextBox.TabIndex = 8;
            this.Reg5TextBox.Text = "00400005";
            this.Reg5TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Reg5TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Reg5TextBox_KeyPress);
            this.Reg5TextBox.LostFocus += new System.EventHandler(this.Reg5TextBox_LostFocus);
            // 
            // RefButton
            // 
            this.RefButton.Location = new System.Drawing.Point(16, 139);
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
            this.SetAsDefaultRegButton.Location = new System.Drawing.Point(331, 14);
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
            this.ForceLoadRegButton.Location = new System.Drawing.Point(331, 71);
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
            this.LoadDefRegButton.Location = new System.Drawing.Point(331, 42);
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
            this.AvaibleCOMsComBox.Location = new System.Drawing.Point(143, 11);
            this.AvaibleCOMsComBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AvaibleCOMsComBox.Name = "AvaibleCOMsComBox";
            this.AvaibleCOMsComBox.Size = new System.Drawing.Size(87, 24);
            this.AvaibleCOMsComBox.TabIndex = 10;
            this.AvaibleCOMsComBox.DropDown += new System.EventHandler(this.AvaibleCOMsComBox_DropDown);
            // 
            // WriteR0Button
            // 
            this.WriteR0Button.Location = new System.Drawing.Point(201, 14);
            this.WriteR0Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.WriteR0Button.Name = "WriteR0Button";
            this.WriteR0Button.Size = new System.Drawing.Size(84, 23);
            this.WriteR0Button.TabIndex = 11;
            this.WriteR0Button.Text = "Write R0";
            this.WriteR0Button.UseVisualStyleBackColor = true;
            this.WriteR0Button.Click += new System.EventHandler(this.WriteR0Button_Click);
            // 
            // WriteR1Button
            // 
            this.WriteR1Button.Location = new System.Drawing.Point(201, 42);
            this.WriteR1Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.WriteR1Button.Name = "WriteR1Button";
            this.WriteR1Button.Size = new System.Drawing.Size(84, 23);
            this.WriteR1Button.TabIndex = 11;
            this.WriteR1Button.Text = "Write R1";
            this.WriteR1Button.UseVisualStyleBackColor = true;
            this.WriteR1Button.Click += new System.EventHandler(this.WriteR1Button_Click);
            // 
            // WriteR2Button
            // 
            this.WriteR2Button.Location = new System.Drawing.Point(201, 70);
            this.WriteR2Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.WriteR2Button.Name = "WriteR2Button";
            this.WriteR2Button.Size = new System.Drawing.Size(84, 23);
            this.WriteR2Button.TabIndex = 11;
            this.WriteR2Button.Text = "Write R2";
            this.WriteR2Button.UseVisualStyleBackColor = true;
            this.WriteR2Button.Click += new System.EventHandler(this.WriteR2Button_Click);
            // 
            // WriteR3Button
            // 
            this.WriteR3Button.Location = new System.Drawing.Point(201, 98);
            this.WriteR3Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.WriteR3Button.Name = "WriteR3Button";
            this.WriteR3Button.Size = new System.Drawing.Size(84, 23);
            this.WriteR3Button.TabIndex = 11;
            this.WriteR3Button.Text = "Write R3";
            this.WriteR3Button.UseVisualStyleBackColor = true;
            this.WriteR3Button.Click += new System.EventHandler(this.WriteR3Button_Click);
            // 
            // WriteR4Button
            // 
            this.WriteR4Button.Location = new System.Drawing.Point(201, 124);
            this.WriteR4Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.WriteR4Button.Name = "WriteR4Button";
            this.WriteR4Button.Size = new System.Drawing.Size(84, 23);
            this.WriteR4Button.TabIndex = 11;
            this.WriteR4Button.Text = "Write R4";
            this.WriteR4Button.UseVisualStyleBackColor = true;
            this.WriteR4Button.Click += new System.EventHandler(this.WriteR4Button_Click);
            // 
            // WriteR5Button
            // 
            this.WriteR5Button.Location = new System.Drawing.Point(201, 153);
            this.WriteR5Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.WriteR5Button.Name = "WriteR5Button";
            this.WriteR5Button.Size = new System.Drawing.Size(84, 23);
            this.WriteR5Button.TabIndex = 11;
            this.WriteR5Button.Text = "Write R5";
            this.WriteR5Button.UseVisualStyleBackColor = true;
            this.WriteR5Button.Click += new System.EventHandler(this.WriteR5Button_Click);
            // 
            // RegistersTabControl
            // 
            this.RegistersTabControl.Controls.Add(this.RegistersPage);
            this.RegistersTabControl.Controls.Add(this.SavedRegistersPage);
            this.RegistersTabControl.Location = new System.Drawing.Point(352, 32);
            this.RegistersTabControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RegistersTabControl.Name = "RegistersTabControl";
            this.RegistersTabControl.SelectedIndex = 0;
            this.RegistersTabControl.Size = new System.Drawing.Size(708, 539);
            this.RegistersTabControl.TabIndex = 12;
            // 
            // RegistersPage
            // 
            this.RegistersPage.Controls.Add(this.MoveRegsIntoMemsGroupBox);
            this.RegistersPage.Controls.Add(this.ChargePumpGroupBox);
            this.RegistersPage.Controls.Add(this.groupBox1);
            this.RegistersPage.Controls.Add(this.OutInfoGroupBox);
            this.RegistersPage.Controls.Add(this.FreqControlGroupBox);
            this.RegistersPage.Controls.Add(this.Reg3Label);
            this.RegistersPage.Controls.Add(this.WriteR5Button);
            this.RegistersPage.Controls.Add(this.Reg0TextBox);
            this.RegistersPage.Controls.Add(this.WriteR4Button);
            this.RegistersPage.Controls.Add(this.Reg0Label);
            this.RegistersPage.Controls.Add(this.WriteR3Button);
            this.RegistersPage.Controls.Add(this.Reg1Label);
            this.RegistersPage.Controls.Add(this.WriteR1Button);
            this.RegistersPage.Controls.Add(this.Reg1TextBox);
            this.RegistersPage.Controls.Add(this.WriteR2Button);
            this.RegistersPage.Controls.Add(this.Reg2Label);
            this.RegistersPage.Controls.Add(this.WriteR0Button);
            this.RegistersPage.Controls.Add(this.Reg2TextBox);
            this.RegistersPage.Controls.Add(this.Reg3TextBox);
            this.RegistersPage.Controls.Add(this.ForceLoadRegButton);
            this.RegistersPage.Controls.Add(this.Reg4Label);
            this.RegistersPage.Controls.Add(this.LoadDefRegButton);
            this.RegistersPage.Controls.Add(this.Reg4TextBox);
            this.RegistersPage.Controls.Add(this.SetAsDefaultRegButton);
            this.RegistersPage.Controls.Add(this.Reg5Label);
            this.RegistersPage.Controls.Add(this.Reg5TextBox);
            this.RegistersPage.Controls.Add(this.RefFreqGroupBox);
            this.RegistersPage.Location = new System.Drawing.Point(4, 25);
            this.RegistersPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RegistersPage.Name = "RegistersPage";
            this.RegistersPage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RegistersPage.Size = new System.Drawing.Size(700, 510);
            this.RegistersPage.TabIndex = 0;
            this.RegistersPage.Text = "Registers";
            this.RegistersPage.UseVisualStyleBackColor = true;
            this.RegistersPage.Click += new System.EventHandler(this.RegistersPage_Click);
            // 
            // MoveRegsIntoMemsGroupBox
            // 
            this.MoveRegsIntoMemsGroupBox.Controls.Add(this.MoveRegsIntoMem1Button);
            this.MoveRegsIntoMemsGroupBox.Controls.Add(this.MoveRegsIntoMem2Button);
            this.MoveRegsIntoMemsGroupBox.Controls.Add(this.MoveRegsIntoMem3Button);
            this.MoveRegsIntoMemsGroupBox.Controls.Add(this.MoveRegsIntoMem4Button);
            this.MoveRegsIntoMemsGroupBox.Location = new System.Drawing.Point(469, 13);
            this.MoveRegsIntoMemsGroupBox.Name = "MoveRegsIntoMemsGroupBox";
            this.MoveRegsIntoMemsGroupBox.Size = new System.Drawing.Size(214, 159);
            this.MoveRegsIntoMemsGroupBox.TabIndex = 27;
            this.MoveRegsIntoMemsGroupBox.TabStop = false;
            this.MoveRegsIntoMemsGroupBox.Text = "Move actual registers into saved registers window:";
            // 
            // MoveRegsIntoMem1Button
            // 
            this.MoveRegsIntoMem1Button.Location = new System.Drawing.Point(11, 41);
            this.MoveRegsIntoMem1Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MoveRegsIntoMem1Button.Name = "MoveRegsIntoMem1Button";
            this.MoveRegsIntoMem1Button.Size = new System.Drawing.Size(99, 23);
            this.MoveRegsIntoMem1Button.TabIndex = 9;
            this.MoveRegsIntoMem1Button.Text = "Memory 1";
            this.MoveRegsIntoMem1Button.UseVisualStyleBackColor = true;
            this.MoveRegsIntoMem1Button.Click += new System.EventHandler(this.MoveRegsIntoMem1Button_Click);
            // 
            // MoveRegsIntoMem2Button
            // 
            this.MoveRegsIntoMem2Button.Location = new System.Drawing.Point(11, 69);
            this.MoveRegsIntoMem2Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MoveRegsIntoMem2Button.Name = "MoveRegsIntoMem2Button";
            this.MoveRegsIntoMem2Button.Size = new System.Drawing.Size(99, 23);
            this.MoveRegsIntoMem2Button.TabIndex = 9;
            this.MoveRegsIntoMem2Button.Text = "Memory 2";
            this.MoveRegsIntoMem2Button.UseVisualStyleBackColor = true;
            this.MoveRegsIntoMem2Button.Click += new System.EventHandler(this.MoveRegsIntoMem2Button_Click);
            // 
            // MoveRegsIntoMem3Button
            // 
            this.MoveRegsIntoMem3Button.Location = new System.Drawing.Point(11, 97);
            this.MoveRegsIntoMem3Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MoveRegsIntoMem3Button.Name = "MoveRegsIntoMem3Button";
            this.MoveRegsIntoMem3Button.Size = new System.Drawing.Size(99, 23);
            this.MoveRegsIntoMem3Button.TabIndex = 9;
            this.MoveRegsIntoMem3Button.Text = "Memory 3";
            this.MoveRegsIntoMem3Button.UseVisualStyleBackColor = true;
            this.MoveRegsIntoMem3Button.Click += new System.EventHandler(this.MoveRegsIntoMem3Button_Click);
            // 
            // MoveRegsIntoMem4Button
            // 
            this.MoveRegsIntoMem4Button.Location = new System.Drawing.Point(11, 125);
            this.MoveRegsIntoMem4Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MoveRegsIntoMem4Button.Name = "MoveRegsIntoMem4Button";
            this.MoveRegsIntoMem4Button.Size = new System.Drawing.Size(99, 23);
            this.MoveRegsIntoMem4Button.TabIndex = 9;
            this.MoveRegsIntoMem4Button.Text = "Memory 4";
            this.MoveRegsIntoMem4Button.UseVisualStyleBackColor = true;
            this.MoveRegsIntoMem4Button.Click += new System.EventHandler(this.MoveRegsIntoMem4Button_Click);
            // 
            // ChargePumpGroupBox
            // 
            this.ChargePumpGroupBox.Controls.Add(this.PosPFDCheckBox);
            this.ChargePumpGroupBox.Controls.Add(this.CPCycleSlipCheckBox);
            this.ChargePumpGroupBox.Controls.Add(this.CPTriStateOutCheckBox);
            this.ChargePumpGroupBox.Controls.Add(this.CPFastLockCheckBox);
            this.ChargePumpGroupBox.Controls.Add(this.RSetTextBox);
            this.ChargePumpGroupBox.Controls.Add(this.CPTestComboBox);
            this.ChargePumpGroupBox.Controls.Add(this.CPLinearityComboBox);
            this.ChargePumpGroupBox.Controls.Add(this.CPTestLabel);
            this.ChargePumpGroupBox.Controls.Add(this.CPCurrentComboBox);
            this.ChargePumpGroupBox.Controls.Add(this.CPlinearityLabel);
            this.ChargePumpGroupBox.Controls.Add(this.RSetLabel);
            this.ChargePumpGroupBox.Controls.Add(this.CPCurrentLabel);
            this.ChargePumpGroupBox.Location = new System.Drawing.Point(355, 255);
            this.ChargePumpGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.ChargePumpGroupBox.Name = "ChargePumpGroupBox";
            this.ChargePumpGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.ChargePumpGroupBox.Size = new System.Drawing.Size(335, 158);
            this.ChargePumpGroupBox.TabIndex = 26;
            this.ChargePumpGroupBox.TabStop = false;
            this.ChargePumpGroupBox.Text = "Charge Pump";
            // 
            // PosPFDCheckBox
            // 
            this.PosPFDCheckBox.AutoSize = true;
            this.PosPFDCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.PosPFDCheckBox.Location = new System.Drawing.Point(212, 116);
            this.PosPFDCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.PosPFDCheckBox.Name = "PosPFDCheckBox";
            this.PosPFDCheckBox.Size = new System.Drawing.Size(110, 21);
            this.PosPFDCheckBox.TabIndex = 18;
            this.PosPFDCheckBox.Text = "Positive PFD";
            this.PosPFDCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.PosPFDCheckBox.UseVisualStyleBackColor = true;
            // 
            // CPCycleSlipCheckBox
            // 
            this.CPCycleSlipCheckBox.AutoSize = true;
            this.CPCycleSlipCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CPCycleSlipCheckBox.Location = new System.Drawing.Point(227, 87);
            this.CPCycleSlipCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.CPCycleSlipCheckBox.Name = "CPCycleSlipCheckBox";
            this.CPCycleSlipCheckBox.Size = new System.Drawing.Size(95, 21);
            this.CPCycleSlipCheckBox.TabIndex = 18;
            this.CPCycleSlipCheckBox.Text = "Cycle Slip:";
            this.CPCycleSlipCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CPCycleSlipCheckBox.UseVisualStyleBackColor = true;
            // 
            // CPTriStateOutCheckBox
            // 
            this.CPTriStateOutCheckBox.AutoSize = true;
            this.CPTriStateOutCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CPTriStateOutCheckBox.Location = new System.Drawing.Point(196, 59);
            this.CPTriStateOutCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.CPTriStateOutCheckBox.Name = "CPTriStateOutCheckBox";
            this.CPTriStateOutCheckBox.Size = new System.Drawing.Size(129, 21);
            this.CPTriStateOutCheckBox.TabIndex = 18;
            this.CPTriStateOutCheckBox.Text = "Tristate Output:";
            this.CPTriStateOutCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CPTriStateOutCheckBox.UseVisualStyleBackColor = true;
            // 
            // CPFastLockCheckBox
            // 
            this.CPFastLockCheckBox.AutoSize = true;
            this.CPFastLockCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CPFastLockCheckBox.Location = new System.Drawing.Point(227, 30);
            this.CPFastLockCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.CPFastLockCheckBox.Name = "CPFastLockCheckBox";
            this.CPFastLockCheckBox.Size = new System.Drawing.Size(95, 21);
            this.CPFastLockCheckBox.TabIndex = 18;
            this.CPFastLockCheckBox.Text = "Fast Lock:";
            this.CPFastLockCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CPFastLockCheckBox.UseVisualStyleBackColor = true;
            // 
            // RSetTextBox
            // 
            this.RSetTextBox.BackColor = System.Drawing.Color.White;
            this.RSetTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.RSetTextBox.Location = new System.Drawing.Point(80, 22);
            this.RSetTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RSetTextBox.MaxLength = 8;
            this.RSetTextBox.Name = "RSetTextBox";
            this.RSetTextBox.Size = new System.Drawing.Size(53, 22);
            this.RSetTextBox.TabIndex = 3;
            this.RSetTextBox.Text = "4700";
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
            this.CPTestComboBox.Location = new System.Drawing.Point(80, 113);
            this.CPTestComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CPTestComboBox.Name = "CPTestComboBox";
            this.CPTestComboBox.Size = new System.Drawing.Size(91, 24);
            this.CPTestComboBox.TabIndex = 16;
            this.CPTestComboBox.SelectedIndexChanged += new System.EventHandler(this.ModeIntFracComboBox_SelectedIndexChanged);
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
            this.CPLinearityComboBox.Location = new System.Drawing.Point(80, 82);
            this.CPLinearityComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CPLinearityComboBox.Name = "CPLinearityComboBox";
            this.CPLinearityComboBox.Size = new System.Drawing.Size(91, 24);
            this.CPLinearityComboBox.TabIndex = 16;
            this.CPLinearityComboBox.SelectedIndexChanged += new System.EventHandler(this.CPLinearityComboBox_SelectedIndexChanged);
            // 
            // CPTestLabel
            // 
            this.CPTestLabel.Location = new System.Drawing.Point(7, 117);
            this.CPTestLabel.Name = "CPTestLabel";
            this.CPTestLabel.Size = new System.Drawing.Size(68, 17);
            this.CPTestLabel.TabIndex = 17;
            this.CPTestLabel.Text = "Test:";
            this.CPTestLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CPCurrentComboBox
            // 
            this.CPCurrentComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CPCurrentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CPCurrentComboBox.FormattingEnabled = true;
            this.CPCurrentComboBox.Location = new System.Drawing.Point(80, 52);
            this.CPCurrentComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CPCurrentComboBox.Name = "CPCurrentComboBox";
            this.CPCurrentComboBox.Size = new System.Drawing.Size(91, 24);
            this.CPCurrentComboBox.TabIndex = 16;
            this.CPCurrentComboBox.SelectedIndexChanged += new System.EventHandler(this.CPCurrentComboBox_SelectedIndexChanged);
            // 
            // CPlinearityLabel
            // 
            this.CPlinearityLabel.Location = new System.Drawing.Point(7, 86);
            this.CPlinearityLabel.Name = "CPlinearityLabel";
            this.CPlinearityLabel.Size = new System.Drawing.Size(68, 17);
            this.CPlinearityLabel.TabIndex = 17;
            this.CPlinearityLabel.Text = "Linearity:";
            this.CPlinearityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RSetLabel
            // 
            this.RSetLabel.Location = new System.Drawing.Point(7, 26);
            this.RSetLabel.Name = "RSetLabel";
            this.RSetLabel.Size = new System.Drawing.Size(68, 17);
            this.RSetLabel.TabIndex = 17;
            this.RSetLabel.Text = "R set:";
            this.RSetLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CPCurrentLabel
            // 
            this.CPCurrentLabel.Location = new System.Drawing.Point(11, 55);
            this.CPCurrentLabel.Name = "CPCurrentLabel";
            this.CPCurrentLabel.Size = new System.Drawing.Size(64, 17);
            this.CPCurrentLabel.TabIndex = 17;
            this.CPCurrentLabel.Text = "Current:";
            this.CPCurrentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RF_A_EN_Label);
            this.groupBox1.Controls.Add(this.RF_A_PWR_Label);
            this.groupBox1.Controls.Add(this.RF_B_EN_Label);
            this.groupBox1.Controls.Add(this.RF_B_PWR_Label);
            this.groupBox1.Controls.Add(this.RF_B_PWR_ComboBox);
            this.groupBox1.Controls.Add(this.RF_A_EN_ComboBox);
            this.groupBox1.Controls.Add(this.RF_A_PWR_ComboBox);
            this.groupBox1.Controls.Add(this.RF_B_EN_ComboBox);
            this.groupBox1.Location = new System.Drawing.Point(231, 421);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(459, 75);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Output Controls";
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
            // RF_B_PWR_ComboBox
            // 
            this.RF_B_PWR_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RF_B_PWR_ComboBox.FormattingEnabled = true;
            this.RF_B_PWR_ComboBox.Items.AddRange(new object[] {
            "-4 dBm",
            "-1 dBm",
            "+2 dBm",
            "+5 dBm"});
            this.RF_B_PWR_ComboBox.Location = new System.Drawing.Point(352, 47);
            this.RF_B_PWR_ComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RF_B_PWR_ComboBox.Name = "RF_B_PWR_ComboBox";
            this.RF_B_PWR_ComboBox.Size = new System.Drawing.Size(100, 24);
            this.RF_B_PWR_ComboBox.TabIndex = 16;
            // 
            // RF_A_EN_ComboBox
            // 
            this.RF_A_EN_ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.RF_A_EN_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RF_A_EN_ComboBox.FormattingEnabled = true;
            this.RF_A_EN_ComboBox.Items.AddRange(new object[] {
            "0. Disabled",
            "1. Enabled"});
            this.RF_A_EN_ComboBox.Location = new System.Drawing.Point(127, 18);
            this.RF_A_EN_ComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RF_A_EN_ComboBox.Name = "RF_A_EN_ComboBox";
            this.RF_A_EN_ComboBox.Size = new System.Drawing.Size(100, 24);
            this.RF_A_EN_ComboBox.TabIndex = 16;
            this.RF_A_EN_ComboBox.SelectedIndexChanged += new System.EventHandler(this.RF_A_EN_ComboBox_SelectedIndexChanged);
            // 
            // RF_A_PWR_ComboBox
            // 
            this.RF_A_PWR_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RF_A_PWR_ComboBox.FormattingEnabled = true;
            this.RF_A_PWR_ComboBox.Items.AddRange(new object[] {
            "-4 dBm",
            "-1 dBm",
            "+2 dBm",
            "+5 dBm"});
            this.RF_A_PWR_ComboBox.Location = new System.Drawing.Point(127, 47);
            this.RF_A_PWR_ComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RF_A_PWR_ComboBox.Name = "RF_A_PWR_ComboBox";
            this.RF_A_PWR_ComboBox.Size = new System.Drawing.Size(100, 24);
            this.RF_A_PWR_ComboBox.TabIndex = 16;
            this.RF_A_PWR_ComboBox.SelectedIndexChanged += new System.EventHandler(this.RF_A_PWR_ComboBox_SelectedIndexChanged);
            // 
            // RF_B_EN_ComboBox
            // 
            this.RF_B_EN_ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.RF_B_EN_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RF_B_EN_ComboBox.FormattingEnabled = true;
            this.RF_B_EN_ComboBox.Items.AddRange(new object[] {
            "0. Disabled",
            "1. Enabled"});
            this.RF_B_EN_ComboBox.Location = new System.Drawing.Point(352, 18);
            this.RF_B_EN_ComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RF_B_EN_ComboBox.Name = "RF_B_EN_ComboBox";
            this.RF_B_EN_ComboBox.Size = new System.Drawing.Size(100, 24);
            this.RF_B_EN_ComboBox.TabIndex = 16;
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
            this.OutInfoGroupBox.Location = new System.Drawing.Point(7, 423);
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
            this.FreqControlGroupBox.Controls.Add(this.ADivComboBox);
            this.FreqControlGroupBox.Controls.Add(this.FracNLabel);
            this.FreqControlGroupBox.Controls.Add(this.ModeIntFracComboBox);
            this.FreqControlGroupBox.Controls.Add(this.IntNLabel);
            this.FreqControlGroupBox.Controls.Add(this.ModeIntFracLabel);
            this.FreqControlGroupBox.Controls.Add(this.ModLabel);
            this.FreqControlGroupBox.Controls.Add(this.ADivLabel);
            this.FreqControlGroupBox.Controls.Add(this.PhasePLabel);
            this.FreqControlGroupBox.Controls.Add(this.IntNNumUpDown);
            this.FreqControlGroupBox.Controls.Add(this.ModNumUpDown);
            this.FreqControlGroupBox.Controls.Add(this.FracNNumUpDown);
            this.FreqControlGroupBox.Controls.Add(this.PhasePNumericUpDown);
            this.FreqControlGroupBox.Location = new System.Drawing.Point(9, 302);
            this.FreqControlGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.FreqControlGroupBox.Name = "FreqControlGroupBox";
            this.FreqControlGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.FreqControlGroupBox.Size = new System.Drawing.Size(339, 111);
            this.FreqControlGroupBox.TabIndex = 23;
            this.FreqControlGroupBox.TabStop = false;
            this.FreqControlGroupBox.Text = "Output Frequency Control";
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
            this.IntNNumUpDown.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.IntNScrollHandlerFunction);
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
            this.ModNumUpDown.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.ModScrollHandlerFunction);
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
            this.FracNNumUpDown.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.FracNScrollHandlerFunction);
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
            this.PhasePNumericUpDown.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.PhasePScrollHandlerFunction);
            // 
            // RefFreqGroupBox
            // 
            this.RefFreqGroupBox.Controls.Add(this.RDivUpDown);
            this.RefFreqGroupBox.Controls.Add(this.RefFTextBox);
            this.RefFreqGroupBox.Controls.Add(this.DivideBy2CheckBox);
            this.RefFreqGroupBox.Controls.Add(this.DoubleRefFCheckBox);
            this.RefFreqGroupBox.Controls.Add(this.RefFLabel);
            this.RefFreqGroupBox.Controls.Add(this.fPfdLabel);
            this.RefFreqGroupBox.Controls.Add(this.RDivLabel);
            this.RefFreqGroupBox.Controls.Add(this.MHzLabel4);
            this.RefFreqGroupBox.Controls.Add(this.MHzLabel3);
            this.RefFreqGroupBox.Controls.Add(this.fPfdScreenLabel);
            this.RefFreqGroupBox.Location = new System.Drawing.Point(7, 183);
            this.RefFreqGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.RefFreqGroupBox.Name = "RefFreqGroupBox";
            this.RefFreqGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.RefFreqGroupBox.Size = new System.Drawing.Size(304, 111);
            this.RefFreqGroupBox.TabIndex = 22;
            this.RefFreqGroupBox.TabStop = false;
            this.RefFreqGroupBox.Text = "Reference Frequency";
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
            this.RDivUpDown.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.RDivScrollHandlerFunction);
            // 
            // RefFTextBox
            // 
            this.RefFTextBox.BackColor = System.Drawing.Color.White;
            this.RefFTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.RefFTextBox.Location = new System.Drawing.Point(87, 26);
            this.RefFTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RefFTextBox.MaxLength = 9;
            this.RefFTextBox.Name = "RefFTextBox";
            this.RefFTextBox.Size = new System.Drawing.Size(89, 22);
            this.RefFTextBox.TabIndex = 3;
            this.RefFTextBox.Text = "10,000000";
            this.RefFTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RefFTextBox.TextChanged += new System.EventHandler(this.RefFTextBox_TextChanged);
            this.RefFTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RefFTextBox_KeyDown);
            this.RefFTextBox.LostFocus += new System.EventHandler(this.RefFTextBox_LostFocus);
            // 
            // DivideBy2CheckBox
            // 
            this.DivideBy2CheckBox.AutoSize = true;
            this.DivideBy2CheckBox.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.DivideBy2CheckBox.Location = new System.Drawing.Point(267, 14);
            this.DivideBy2CheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.DivideBy2CheckBox.Name = "DivideBy2CheckBox";
            this.DivideBy2CheckBox.Size = new System.Drawing.Size(28, 38);
            this.DivideBy2CheckBox.TabIndex = 21;
            this.DivideBy2CheckBox.Text = "÷2";
            this.DivideBy2CheckBox.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.DivideBy2CheckBox.UseVisualStyleBackColor = true;
            this.DivideBy2CheckBox.CheckedChanged += new System.EventHandler(this.DivideBy2CheckBox_CheckedChanged);
            // 
            // DoubleRefFCheckBox
            // 
            this.DoubleRefFCheckBox.AutoSize = true;
            this.DoubleRefFCheckBox.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.DoubleRefFCheckBox.Location = new System.Drawing.Point(229, 14);
            this.DoubleRefFCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.DoubleRefFCheckBox.Name = "DoubleRefFCheckBox";
            this.DoubleRefFCheckBox.Size = new System.Drawing.Size(26, 38);
            this.DoubleRefFCheckBox.TabIndex = 21;
            this.DoubleRefFCheckBox.Text = "x2";
            this.DoubleRefFCheckBox.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.DoubleRefFCheckBox.UseVisualStyleBackColor = true;
            this.DoubleRefFCheckBox.CheckedChanged += new System.EventHandler(this.DoubleRefFCheckBox_CheckedChanged);
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
            this.fPfdLabel.Location = new System.Drawing.Point(20, 87);
            this.fPfdLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fPfdLabel.Name = "fPfdLabel";
            this.fPfdLabel.Size = new System.Drawing.Size(61, 16);
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
            this.MHzLabel4.Location = new System.Drawing.Point(169, 86);
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
            // fPfdScreenLabel
            // 
            this.fPfdScreenLabel.Location = new System.Drawing.Point(65, 87);
            this.fPfdScreenLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fPfdScreenLabel.Name = "fPfdScreenLabel";
            this.fPfdScreenLabel.Size = new System.Drawing.Size(109, 16);
            this.fPfdScreenLabel.TabIndex = 20;
            this.fPfdScreenLabel.Text = "10.000 000";
            this.fPfdScreenLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SavedRegistersPage
            // 
            this.SavedRegistersPage.Controls.Add(this.ImportMem4Button);
            this.SavedRegistersPage.Controls.Add(this.ImportMem3Button);
            this.SavedRegistersPage.Controls.Add(this.ImportMem2Button);
            this.SavedRegistersPage.Controls.Add(this.ImportMem1Button);
            this.SavedRegistersPage.Controls.Add(this.SavReg3Label);
            this.SavedRegistersPage.Controls.Add(this.R0M4);
            this.SavedRegistersPage.Controls.Add(this.R0M3);
            this.SavedRegistersPage.Controls.Add(this.LoadRegMemory);
            this.SavedRegistersPage.Controls.Add(this.SaveRegMemory);
            this.SavedRegistersPage.Controls.Add(this.R0M2);
            this.SavedRegistersPage.Controls.Add(this.R0M1);
            this.SavedRegistersPage.Controls.Add(this.Mem4Label);
            this.SavedRegistersPage.Controls.Add(this.Mem3Label);
            this.SavedRegistersPage.Controls.Add(this.Mem2Label);
            this.SavedRegistersPage.Controls.Add(this.Mem1Label);
            this.SavedRegistersPage.Controls.Add(this.SavReg0Label);
            this.SavedRegistersPage.Controls.Add(this.SavReg1Label);
            this.SavedRegistersPage.Controls.Add(this.R1M4);
            this.SavedRegistersPage.Controls.Add(this.R1M3);
            this.SavedRegistersPage.Controls.Add(this.R1M2);
            this.SavedRegistersPage.Controls.Add(this.R1M1);
            this.SavedRegistersPage.Controls.Add(this.SavReg2Label);
            this.SavedRegistersPage.Controls.Add(this.R2M4);
            this.SavedRegistersPage.Controls.Add(this.R2M3);
            this.SavedRegistersPage.Controls.Add(this.R2M2);
            this.SavedRegistersPage.Controls.Add(this.R2M1);
            this.SavedRegistersPage.Controls.Add(this.R3M4);
            this.SavedRegistersPage.Controls.Add(this.R3M3);
            this.SavedRegistersPage.Controls.Add(this.R3M2);
            this.SavedRegistersPage.Controls.Add(this.R3M1);
            this.SavedRegistersPage.Controls.Add(this.SavReg4Label);
            this.SavedRegistersPage.Controls.Add(this.R4M4);
            this.SavedRegistersPage.Controls.Add(this.R4M3);
            this.SavedRegistersPage.Controls.Add(this.R5M4);
            this.SavedRegistersPage.Controls.Add(this.R4M2);
            this.SavedRegistersPage.Controls.Add(this.R5M3);
            this.SavedRegistersPage.Controls.Add(this.R4M1);
            this.SavedRegistersPage.Controls.Add(this.R5M2);
            this.SavedRegistersPage.Controls.Add(this.SavReg5Label);
            this.SavedRegistersPage.Controls.Add(this.R5M1);
            this.SavedRegistersPage.Location = new System.Drawing.Point(4, 25);
            this.SavedRegistersPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SavedRegistersPage.Name = "SavedRegistersPage";
            this.SavedRegistersPage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SavedRegistersPage.Size = new System.Drawing.Size(700, 510);
            this.SavedRegistersPage.TabIndex = 1;
            this.SavedRegistersPage.Text = "Saved Registers";
            this.SavedRegistersPage.UseVisualStyleBackColor = true;
            // 
            // ImportMem4Button
            // 
            this.ImportMem4Button.Location = new System.Drawing.Point(365, 203);
            this.ImportMem4Button.Name = "ImportMem4Button";
            this.ImportMem4Button.Size = new System.Drawing.Size(84, 49);
            this.ImportMem4Button.TabIndex = 21;
            this.ImportMem4Button.Text = "Import Memory 4";
            this.ImportMem4Button.UseVisualStyleBackColor = true;
            this.ImportMem4Button.Click += new System.EventHandler(this.ImportMem4Button_Click);
            // 
            // ImportMem3Button
            // 
            this.ImportMem3Button.Location = new System.Drawing.Point(275, 203);
            this.ImportMem3Button.Name = "ImportMem3Button";
            this.ImportMem3Button.Size = new System.Drawing.Size(84, 49);
            this.ImportMem3Button.TabIndex = 21;
            this.ImportMem3Button.Text = "Import Memory 3";
            this.ImportMem3Button.UseVisualStyleBackColor = true;
            this.ImportMem3Button.Click += new System.EventHandler(this.ImportMem3Button_Click);
            // 
            // ImportMem2Button
            // 
            this.ImportMem2Button.Location = new System.Drawing.Point(185, 203);
            this.ImportMem2Button.Name = "ImportMem2Button";
            this.ImportMem2Button.Size = new System.Drawing.Size(84, 49);
            this.ImportMem2Button.TabIndex = 21;
            this.ImportMem2Button.Text = "Import Memory 2";
            this.ImportMem2Button.UseVisualStyleBackColor = true;
            this.ImportMem2Button.Click += new System.EventHandler(this.ImportMem2Button_Click);
            // 
            // ImportMem1Button
            // 
            this.ImportMem1Button.Location = new System.Drawing.Point(95, 203);
            this.ImportMem1Button.Name = "ImportMem1Button";
            this.ImportMem1Button.Size = new System.Drawing.Size(84, 49);
            this.ImportMem1Button.TabIndex = 21;
            this.ImportMem1Button.Text = "Import Memory 1";
            this.ImportMem1Button.UseVisualStyleBackColor = true;
            this.ImportMem1Button.Click += new System.EventHandler(this.ImportMem1Button_Click);
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
            this.R0M4.Text = "80C90000";
            this.R0M4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.R0M3.Text = "80C90000";
            this.R0M3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LoadRegMemory
            // 
            this.LoadRegMemory.Location = new System.Drawing.Point(185, 346);
            this.LoadRegMemory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LoadRegMemory.Name = "LoadRegMemory";
            this.LoadRegMemory.Size = new System.Drawing.Size(115, 43);
            this.LoadRegMemory.TabIndex = 2;
            this.LoadRegMemory.Text = "Load registers from memory";
            this.LoadRegMemory.UseVisualStyleBackColor = true;
            this.LoadRegMemory.Click += new System.EventHandler(this.LoadRegMemory_Click);
            // 
            // SaveRegMemory
            // 
            this.SaveRegMemory.Location = new System.Drawing.Point(185, 297);
            this.SaveRegMemory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SaveRegMemory.Name = "SaveRegMemory";
            this.SaveRegMemory.Size = new System.Drawing.Size(115, 43);
            this.SaveRegMemory.TabIndex = 2;
            this.SaveRegMemory.Text = "Save registers into memory";
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
            this.R0M2.Text = "80C90000";
            this.R0M2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.R0M1.Text = "80C90000";
            this.R0M1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.R1M4.Text = "800103E9";
            this.R1M4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.R1M3.Text = "800103E9";
            this.R1M3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.R1M2.Text = "800103E9";
            this.R1M2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.R1M1.Text = "800103E9";
            this.R1M1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.R2M4.Text = "00005F42";
            this.R2M4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.R2M3.Text = "00005F42";
            this.R2M3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.R2M2.Text = "00005F42";
            this.R2M2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.R2M1.Text = "00005F42";
            this.R2M1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.R3M4.Text = "00001F23";
            this.R3M4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.R3M3.Text = "00001F23";
            this.R3M3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.R3M2.Text = "00001F23";
            this.R3M2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.R3M1.Text = "00001F23";
            this.R3M1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.R4M4.Text = "63BE80E4";
            this.R4M4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.R4M3.Text = "63BE80E4";
            this.R4M3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.R5M4.Text = "00400005";
            this.R5M4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.R4M2.Text = "63BE80E4";
            this.R4M2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.R5M3.Text = "00400005";
            this.R5M3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.R4M1.Text = "63BE80E4";
            this.R4M1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.R5M2.Text = "00400005";
            this.R5M2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.R5M1.Text = "00400005";
            this.R5M1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // RegistersGroupBox
            // 
            this.RegistersGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RegistersGroupBox.Location = new System.Drawing.Point(352, 11);
            this.RegistersGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RegistersGroupBox.Name = "RegistersGroupBox";
            this.RegistersGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RegistersGroupBox.Size = new System.Drawing.Size(703, 556);
            this.RegistersGroupBox.TabIndex = 13;
            this.RegistersGroupBox.TabStop = false;
            this.RegistersGroupBox.Text = "Registers Settings";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 579);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 13, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1067, 22);
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
            this.InputFreqTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.InputFreqTextBox.Location = new System.Drawing.Point(80, 192);
            this.InputFreqTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.InputFreqTextBox.MaxLength = 12;
            this.InputFreqTextBox.Name = "InputFreqTextBox";
            this.InputFreqTextBox.Size = new System.Drawing.Size(109, 22);
            this.InputFreqTextBox.TabIndex = 3;
            this.InputFreqTextBox.Text = "2851.750000";
            this.InputFreqTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.InputFreqTextBox.TextChanged += new System.EventHandler(this.InputFreqTextBox_TextChanged);
            this.InputFreqTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InputFreqTextBox_KeyDown);
            this.InputFreqTextBox.LostFocus += new System.EventHandler(this.RefFTextBox_LostFocus);
            this.InputFreqTextBox.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.InputFreqHandlerFunction);
            // 
            // MHzLabel6
            // 
            this.MHzLabel6.Location = new System.Drawing.Point(195, 195);
            this.MHzLabel6.Name = "MHzLabel6";
            this.MHzLabel6.Size = new System.Drawing.Size(40, 17);
            this.MHzLabel6.TabIndex = 17;
            this.MHzLabel6.Text = "MHz";
            this.MHzLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DeltaShowLabel
            // 
            this.DeltaShowLabel.Location = new System.Drawing.Point(80, 222);
            this.DeltaShowLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DeltaShowLabel.Name = "DeltaShowLabel";
            this.DeltaShowLabel.Size = new System.Drawing.Size(109, 16);
            this.DeltaShowLabel.TabIndex = 20;
            this.DeltaShowLabel.Text = "0";
            this.DeltaShowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HzLabel
            // 
            this.HzLabel.Location = new System.Drawing.Point(195, 222);
            this.HzLabel.Name = "HzLabel";
            this.HzLabel.Size = new System.Drawing.Size(40, 17);
            this.HzLabel.TabIndex = 17;
            this.HzLabel.Text = "Hz";
            this.HzLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DeltaLabel
            // 
            this.DeltaLabel.Location = new System.Drawing.Point(18, 221);
            this.DeltaLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DeltaLabel.Name = "DeltaLabel";
            this.DeltaLabel.Size = new System.Drawing.Size(61, 16);
            this.DeltaLabel.TabIndex = 20;
            this.DeltaLabel.Text = "Delta:";
            this.DeltaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // InputFreqLabel
            // 
            this.InputFreqLabel.Location = new System.Drawing.Point(18, 195);
            this.InputFreqLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.InputFreqLabel.Name = "InputFreqLabel";
            this.InputFreqLabel.Size = new System.Drawing.Size(61, 16);
            this.InputFreqLabel.TabIndex = 20;
            this.InputFreqLabel.Text = "Input f:";
            this.InputFreqLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(16, 260);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ReadOnly = true;
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox.Size = new System.Drawing.Size(318, 307);
            this.textBox.TabIndex = 21;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 601);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.InputFreqLabel);
            this.Controls.Add(this.DeltaLabel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.HzLabel);
            this.Controls.Add(this.InputFreqTextBox);
            this.Controls.Add(this.RegistersTabControl);
            this.Controls.Add(this.RegistersGroupBox);
            this.Controls.Add(this.AvaibleCOMsComBox);
            this.Controls.Add(this.PloInitButton);
            this.Controls.Add(this.DeltaShowLabel);
            this.Controls.Add(this.RefButton);
            this.Controls.Add(this.Out2Button);
            this.Controls.Add(this.MHzLabel6);
            this.Controls.Add(this.Out1Button);
            this.Controls.Add(this.PortButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Synthesizer Control Program by OK2FKU";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Click += new System.EventHandler(this.CheckAndApllyChangesForm1_Click);
            this.RegistersTabControl.ResumeLayout(false);
            this.RegistersPage.ResumeLayout(false);
            this.RegistersPage.PerformLayout();
            this.MoveRegsIntoMemsGroupBox.ResumeLayout(false);
            this.ChargePumpGroupBox.ResumeLayout(false);
            this.ChargePumpGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.OutInfoGroupBox.ResumeLayout(false);
            this.FreqControlGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.IntNNumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModNumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FracNNumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PhasePNumericUpDown)).EndInit();
            this.RefFreqGroupBox.ResumeLayout(false);
            this.RefFreqGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RDivUpDown)).EndInit();
            this.SavedRegistersPage.ResumeLayout(false);
            this.SavedRegistersPage.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button PortButton;
        private System.Windows.Forms.Button Out1Button;
        private System.Windows.Forms.Button Out2Button;
        private System.Windows.Forms.Button PloInitButton;
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
        private System.Windows.Forms.Button RefButton;
        private System.Windows.Forms.Button SetAsDefaultRegButton;
        private System.Windows.Forms.Button ForceLoadRegButton;
        private System.Windows.Forms.Button LoadDefRegButton;
        public System.Windows.Forms.ComboBox AvaibleCOMsComBox;
        private System.Windows.Forms.Button WriteR0Button;
        private System.Windows.Forms.Button WriteR1Button;
        private System.Windows.Forms.Button WriteR2Button;
        private System.Windows.Forms.Button WriteR3Button;
        private System.Windows.Forms.Button WriteR4Button;
        private System.Windows.Forms.Button WriteR5Button;
        private System.Windows.Forms.TabControl RegistersTabControl;
        private System.Windows.Forms.TabPage RegistersPage;
        private System.Windows.Forms.TabPage SavedRegistersPage;
        private System.Windows.Forms.Label SavReg3Label;
        private System.Windows.Forms.TextBox R0M4;
        private System.Windows.Forms.TextBox R0M3;
        private System.Windows.Forms.TextBox R0M2;
        private System.Windows.Forms.TextBox R0M1;
        private System.Windows.Forms.Label Mem1Label;
        private System.Windows.Forms.Label SavReg0Label;
        private System.Windows.Forms.Label SavReg1Label;
        private System.Windows.Forms.TextBox R1M4;
        private System.Windows.Forms.TextBox R1M3;
        private System.Windows.Forms.TextBox R1M2;
        private System.Windows.Forms.TextBox R1M1;
        private System.Windows.Forms.Label SavReg2Label;
        private System.Windows.Forms.TextBox R2M4;
        private System.Windows.Forms.TextBox R2M3;
        private System.Windows.Forms.TextBox R2M2;
        private System.Windows.Forms.TextBox R2M1;
        private System.Windows.Forms.TextBox R3M4;
        private System.Windows.Forms.TextBox R3M3;
        private System.Windows.Forms.TextBox R3M2;
        private System.Windows.Forms.TextBox R3M1;
        private System.Windows.Forms.Label SavReg4Label;
        private System.Windows.Forms.TextBox R4M4;
        private System.Windows.Forms.TextBox R4M3;
        private System.Windows.Forms.TextBox R5M4;
        private System.Windows.Forms.TextBox R4M2;
        private System.Windows.Forms.TextBox R5M3;
        private System.Windows.Forms.TextBox R4M1;
        private System.Windows.Forms.TextBox R5M2;
        private System.Windows.Forms.Label SavReg5Label;
        private System.Windows.Forms.TextBox R5M1;
        private System.Windows.Forms.Label Mem4Label;
        private System.Windows.Forms.Label Mem3Label;
        private System.Windows.Forms.Label Mem2Label;
        private System.Windows.Forms.GroupBox RegistersGroupBox;
        private System.Windows.Forms.Button SaveRegMemory;
        private System.Windows.Forms.Button LoadRegMemory;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label RF_A_EN_Label;
        private System.Windows.Forms.ComboBox RF_A_EN_ComboBox;
        private System.Windows.Forms.Label RF_A_PWR_Label;
        private System.Windows.Forms.ComboBox RF_A_PWR_ComboBox;
        private System.Windows.Forms.Label ModLabel;
        private System.Windows.Forms.Label FracNLabel;
        private System.Windows.Forms.Label IntNLabel;
        private System.Windows.Forms.Label ModeIntFracLabel;
        private System.Windows.Forms.ComboBox ModeIntFracComboBox;
        public System.Windows.Forms.NumericUpDown IntNNumUpDown;
        private System.Windows.Forms.NumericUpDown ModNumUpDown;
        private System.Windows.Forms.NumericUpDown FracNNumUpDown;
        private System.Windows.Forms.Label fOutAScreenLabel;
        private System.Windows.Forms.Label fOutALabel;
        private System.Windows.Forms.Label MHzLabel1;
        private System.Windows.Forms.Label fVcoLabel;
        private System.Windows.Forms.Label fVcoScreenLabel;
        private System.Windows.Forms.Label MHzLabel2;
        private CheckBox DivideBy2CheckBox;
        private CheckBox DoubleRefFCheckBox;
        private Label MHzLabel3;
        private Label RefFLabel;
        private TextBox RefFTextBox;
        private NumericUpDown RDivUpDown;
        private Label RDivLabel;
        private Label fPfdLabel;
        private Label fPfdScreenLabel;
        private NumericUpDown PhasePNumericUpDown;
        private Label MHzLabel4;
        private Label PhasePLabel;
        private Label ADivLabel;
        private ComboBox RF_B_PWR_ComboBox;
        private ComboBox RF_B_EN_ComboBox;
        private Label RF_B_PWR_Label;
        private Label RF_B_EN_Label;
        private Label fOutBLabel;
        private Label fOutBScreenLabel;
        private Label MHzLabel5;
        private GroupBox RefFreqGroupBox;
        private GroupBox FreqControlGroupBox;
        private GroupBox OutInfoGroupBox;
        private GroupBox groupBox1;
        private GroupBox ChargePumpGroupBox;
        private TextBox RSetTextBox;
        private Label RSetLabel;
        private ComboBox CPCurrentComboBox;
        private Label CPCurrentLabel;
        private ComboBox CPTestComboBox;
        private ComboBox CPLinearityComboBox;
        private Label CPTestLabel;
        private Label CPlinearityLabel;
        private CheckBox CPTriStateOutCheckBox;
        private CheckBox CPFastLockCheckBox;
        private CheckBox CPCycleSlipCheckBox;
        private CheckBox PosPFDCheckBox;
        private ComboBox ADivComboBox;
        private TextBox InputFreqTextBox;
        private Label MHzLabel6;
        private Label DeltaShowLabel;
        private Label HzLabel;
        private Label DeltaLabel;
        private Label InputFreqLabel;
        private GroupBox MoveRegsIntoMemsGroupBox;
        private Button MoveRegsIntoMem1Button;
        private Button MoveRegsIntoMem2Button;
        private Button MoveRegsIntoMem3Button;
        private Button MoveRegsIntoMem4Button;
        private Button ImportMem4Button;
        private Button ImportMem3Button;
        private Button ImportMem2Button;
        private Button ImportMem1Button;
        public TextBox textBox; // Hello there!, Rename me
    }
}

