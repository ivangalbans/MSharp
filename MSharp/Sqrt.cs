using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    /// <summary>
    /// Representa funcion Raiz Cuadrada
    /// /// </summary>
    public class Sqrt : Elemental, IDerivate
    {
        public Sqrt() { }

        public Sqrt(FunctionArithmetic function) : base(function) { }

        public override float Evaluate(float x)
        {
            return (float)Math.Sqrt(_function.Evaluate(x));
        }

        public FunctionArithmetic Derive
        {
            //sqrt(x)' = 0.5/(sqrt(x))

            get 
            { 
                if(_function is IDerivate)
                    return new Multiplication(new Division(new ConstantArithmetic((float)0.5), new Sqrt(_function)) , (_function as IDerivate).Derive);
                
                MSharpErrors.OnError("Compilation Error. Funcion no derivable");
                return null;   
            }
        }

        public override string ToString()
        {
            return string.Format("sqrt {0}", _function);
        }

        public override string ToText
        {
            get { return "sqrt"; }
        }
    }
}
