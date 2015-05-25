using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    /// <summary>
    /// Representa el operador de Asignacion
    /// </summary>
    public class Assign : SpecialOperator
    {
        public Assign(){}

        
        public override string ToString()
        {
            return "=";
        }

        public override string ToText
        {
            get { return "="; }
        }
    }
}
