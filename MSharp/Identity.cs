using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    /// <summary>
    /// Representa funcion la funcion identidad
    /// /// </summary>
    public class Identity : FunctionArithmetic, IDerivate
    {
        public Identity() { }

        public Identity(string name)
        {
            _name = name;
        }

        public override float Evaluate(float x)
        {
            return x;
        }

        public FunctionArithmetic Derive
        {
            // x' = 1
            get { return new ConstantArithmetic(1); }
        }

        public override string ToString()
        {
            return string.Format("x");
        }

    }
}
