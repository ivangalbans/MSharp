using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    /// <summary>
    /// Representa la funcion Valor Absoluto
    /// </summary>
    public class Abs : Elemental
    {
        public Abs() { }

        public Abs(FunctionArithmetic function) : base(function) { }

        public override float Evaluate(float x)
        {
            return Math.Abs(_function.Evaluate(x));
        }

         public override string ToString()
         {
             return string.Format("abs {0}", _function);
         }


         public override string ToText
         {
             get { return "abs"; }
         }
    }
}
