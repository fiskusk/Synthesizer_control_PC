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
            this.OpenPortButton = new System.Windows.Forms.Button();
            this.ClosePortButton = new System.Windows.Forms.Button();
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
            this.RF_A_PWR_ComboBox = new System.Windows.Forms.ComboBox();
            this.RF_A_EN_ComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SavedRegistersPage = new System.Windows.Forms.TabPage();
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
            this.RegistersTabControl.SuspendLayout();
            this.RegistersPage.SuspendLayout();
            this.SavedRegistersPage.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpenPortButton
            // 
            this.OpenPortButton.Location = new System.Drawing.Point(12, 9);
            this.OpenPortButton.Name = "OpenPortButton";
            this.OpenPortButton.Size = new System.Drawing.Size(75, 23);
            this.OpenPortButton.TabIndex = 0;
            this.OpenPortButton.Text = "Open Port";
            this.OpenPortButton.UseVisualStyleBackColor = true;
            this.OpenPortButton.Click += new System.EventHandler(this.OpenPortButton_Click);
            // 
            // ClosePortButton
            // 
            this.ClosePortButton.Location = new System.Drawing.Point(12, 38);
            this.ClosePortButton.Name = "ClosePortButton";
            this.ClosePortButton.Size = new System.Drawing.Size(75, 23);
            this.ClosePortButton.TabIndex = 0;
            this.ClosePortButton.Text = "Close Port";
            this.ClosePortButton.UseVisualStyleBackColor = true;
            this.ClosePortButton.Click += new System.EventHandler(this.ClosePortButton_Click);
            // 
            // Out1Button
            // 
            this.Out1Button.Location = new System.Drawing.Point(9, 103);
            this.Out1Button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Out1Button.Name = "Out1Button";
            this.Out1Button.Size = new System.Drawing.Size(75, 23);
            this.Out1Button.TabIndex = 1;
            this.Out1Button.Text = "Out 1 Off";
            this.Out1Button.UseVisualStyleBackColor = true;
            this.Out1Button.Click += new System.EventHandler(this.Out1Button_Click);
            // 
            // Out2Button
            // 
            this.Out2Button.Location = new System.Drawing.Point(9, 131);
            this.Out2Button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Out2Button.Name = "Out2Button";
            this.Out2Button.Size = new System.Drawing.Size(75, 23);
            this.Out2Button.TabIndex = 1;
            this.Out2Button.Text = "Out 2 Off";
            this.Out2Button.UseVisualStyleBackColor = true;
            this.Out2Button.Click += new System.EventHandler(this.Out2Button_Click);
            // 
            // PloInitButton
            // 
            this.PloInitButton.Location = new System.Drawing.Point(118, 103);
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
            this.Reg0TextBox.Location = new System.Drawing.Point(71, 11);
            this.Reg0TextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Reg0TextBox.MaxLength = 8;
            this.Reg0TextBox.Name = "Reg0TextBox";
            this.Reg0TextBox.Size = new System.Drawing.Size(76, 20);
            this.Reg0TextBox.TabIndex = 3;
            this.Reg0TextBox.Text = "80C90000";
            this.Reg0TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Reg0TextBox.Click += new System.EventHandler(this.Reg0TextBox_Click);
            this.Reg0TextBox.TextChanged += new System.EventHandler(this.Reg0TextBox_TextChanged);
            this.Reg0TextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Reg0TextBox_KeyDown);
            // 
            // Reg0Label
            // 
            this.Reg0Label.AutoSize = true;
            this.Reg0Label.Location = new System.Drawing.Point(12, 14);
            this.Reg0Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Reg0Label.Name = "Reg0Label";
            this.Reg0Label.Size = new System.Drawing.Size(55, 13);
            this.Reg0Label.TabIndex = 4;
            this.Reg0Label.Text = "Register 0";
            // 
            // Reg1Label
            // 
            this.Reg1Label.AutoSize = true;
            this.Reg1Label.Location = new System.Drawing.Point(12, 37);
            this.Reg1Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Reg1Label.Name = "Reg1Label";
            this.Reg1Label.Size = new System.Drawing.Size(55, 13);
            this.Reg1Label.TabIndex = 5;
            this.Reg1Label.Text = "Register 1";
            // 
            // Reg1TextBox
            // 
            this.Reg1TextBox.BackColor = System.Drawing.Color.White;
            this.Reg1TextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Reg1TextBox.Location = new System.Drawing.Point(71, 34);
            this.Reg1TextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Reg1TextBox.MaxLength = 8;
            this.Reg1TextBox.Name = "Reg1TextBox";
            this.Reg1TextBox.Size = new System.Drawing.Size(76, 20);
            this.Reg1TextBox.TabIndex = 6;
            this.Reg1TextBox.Text = "800103E9";
            this.Reg1TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Reg1TextBox.Click += new System.EventHandler(this.Reg1TextBox_Click);
            this.Reg1TextBox.TextChanged += new System.EventHandler(this.Reg1TextBox_TextChanged);
            this.Reg1TextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Reg1TextBox_KeyDown);
            // 
            // Reg2Label
            // 
            this.Reg2Label.AutoSize = true;
            this.Reg2Label.Location = new System.Drawing.Point(12, 59);
            this.Reg2Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Reg2Label.Name = "Reg2Label";
            this.Reg2Label.Size = new System.Drawing.Size(55, 13);
            this.Reg2Label.TabIndex = 7;
            this.Reg2Label.Text = "Register 2";
            // 
            // Reg2TextBox
            // 
            this.Reg2TextBox.BackColor = System.Drawing.Color.White;
            this.Reg2TextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Reg2TextBox.Location = new System.Drawing.Point(71, 57);
            this.Reg2TextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Reg2TextBox.MaxLength = 8;
            this.Reg2TextBox.Name = "Reg2TextBox";
            this.Reg2TextBox.Size = new System.Drawing.Size(76, 20);
            this.Reg2TextBox.TabIndex = 8;
            this.Reg2TextBox.Text = "00005F42";
            this.Reg2TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Reg2TextBox.Click += new System.EventHandler(this.Reg2TextBox_Click);
            this.Reg2TextBox.TextChanged += new System.EventHandler(this.Reg2TextBox_TextChanged);
            this.Reg2TextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Reg2TextBox_KeyDown);
            // 
            // Reg3Label
            // 
            this.Reg3Label.AutoSize = true;
            this.Reg3Label.Location = new System.Drawing.Point(12, 82);
            this.Reg3Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Reg3Label.Name = "Reg3Label";
            this.Reg3Label.Size = new System.Drawing.Size(55, 13);
            this.Reg3Label.TabIndex = 7;
            this.Reg3Label.Text = "Register 3";
            // 
            // Reg3TextBox
            // 
            this.Reg3TextBox.BackColor = System.Drawing.Color.White;
            this.Reg3TextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Reg3TextBox.Location = new System.Drawing.Point(71, 80);
            this.Reg3TextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Reg3TextBox.MaxLength = 8;
            this.Reg3TextBox.Name = "Reg3TextBox";
            this.Reg3TextBox.Size = new System.Drawing.Size(76, 20);
            this.Reg3TextBox.TabIndex = 8;
            this.Reg3TextBox.Text = "00001F23";
            this.Reg3TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Reg3TextBox.Click += new System.EventHandler(this.Reg3TextBox_Click);
            this.Reg3TextBox.TextChanged += new System.EventHandler(this.Reg3TextBox_TextChanged);
            this.Reg3TextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Reg3TextBox_KeyDown);
            // 
            // Reg4Label
            // 
            this.Reg4Label.AutoSize = true;
            this.Reg4Label.Location = new System.Drawing.Point(12, 103);
            this.Reg4Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Reg4Label.Name = "Reg4Label";
            this.Reg4Label.Size = new System.Drawing.Size(55, 13);
            this.Reg4Label.TabIndex = 7;
            this.Reg4Label.Text = "Register 4";
            // 
            // Reg4TextBox
            // 
            this.Reg4TextBox.BackColor = System.Drawing.Color.White;
            this.Reg4TextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Reg4TextBox.Location = new System.Drawing.Point(71, 101);
            this.Reg4TextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Reg4TextBox.MaxLength = 8;
            this.Reg4TextBox.Name = "Reg4TextBox";
            this.Reg4TextBox.Size = new System.Drawing.Size(76, 20);
            this.Reg4TextBox.TabIndex = 8;
            this.Reg4TextBox.Text = "63BE80E4";
            this.Reg4TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Reg4TextBox.Click += new System.EventHandler(this.Reg4TextBox_Click);
            this.Reg4TextBox.TextChanged += new System.EventHandler(this.Reg4TextBox_TextChanged);
            this.Reg4TextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Reg4TextBox_KeyDown);
            // 
            // Reg5Label
            // 
            this.Reg5Label.AutoSize = true;
            this.Reg5Label.Location = new System.Drawing.Point(12, 126);
            this.Reg5Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Reg5Label.Name = "Reg5Label";
            this.Reg5Label.Size = new System.Drawing.Size(55, 13);
            this.Reg5Label.TabIndex = 7;
            this.Reg5Label.Text = "Register 5";
            // 
            // Reg5TextBox
            // 
            this.Reg5TextBox.BackColor = System.Drawing.Color.White;
            this.Reg5TextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Reg5TextBox.Location = new System.Drawing.Point(71, 124);
            this.Reg5TextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Reg5TextBox.MaxLength = 8;
            this.Reg5TextBox.Name = "Reg5TextBox";
            this.Reg5TextBox.Size = new System.Drawing.Size(76, 20);
            this.Reg5TextBox.TabIndex = 8;
            this.Reg5TextBox.Text = "00400005";
            this.Reg5TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Reg5TextBox.Click += new System.EventHandler(this.Reg5TextBox_Click);
            this.Reg5TextBox.TextChanged += new System.EventHandler(this.Reg5TextBox_TextChanged);
            this.Reg5TextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Reg5TextBox_KeyDown);
            // 
            // RefButton
            // 
            this.RefButton.Location = new System.Drawing.Point(9, 158);
            this.RefButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RefButton.Name = "RefButton";
            this.RefButton.Size = new System.Drawing.Size(75, 23);
            this.RefButton.TabIndex = 1;
            this.RefButton.Text = "Ext Ref";
            this.RefButton.UseVisualStyleBackColor = true;
            this.RefButton.Click += new System.EventHandler(this.RefButton_Click);
            // 
            // SetAsDefaultRegButton
            // 
            this.SetAsDefaultRegButton.Location = new System.Drawing.Point(248, 11);
            this.SetAsDefaultRegButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SetAsDefaultRegButton.Name = "SetAsDefaultRegButton";
            this.SetAsDefaultRegButton.Size = new System.Drawing.Size(74, 19);
            this.SetAsDefaultRegButton.TabIndex = 9;
            this.SetAsDefaultRegButton.Text = "Set As Def";
            this.SetAsDefaultRegButton.UseVisualStyleBackColor = true;
            this.SetAsDefaultRegButton.Click += new System.EventHandler(this.SetAsDefaultRegButton_Click);
            // 
            // ForceLoadRegButton
            // 
            this.ForceLoadRegButton.Location = new System.Drawing.Point(248, 58);
            this.ForceLoadRegButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ForceLoadRegButton.Name = "ForceLoadRegButton";
            this.ForceLoadRegButton.Size = new System.Drawing.Size(74, 19);
            this.ForceLoadRegButton.TabIndex = 9;
            this.ForceLoadRegButton.Text = "Force Load ";
            this.ForceLoadRegButton.UseVisualStyleBackColor = true;
            this.ForceLoadRegButton.Click += new System.EventHandler(this.ForceLoadRegButton_Click);
            // 
            // LoadDefRegButton
            // 
            this.LoadDefRegButton.Location = new System.Drawing.Point(248, 34);
            this.LoadDefRegButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LoadDefRegButton.Name = "LoadDefRegButton";
            this.LoadDefRegButton.Size = new System.Drawing.Size(74, 19);
            this.LoadDefRegButton.TabIndex = 9;
            this.LoadDefRegButton.Text = "Load Def";
            this.LoadDefRegButton.UseVisualStyleBackColor = true;
            this.LoadDefRegButton.Click += new System.EventHandler(this.LoadDefRegButton_Click);
            // 
            // AvaibleCOMsComBox
            // 
            this.AvaibleCOMsComBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AvaibleCOMsComBox.FormattingEnabled = true;
            this.AvaibleCOMsComBox.Location = new System.Drawing.Point(107, 9);
            this.AvaibleCOMsComBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AvaibleCOMsComBox.Name = "AvaibleCOMsComBox";
            this.AvaibleCOMsComBox.Size = new System.Drawing.Size(66, 21);
            this.AvaibleCOMsComBox.TabIndex = 10;
            this.AvaibleCOMsComBox.DropDown += new System.EventHandler(this.AvaibleCOMsComBox_DropDown);
            // 
            // WriteR0Button
            // 
            this.WriteR0Button.Location = new System.Drawing.Point(151, 11);
            this.WriteR0Button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.WriteR0Button.Name = "WriteR0Button";
            this.WriteR0Button.Size = new System.Drawing.Size(63, 19);
            this.WriteR0Button.TabIndex = 11;
            this.WriteR0Button.Text = "Write R0";
            this.WriteR0Button.UseVisualStyleBackColor = true;
            this.WriteR0Button.Click += new System.EventHandler(this.WriteR0Button_Click);
            // 
            // WriteR1Button
            // 
            this.WriteR1Button.Location = new System.Drawing.Point(151, 34);
            this.WriteR1Button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.WriteR1Button.Name = "WriteR1Button";
            this.WriteR1Button.Size = new System.Drawing.Size(63, 19);
            this.WriteR1Button.TabIndex = 11;
            this.WriteR1Button.Text = "Write R1";
            this.WriteR1Button.UseVisualStyleBackColor = true;
            this.WriteR1Button.Click += new System.EventHandler(this.WriteR1Button_Click);
            // 
            // WriteR2Button
            // 
            this.WriteR2Button.Location = new System.Drawing.Point(151, 57);
            this.WriteR2Button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.WriteR2Button.Name = "WriteR2Button";
            this.WriteR2Button.Size = new System.Drawing.Size(63, 19);
            this.WriteR2Button.TabIndex = 11;
            this.WriteR2Button.Text = "Write R2";
            this.WriteR2Button.UseVisualStyleBackColor = true;
            this.WriteR2Button.Click += new System.EventHandler(this.WriteR2Button_Click);
            // 
            // WriteR3Button
            // 
            this.WriteR3Button.Location = new System.Drawing.Point(151, 80);
            this.WriteR3Button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.WriteR3Button.Name = "WriteR3Button";
            this.WriteR3Button.Size = new System.Drawing.Size(63, 19);
            this.WriteR3Button.TabIndex = 11;
            this.WriteR3Button.Text = "Write R3";
            this.WriteR3Button.UseVisualStyleBackColor = true;
            this.WriteR3Button.Click += new System.EventHandler(this.WriteR3Button_Click);
            // 
            // WriteR4Button
            // 
            this.WriteR4Button.Location = new System.Drawing.Point(151, 101);
            this.WriteR4Button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.WriteR4Button.Name = "WriteR4Button";
            this.WriteR4Button.Size = new System.Drawing.Size(63, 19);
            this.WriteR4Button.TabIndex = 11;
            this.WriteR4Button.Text = "Write R4";
            this.WriteR4Button.UseVisualStyleBackColor = true;
            this.WriteR4Button.Click += new System.EventHandler(this.WriteR4Button_Click);
            // 
            // WriteR5Button
            // 
            this.WriteR5Button.Location = new System.Drawing.Point(151, 124);
            this.WriteR5Button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.WriteR5Button.Name = "WriteR5Button";
            this.WriteR5Button.Size = new System.Drawing.Size(63, 19);
            this.WriteR5Button.TabIndex = 11;
            this.WriteR5Button.Text = "Write R5";
            this.WriteR5Button.UseVisualStyleBackColor = true;
            this.WriteR5Button.Click += new System.EventHandler(this.WriteR5Button_Click);
            // 
            // RegistersTabControl
            // 
            this.RegistersTabControl.Controls.Add(this.RegistersPage);
            this.RegistersTabControl.Controls.Add(this.SavedRegistersPage);
            this.RegistersTabControl.Location = new System.Drawing.Point(439, 26);
            this.RegistersTabControl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RegistersTabControl.Name = "RegistersTabControl";
            this.RegistersTabControl.SelectedIndex = 0;
            this.RegistersTabControl.Size = new System.Drawing.Size(356, 346);
            this.RegistersTabControl.TabIndex = 12;
            // 
            // RegistersPage
            // 
            this.RegistersPage.Controls.Add(this.RF_A_PWR_ComboBox);
            this.RegistersPage.Controls.Add(this.RF_A_EN_ComboBox);
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
            this.RegistersPage.Controls.Add(this.label2);
            this.RegistersPage.Controls.Add(this.label1);
            this.RegistersPage.Controls.Add(this.Reg5Label);
            this.RegistersPage.Controls.Add(this.Reg5TextBox);
            this.RegistersPage.Location = new System.Drawing.Point(4, 22);
            this.RegistersPage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RegistersPage.Name = "RegistersPage";
            this.RegistersPage.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RegistersPage.Size = new System.Drawing.Size(348, 320);
            this.RegistersPage.TabIndex = 0;
            this.RegistersPage.Text = "Registers";
            this.RegistersPage.UseVisualStyleBackColor = true;
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
            this.RF_A_PWR_ComboBox.Location = new System.Drawing.Point(94, 176);
            this.RF_A_PWR_ComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RF_A_PWR_ComboBox.Name = "RF_A_PWR_ComboBox";
            this.RF_A_PWR_ComboBox.Size = new System.Drawing.Size(92, 21);
            this.RF_A_PWR_ComboBox.TabIndex = 16;
            this.RF_A_PWR_ComboBox.SelectedIndexChanged += new System.EventHandler(this.RF_A_PWR_ComboBox_SelectedIndexChanged);
            // 
            // RF_A_EN_ComboBox
            // 
            this.RF_A_EN_ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.RF_A_EN_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RF_A_EN_ComboBox.FormattingEnabled = true;
            this.RF_A_EN_ComboBox.Items.AddRange(new object[] {
            "0. Disabled",
            "1. Enabled"});
            this.RF_A_EN_ComboBox.Location = new System.Drawing.Point(94, 153);
            this.RF_A_EN_ComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RF_A_EN_ComboBox.Name = "RF_A_EN_ComboBox";
            this.RF_A_EN_ComboBox.Size = new System.Drawing.Size(92, 21);
            this.RF_A_EN_ComboBox.TabIndex = 16;
            this.RF_A_EN_ComboBox.SelectedIndexChanged += new System.EventHandler(this.RF_A_EN_ComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(4, 179);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "RFoutA Power:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 155);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "RFoutA Enable:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // SavedRegistersPage
            // 
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
            this.SavedRegistersPage.Location = new System.Drawing.Point(4, 22);
            this.SavedRegistersPage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SavedRegistersPage.Name = "SavedRegistersPage";
            this.SavedRegistersPage.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SavedRegistersPage.Size = new System.Drawing.Size(348, 320);
            this.SavedRegistersPage.TabIndex = 1;
            this.SavedRegistersPage.Text = "Saved Registers";
            this.SavedRegistersPage.UseVisualStyleBackColor = true;
            // 
            // SavReg3Label
            // 
            this.SavReg3Label.AutoSize = true;
            this.SavReg3Label.Location = new System.Drawing.Point(12, 101);
            this.SavReg3Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SavReg3Label.Name = "SavReg3Label";
            this.SavReg3Label.Size = new System.Drawing.Size(55, 13);
            this.SavReg3Label.TabIndex = 13;
            this.SavReg3Label.Text = "Register 3";
            // 
            // R0M4
            // 
            this.R0M4.BackColor = System.Drawing.Color.White;
            this.R0M4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R0M4.Location = new System.Drawing.Point(274, 30);
            this.R0M4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.R0M4.MaxLength = 8;
            this.R0M4.Name = "R0M4";
            this.R0M4.Size = new System.Drawing.Size(64, 20);
            this.R0M4.TabIndex = 9;
            this.R0M4.Text = "80C90000";
            this.R0M4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // R0M3
            // 
            this.R0M3.BackColor = System.Drawing.Color.White;
            this.R0M3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R0M3.Location = new System.Drawing.Point(206, 30);
            this.R0M3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.R0M3.MaxLength = 8;
            this.R0M3.Name = "R0M3";
            this.R0M3.Size = new System.Drawing.Size(64, 20);
            this.R0M3.TabIndex = 9;
            this.R0M3.Text = "80C90000";
            this.R0M3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LoadRegMemory
            // 
            this.LoadRegMemory.Location = new System.Drawing.Point(130, 230);
            this.LoadRegMemory.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LoadRegMemory.Name = "LoadRegMemory";
            this.LoadRegMemory.Size = new System.Drawing.Size(86, 35);
            this.LoadRegMemory.TabIndex = 2;
            this.LoadRegMemory.Text = "Load registers from memory";
            this.LoadRegMemory.UseVisualStyleBackColor = true;
            this.LoadRegMemory.Click += new System.EventHandler(this.LoadRegMemory_Click);
            // 
            // SaveRegMemory
            // 
            this.SaveRegMemory.Location = new System.Drawing.Point(130, 190);
            this.SaveRegMemory.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SaveRegMemory.Name = "SaveRegMemory";
            this.SaveRegMemory.Size = new System.Drawing.Size(86, 35);
            this.SaveRegMemory.TabIndex = 2;
            this.SaveRegMemory.Text = "Save registers into memory";
            this.SaveRegMemory.UseVisualStyleBackColor = true;
            this.SaveRegMemory.Click += new System.EventHandler(this.SaveRegMemory_Click);
            // 
            // R0M2
            // 
            this.R0M2.BackColor = System.Drawing.Color.White;
            this.R0M2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R0M2.Location = new System.Drawing.Point(139, 30);
            this.R0M2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.R0M2.MaxLength = 8;
            this.R0M2.Name = "R0M2";
            this.R0M2.Size = new System.Drawing.Size(64, 20);
            this.R0M2.TabIndex = 9;
            this.R0M2.Text = "80C90000";
            this.R0M2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // R0M1
            // 
            this.R0M1.BackColor = System.Drawing.Color.White;
            this.R0M1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R0M1.Location = new System.Drawing.Point(71, 30);
            this.R0M1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.R0M1.MaxLength = 8;
            this.R0M1.Name = "R0M1";
            this.R0M1.Size = new System.Drawing.Size(64, 20);
            this.R0M1.TabIndex = 9;
            this.R0M1.Text = "80C90000";
            this.R0M1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Mem4Label
            // 
            this.Mem4Label.Location = new System.Drawing.Point(274, 12);
            this.Mem4Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Mem4Label.Name = "Mem4Label";
            this.Mem4Label.Size = new System.Drawing.Size(63, 14);
            this.Mem4Label.TabIndex = 10;
            this.Mem4Label.Text = "Memory 4";
            this.Mem4Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Mem3Label
            // 
            this.Mem3Label.Location = new System.Drawing.Point(206, 12);
            this.Mem3Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Mem3Label.Name = "Mem3Label";
            this.Mem3Label.Size = new System.Drawing.Size(63, 14);
            this.Mem3Label.TabIndex = 10;
            this.Mem3Label.Text = "Memory 3";
            this.Mem3Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Mem2Label
            // 
            this.Mem2Label.Location = new System.Drawing.Point(139, 12);
            this.Mem2Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Mem2Label.Name = "Mem2Label";
            this.Mem2Label.Size = new System.Drawing.Size(63, 14);
            this.Mem2Label.TabIndex = 10;
            this.Mem2Label.Text = "Memory 2";
            this.Mem2Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Mem1Label
            // 
            this.Mem1Label.Location = new System.Drawing.Point(71, 12);
            this.Mem1Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Mem1Label.Name = "Mem1Label";
            this.Mem1Label.Size = new System.Drawing.Size(63, 14);
            this.Mem1Label.TabIndex = 10;
            this.Mem1Label.Text = "Memory 1";
            this.Mem1Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SavReg0Label
            // 
            this.SavReg0Label.AutoSize = true;
            this.SavReg0Label.Location = new System.Drawing.Point(12, 32);
            this.SavReg0Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SavReg0Label.Name = "SavReg0Label";
            this.SavReg0Label.Size = new System.Drawing.Size(55, 13);
            this.SavReg0Label.TabIndex = 10;
            this.SavReg0Label.Text = "Register 0";
            // 
            // SavReg1Label
            // 
            this.SavReg1Label.AutoSize = true;
            this.SavReg1Label.Location = new System.Drawing.Point(12, 55);
            this.SavReg1Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SavReg1Label.Name = "SavReg1Label";
            this.SavReg1Label.Size = new System.Drawing.Size(55, 13);
            this.SavReg1Label.TabIndex = 11;
            this.SavReg1Label.Text = "Register 1";
            // 
            // R1M4
            // 
            this.R1M4.BackColor = System.Drawing.Color.White;
            this.R1M4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R1M4.Location = new System.Drawing.Point(274, 53);
            this.R1M4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.R1M4.MaxLength = 8;
            this.R1M4.Name = "R1M4";
            this.R1M4.Size = new System.Drawing.Size(64, 20);
            this.R1M4.TabIndex = 12;
            this.R1M4.Text = "800103E9";
            this.R1M4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // R1M3
            // 
            this.R1M3.BackColor = System.Drawing.Color.White;
            this.R1M3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R1M3.Location = new System.Drawing.Point(206, 53);
            this.R1M3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.R1M3.MaxLength = 8;
            this.R1M3.Name = "R1M3";
            this.R1M3.Size = new System.Drawing.Size(64, 20);
            this.R1M3.TabIndex = 12;
            this.R1M3.Text = "800103E9";
            this.R1M3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // R1M2
            // 
            this.R1M2.BackColor = System.Drawing.Color.White;
            this.R1M2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R1M2.Location = new System.Drawing.Point(139, 53);
            this.R1M2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.R1M2.MaxLength = 8;
            this.R1M2.Name = "R1M2";
            this.R1M2.Size = new System.Drawing.Size(64, 20);
            this.R1M2.TabIndex = 12;
            this.R1M2.Text = "800103E9";
            this.R1M2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // R1M1
            // 
            this.R1M1.BackColor = System.Drawing.Color.White;
            this.R1M1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R1M1.Location = new System.Drawing.Point(71, 53);
            this.R1M1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.R1M1.MaxLength = 8;
            this.R1M1.Name = "R1M1";
            this.R1M1.Size = new System.Drawing.Size(64, 20);
            this.R1M1.TabIndex = 12;
            this.R1M1.Text = "800103E9";
            this.R1M1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SavReg2Label
            // 
            this.SavReg2Label.AutoSize = true;
            this.SavReg2Label.Location = new System.Drawing.Point(12, 78);
            this.SavReg2Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SavReg2Label.Name = "SavReg2Label";
            this.SavReg2Label.Size = new System.Drawing.Size(55, 13);
            this.SavReg2Label.TabIndex = 14;
            this.SavReg2Label.Text = "Register 2";
            // 
            // R2M4
            // 
            this.R2M4.BackColor = System.Drawing.Color.White;
            this.R2M4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R2M4.Location = new System.Drawing.Point(274, 76);
            this.R2M4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.R2M4.MaxLength = 8;
            this.R2M4.Name = "R2M4";
            this.R2M4.Size = new System.Drawing.Size(64, 20);
            this.R2M4.TabIndex = 17;
            this.R2M4.Text = "00005F42";
            this.R2M4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // R2M3
            // 
            this.R2M3.BackColor = System.Drawing.Color.White;
            this.R2M3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R2M3.Location = new System.Drawing.Point(206, 76);
            this.R2M3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.R2M3.MaxLength = 8;
            this.R2M3.Name = "R2M3";
            this.R2M3.Size = new System.Drawing.Size(64, 20);
            this.R2M3.TabIndex = 17;
            this.R2M3.Text = "00005F42";
            this.R2M3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // R2M2
            // 
            this.R2M2.BackColor = System.Drawing.Color.White;
            this.R2M2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R2M2.Location = new System.Drawing.Point(139, 76);
            this.R2M2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.R2M2.MaxLength = 8;
            this.R2M2.Name = "R2M2";
            this.R2M2.Size = new System.Drawing.Size(64, 20);
            this.R2M2.TabIndex = 17;
            this.R2M2.Text = "00005F42";
            this.R2M2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // R2M1
            // 
            this.R2M1.BackColor = System.Drawing.Color.White;
            this.R2M1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R2M1.Location = new System.Drawing.Point(71, 76);
            this.R2M1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.R2M1.MaxLength = 8;
            this.R2M1.Name = "R2M1";
            this.R2M1.Size = new System.Drawing.Size(64, 20);
            this.R2M1.TabIndex = 17;
            this.R2M1.Text = "00005F42";
            this.R2M1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // R3M4
            // 
            this.R3M4.BackColor = System.Drawing.Color.White;
            this.R3M4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R3M4.Location = new System.Drawing.Point(274, 98);
            this.R3M4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.R3M4.MaxLength = 8;
            this.R3M4.Name = "R3M4";
            this.R3M4.Size = new System.Drawing.Size(64, 20);
            this.R3M4.TabIndex = 18;
            this.R3M4.Text = "00001F23";
            this.R3M4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // R3M3
            // 
            this.R3M3.BackColor = System.Drawing.Color.White;
            this.R3M3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R3M3.Location = new System.Drawing.Point(206, 98);
            this.R3M3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.R3M3.MaxLength = 8;
            this.R3M3.Name = "R3M3";
            this.R3M3.Size = new System.Drawing.Size(64, 20);
            this.R3M3.TabIndex = 18;
            this.R3M3.Text = "00001F23";
            this.R3M3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // R3M2
            // 
            this.R3M2.BackColor = System.Drawing.Color.White;
            this.R3M2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R3M2.Location = new System.Drawing.Point(139, 98);
            this.R3M2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.R3M2.MaxLength = 8;
            this.R3M2.Name = "R3M2";
            this.R3M2.Size = new System.Drawing.Size(64, 20);
            this.R3M2.TabIndex = 18;
            this.R3M2.Text = "00001F23";
            this.R3M2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // R3M1
            // 
            this.R3M1.BackColor = System.Drawing.Color.White;
            this.R3M1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R3M1.Location = new System.Drawing.Point(71, 98);
            this.R3M1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.R3M1.MaxLength = 8;
            this.R3M1.Name = "R3M1";
            this.R3M1.Size = new System.Drawing.Size(64, 20);
            this.R3M1.TabIndex = 18;
            this.R3M1.Text = "00001F23";
            this.R3M1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SavReg4Label
            // 
            this.SavReg4Label.AutoSize = true;
            this.SavReg4Label.Location = new System.Drawing.Point(12, 122);
            this.SavReg4Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SavReg4Label.Name = "SavReg4Label";
            this.SavReg4Label.Size = new System.Drawing.Size(55, 13);
            this.SavReg4Label.TabIndex = 15;
            this.SavReg4Label.Text = "Register 4";
            // 
            // R4M4
            // 
            this.R4M4.BackColor = System.Drawing.Color.White;
            this.R4M4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R4M4.Location = new System.Drawing.Point(274, 119);
            this.R4M4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.R4M4.MaxLength = 8;
            this.R4M4.Name = "R4M4";
            this.R4M4.Size = new System.Drawing.Size(64, 20);
            this.R4M4.TabIndex = 19;
            this.R4M4.Text = "63BE80E4";
            this.R4M4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // R4M3
            // 
            this.R4M3.BackColor = System.Drawing.Color.White;
            this.R4M3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R4M3.Location = new System.Drawing.Point(206, 119);
            this.R4M3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.R4M3.MaxLength = 8;
            this.R4M3.Name = "R4M3";
            this.R4M3.Size = new System.Drawing.Size(64, 20);
            this.R4M3.TabIndex = 19;
            this.R4M3.Text = "63BE80E4";
            this.R4M3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // R5M4
            // 
            this.R5M4.BackColor = System.Drawing.Color.White;
            this.R5M4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R5M4.Location = new System.Drawing.Point(274, 142);
            this.R5M4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.R5M4.MaxLength = 8;
            this.R5M4.Name = "R5M4";
            this.R5M4.Size = new System.Drawing.Size(64, 20);
            this.R5M4.TabIndex = 20;
            this.R5M4.Text = "00400005";
            this.R5M4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // R4M2
            // 
            this.R4M2.BackColor = System.Drawing.Color.White;
            this.R4M2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R4M2.Location = new System.Drawing.Point(139, 119);
            this.R4M2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.R4M2.MaxLength = 8;
            this.R4M2.Name = "R4M2";
            this.R4M2.Size = new System.Drawing.Size(64, 20);
            this.R4M2.TabIndex = 19;
            this.R4M2.Text = "63BE80E4";
            this.R4M2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // R5M3
            // 
            this.R5M3.BackColor = System.Drawing.Color.White;
            this.R5M3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R5M3.Location = new System.Drawing.Point(206, 142);
            this.R5M3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.R5M3.MaxLength = 8;
            this.R5M3.Name = "R5M3";
            this.R5M3.Size = new System.Drawing.Size(64, 20);
            this.R5M3.TabIndex = 20;
            this.R5M3.Text = "00400005";
            this.R5M3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // R4M1
            // 
            this.R4M1.BackColor = System.Drawing.Color.White;
            this.R4M1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R4M1.Location = new System.Drawing.Point(71, 119);
            this.R4M1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.R4M1.MaxLength = 8;
            this.R4M1.Name = "R4M1";
            this.R4M1.Size = new System.Drawing.Size(64, 20);
            this.R4M1.TabIndex = 19;
            this.R4M1.Text = "63BE80E4";
            this.R4M1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // R5M2
            // 
            this.R5M2.BackColor = System.Drawing.Color.White;
            this.R5M2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R5M2.Location = new System.Drawing.Point(139, 142);
            this.R5M2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.R5M2.MaxLength = 8;
            this.R5M2.Name = "R5M2";
            this.R5M2.Size = new System.Drawing.Size(64, 20);
            this.R5M2.TabIndex = 20;
            this.R5M2.Text = "00400005";
            this.R5M2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SavReg5Label
            // 
            this.SavReg5Label.AutoSize = true;
            this.SavReg5Label.Location = new System.Drawing.Point(12, 145);
            this.SavReg5Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SavReg5Label.Name = "SavReg5Label";
            this.SavReg5Label.Size = new System.Drawing.Size(55, 13);
            this.SavReg5Label.TabIndex = 16;
            this.SavReg5Label.Text = "Register 5";
            // 
            // R5M1
            // 
            this.R5M1.BackColor = System.Drawing.Color.White;
            this.R5M1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.R5M1.Location = new System.Drawing.Point(71, 142);
            this.R5M1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.R5M1.MaxLength = 8;
            this.R5M1.Name = "R5M1";
            this.R5M1.Size = new System.Drawing.Size(64, 20);
            this.R5M1.TabIndex = 20;
            this.R5M1.Text = "00400005";
            this.R5M1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // RegistersGroupBox
            // 
            this.RegistersGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RegistersGroupBox.Location = new System.Drawing.Point(439, 9);
            this.RegistersGroupBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RegistersGroupBox.Name = "RegistersGroupBox";
            this.RegistersGroupBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RegistersGroupBox.Size = new System.Drawing.Size(352, 360);
            this.RegistersGroupBox.TabIndex = 13;
            this.RegistersGroupBox.TabStop = false;
            this.RegistersGroupBox.Text = "Registers Settings";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.RegistersTabControl);
            this.Controls.Add(this.RegistersGroupBox);
            this.Controls.Add(this.AvaibleCOMsComBox);
            this.Controls.Add(this.PloInitButton);
            this.Controls.Add(this.RefButton);
            this.Controls.Add(this.Out2Button);
            this.Controls.Add(this.Out1Button);
            this.Controls.Add(this.ClosePortButton);
            this.Controls.Add(this.OpenPortButton);
            this.Name = "Form1";
            this.Text = "Synthesizer Control Program by OK2FKU";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Click += new System.EventHandler(this.CheckAndApllyChangesForm1_Click);
            this.RegistersTabControl.ResumeLayout(false);
            this.RegistersPage.ResumeLayout(false);
            this.RegistersPage.PerformLayout();
            this.SavedRegistersPage.ResumeLayout(false);
            this.SavedRegistersPage.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OpenPortButton;
        private System.Windows.Forms.Button ClosePortButton;
        private System.Windows.Forms.Button Out1Button;
        private System.Windows.Forms.Button Out2Button;
        private System.Windows.Forms.Button PloInitButton;
        private System.Windows.Forms.TextBox Reg0TextBox;
        private System.Windows.Forms.Label Reg0Label;
        private System.Windows.Forms.Label Reg1Label;
        private System.Windows.Forms.TextBox Reg1TextBox;
        private System.Windows.Forms.Label Reg2Label;
        private System.Windows.Forms.TextBox Reg2TextBox;
        private System.Windows.Forms.Label Reg3Label;
        private System.Windows.Forms.TextBox Reg3TextBox;
        private System.Windows.Forms.Label Reg4Label;
        private System.Windows.Forms.TextBox Reg4TextBox;
        private System.Windows.Forms.Label Reg5Label;
        private System.Windows.Forms.TextBox Reg5TextBox;
        private System.Windows.Forms.Button RefButton;
        private System.Windows.Forms.Button SetAsDefaultRegButton;
        private System.Windows.Forms.Button ForceLoadRegButton;
        private System.Windows.Forms.Button LoadDefRegButton;
        private System.Windows.Forms.ComboBox AvaibleCOMsComBox;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox RF_A_EN_ComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox RF_A_PWR_ComboBox;
    }
}

