using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    /// <summary>
    /// Representa un Literal en el lenguaje M#
    /// </summary>
    public class Literal : FunctionArithmetic, IDerivate
    {
        //private string name;
        private float result;

        public Literal() { }

        /// <summary>
        /// Contructor de Literal
        /// </summary>
        /// <param name="name">Nombre del literal</param>
        public Literal(string name)
        {
            _name = name;
        }

        public override float Evaluate(float x)
        {
            result = Memory.GetVariable(_name);
            
            return result;
        }

        public override string ToString()
        {
            return _name;
        }

        public FunctionArithmetic Derive
        {
            get { return new ConstantArithmetic(0); }
        }


    }
}
