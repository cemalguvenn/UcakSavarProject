
namespace Savas
{
    partial class AnaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnaForm));
            this.bilgiPanel = new System.Windows.Forms.Panel();
            this.sureLabel = new System.Windows.Forms.Label();
            this.bilgiLabel = new System.Windows.Forms.Label();
            this.ucakSavarPanel = new System.Windows.Forms.Panel();
            this.savasAlani = new System.Windows.Forms.Panel();
            this.bilgiPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // bilgiPanel
            // 
            this.bilgiPanel.BackColor = System.Drawing.Color.SteelBlue;
            this.bilgiPanel.Controls.Add(this.sureLabel);
            this.bilgiPanel.Controls.Add(this.bilgiLabel);
            this.bilgiPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.bilgiPanel.Location = new System.Drawing.Point(0, 0);
            this.bilgiPanel.Name = "bilgiPanel";
            this.bilgiPanel.Size = new System.Drawing.Size(1004, 119);
            this.bilgiPanel.TabIndex = 0;
            // 
            // sureLabel
            // 
            this.sureLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sureLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sureLabel.ForeColor = System.Drawing.Color.White;
            this.sureLabel.Location = new System.Drawing.Point(776, 40);
            this.sureLabel.Name = "sureLabel";
            this.sureLabel.Size = new System.Drawing.Size(163, 55);
            this.sureLabel.TabIndex = 1;
            this.sureLabel.Text = "0:00";
            this.sureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bilgiLabel
            // 
            this.bilgiLabel.AutoSize = true;
            this.bilgiLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bilgiLabel.ForeColor = System.Drawing.Color.White;
            this.bilgiLabel.Location = new System.Drawing.Point(20, 17);
            this.bilgiLabel.Name = "bilgiLabel";
            this.bilgiLabel.Size = new System.Drawing.Size(617, 78);
            this.bilgiLabel.TabIndex = 0;
            this.bilgiLabel.Text = "Oyunu başlatmak için ENTER tuşuna basın.\r\nUçaksavarı hareket ettirmek için SAĞ/SO" +
    "L yön tuşlarına basın.\r\nAteş etmek için BOŞUL tuşuna basın.";
            // 
            // ucakSavarPanel
            // 
            this.ucakSavarPanel.BackColor = System.Drawing.Color.Teal;
            this.ucakSavarPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucakSavarPanel.Location = new System.Drawing.Point(0, 405);
            this.ucakSavarPanel.Name = "ucakSavarPanel";
            this.ucakSavarPanel.Size = new System.Drawing.Size(1004, 110);
            this.ucakSavarPanel.TabIndex = 1;
            // 
            // savasAlani
            // 
            this.savasAlani.BackColor = System.Drawing.Color.DarkSlateGray;
            this.savasAlani.Dock = System.Windows.Forms.DockStyle.Fill;
            this.savasAlani.Location = new System.Drawing.Point(0, 119);
            this.savasAlani.Name = "savasAlani";
            this.savasAlani.Size = new System.Drawing.Size(1004, 286);
            this.savasAlani.TabIndex = 2;
            // 
            // AnaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 515);
            this.Controls.Add(this.savasAlani);
            this.Controls.Add(this.ucakSavarPanel);
            this.Controls.Add(this.bilgiPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AnaForm";
            this.Text = "Savaş Oyunu";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AnaForm_KeyDown);
            this.bilgiPanel.ResumeLayout(false);
            this.bilgiPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel bilgiPanel;
        private System.Windows.Forms.Label sureLabel;
        private System.Windows.Forms.Label bilgiLabel;
        private System.Windows.Forms.Panel ucakSavarPanel;
        private System.Windows.Forms.Panel savasAlani;
    }
}

