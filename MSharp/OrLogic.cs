using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    public class OrLogic : Logic
    {
        public OrLogic() { }

        public OrLogic(FunctionBoolean left, FunctionBoolean right) : base(left, right) { }

        public override bool Evaluate(float x)
        {
            return left.Evaluate(x) | right.Evaluate(x);
        }

        public override string ToText
        {
            get { return "|"; }
        }
    }
}
