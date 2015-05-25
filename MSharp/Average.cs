using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    /// <summary>
    /// Representa la funcion Promedio
    /// </summary>
    public class Average : N_ary_Function
    {
        FunctionArithmetic _first,_second,_third;

        public Average() { }

        /// <summary>
        /// Constructor de la funcion Promedio. Recibe tres tipos de funciones aritmeticas las cuales sera promediadas
        /// </summary>
        /// <param name="first">Primera FunctionAritmetic</param>
        /// <param name="second">Segunda FunctionAritmetic</param>
        /// <param name="third">Tercera FunctionAritmetic</param>
        public Average(FunctionArithmetic first, FunctionArithmetic second, FunctionArithmetic third)
        {
            this._first = first; this._second = second; this._third = third;
        }

        public override float Evaluate(float x)
        {
            return (_first.Evaluate(x) + _second.Evaluate(x) + _third.Evaluate(x)) / (float)3.0;
        }


        public override int Precedence
        {
            get { return 1000; }
        }

        public override int Arity
        {
            get { return 3; }
        }

        public override string ToText
        {
            get { return "Ave"; }
        }
    }
}
