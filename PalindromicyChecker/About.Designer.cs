
namespace PalindromicyChecker
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.About = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // About
            // 
            this.About.BackColor = System.Drawing.SystemColors.Window;
            this.About.Dock = System.Windows.Forms.DockStyle.Fill;
            this.About.Location = new System.Drawing.Point(0, 0);
            this.About.Multiline = true;
            this.About.Name = "About";
            this.About.ReadOnly = true;
            this.About.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.About.Size = new System.Drawing.Size(401, 363);
            this.About.TabIndex = 0;
            this.About.Text = resources.GetString("About.Text");
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 363);
            this.Controls.Add(this.About);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(417, 402);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(417, 402);
            this.Name = "AboutForm";
            this.Text = "About Palindromicy Checker";
            this.Shown += new System.EventHandler(this.AboutForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox About;
    }
}