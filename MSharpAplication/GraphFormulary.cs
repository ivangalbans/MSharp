using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MSharpAplication
{
    public partial class FormFunction : Form
    {

        private static Color GiveColor()
        {
            Color[] color = { Color.Red, Color.Blue, Color.Yellow, Color.Green, Color.Black, Color.White };

            //Para seleccionar color aleatorio
            Random rnd = new Random(Environment.TickCount);

            return color[rnd.Next(0, color.Length)];
        }

        public void GraphFunction(Func<float, float> function)
        {
            functionsViewer1.Functions.Add(new XControls.FunctionInfo()
            {
                //Name = "Ivan",
                Function = function,
                Color = GiveColor()
            });
        }

        public FormFunction()
        {
            InitializeComponent();
            //Aux();
        }


        private void Aux()
        {
             functionsViewer1.Functions.Add(new XControls.FunctionInfo()
            {
                Name = "f",
                Function = x => (float)(Math.Sin(x) * x* x+ Math.Tan(x))
            });

            functionsViewer1.Functions.Add(new XControls.FunctionInfo()
            {
                Name = "f",
                Function = x => (float)(Math.Sin(x) * x),
                Color = Color.Cyan
            });

            functionsViewer1.Functions.Add(new XControls.FunctionInfo()
            {
                Name = "f",
                Function = x => (float) x+1,
                Color = Color.Cyan
            });
            
            
            functionsViewer1.Functions.Add(new XControls.FunctionInfo()
            {
                Name = "f",
                Function = x => (float)(x*x - 3),
                Color = Color.Gray
            }); 

            functionsViewer1.Functions.Add(new XControls.FunctionInfo()
            {
                Name = "f",
                Function = x => (float)(Math.Tan(x))
            });

            functionsViewer1.Functions.Add(new XControls.FunctionInfo()
            {
                Name = "g",
                Color = Color.DarkBlue,
                Function = new Func<float, float>(XAlCubo)
            });
        }


        float XAlCubo(float x)
        {
            return x*x*x;
        }

    }
}
