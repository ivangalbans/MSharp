using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    /// <summary>
    /// Comando de guardar variables
    /// </summary>
    public class Let : Statement, IExecutable
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
                MSharpErrors.OnError("Compilation Error. Comando let tiene minimo 3 token");
                return false;
            }
                

            //Si no es una variable lo que viene luego del let
            if (!((instruction[0] is Text) || (instruction[0] is Literal)))
            {
                MSharpErrors.OnError("Incorrecto nombre en la declaracion de literal");
                return false;
            }
                

            //Toda intruccion let posee el operador igual luego del nombre del tipo que se quiere declarar.
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
                    Memory.SaveText(nameVariable, (instruction[0] as Text).Value);
                }

                //Es un tipo number
                else
                {
                    ConditionalFunction ecuation = ConvertToConditionalFunction.FetchFunction(instruction);

                    if(ecuation != null)
                    {
                        float toSave = ecuation.Evaluate(0);
                        //    Guardar variable en la memoria
                        if(!Compiler._haveError)
                            Memory.SaveVariable(nameVariable, toSave);
                    }

                }

            }
            
        }

        public override string ToText
        {
            get { return "let"; }
        }
    }
}
