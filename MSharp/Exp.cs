using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    /// <summary>
    /// Representa la funcion Exponencial
    /// </summary>
    public class Exp : Elemental, IDerivate
    {
        public Exp() { }

        public Exp(FunctionArithmetic function) : base(function) { }

        public override float Evaluate(float x)
        {
            return (float)Math.Exp(_function.Evaluate(x));
        }

        public FunctionArithmetic Derive
        {
            // (e^x)' = e^x
            get 
            {
                if (!(_function is IDerivate))
                {
                    MSharpErrors.OnError("Compilation Error. Funcion no derivable");
                    return null;
                }
                return new Multiplication(new Exp(_function), (_function as IDerivate).Derive);            
            }
        }

        public override string ToString()
        {
            return string.Format("exp {0}", _function);
        }



        public override string ToText
        {
            get { return "exp"; }
        }
    }
}
