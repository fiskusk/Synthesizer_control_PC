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
            this.ClosePortButton.Enabled = false;
            this.ClosePortButton.UseVisualStyleBackColor = true;
            this.ClosePortButton.Click += new System.EventHandler(this.ClosePortButton_Click);
            // 
            // Out1Button
            // 
            this.Out1Button.Location = new System.Drawing.Point(16, 61);
            this.Out1Button.Name = "Out1Button";
            this.Out1Button.Size = new System.Drawing.Size(100, 28);
            this.Out1Button.TabIndex = 1;
            this.Out1Button.Text = "Out 1 Off";
            this.Out1Button.Enabled = false;
            this.Out1Button.UseVisualStyleBackColor = true;
            this.Out1Button.Click += new System.EventHandler(this.Out1Button_Click);
            // 
            // Out2Button
            // 
            this.Out2Button.Location = new System.Drawing.Point(167, 61);
            this.Out2Button.Name = "Out2Button";
            this.Out2Button.Size = new System.Drawing.Size(100, 28);
            this.Out2Button.TabIndex = 1;
            this.Out2Button.Text = "Out 2 Off";
            this.Out2Button.Enabled = false;
            this.Out2Button.UseVisualStyleBackColor = true;
            this.Out2Button.Click += new System.EventHandler(this.Out2Button_Click);
            // 
            // PloInitButton
            // 
            this.PloInitButton.Location = new System.Drawing.Point(16, 124);
            this.PloInitButton.Name = "PloInitButton";
            this.PloInitButton.Size = new System.Drawing.Size(100, 28);
            this.PloInitButton.TabIndex = 2;
            this.PloInitButton.Text = "PLO Init";
            this.PloInitButton.Enabled = false;
            this.PloInitButton.UseVisualStyleBackColor = true;
            this.PloInitButton.Click += new System.EventHandler(this.PloInitButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.PloInitButton);
            this.Controls.Add(this.Out2Button);
            this.Controls.Add(this.Out1Button);
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
        private System.Windows.Forms.Button Out1Button;
        private System.Windows.Forms.Button Out2Button;
        private System.Windows.Forms.Button PloInitButton;
    }
}

