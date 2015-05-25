using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    /// <summary>
    /// Clase estatica encargada en el manejo de errores
    /// </summary>
    public static class MSharpErrors
    {
        public static event ErrorHandler Error;
        public delegate void ErrorHandler(string errorMessage);

        internal static void OnError(string message)
        {
            
            if (Error != null)
            {
                Compiler._haveError = true;
                Error(string.Format("Error Line {0}: {1}",Compiler._lineError, message));
            }
                
        }
    }
}
