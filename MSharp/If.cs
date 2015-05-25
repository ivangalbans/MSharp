using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    public class If : Statement
    {
        public override string ToText
        {
            get { return "if"; }
        }
    }
}
