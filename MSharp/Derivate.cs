using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    /// <summary>
    /// Representa funcion de tipo, funcion Derivada
    /// /// </summary>
    public class Derivate : UnaryFunction, IDerivate
    {
        public Derivate() { }

       public Derivate(FunctionArithmetic function) : base(function) { }

        public override int Precedence
        {
            get{ return 11; }
        }

        public override int Arity
        {
            get { return 1; }
        }


        public override float Evaluate(float x)
        {
            if(!(_function is IDerivate))
            {
                MSharpErrors.OnError(string.Format("Compilation Error. Funcion no derivable"));
                return 0;
            }
            return (_function as IDerivate).Derive.Evaluate(x);
        }


        public FunctionArithmetic Derive
        {
            get 
            { 
                if(_function is IDerivate)
                    return new Derivate((_function as IDerivate).Derive);

                return null;
            }
        }

        public override string ToText
        {
            get { return "'"; }
        }
    }
}
