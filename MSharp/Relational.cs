using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    /// <summary>
    /// Contiene a los operadores relacionales
    /// </summary>
    public abstract class Relational : BinaryOperator
    {

        protected FunctionArithmetic left;
        protected FunctionArithmetic right;

        public Relational() { }

        public Relational(FunctionArithmetic left, FunctionArithmetic right)
        {
            this.left = left;
            this.right = right;
        }

        public override int Precedence
        {
            get{ return 4;}
        }

    }
}
