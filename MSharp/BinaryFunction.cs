using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    public abstract class BinaryFunction : RelationFunctionArithmetic
    {

        protected FunctionArithmetic left;
        protected FunctionArithmetic right;

        public BinaryFunction() { }

        /// <summary>
        /// Representa una Funcion Binaria
        /// </summary>
        /// <param name="left">El primer operando de tipo FunctionArithmeti</param>
        /// <param name="right">El segundo operando de tipo FunctionArithmeti</param>
        public BinaryFunction(FunctionArithmetic left, FunctionArithmetic right)
        {
            this.left = left;
            this.right = right;
        }


        public override int Arity
        {
            get{ return 2;}
        }

    }
}
