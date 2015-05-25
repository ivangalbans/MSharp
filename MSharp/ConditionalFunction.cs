using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    /// <summary>
    /// Representa una funcion condicional
    /// </summary>
    public class ConditionalFunction : FunctionArithmetic, IDerivate
    {
        FunctionArithmetic body;
        FunctionBoolean proposition;
        ConditionalFunction ptrElse;

        /// <summary>
        /// Constructor de Funcion
        /// </summary>
        /// <param name="body">Cuerpo de la funcion</param>
        /// <param name="proposition">Proposicion a evaluar</param>
        /// <param name="ptrElse">Puntero a otra funcion condicional</param> 
        public ConditionalFunction(FunctionArithmetic body, FunctionBoolean proposition, ConditionalFunction ptrElse)
        {
            this.body = body;
            this.proposition = proposition;
            this.ptrElse = ptrElse;
        }

        public override float Evaluate(float x)
        {
            return proposition.Evaluate(x) ? body.Evaluate(x) : ptrElse.Evaluate(x);
        }

        public FunctionArithmetic Derive
        {
            get 
            {
                List<FunctionArithmetic> listBody = new List<FunctionArithmetic>();
                List<FunctionBoolean> listCondition = new List<FunctionBoolean>();

                ConditionalFunction current = this;

                do
                {
                    listBody.Add(current.body);
                    listCondition.Add(current.proposition);

                    current = current.ptrElse;
                
                } while (current != null);

                FunctionArithmetic funcDerivate = ConvertToConditionalFunction.GetDerivate(listBody, listCondition);

                return funcDerivate;
            }
        }


    }
}
