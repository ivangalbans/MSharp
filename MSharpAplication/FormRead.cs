using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MSharp;

namespace MSharpAplication
{
    public partial class FormRead : Form
    {
        Compiler _compiler;

        public FormRead()
        {
            InitializeComponent();
        }

        public FormRead(Compiler compiler)
        {
            InitializeComponent();

            _compiler = compiler;
        }


        private void textBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                try
                {
                    Read._number = float.Parse(textBox1.Text);
                    Memory.ChangeVariable(Read._name, Read._number);
                }
                catch (FormatException)
                {

                    throw new Exception("El numero fue introducido incorrectamente");
                }
                finally
                {
                    _compiler._isRead = false;
                    Compiler._isOKRead = false;

                    //_compiler.Begin();

                    textBox1.Text = "";
                    this.Close();
                }

                
            }

        }

        public void Activar()
        {
            this.ShowDialog();
        }

        private void FormRead_Load(object sender, EventArgs e)
        {
        
        }
    }
}
