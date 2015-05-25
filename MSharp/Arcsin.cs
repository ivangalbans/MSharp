using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    /// <summary>
    /// Representa la funcion Arcoseno
    /// </summary>
    public class Arcsin : InverseTrigonometric
    {
        public Arcsin() { }

        public Arcsin(FunctionArithmetic function) : base(function) { }

        public override float Evaluate(float x)
        {
            return (float)Math.Asin(_function.Evaluate(x));
        }

        public override FunctionArithmetic Derive
        {
            // arcsin(x)' = 1 / ( sqrt(1 - x^2) )
            get
            {
                if(_function is IDerivate)
                {
                    Multiplication xSquare = new Multiplication(_function, _function);
                    FunctionArithmetic externDerivate = new Division(new ConstantArithmetic(1),
                             new Sqrt(new Substraction(new ConstantArithmetic(1), xSquare)));
                    return new Multiplication(externDerivate, (_function as IDerivate).Derive);
                }
                MSharpErrors.OnError("Compilation Error. Funcion no derivable");
                return null; 
            }
        }

        public override string ToString()
        {
            return string.Format("arcsin {0}", _function);
        }



        public override string ToText
        {
            get { return "arcsin"; }
        }
    }
}
