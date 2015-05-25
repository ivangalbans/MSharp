using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    public class NegationLogic : UnaryOperator
    {
        public NegationLogic() { }

        public NegationLogic(FunctionBoolean term) : base(term) { }

        public override bool Evaluate(float x)
        {
            return !term.Evaluate(x);
        }
        public override string ToString()
        {
            return "!";
        }

        public override string ToText
        {
            get { return "!"; }
        }
    }
}
