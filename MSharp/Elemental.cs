using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    /// <summary>
    /// Tipos de funciones elementales predefinidas
    /// </summary>
    public abstract class Elemental : UnaryFunction
    {
        public Elemental() { }

        public Elemental(FunctionArithmetic term):base(term)
        {
        }

        public override int Precedence
        {
            get { return 9; }
        }

    }
}
