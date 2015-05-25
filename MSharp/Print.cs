using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MSharp
{
    public class Print : Statement, IExecutable
    {

        public Print() { }


        /// <summary>
        /// Representa un analisis sintactico de la expresion
        /// </summary>
        /// <returns>True si la expresion esta bien escrita, false en caso contrario.</returns>
        private bool SyntacticAnalysis(List<Expression> instruction)
        {
            if (instruction.Count == 0)
            {
                MSharpErrors.OnError("Comando print tiene que tener alguna instruccion a mostrar");
                return false;
            }

            RecognizeText(instruction);

            return true;
        }

        private void RecognizeText(List<Expression> instruction)
        {
            for (int i = 0; i < instruction.Count; i++)
            {
                string name = instruction[i].ToString() + "";
                if (Memory.DataText.ContainsKey(name))
                {
                    instruction[i] = new Text(instruction[i].ToString(), Memory.DataText[instruction[i].ToString()]);
                }
            }
                
        }

        public void Execute(List<Expression> instruction)
        {
            //Eliminar keyword de tipo IExecutable. No lo necesito para compilar.
            instruction.RemoveAt(0);

            if(SyntacticAnalysis(instruction))
            {
                if (instruction.Count == 1 && (instruction[0] is Text))
                {
                    if ((instruction[0] as Text).isOnlyText)
                        Display._output.Text += string.Format("{0}\n", (instruction[0] as Text).Value);
                    else
                        Display._output.Text += string.Format("{0}\n", Memory.GetText( (instruction[0] as Text).Name));
                }

                else
                {
                    FunctionArithmetic ecuation = ConvertToConditionalFunction.FetchFunction(instruction);
                    
                    float toShow = 0;
                    if(ecuation != null)
                        toShow = ecuation.Evaluate(0);

                    if(!Compiler._haveError)
                        Display._output.Text += string.Format("{0}\n", toShow);
                }
            }

     
        }

        public override string ToText
        {
            get { return "print"; }
        }
    }
}
