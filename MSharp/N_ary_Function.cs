using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    public abstract class N_ary_Function : RelationFunctionArithmetic
    {
        internal FunctionArithmetic[] _parameters;

        public N_ary_Function() { }

        public N_ary_Function(params FunctionArithmetic[] parameters)
        {
            _parameters = parameters;
        }
    }
}
