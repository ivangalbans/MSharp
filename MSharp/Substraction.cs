using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    /// <summary>
    /// Representa funcion de tipo Substraccion
    /// /// </summary>
    public class Substraction : BinaryFunction, IDerivate
    {
        public Substraction() { }

        public Substraction(FunctionArithmetic left, FunctionArithmetic rigth) : base(left, rigth) { }

        public override int Precedence
        {
            get { return 5; }
        }

        public override float Evaluate(float x)
        {
            return left.Evaluate(x) - right.Evaluate(x);
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
                return new Substraction((left as IDerivate).Derive, (right as IDerivate).Derive); 
            }
        }

        /*public override string ToString()
        {
            return string.Format("({0} - {1})", left.ToString(), right.ToString());
        }*/


        public override string ToText
        {
            get { return "-"; }
        }
    }
}
