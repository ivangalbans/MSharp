using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    /// <summary>
    /// Clase que agrupa a los operadores especiales del lenguaje M#
    /// </summary>
    public abstract class SpecialOperator : Function
    {
        //Representacion en codigo
        public abstract string ToText { get; }
    }
}
