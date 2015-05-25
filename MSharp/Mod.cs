using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    /// <summary>
    /// Representa funcion de tipo Modulo
    /// /// </summary>
    public class Mod : BinaryFunction
    {
        public Mod() { }

        public override int Precedence
        {
            get { return 6; }
        }


        public Mod(FunctionArithmetic left, FunctionArithmetic rigth) : base(left, rigth) { }


        public override float Evaluate(float x)
        {
            /*
             * Remember the Division by Zero
            */
            return int.Parse(left.Evaluate(x).ToString()) % int.Parse(right.Evaluate(x).ToString());
        }


         public override string ToText
         {
             get { return "%"; }
         }
    }
}
