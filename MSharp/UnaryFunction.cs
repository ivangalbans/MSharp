using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    /// <summary>
    /// Representa un operador unario
    /// </summary>
    public abstract class UnaryFunction : RelationFunctionArithmetic
    {

         public UnaryFunction() { }

         public UnaryFunction(FunctionArithmetic function)
         {
             this._function = function;
         }

         public override int Arity
         {
             get { return 1; }
         }

    }
}
