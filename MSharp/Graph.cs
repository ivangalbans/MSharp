using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XControls;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace MSharp
{
    /// <summary>
    /// Comando que grafica funciones;
    /// </summary>
    public class Graph : Statement, IExecutable
    {

        public Graph() { }

        /// <summary>
        /// Representa un analisis sintactico de la expresion
        /// </summary>
        /// <returns>True si la expresion esta bien escrita, false en caso contrario.</returns>
        private bool SyntacticAnalysis(List<Expression> instruction)
        {
            if (instruction.Count == 0)
            {
                MSharpErrors.OnError("Se esperaba una funcion a graficar");
                return false;
            }
                
            //Identificar Literales
            for (int i = 0; i < instruction.Count; i++)
                if (instruction[i] is Literal && !Memory.ExistName(instruction[i].ToString()))
                    instruction[i] = new Identity();

            return true;
        }

        public void Execute(List<Expression> instruction)
        {

            //Eliminar keyword de tipo IExecutable. No lo necesito para compilar.
            instruction.RemoveAt(0);

            if(SyntacticAnalysis(instruction))
            {
                ConditionalFunction functionGraph = ConvertToConditionalFunction.FetchFunction(instruction);

                if(functionGraph != null)
                {
                    
                    Random rn = new Random((Environment.TickCount + instruction.GetHashCode()) % int.MaxValue);

                    float pp = functionGraph.Evaluate(5);


                    Display._fViewer.Functions.Add(new XControls.FunctionInfo()
                    {
                        Name = "f" + Environment.TickCount.ToString(),
                        Function = x => functionGraph.Evaluate(x),
                        Color = Color.FromArgb(rn.Next(255), rn.Next(255), rn.Next(255))
                    });

                    Display.onActivateGraph = true;
                }

                
            }
         
        }


        public override string ToText
        {
            get { return "graph"; }
        }
    }
}
