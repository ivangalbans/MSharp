using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    public abstract class RelationFunctionBoolean : FunctionBoolean
    {
        public abstract string ToText { get; }

        public abstract int Precedence { get; }
        public abstract int Arity { get; }

        public virtual bool Associative
        {
            //Se da la implementacion de que todos los operadores son asociativos a la izquierda(true)
            //Puede ser reimplementado
            get { return true; }
        }

    }
}
