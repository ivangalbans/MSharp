using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    /// <summary>
    /// Representa la funcion Cotagente
    /// /// </summary>
    public class Cot : Trigonometric
    {
        public Cot() { }

        public Cot(FunctionArithmetic function) : base(function) { }

        public override float Evaluate(float x)
        {
            return (float)(1.0 / Math.Tan(_function.Evaluate(x)));
        }

        public override FunctionArithmetic Derive
        {
            //cot(x)' = - (csc(x)^2)
            get
            {
                if(_function is IDerivate)
                {
                    Division csc = new Division(new ConstantArithmetic(1), new Sin(_function));
                    return new Multiplication(new Negative(new Multiplication(csc, csc)), (_function as IDerivate).Derive);
                }
                MSharpErrors.OnError("Compilation Error. Funcion no derivable");
                return null; 
            }
        }

        public override string ToString()
        {
            return string.Format("cot {0}", _function);
        }


        public override string ToText
        {
            get { return "cot"; }
        }
    }
}
