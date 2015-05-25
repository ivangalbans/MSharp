using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    /// <summary>
    /// Representa a las funciones trigonometricas inversas
    /// </summary>
    public abstract class InverseTrigonometric : Elemental, IDerivate
    {
        public InverseTrigonometric() { }

        public InverseTrigonometric(FunctionArithmetic term) : base(term)
        {
        }

        public abstract FunctionArithmetic Derive { get; }
    }
}
