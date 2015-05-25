using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    public class GreaterOrEqual : RelationalComposite
    {

        public GreaterOrEqual() { }

        public GreaterOrEqual(FunctionArithmetic left, FunctionArithmetic right) : base(left, right) { }

        public override bool Evaluate(float x)
        {
            return (left.Evaluate(x) >= right.Evaluate(x)) ? true : false;
        }



        public override string ToText
        {
            get { return ">="; }
        }
    }
}
