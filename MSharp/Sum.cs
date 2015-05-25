using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    /// <summary>
    /// Representa funcion de tipo Adicion
    /// /// </summary>
    public class Sum : BinaryFunction, IDerivate
    {
        public Sum() { }

        public Sum(FunctionArithmetic left, FunctionArithmetic rigth) : base(left, rigth) { }

        public override int Precedence
        {
            get { return 5; }
        }

        public override float Evaluate(float x)
        {
            return left.Evaluate(x) + right.Evaluate(x);
        }

        public FunctionArithmetic Derive
        {
            get
            {
                if (!(left is IDerivate && right is IDerivate))
                {
                    MSharpErrors.OnError("Compilation Error. Funcion no derivable");
                    return null;
                }
                return new Sum((left as IDerivate).Derive, (right as IDerivate).Derive);
            }
        }


        public override string ToText
        {
            get { return "+"; }
        }
    }

}
