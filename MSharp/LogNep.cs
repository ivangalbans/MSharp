using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    /// <summary>
    /// Representa la funcion Logaritmo Neperiano    /// /// </summary>
    public class LogNep : Elemental, IDerivate
    {
        public LogNep() { }

        public LogNep(FunctionArithmetic function) : base(function) { }

        public override float Evaluate(float x)
        {
            return (float)Math.Log(_function.Evaluate(x), Math.E);
        }

        public FunctionArithmetic Derive
        {
            //ln(x)' = 1/x
            get 
            { 
                if(!(_function is IDerivate))
                {
                    MSharpErrors.OnError("Compilation Error. Funcion no derivable");
                    return null;
                }
                return new Multiplication(new Division(new ConstantArithmetic(1), _function), (_function as IDerivate).Derive); 
            }
        }

        public override string ToString()
        {
            return string.Format("ln {0}", _function);
        }



        public override string ToText
        {
            get { return "ln"; }
        }
    }
}
