using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    /// <summary>
    /// Representa el tipo especial Parentesis Cerrado
    /// </summary>
    public class ClosedParenthesis : SpecialOperator
    {
        public ClosedParenthesis() { }

        public override string ToString()
        {
            return ")";
        }

        public override string ToText
        {
            get { return ")"; }
        }
    }
}
