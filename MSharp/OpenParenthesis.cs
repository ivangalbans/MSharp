using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    /// <summary>
    /// Representa el tipo especial Parentesis Abierto
    /// </summary>
    public class OpenParenthesis : SpecialOperator
    {
        public OpenParenthesis() { }


        public override string ToString()
        {
            return "(";
        }


        public override string ToText
        {
            get { return "("; }
        }
    }
}
