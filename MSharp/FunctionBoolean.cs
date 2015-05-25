using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    /// <summary>
    /// Representa una clase de tipo funcion booleana
    /// </summary>
    public abstract class FunctionBoolean : Function
    {
        //Metodo que opera entre funciones aritmeticas y devuelve un tipo booleano
        public abstract bool Evaluate(float x);

        //Body
        protected FunctionBoolean function;
        
    }
}
