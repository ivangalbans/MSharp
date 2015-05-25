using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    /// <summary>
    /// Representa funcion de tipo Division
    /// /// </summary>
    public class Division : BinaryFunction, IDerivate
    {

        public Division() { }

        public Division(FunctionArithmetic left, FunctionArithmetic rigth) : base(left, rigth) { }

        public override int Precedence
        {
            get { return 6; }
        }

        public override float Evaluate(float x)
        {
            if (left is ConstantArithmetic && !(right is ConstantArithmetic))
                if (left.Evaluate(x) == 0)
                    return 0;

            return (float) (left.Evaluate(x) / right.Evaluate(x));
        }


         public FunctionArithmetic Derive
        {
            /*
             * (f(x)/g(x))' = ( f'(x)g(x) - f(x)g'(x) ) / (g(x)*g(x))
             * */
            get 
            {
                if(left is IDerivate && right is IDerivate)
                {
                    FunctionArithmetic numerator = new Substraction(new Multiplication((left as IDerivate).Derive, right),
                                                            new Multiplication(left, (right as IDerivate).Derive));
                    FunctionArithmetic denominator = new Multiplication(right, right);

                    return new Division(numerator, denominator); 
                }
                MSharpErrors.OnError("Compilation Error. Funcion no derivable");
                return null;   
            }
        }


         public override string ToText
         {
             get { return "/"; }
         }
    }
}
