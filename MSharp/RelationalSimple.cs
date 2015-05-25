using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    public abstract class RelationalSimple : Relational
    {
        public RelationalSimple() { }

        public RelationalSimple(FunctionArithmetic left, FunctionArithmetic right) : base(left, right) { }
    }
}
