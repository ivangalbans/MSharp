using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    /// <summary>
    /// Representa una Constante
    /// </summary>
    public class ConstantArithmetic : FunctionArithmetic, IDerivate
    {
        private float number;

        /// <summary>
        /// Constructor de Constante
        /// </summary>
        /// <param name="number">Representa el numero de la constante</param>
        public ConstantArithmetic(float number)
        {
            this.number = number;
        }


        public override float Evaluate(float x)
        {
            return number;
        }

        public override string ToString()
        {
            return number.ToString();
        }

        public FunctionArithmetic Derive
        {
            get { return new ConstantArithmetic(0); }
        }


    }
}
