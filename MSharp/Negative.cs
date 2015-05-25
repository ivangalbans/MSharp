using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    /// <summary>
    /// Representa funcion Negativa
    /// /// </summary>
    public class Negative : UnaryFunction, IDerivate
    {
        public Negative() { }

        public Negative(FunctionArithmetic function) : base(function) { }

        public override float Evaluate(float x)
        {
            return -1 * _function.Evaluate(x);
        }

        public override int Precedence
        {
            get{ return 7;}
        }

        public FunctionArithmetic Derive
        {
            get
            {
                if (_function is IDerivate)
                    return new Negative((_function as IDerivate).Derive);

                MSharpErrors.OnError("Compilation Error. Funcion no derivable");
                return null;
            }
        }


        public override string ToText
        {
            get { return "-unary"; }
        }
    }
}
