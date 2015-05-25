using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    /// <summary>
    /// Comando para definir funciones
    /// </summary>
    public class Def : Statement, IExecutable
    {

        string name;
        string parameter;

        public Def() { }

        //public static 

        /// <summary>
        /// Representa un analisis sintactico de la expresion
        /// </summary>
        /// <returns>True si la expresion esta bien escrita, false en caso contrario.</returns>
        private bool SyntacticAnalysis(List<Expression> instruction)
        {
            if (!(instruction.Count >= 6))
            {
                MSharpErrors.OnError("Compilation Error. Incorrecta declaracion de funcion");
                return false;
            }
                

            //Verificar que es un tipo variable lo que viene luego del def. En este caso seria el nombre de la funcion.
            if (!(instruction[0] is LocalFunction) )
            {
                MSharpErrors.OnError("Incorrecto nombre en la declaracion de la funcion.");
                return false;
            }

            //Nombre con que fue declarada la funcion
            name = instruction[0].ToString();

            if (!(instruction[1] is OpenParenthesis))
            {
                MSharpErrors.OnError("( expected");
                return false;
            }
                

            //Verificar que es un tipo variable lo que viene luego del parentesis abierto. En este caso seria el termino independiente de la funcion.
            if (!(instruction[2] is Literal))
            {
                MSharpErrors.OnError("Incorrecto nombre de termino independiente de la funcion.");
                return false;
            }

            //Termino independiente de la funcion
            parameter = instruction[2].ToString();

            if (!(instruction[3] is ClosedParenthesis))
            {
                MSharpErrors.OnError(") expected");
                return false;
            }

            if (!(instruction[4] is Assign))
            {
                MSharpErrors.OnError("= expected");
                return false;
            }

            //Para trabajar solo con el miembro a la derecha del =
            instruction.RemoveRange(0, 5);

            //Identificar el termino independiente en la funcion. No confundir con las variables locales!!!
            RecognizeParameter(instruction, parameter);

            return true;
        }


        public void Execute(List<Expression> instruction)
        {
            //Eliminar keyword de tipo IExecutable. No lo necesito para compilar.
            instruction.RemoveAt(0);

            if(SyntacticAnalysis(instruction))
            {
                FunctionArithmetic tempFunction = ConvertToConditionalFunction.FetchFunction(instruction);

                if(tempFunction != null)
                {
                    //Guardar la funcion
                    Memory.SaveFunction(name, ConvertToConditionalFunction.FetchFunction(instruction));
                }
            }

        }

        private void RecognizeParameter(List<Expression> instruction, string parameter)
        {
            for (int i = 0; i < instruction.Count; i++)
                if (instruction[i] is Literal && instruction[i].ToString() == parameter)
                    instruction[i] = new Identity(parameter);
        }

        public override string ToText
        {
            get { return "def"; }
        }
    }
}
