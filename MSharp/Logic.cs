using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    /// <summary>
    /// Contiene a los operadores logicos
    /// </summary>
    public abstract class Logic : BinaryOperator
    {
        protected FunctionBoolean left;
        protected FunctionBoolean right;

        public Logic() { }

        public Logic(FunctionBoolean left, FunctionBoolean right)
        {
            this.left = left; this.right = right;
        }

        public override int Precedence
        {
            get { return 2; }
        }

    }
}
