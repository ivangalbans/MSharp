using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    /// <summary>
    /// Representa una funcion local del proyecto.
    /// </summary>
    public class LocalFunction : FunctionArithmetic, IDerivate
    {
        //Determina si la funcion fue declarada
        bool _existFunction;

        public LocalFunction() { }

        /// <summary>
        /// Constructor de funcion local
        /// </summary>
        /// <param name="name">Representa el nombre de la funcion</param>
        public LocalFunction(string name)
        {
            _name = name;
        }

        /// <summary>
        /// Constructor de funcion local
        /// </summary>
        /// <param name="name">Representa el nombre de la funcion</param>
        /// <param name="fparam">Representa la funcion en la que se desea evaluar dicha funcion</param>
        public LocalFunction(string name, FunctionArithmetic fparam)
        {
            _existFunction = true;
            _name = name;
            _function = fparam;

            if (!Memory.DataFunction.ContainsKey(name))
            {
                _existFunction = false;
                MSharpErrors.OnError(string.Format("La funcion {0} no ha sido declarada", _name));
            }
                

        }

        public int Precedence
        {
            get { return 10; }
        }

        public int Arity
        {
            get { return 1; }
        }

        public virtual bool Associative
        {
            get { return true; }
        }

        public override float Evaluate(float x)
        {
            if (_existFunction == false)
                return 0;
            return Memory.DataFunction[_name].Evaluate(_function.Evaluate(x));
        }

        public FunctionArithmetic Derive
        {
            get 
            {
                if (_existFunction == false)
                    return null;
                    
                FunctionArithmetic functionToDerive = Memory.DataFunction[_name] as FunctionArithmetic;
                if(functionToDerive is IDerivate)
                    return (functionToDerive as IDerivate).Derive;
                return null;
            }
        }


        /// <summary>
        /// Constructor de funcion local
        /// </summary>
        /// <param name="name">Representa el nombre de la funcion</param>
        /// <param name="fparam">Representa la funcion en la que se desea evaluar dicha funcion</param>
        /*public static float Solve_Function(string name, float number)
        {
            if (!Memory.DataFunction.ContainsKey(name))
                throw new Exception(string.Format("No se ha declarado una funcion de nombre {0}", name));
            return Memory.DataFunction[name].Evaluate(number);
        }*/

        public override string ToString()
        {
            return _name;
        }

    }
}
