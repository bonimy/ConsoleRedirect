namespace SampleApp
{
    partial class Form1
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
            this.tbxPath = new System.Windows.Forms.TextBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.btnPath = new System.Windows.Forms.Button();
            this.lblArgs = new System.Windows.Forms.Label();
            this.tbxArgs = new System.Windows.Forms.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.conApp = new ConsoleRedirect.ConsoleOutputRichTextBox();
            this.SuspendLayout();
            // 
            // tbxPath
            // 
            this.tbxPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxPath.Location = new System.Drawing.Point(12, 25);
            this.tbxPath.Name = "tbxPath";
            this.tbxPath.Size = new System.Drawing.Size(764, 20);
            this.tbxPath.TabIndex = 1;
            this.tbxPath.TextChanged += new System.EventHandler(this.tbxPath_TextChanged);
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(12, 9);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(87, 13);
            this.lblPath.TabIndex = 0;
            this.lblPath.Text = "Application Path:";
            // 
            // btnPath
            // 
            this.btnPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPath.AutoSize = true;
            this.btnPath.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPath.Location = new System.Drawing.Point(782, 23);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(26, 23);
            this.btnPath.TabIndex = 1;
            this.btnPath.Text = "...";
            this.btnPath.UseVisualStyleBackColor = true;
            this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
            // 
            // lblArgs
            // 
            this.lblArgs.AutoSize = true;
            this.lblArgs.Location = new System.Drawing.Point(12, 52);
            this.lblArgs.Name = "lblArgs";
            this.lblArgs.Size = new System.Drawing.Size(60, 13);
            this.lblArgs.TabIndex = 0;
            this.lblArgs.Text = "Arguments:";
            // 
            // tbxArgs
            // 
            this.tbxArgs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxArgs.Location = new System.Drawing.Point(12, 68);
            this.tbxArgs.Name = "tbxArgs";
            this.tbxArgs.Size = new System.Drawing.Size(796, 20);
            this.tbxArgs.TabIndex = 2;
            // 
            // btnRun
            // 
            this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRun.AutoSize = true;
            this.btnRun.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRun.Location = new System.Drawing.Point(762, 94);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(46, 23);
            this.btnRun.TabIndex = 3;
            this.btnRun.Text = "Run...";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // conApp
            // 
            this.conApp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.conApp.BackColor = System.ConsoleColor.DarkYellow;
            this.conApp.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conApp.ForeColor = System.ConsoleColor.White;
            this.conApp.Location = new System.Drawing.Point(12, 123);
            this.conApp.Name = "conApp";
            this.conApp.ReadOnly = true;
            this.conApp.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.conApp.Size = new System.Drawing.Size(796, 440);
            this.conApp.TabIndex = 0;
            this.conApp.Text = "Sample Text";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 575);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.tbxArgs);
            this.Controls.Add(this.lblArgs);
            this.Controls.Add(this.btnPath);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.tbxPath);
            this.Controls.Add(this.conApp);
            this.Name = "Form1";
            this.Text = "Process Runner";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ConsoleRedirect.ConsoleOutputRichTextBox conApp;
        private System.Windows.Forms.TextBox tbxPath;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Button btnPath;
        private System.Windows.Forms.Label lblArgs;
        private System.Windows.Forms.TextBox tbxArgs;
        private System.Windows.Forms.Button btnRun;
    }
}

