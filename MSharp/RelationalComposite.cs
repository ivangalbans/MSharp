using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    public abstract class RelationalComposite : Relational
    {
        public RelationalComposite() { }
        public RelationalComposite(FunctionArithmetic left, FunctionArithmetic right) : base(left, right) { }

    }
}
