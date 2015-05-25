using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    public abstract class Trigonometric : Elemental, IDerivate
    {
        public Trigonometric() { }

        public Trigonometric(FunctionArithmetic term):base(term)
        {
        }


        public abstract FunctionArithmetic Derive { get; }

    }
}
