using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    /// <summary>
    /// Comando usado para cambiar valores de las variables
    /// </summary>
    public class Set : Statement, IExecutable
    {
        /// <summary>
        /// Representa un analisis sintactico de la expresion
        /// </summary>
        /// <returns>True si la expresion esta bien escrita, false en caso contrario.</returns>
        private bool SyntacticAnalysis(List<Expression> instruction)
        {
            //Tiene que haber al menos tres tokens (<name> = value)
            if (instruction.Count < 3)
            {
                MSharpErrors.OnError("Compilation Error. Comando set tiene minimo 3 token");
                return false;
            }

            //Si no es un literal lo que viene luego del let
            if (!(instruction[0] is Literal) && !(instruction[0] is Text))
            {
                MSharpErrors.OnError("Incorrecto nombre en la declaracion de literal");
                return false;
            }
                

            //Toda intruccion set posee el operador igual luego del nombre del tipo que se quiere cambiar.
            if (!(instruction[1] is Assign))
            {
                MSharpErrors.OnError("= expected");
                return false;
            }

            return true;
        }

        public void Execute(List<Expression> instruction)
        {
            //Eliminar keyword de tipo IExecutable. No lo necesito para compilar.
            instruction.RemoveAt(0);

            if(SyntacticAnalysis(instruction))
            {
                string nameVariable = instruction[0].ToString();

                //Solo trabajar con las expresiones de la derecha del =
                instruction.RemoveAt(0); instruction.RemoveAt(0);

                //Si es un tipo Text y del operador =, y no hay mas tokens
                if (instruction.Count == 1 && (instruction[0] is Text))
                {
                    Memory.ChangeText(nameVariable, (instruction[0] as Text).Value);
                }

                //Es un tipo number
                else
                {
                    FunctionArithmetic ecuation = ConvertToConditionalFunction.FetchFunction(instruction);
                    //Guardar variable en la memoria
                    if (ecuation != null) 
                        Memory.ChangeVariable(nameVariable, ecuation.Evaluate(0));
                }

            }

            
        }

        public override string ToText
        {
            get { return "set"; }
        }
    }
}
