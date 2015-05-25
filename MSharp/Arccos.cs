using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    /// <summary>
    /// Representa la funcion Arcocoseno
    /// </summary>
    public class Arccos : InverseTrigonometric
    {
        public Arccos() { }

        public Arccos(FunctionArithmetic function) : base(function) { }

        public override float Evaluate(float x)
        {
            return (float)Math.Acos(_function.Evaluate(x));
        }

        public override FunctionArithmetic Derive
        {
            // arccos(x)' = -(arcsin(x)')
            get
            {
                FunctionArithmetic arcsin = new Arcsin(_function);

                if (arcsin is IDerivate && _function is IDerivate)
                {
                    FunctionArithmetic externDerivate = new Negative((arcsin as IDerivate).Derive);
                    return new Multiplication(externDerivate, (_function as IDerivate).Derive);
                }

                MSharpErrors.OnError("Compilation Error. Funcion no derivable");
                return null; 
            }
        }

        public override string ToString()
        {
            return string.Format("arccos {0}", _function);
        }


        public override string ToText
        {
            get { return "arccos"; }
        }
    }
}
