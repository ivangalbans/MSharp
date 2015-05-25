using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    /// <summary>
    /// Representa una funcion aritmetica
    /// </summary>
    public abstract class FunctionArithmetic : Function
    {
        public FunctionArithmetic() { }

        /// <summary>
        /// Metodo que evalua un punto en una funcion
        /// </summary>
        /// <param name="x">Punto a evaluar en funcion</param>
        /// <returns>Resultado de la evaluacion de la funcion</returns>
        public abstract float Evaluate(float x);

        //Nombre de la funcion
        protected string _name;

        //Parametro en que se evaluara. Termino independiente
        protected string _parameter;

        //Cuerpo. Funcion.
        protected FunctionArithmetic _function;

    }
}
