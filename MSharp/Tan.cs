using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    /// <summary>
    /// Representa funcion Tangente
    /// /// </summary>
    public class Tan : Trigonometric
    {
        public Tan() { }
        public Tan(FunctionArithmetic function) : base(function) { }

        public override float Evaluate(float x)
        {
            return (float)Math.Tan(_function.Evaluate(x));
        }

        public override FunctionArithmetic Derive
        {
            // tan(x)' = (sec(x))^2
            get 
            {
                if (_function is IDerivate)
                {
                    Division sec = new Division(new ConstantArithmetic(1), new Cos(_function));
                    return new Multiplication(new Multiplication(sec, sec), (_function as IDerivate).Derive);
                }
                MSharpErrors.OnError("Compilation Error. Funcion no derivable");
                return null;
            }
        }

        public override string ToString()
        {
            return string.Format("tan {0}", _function);
        }


        public override string ToText
        {
            get { return "tan"; }
        }
    }
}
