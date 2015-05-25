using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    /// <summary>
    /// Representa funcion de tipo Multiplicacion
    /// /// </summary>
    public class Multiplication : BinaryFunction, IDerivate
    {
        public Multiplication() { }

        public Multiplication(FunctionArithmetic left, FunctionArithmetic rigth) : base(left, rigth) { }

        public override int Precedence
        {
            get { return 6; }
        }

        public override float Evaluate(float x)
        {
            if (left is ConstantArithmetic)
                if (left.Evaluate(x) == 0)
                    return 0;

            if (right is ConstantArithmetic)
                if (right.Evaluate(x) == 0)
                    return 0;
                
            return left.Evaluate(x) * right.Evaluate(x);
        }

        public FunctionArithmetic Derive
        {
            /*
             * (f(x)*g(x))' = f'(x)g(x) + f(x)g'(x)
             * */

            get 
            {
                if (!(left is IDerivate && right is IDerivate))
                {
                    MSharpErrors.OnError("Compilation Error. Funcion no derivable");
                    return null;  
                }
                return new Sum( new Multiplication((left as IDerivate).Derive,right) , new Multiplication(left, (right as IDerivate).Derive) ); 
            }
        }

        public override string ToText
        {
            get { return "*"; }
        }
    }
}
