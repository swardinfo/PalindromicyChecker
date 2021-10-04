
namespace PalindromicyChecker
{
    partial class HelpForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpForm));
            this.Help = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Help
            // 
            this.Help.BackColor = System.Drawing.SystemColors.Window;
            this.Help.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Help.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Help.Location = new System.Drawing.Point(0, 0);
            this.Help.Multiline = true;
            this.Help.Name = "Help";
            this.Help.ReadOnly = true;
            this.Help.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Help.Size = new System.Drawing.Size(695, 657);
            this.Help.TabIndex = 0;
            this.Help.Text = resources.GetString("Help.Text");
            this.Help.UseSystemPasswordChar = true;
            // 
            // HelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 657);
            this.Controls.Add(this.Help);
            this.Name = "HelpForm";
            this.Text = "Help";
            this.Shown += new System.EventHandler(this.HelpForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Help;
    }
}