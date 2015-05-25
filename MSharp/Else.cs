using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{

    public class Else : Statement
    {
        public override string ToText
        {
            get { return "else"; }
        }
    }
}
