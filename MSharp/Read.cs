using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MSharp
{
    /// <summary>
    /// Comando para leer numeros introducidos por el usuario
    /// </summary>
    public class Read : Statement, IExecutable
    {
        //Nombre de la variable a la que el usuario va a asignar la lectura
        public static string _name;

        //Numero que entrara el usuario
        public static float _number;

        /// <summary>
        /// Representa un analisis sintactico de la expresion
        /// </summary>
        /// <returns>True si la expresion esta bien escrita, false en caso contrario.</returns>
        private bool SyntacticAnalysis(List<Expression> instruction)
        {
            if (instruction.Count != 1)
            {
                MSharpErrors.OnError("Incorrecta sintaxis de read");
                return false;
            }
                

            if (!(instruction[0] is Literal))
            {
                MSharpErrors.OnError("Solo se aplica read a los literales");
                return false;
            }

            _name = instruction[0].ToString();
            return true;
        }

        public void Execute(List<Expression> instruction)
        {
            //Eliminar keyword de tipo IExecutable. No lo necesito para compilar.
            instruction.RemoveAt(0);

            if(SyntacticAnalysis(instruction))
            {
                Compiler._isOKRead = true; 
            }

        }

        public override string ToText
        {
            get { return "read"; }
        }
    }
}
