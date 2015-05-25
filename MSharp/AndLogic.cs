using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{

    /// <summary>
    /// Representa el operador And Logico a nivel de bits
    /// </summary>
    public class AndLogic : Logic
    {
        public AndLogic() { }
        public AndLogic(FunctionBoolean left, FunctionBoolean right) : base(left, right) { }

        
        public override bool Evaluate(float x)
        {
            return left.Evaluate(x) & right.Evaluate(x);
        }



        public override string ToText
        {
            get { return "&"; }
        }
    }
}
