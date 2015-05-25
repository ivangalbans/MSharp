using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XControls;
using MSharp;
using Tokenizing;
using System.IO;

namespace MSharpAplication
{
    public partial class FormAplication : Form
    {
        
        public FormAplication()
        {
            InitializeComponent();
            Memory.InitializeTypes();
        }


        private void Ejecuta()
        {
            Compiler.Close();
            
            // Clear text boxes for errors and output
            rtbError.Text = "";
            rtbOutput.Text = "";
            
            // Create a tokenizer of type MSharpTokenizer
            Tokenizer tokenizer = new Tokenizer();


            MSharpErrors.Error -= Show_Error;
            MSharpErrors.Error += Show_Error;

            FormAplication frmAplication = new FormAplication();
            FormFunction frmFunction = new FormFunction();
            FormRead frmReadShow = new FormRead();

            
            Display display = new Display(rtbCode, rtbOutput, frmReadShow, frmFunction.functionsViewer1);
            Compiler compiler = new Compiler();
            FormRead frmRead = new FormRead(compiler);

            while(compiler.Begin())
            {
                if (compiler._isRead)
                    frmRead.ShowDialog();
            }

            if(Display.onActivateGraph)
                frmFunction.Show();

            MSharpErrors.Error += Show_Error;
            MSharpErrors.Error -= Show_Error;
        }

        private void startDebug_Click(object sender, EventArgs e)
        {
            Ejecuta();
        }
        void Show_Error(string errorMessage)
        {
            // Each error is appened to error textbox.
            rtbError.Text += string.Format("{0}\n", errorMessage);
        }

        void tokenizer_Error(string errorMessage, int line, int col)
        {
            // Each error is appened to error textbox.
            rtbError.Text += string.Format("{0} at {1}:{2} \n\r", errorMessage, line, col);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                rtbCode.SaveFile(saveFileDialog1.FileName);
            }
            
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                rtbCode.LoadFile(openFileDialog1.FileName);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout about = new FormAbout();
            about.ShowDialog();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }




    }
}
