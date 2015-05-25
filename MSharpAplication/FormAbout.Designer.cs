namespace MSharpAplication
{
    partial class FormAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbout));
            this.pbxFotoIvan = new System.Windows.Forms.PictureBox();
            this.lblInformationPersonal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFotoIvan)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxFotoIvan
            // 
            this.pbxFotoIvan.ErrorImage = null;
            this.pbxFotoIvan.Image = ((System.Drawing.Image)(resources.GetObject("pbxFotoIvan.Image")));
            this.pbxFotoIvan.InitialImage = null;
            this.pbxFotoIvan.Location = new System.Drawing.Point(23, 12);
            this.pbxFotoIvan.Name = "pbxFotoIvan";
            this.pbxFotoIvan.Size = new System.Drawing.Size(253, 294);
            this.pbxFotoIvan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxFotoIvan.TabIndex = 1;
            this.pbxFotoIvan.TabStop = false;
            // 
            // lblInformationPersonal
            // 
            this.lblInformationPersonal.AutoSize = true;
            this.lblInformationPersonal.BackColor = System.Drawing.Color.Transparent;
            this.lblInformationPersonal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblInformationPersonal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInformationPersonal.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblInformationPersonal.Location = new System.Drawing.Point(305, 76);
            this.lblInformationPersonal.Name = "lblInformationPersonal";
            this.lblInformationPersonal.Size = new System.Drawing.Size(438, 102);
            this.lblInformationPersonal.TabIndex = 2;
            this.lblInformationPersonal.Text = "Iván Galbán Smith\r\nDireción correo: i.galban@lab.matcom.uh.cu\r\nFacultad de Matemá" +
    "tica y Computación\r\nUniversidad de La Habana, Cuba";
            // 
            // FormAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(766, 319);
            this.Controls.Add(this.lblInformationPersonal);
            this.Controls.Add(this.pbxFotoIvan);
            this.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About Developed";
            ((System.ComponentModel.ISupportInitialize)(this.pbxFotoIvan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxFotoIvan;
        private System.Windows.Forms.Label lblInformationPersonal;
    }
}