namespace MSharpAplication
{
    partial class FormFunction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFunction));
            this.functionsViewer1 = new XControls.FunctionsViewer();
            this.SuspendLayout();
            // 
            // functionsViewer1
            // 
            this.functionsViewer1.BackColor = System.Drawing.Color.SteelBlue;
            this.functionsViewer1.Center = ((System.Drawing.PointF)(resources.GetObject("functionsViewer1.Center")));
            this.functionsViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.functionsViewer1.Location = new System.Drawing.Point(0, 0);
            this.functionsViewer1.Name = "functionsViewer1";
            this.functionsViewer1.Scale = 3F;
            this.functionsViewer1.Size = new System.Drawing.Size(583, 595);
            this.functionsViewer1.TabIndex = 0;
            // 
            // FormFunction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 595);
            this.Controls.Add(this.functionsViewer1);
            this.Name = "FormFunction";
            this.Text = "Function";
            this.ResumeLayout(false);

        }

        #endregion

        public global::XControls.FunctionsViewer functionsViewer1;




    }
}

