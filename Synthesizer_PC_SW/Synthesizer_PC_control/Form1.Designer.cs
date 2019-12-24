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
            this.SuspendLayout();
            // 
            // OpenPortButton
            // 
            this.OpenPortButton.Location = new System.Drawing.Point(16, 11);
            this.OpenPortButton.Margin = new System.Windows.Forms.Padding(4);
            this.OpenPortButton.Name = "OpenPortButton";
            this.OpenPortButton.Size = new System.Drawing.Size(100, 28);
            this.OpenPortButton.TabIndex = 0;
            this.OpenPortButton.Text = "Open Port";
            this.OpenPortButton.UseVisualStyleBackColor = true;
            this.OpenPortButton.Click += new System.EventHandler(this.OpenPortButton_Click);
            // 
            // ClosePortButton
            // 
            this.ClosePortButton.Enabled = false;
            this.ClosePortButton.Location = new System.Drawing.Point(16, 47);
            this.ClosePortButton.Margin = new System.Windows.Forms.Padding(4);
            this.ClosePortButton.Name = "ClosePortButton";
            this.ClosePortButton.Size = new System.Drawing.Size(100, 28);
            this.ClosePortButton.TabIndex = 0;
            this.ClosePortButton.Text = "Close Port";
            this.ClosePortButton.UseVisualStyleBackColor = true;
            this.ClosePortButton.Click += new System.EventHandler(this.ClosePortButton_Click);
            // 
            // Out1Button
            // 
            this.Out1Button.Enabled = false;
            this.Out1Button.Location = new System.Drawing.Point(12, 127);
            this.Out1Button.Name = "Out1Button";
            this.Out1Button.Size = new System.Drawing.Size(100, 28);
            this.Out1Button.TabIndex = 1;
            this.Out1Button.Text = "Out 1 Off";
            this.Out1Button.UseVisualStyleBackColor = true;
            this.Out1Button.Click += new System.EventHandler(this.Out1Button_Click);
            // 
            // Out2Button
            // 
            this.Out2Button.Enabled = false;
            this.Out2Button.Location = new System.Drawing.Point(12, 161);
            this.Out2Button.Name = "Out2Button";
            this.Out2Button.Size = new System.Drawing.Size(100, 28);
            this.Out2Button.TabIndex = 1;
            this.Out2Button.Text = "Out 2 Off";
            this.Out2Button.UseVisualStyleBackColor = true;
            this.Out2Button.Click += new System.EventHandler(this.Out2Button_Click);
            // 
            // PloInitButton
            // 
            this.PloInitButton.Enabled = false;
            this.PloInitButton.Location = new System.Drawing.Point(158, 127);
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
            this.Reg0TextBox.Enabled = false;
            this.Reg0TextBox.Location = new System.Drawing.Point(732, 14);
            this.Reg0TextBox.MaxLength = 8;
            this.Reg0TextBox.Name = "Reg0TextBox";
            this.Reg0TextBox.Size = new System.Drawing.Size(100, 22);
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
            this.Reg0Label.Location = new System.Drawing.Point(653, 17);
            this.Reg0Label.Name = "Reg0Label";
            this.Reg0Label.Size = new System.Drawing.Size(73, 17);
            this.Reg0Label.TabIndex = 4;
            this.Reg0Label.Text = "Register 0";
            // 
            // Reg1Label
            // 
            this.Reg1Label.AutoSize = true;
            this.Reg1Label.Location = new System.Drawing.Point(653, 45);
            this.Reg1Label.Name = "Reg1Label";
            this.Reg1Label.Size = new System.Drawing.Size(73, 17);
            this.Reg1Label.TabIndex = 5;
            this.Reg1Label.Text = "Register 1";
            // 
            // Reg1TextBox
            // 
            this.Reg1TextBox.BackColor = System.Drawing.Color.White;
            this.Reg1TextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Reg1TextBox.Enabled = false;
            this.Reg1TextBox.Location = new System.Drawing.Point(732, 42);
            this.Reg1TextBox.MaxLength = 8;
            this.Reg1TextBox.Name = "Reg1TextBox";
            this.Reg1TextBox.Size = new System.Drawing.Size(100, 22);
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
            this.Reg2Label.Location = new System.Drawing.Point(653, 73);
            this.Reg2Label.Name = "Reg2Label";
            this.Reg2Label.Size = new System.Drawing.Size(73, 17);
            this.Reg2Label.TabIndex = 7;
            this.Reg2Label.Text = "Register 2";
            // 
            // Reg2TextBox
            // 
            this.Reg2TextBox.BackColor = System.Drawing.Color.White;
            this.Reg2TextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Reg2TextBox.Enabled = false;
            this.Reg2TextBox.Location = new System.Drawing.Point(732, 70);
            this.Reg2TextBox.MaxLength = 8;
            this.Reg2TextBox.Name = "Reg2TextBox";
            this.Reg2TextBox.Size = new System.Drawing.Size(100, 22);
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
            this.Reg3Label.Location = new System.Drawing.Point(653, 101);
            this.Reg3Label.Name = "Reg3Label";
            this.Reg3Label.Size = new System.Drawing.Size(73, 17);
            this.Reg3Label.TabIndex = 7;
            this.Reg3Label.Text = "Register 3";
            // 
            // Reg3TextBox
            // 
            this.Reg3TextBox.BackColor = System.Drawing.Color.White;
            this.Reg3TextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Reg3TextBox.Enabled = false;
            this.Reg3TextBox.Location = new System.Drawing.Point(732, 98);
            this.Reg3TextBox.MaxLength = 8;
            this.Reg3TextBox.Name = "Reg3TextBox";
            this.Reg3TextBox.Size = new System.Drawing.Size(100, 22);
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
            this.Reg4Label.Location = new System.Drawing.Point(653, 127);
            this.Reg4Label.Name = "Reg4Label";
            this.Reg4Label.Size = new System.Drawing.Size(73, 17);
            this.Reg4Label.TabIndex = 7;
            this.Reg4Label.Text = "Register 4";
            // 
            // Reg4TextBox
            // 
            this.Reg4TextBox.BackColor = System.Drawing.Color.White;
            this.Reg4TextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Reg4TextBox.Enabled = false;
            this.Reg4TextBox.Location = new System.Drawing.Point(732, 124);
            this.Reg4TextBox.MaxLength = 8;
            this.Reg4TextBox.Name = "Reg4TextBox";
            this.Reg4TextBox.Size = new System.Drawing.Size(100, 22);
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
            this.Reg5Label.Location = new System.Drawing.Point(653, 155);
            this.Reg5Label.Name = "Reg5Label";
            this.Reg5Label.Size = new System.Drawing.Size(73, 17);
            this.Reg5Label.TabIndex = 7;
            this.Reg5Label.Text = "Register 5";
            // 
            // Reg5TextBox
            // 
            this.Reg5TextBox.BackColor = System.Drawing.Color.White;
            this.Reg5TextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Reg5TextBox.Enabled = false;
            this.Reg5TextBox.Location = new System.Drawing.Point(732, 152);
            this.Reg5TextBox.MaxLength = 8;
            this.Reg5TextBox.Name = "Reg5TextBox";
            this.Reg5TextBox.Size = new System.Drawing.Size(100, 22);
            this.Reg5TextBox.TabIndex = 8;
            this.Reg5TextBox.Text = "00400005";
            this.Reg5TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Reg5TextBox.Click += new System.EventHandler(this.Reg5TextBox_Click);
            this.Reg5TextBox.TextChanged += new System.EventHandler(this.Reg5TextBox_TextChanged);
            this.Reg5TextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Reg5TextBox_KeyDown);
            // 
            // RefButton
            // 
            this.RefButton.Enabled = false;
            this.RefButton.Location = new System.Drawing.Point(12, 195);
            this.RefButton.Name = "RefButton";
            this.RefButton.Size = new System.Drawing.Size(100, 28);
            this.RefButton.TabIndex = 1;
            this.RefButton.Text = "Ext Ref";
            this.RefButton.UseVisualStyleBackColor = true;
            this.RefButton.Click += new System.EventHandler(this.RefButton_Click);
            // 
            // SetAsDefaultRegButton
            // 
            this.SetAsDefaultRegButton.Enabled = false;
            this.SetAsDefaultRegButton.Location = new System.Drawing.Point(627, 187);
            this.SetAsDefaultRegButton.Name = "SetAsDefaultRegButton";
            this.SetAsDefaultRegButton.Size = new System.Drawing.Size(99, 23);
            this.SetAsDefaultRegButton.TabIndex = 9;
            this.SetAsDefaultRegButton.Text = "Set As Def";
            this.SetAsDefaultRegButton.UseVisualStyleBackColor = true;
            this.SetAsDefaultRegButton.Click += new System.EventHandler(this.SetAsDefaultRegButton_Click);
            // 
            // ForceLoadRegButton
            // 
            this.ForceLoadRegButton.Enabled = false;
            this.ForceLoadRegButton.Location = new System.Drawing.Point(733, 187);
            this.ForceLoadRegButton.Name = "ForceLoadRegButton";
            this.ForceLoadRegButton.Size = new System.Drawing.Size(99, 23);
            this.ForceLoadRegButton.TabIndex = 9;
            this.ForceLoadRegButton.Text = "Force Load ";
            this.ForceLoadRegButton.UseVisualStyleBackColor = true;
            this.ForceLoadRegButton.Click += new System.EventHandler(this.ForceLoadRegButton_Click);
            // 
            // LoadDefRegButton
            // 
            this.LoadDefRegButton.Enabled = false;
            this.LoadDefRegButton.Location = new System.Drawing.Point(627, 216);
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
            this.AvaibleCOMsComBox.Name = "AvaibleCOMsComBox";
            this.AvaibleCOMsComBox.Size = new System.Drawing.Size(87, 24);
            this.AvaibleCOMsComBox.TabIndex = 10;
            this.AvaibleCOMsComBox.DropDown += new System.EventHandler(this.AvaibleCOMsComBox_DropDown);
            // 
            // WriteR0Button
            // 
            this.WriteR0Button.Enabled = false;
            this.WriteR0Button.Location = new System.Drawing.Point(838, 14);
            this.WriteR0Button.Name = "WriteR0Button";
            this.WriteR0Button.Size = new System.Drawing.Size(84, 23);
            this.WriteR0Button.TabIndex = 11;
            this.WriteR0Button.Text = "Write R0";
            this.WriteR0Button.UseVisualStyleBackColor = true;
            this.WriteR0Button.Click += new System.EventHandler(this.WriteR0Button_Click);
            // 
            // WriteR1Button
            // 
            this.WriteR1Button.Enabled = false;
            this.WriteR1Button.Location = new System.Drawing.Point(838, 42);
            this.WriteR1Button.Name = "WriteR1Button";
            this.WriteR1Button.Size = new System.Drawing.Size(84, 23);
            this.WriteR1Button.TabIndex = 11;
            this.WriteR1Button.Text = "Write R1";
            this.WriteR1Button.UseVisualStyleBackColor = true;
            this.WriteR1Button.Click += new System.EventHandler(this.WriteR1Button_Click);
            // 
            // WriteR2Button
            // 
            this.WriteR2Button.Enabled = false;
            this.WriteR2Button.Location = new System.Drawing.Point(838, 70);
            this.WriteR2Button.Name = "WriteR2Button";
            this.WriteR2Button.Size = new System.Drawing.Size(84, 23);
            this.WriteR2Button.TabIndex = 11;
            this.WriteR2Button.Text = "Write R2";
            this.WriteR2Button.UseVisualStyleBackColor = true;
            this.WriteR2Button.Click += new System.EventHandler(this.WriteR2Button_Click);
            // 
            // WriteR3Button
            // 
            this.WriteR3Button.Enabled = false;
            this.WriteR3Button.Location = new System.Drawing.Point(838, 98);
            this.WriteR3Button.Name = "WriteR3Button";
            this.WriteR3Button.Size = new System.Drawing.Size(84, 23);
            this.WriteR3Button.TabIndex = 11;
            this.WriteR3Button.Text = "Write R3";
            this.WriteR3Button.UseVisualStyleBackColor = true;
            this.WriteR3Button.Click += new System.EventHandler(this.WriteR3Button_Click);
            // 
            // WriteR4Button
            // 
            this.WriteR4Button.Enabled = false;
            this.WriteR4Button.Location = new System.Drawing.Point(838, 124);
            this.WriteR4Button.Name = "WriteR4Button";
            this.WriteR4Button.Size = new System.Drawing.Size(84, 23);
            this.WriteR4Button.TabIndex = 11;
            this.WriteR4Button.Text = "Write R4";
            this.WriteR4Button.UseVisualStyleBackColor = true;
            this.WriteR4Button.Click += new System.EventHandler(this.WriteR4Button_Click);
            // 
            // WriteR5Button
            // 
            this.WriteR5Button.Enabled = false;
            this.WriteR5Button.Location = new System.Drawing.Point(838, 152);
            this.WriteR5Button.Name = "WriteR5Button";
            this.WriteR5Button.Size = new System.Drawing.Size(84, 23);
            this.WriteR5Button.TabIndex = 11;
            this.WriteR5Button.Text = "Write R5";
            this.WriteR5Button.UseVisualStyleBackColor = true;
            this.WriteR5Button.Click += new System.EventHandler(this.WriteR5Button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.WriteR5Button);
            this.Controls.Add(this.WriteR4Button);
            this.Controls.Add(this.WriteR3Button);
            this.Controls.Add(this.WriteR1Button);
            this.Controls.Add(this.WriteR2Button);
            this.Controls.Add(this.WriteR0Button);
            this.Controls.Add(this.AvaibleCOMsComBox);
            this.Controls.Add(this.ForceLoadRegButton);
            this.Controls.Add(this.LoadDefRegButton);
            this.Controls.Add(this.SetAsDefaultRegButton);
            this.Controls.Add(this.Reg5TextBox);
            this.Controls.Add(this.Reg5Label);
            this.Controls.Add(this.Reg4TextBox);
            this.Controls.Add(this.Reg4Label);
            this.Controls.Add(this.Reg3TextBox);
            this.Controls.Add(this.Reg3Label);
            this.Controls.Add(this.Reg2TextBox);
            this.Controls.Add(this.Reg2Label);
            this.Controls.Add(this.Reg1TextBox);
            this.Controls.Add(this.Reg1Label);
            this.Controls.Add(this.Reg0Label);
            this.Controls.Add(this.Reg0TextBox);
            this.Controls.Add(this.PloInitButton);
            this.Controls.Add(this.RefButton);
            this.Controls.Add(this.Out2Button);
            this.Controls.Add(this.Out1Button);
            this.Controls.Add(this.ClosePortButton);
            this.Controls.Add(this.OpenPortButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Synthesizer Control Program by OK2FKU";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Click += new System.EventHandler(this.CheckAndApllyChangesForm1_Click);
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
    }
}

