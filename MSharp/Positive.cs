using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    /// <summary>
    /// Representa funcion Positiva
    /// /// </summary>
    public class Positive : UnaryFunction, IDerivate
    {

        public Positive() { }

        public Positive(FunctionArithmetic function) : base(function) { }

        public override float Evaluate(float x)
        {
            return _function.Evaluate(x);
        }

        public FunctionArithmetic Derive
        {
            get 
            {
                if(_function is IDerivate)
                    return new Positive( (_function as IDerivate).Derive);

                MSharpErrors.OnError("Compilation Error. Funcion no derivable");
                return null;   
            }
        }


        public override int Precedence
        {
            get { return 7; }
        }


        public override string ToText
        {
            get { return "+unary"; }
        }
    }



}
