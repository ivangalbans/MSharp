using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    /// <summary>
    /// Representa el tipo especial Coma
    /// </summary>
    public class Comma : SpecialOperator
    {

        public override string ToText
        {
            get { return ","; }
        }
    }
}
