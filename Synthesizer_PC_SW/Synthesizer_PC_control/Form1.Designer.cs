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
            this.out1Button = new System.Windows.Forms.Button();
            this.out2Button = new System.Windows.Forms.Button();
            this.ploInitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // OpenPortButton
            // 
            this.OpenPortButton.Location = new System.Drawing.Point(16, 15);
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
            this.ClosePortButton.Location = new System.Drawing.Point(167, 15);
            this.ClosePortButton.Margin = new System.Windows.Forms.Padding(4);
            this.ClosePortButton.Name = "ClosePortButton";
            this.ClosePortButton.Size = new System.Drawing.Size(100, 28);
            this.ClosePortButton.TabIndex = 0;
            this.ClosePortButton.Text = "Close Port";
            this.ClosePortButton.UseVisualStyleBackColor = true;
            this.ClosePortButton.Click += new System.EventHandler(this.ClosePortButton_Click);
            // 
            // out1Button
            // 
            this.out1Button.Location = new System.Drawing.Point(16, 61);
            this.out1Button.Name = "out1Button";
            this.out1Button.Size = new System.Drawing.Size(100, 28);
            this.out1Button.TabIndex = 1;
            this.out1Button.Text = "Out 1 Off";
            this.out1Button.UseVisualStyleBackColor = true;
            this.out1Button.Click += new System.EventHandler(this.out1Button_Click);
            // 
            // out2Button
            // 
            this.out2Button.Location = new System.Drawing.Point(167, 61);
            this.out2Button.Name = "out2Button";
            this.out2Button.Size = new System.Drawing.Size(100, 28);
            this.out2Button.TabIndex = 1;
            this.out2Button.Text = "Out 2 Off";
            this.out2Button.UseVisualStyleBackColor = true;
            this.out2Button.Click += new System.EventHandler(this.out2Button_Click);
            // 
            // ploInitButton
            // 
            this.ploInitButton.Location = new System.Drawing.Point(16, 124);
            this.ploInitButton.Name = "ploInitButton";
            this.ploInitButton.Size = new System.Drawing.Size(100, 28);
            this.ploInitButton.TabIndex = 2;
            this.ploInitButton.Text = "PLO Initialize";
            this.ploInitButton.UseVisualStyleBackColor = true;
            this.ploInitButton.Click += new System.EventHandler(this.ploInitButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.ploInitButton);
            this.Controls.Add(this.out2Button);
            this.Controls.Add(this.out1Button);
            this.Controls.Add(this.ClosePortButton);
            this.Controls.Add(this.OpenPortButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Synthesizer Control Program by OK2FKU";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OpenPortButton;
        private System.Windows.Forms.Button ClosePortButton;
        private System.Windows.Forms.Button out1Button;
        private System.Windows.Forms.Button out2Button;
        private System.Windows.Forms.Button ploInitButton;
    }
}

