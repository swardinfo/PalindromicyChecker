
namespace PalindromicyChecker
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Output = new System.Windows.Forms.TextBox();
            this.Process = new System.Windows.Forms.Button();
            this.MaxRadix = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PermutationsOnly = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.MaxN = new System.Windows.Forms.ComboBox();
            this.MinN = new System.Windows.Forms.ComboBox();
            this.MinRadix = new System.Windows.Forms.ComboBox();
            this.Cancel = new System.Windows.Forms.Button();
            this.Status = new System.Windows.Forms.Label();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.Help = new System.Windows.Forms.Button();
            this.About = new System.Windows.Forms.Button();
            this.CpuCores = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Output
            // 
            this.Output.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Output.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Output.Location = new System.Drawing.Point(13, 106);
            this.Output.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Output.Multiline = true;
            this.Output.Name = "Output";
            this.Output.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Output.Size = new System.Drawing.Size(978, 466);
            this.Output.TabIndex = 0;
            this.Output.WordWrap = false;
            // 
            // Process
            // 
            this.Process.Location = new System.Drawing.Point(583, 47);
            this.Process.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Process.Name = "Process";
            this.Process.Size = new System.Drawing.Size(85, 32);
            this.Process.TabIndex = 1;
            this.Process.Text = "Process";
            this.Process.UseVisualStyleBackColor = true;
            this.Process.Click += new System.EventHandler(this.Process_Click);
            // 
            // MaxRadix
            // 
            this.MaxRadix.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MaxRadix.FormattingEnabled = true;
            this.MaxRadix.Location = new System.Drawing.Point(89, 48);
            this.MaxRadix.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaxRadix.Name = "MaxRadix";
            this.MaxRadix.Size = new System.Drawing.Size(65, 28);
            this.MaxRadix.TabIndex = 2;
            this.MaxRadix.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Min b";
            // 
            // PermutationsOnly
            // 
            this.PermutationsOnly.AutoSize = true;
            this.PermutationsOnly.Location = new System.Drawing.Point(426, 51);
            this.PermutationsOnly.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.PermutationsOnly.Name = "PermutationsOnly";
            this.PermutationsOnly.Size = new System.Drawing.Size(146, 24);
            this.PermutationsOnly.TabIndex = 4;
            this.PermutationsOnly.Text = "Permutations only";
            this.PermutationsOnly.UseVisualStyleBackColor = true;
            this.PermutationsOnly.CheckedChanged += new System.EventHandler(this.PermutationsOnly_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(186, 26);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Min n";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(99, 26);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Max b";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(263, 26);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Max n";
            // 
            // MaxN
            // 
            this.MaxN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MaxN.FormattingEnabled = true;
            this.MaxN.Location = new System.Drawing.Point(251, 48);
            this.MaxN.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaxN.Name = "MaxN";
            this.MaxN.Size = new System.Drawing.Size(65, 28);
            this.MaxN.TabIndex = 9;
            this.MaxN.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectedIndexChanged);
            // 
            // MinN
            // 
            this.MinN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MinN.FormattingEnabled = true;
            this.MinN.Location = new System.Drawing.Point(173, 48);
            this.MinN.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MinN.Name = "MinN";
            this.MinN.Size = new System.Drawing.Size(65, 28);
            this.MinN.TabIndex = 10;
            this.MinN.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectedIndexChanged);
            // 
            // MinRadix
            // 
            this.MinRadix.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MinRadix.FormattingEnabled = true;
            this.MinRadix.Location = new System.Drawing.Point(13, 48);
            this.MinRadix.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MinRadix.Name = "MinRadix";
            this.MinRadix.Size = new System.Drawing.Size(65, 28);
            this.MinRadix.TabIndex = 11;
            this.MinRadix.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectedIndexChanged);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(689, 47);
            this.Cancel.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(85, 32);
            this.Cancel.TabIndex = 12;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // Status
            // 
            this.Status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Status.AutoSize = true;
            this.Status.Location = new System.Drawing.Point(413, 597);
            this.Status.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(49, 20);
            this.Status.TabIndex = 15;
            this.Status.Text = "Status";
            // 
            // ProgressBar
            // 
            this.ProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ProgressBar.Location = new System.Drawing.Point(13, 593);
            this.ProgressBar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(375, 32);
            this.ProgressBar.TabIndex = 16;
            // 
            // Help
            // 
            this.Help.Location = new System.Drawing.Point(794, 47);
            this.Help.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Help.Name = "Help";
            this.Help.Size = new System.Drawing.Size(85, 32);
            this.Help.TabIndex = 17;
            this.Help.Text = "Help";
            this.Help.UseVisualStyleBackColor = true;
            this.Help.Click += new System.EventHandler(this.Help_Click);
            // 
            // About
            // 
            this.About.Location = new System.Drawing.Point(902, 47);
            this.About.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.About.Name = "About";
            this.About.Size = new System.Drawing.Size(85, 32);
            this.About.TabIndex = 18;
            this.About.Text = "About";
            this.About.UseVisualStyleBackColor = true;
            this.About.Click += new System.EventHandler(this.About_Click);
            // 
            // CpuCores
            // 
            this.CpuCores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CpuCores.FormattingEnabled = true;
            this.CpuCores.Location = new System.Drawing.Point(341, 48);
            this.CpuCores.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.CpuCores.Name = "CpuCores";
            this.CpuCores.Size = new System.Drawing.Size(65, 28);
            this.CpuCores.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(336, 22);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 20);
            this.label5.TabIndex = 20;
            this.label5.Text = "CPU Cores";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(1004, 641);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CpuCores);
            this.Controls.Add(this.About);
            this.Controls.Add(this.Help);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.MinRadix);
            this.Controls.Add(this.MinN);
            this.Controls.Add(this.MaxN);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PermutationsOnly);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MaxRadix);
            this.Controls.Add(this.Process);
            this.Controls.Add(this.Output);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MinimumSize = new System.Drawing.Size(1020, 680);
            this.Name = "MainForm";
            this.Text = "Palindromicy Checker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Output;
        private System.Windows.Forms.Button Process;
        private System.Windows.Forms.ComboBox MaxRadix;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox PermutationsOnly;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox MaxN;
        private System.Windows.Forms.ComboBox MinN;
        private System.Windows.Forms.ComboBox MinRadix;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Label CPUWarning;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Button Help;
        private System.Windows.Forms.Button About;
        private System.Windows.Forms.ComboBox CpuCores;
        private System.Windows.Forms.Label label5;
    }
}

