using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    /// <summary>
    /// Representa funcion Coseno
    /// /// </summary>
    public class Cos : Trigonometric
    {
        public Cos() { }
        public Cos(FunctionArithmetic function) : base(function) { }

        public override float Evaluate(float x)
        {
            return (float)Math.Cos(_function.Evaluate(x));
        }

        public override FunctionArithmetic Derive
        {
            
            get 
            {
                if(_function is IDerivate)
                    return new Multiplication(new Negative(new Sin(_function)), (_function as IDerivate).Derive);

                MSharpErrors.OnError("Compilation Error. Funcion no derivable");
                return null;
            }
        }

        public override string ToString()
        {
            return string.Format("cos {0}", _function);
        }


        public override string ToText
        {
            get { return "cos"; }
        }
    }
}
