using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    /// <summary>
    /// Representa funcion Seno
    /// /// </summary>
    public class Sin : Trigonometric
    {
        public Sin() { }

        public Sin(FunctionArithmetic function) : base(function) { }

        public override float Evaluate(float x)
        {
            return (float)Math.Sin(_function.Evaluate(x));
        }


        public override FunctionArithmetic Derive
        {
            get 
            {
                if (_function is IDerivate)
                    return new Multiplication(new Cos(_function), (_function as IDerivate).Derive);

                MSharpErrors.OnError("Compilation Error. Funcion no derivable");
                return null;
            }
        }

        public override string ToString()
        {
            return string.Format("sin {0}", _function);
        }

        public override string ToText
        {
            get { return "sin"; }
        }
    }
}
