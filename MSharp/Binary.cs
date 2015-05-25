using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    /// <summary>
    /// Representa una clase abstracta de Operador Binario
    /// </summary>
    public abstract class BinaryOperator : RelationFunctionBoolean
    {

        public BinaryOperator() { }

        /// <returns>Un entero 2, al ser de tipo Operador Binario</returns>
        public override int Arity
        {
            get { return 2; }
        }

    }
}
