namespace MSharpAplication
{
    partial class FormAplication
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDebug = new System.Windows.Forms.ToolStripMenuItem();
            this.startDebug = new System.Windows.Forms.ToolStripMenuItem();
            this.stopDebug = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rtbCode = new System.Windows.Forms.RichTextBox();
            this.gpBoxCode = new System.Windows.Forms.GroupBox();
            this.gpBoxOutput = new System.Windows.Forms.GroupBox();
            this.rtbOutput = new System.Windows.Forms.RichTextBox();
            this.gpBoxError = new System.Windows.Forms.GroupBox();
            this.rtbError = new System.Windows.Forms.RichTextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.gpBoxCode.SuspendLayout();
            this.gpBoxOutput.SuspendLayout();
            this.gpBoxError.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DarkGray;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.menuDebug,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1184, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // menuDebug
            // 
            this.menuDebug.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startDebug,
            this.stopDebug});
            this.menuDebug.Name = "menuDebug";
            this.menuDebug.Size = new System.Drawing.Size(54, 20);
            this.menuDebug.Text = "Debug";
            // 
            // startDebug
            // 
            this.startDebug.Name = "startDebug";
            this.startDebug.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.startDebug.Size = new System.Drawing.Size(211, 22);
            this.startDebug.Text = "Start Debugging";
            this.startDebug.Click += new System.EventHandler(this.startDebug_Click);
            // 
            // stopDebug
            // 
            this.stopDebug.Name = "stopDebug";
            this.stopDebug.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F5)));
            this.stopDebug.Size = new System.Drawing.Size(211, 22);
            this.stopDebug.Text = "Stop Debugging";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewHelpToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // viewHelpToolStripMenuItem
            // 
            this.viewHelpToolStripMenuItem.Name = "viewHelpToolStripMenuItem";
            this.viewHelpToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.viewHelpToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.viewHelpToolStripMenuItem.Text = "View Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // rtbCode
            // 
            this.rtbCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbCode.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.rtbCode.ForeColor = System.Drawing.Color.White;
            this.rtbCode.Location = new System.Drawing.Point(0, 19);
            this.rtbCode.Name = "rtbCode";
            this.rtbCode.Size = new System.Drawing.Size(845, 358);
            this.rtbCode.TabIndex = 1;
            this.rtbCode.Text = "";
            // 
            // gpBoxCode
            // 
            this.gpBoxCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpBoxCode.Controls.Add(this.rtbCode);
            this.gpBoxCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpBoxCode.ForeColor = System.Drawing.Color.White;
            this.gpBoxCode.Location = new System.Drawing.Point(28, 39);
            this.gpBoxCode.Name = "gpBoxCode";
            this.gpBoxCode.Size = new System.Drawing.Size(851, 377);
            this.gpBoxCode.TabIndex = 2;
            this.gpBoxCode.TabStop = false;
            this.gpBoxCode.Text = "Code";
            // 
            // gpBoxOutput
            // 
            this.gpBoxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpBoxOutput.Controls.Add(this.rtbOutput);
            this.gpBoxOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpBoxOutput.ForeColor = System.Drawing.Color.White;
            this.gpBoxOutput.Location = new System.Drawing.Point(885, 39);
            this.gpBoxOutput.Name = "gpBoxOutput";
            this.gpBoxOutput.Size = new System.Drawing.Size(299, 377);
            this.gpBoxOutput.TabIndex = 4;
            this.gpBoxOutput.TabStop = false;
            this.gpBoxOutput.Text = "Output";
            // 
            // rtbOutput
            // 
            this.rtbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbOutput.Location = new System.Drawing.Point(6, 19);
            this.rtbOutput.Name = "rtbOutput";
            this.rtbOutput.Size = new System.Drawing.Size(287, 358);
            this.rtbOutput.TabIndex = 0;
            this.rtbOutput.Text = "";
            // 
            // gpBoxError
            // 
            this.gpBoxError.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpBoxError.Controls.Add(this.rtbError);
            this.gpBoxError.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpBoxError.ForeColor = System.Drawing.Color.White;
            this.gpBoxError.Location = new System.Drawing.Point(3, 422);
            this.gpBoxError.Name = "gpBoxError";
            this.gpBoxError.Size = new System.Drawing.Size(1181, 136);
            this.gpBoxError.TabIndex = 5;
            this.gpBoxError.TabStop = false;
            this.gpBoxError.Text = "Error";
            // 
            // rtbError
            // 
            this.rtbError.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbError.Location = new System.Drawing.Point(0, 18);
            this.rtbError.Name = "rtbError";
            this.rtbError.Size = new System.Drawing.Size(1175, 109);
            this.rtbError.TabIndex = 0;
            this.rtbError.Text = "";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "M# files |*.mat";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "M# files | *.mat";
            // 
            // FormAplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.gpBoxError);
            this.Controls.Add(this.gpBoxOutput);
            this.Controls.Add(this.gpBoxCode);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormAplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MSharp";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gpBoxCode.ResumeLayout(false);
            this.gpBoxOutput.ResumeLayout(false);
            this.gpBoxError.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.RichTextBox rtbCode;
        private System.Windows.Forms.GroupBox gpBoxCode;
        private System.Windows.Forms.GroupBox gpBoxOutput;
        private System.Windows.Forms.GroupBox gpBoxError;
        private System.Windows.Forms.RichTextBox rtbError;
        private System.Windows.Forms.RichTextBox rtbOutput;
        private System.Windows.Forms.ToolStripMenuItem menuDebug;
        private System.Windows.Forms.ToolStripMenuItem startDebug;
        private System.Windows.Forms.ToolStripMenuItem stopDebug;
        private System.Windows.Forms.ToolStripMenuItem viewHelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

