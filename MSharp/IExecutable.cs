using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    /// <summary>
    /// Interface que implementan todos aquellos statement que son ejecutables
    /// </summary>
    public interface IExecutable
    {
        /// <summary>
        /// Ejecutar el comando
        /// /// <param name="hasta">Lista de expresion a ejecutar</param>
        /// </summary>
         void Execute(List<Expression> instruction);

    }
}
