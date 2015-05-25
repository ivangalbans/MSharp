using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    public abstract class UnaryOperator : RelationFunctionBoolean
    {
        protected FunctionBoolean term;

        public UnaryOperator(){}

        public UnaryOperator(FunctionBoolean term)
        {
            this.term = term;
        }

        public override int Arity
        { 
            get{ return 1;}
        }

        public override int Precedence
        {
            get { return 3; }
        }

    }
}
