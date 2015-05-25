using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    public class ConstantBoolean : FunctionBoolean
    {

        bool constant;

        public ConstantBoolean(bool constant)
        {
            this.constant = constant;
        }


        public override bool Evaluate(float x)
        {
            return constant;
        }

    }
}
