using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    /// <summary>
    /// Representa la funcion Arcotangente
    /// </summary>
    public class Atan : InverseTrigonometric
    {
        public Atan() { }

        public Atan(FunctionArithmetic function) : base(function) { }

        public override float Evaluate(float x)
        {
            return (float)Math.Atan(_function.Evaluate(x));
        }

        public override FunctionArithmetic Derive
        {
            // tan(x)' = 1 / (1 + x^2)
            get 
            {
                if(_function is IDerivate)
                {
                    FunctionArithmetic externDerivate = new Division(new ConstantArithmetic(1), new Sum(new ConstantArithmetic(1),
                                            new Multiplication(_function, _function)));
                    return new Multiplication(externDerivate, (_function as IDerivate).Derive); 
                }
                MSharpErrors.OnError("Compilation Error. Funcion no derivable");
                return null; 
            }
        }

        public override string ToString()
        {
            return string.Format("atan {0}", _function);
        }


        public override string ToText
        {
            get { return "atan"; }
        }
    }
}
