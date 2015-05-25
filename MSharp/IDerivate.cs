using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    /// <summary>
    /// Interface que implementan todos aquellos operadores para los cuales existe una regla de derivacion o se define
    /// </summary>
    public interface IDerivate
    {
        FunctionArithmetic Derive { get; }
    
    }
}
