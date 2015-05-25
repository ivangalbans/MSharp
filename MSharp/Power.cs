using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    /// <summary>
    /// Representa funcion de tipo Potencia
    /// /// </summary>
    public class Power : BinaryFunction, IDerivate
    {
        public Power() { }

        public Power(FunctionArithmetic left, FunctionArithmetic rigth) : base(left, rigth) { }

        public override int Precedence
        {
            get { return 8; }
        }

        public override bool Associative
        {
            get
            {
                return false;
            }
        }

        public override float Evaluate(float x)
        {
            if (right is ConstantArithmetic && !(left is ConstantArithmetic))
                if (right.Evaluate(x) == 0)
                    return 1;

            return (float)Math.Pow(left.Evaluate(x), right.Evaluate(x));
        }

        public FunctionArithmetic Derive
        {
            // (f(x)^g(x))' = ( f(x) ^ g(x) ) * [ g'(x) * ln(f(x)) + g(x) f'(x)/f(x)]
            //f(x) = x g(x) = 2 f(x)^g(x)
            get
            {
                if (!(left is IDerivate && right is IDerivate))
                {
                    MSharpErrors.OnError("Compilation Error. Funcion no derivable");
                    return null;
                }

                Power leftMember = new Power( left, right);
                Sum rightMember = new Sum( new Multiplication( (right as IDerivate).Derive, new LogNep(left) ) , 
                            new Multiplication(right, new Division((left as IDerivate).Derive, left)) );

                return new Multiplication(leftMember, rightMember); 
            }

        }

        public override string ToText
        {
            get { return "^"; }
        }
    }
}
