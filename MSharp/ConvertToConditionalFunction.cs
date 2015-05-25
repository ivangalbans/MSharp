using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tokenizing;

namespace MSharp
{
    /// <summary>
    /// Clase que contiene metodos necesarios para covertir a funciones condicionales. Asi como allar sus derivadas
    /// </summary>

    internal class ConvertToConditionalFunction
    {
        static List<FunctionArithmetic> _listBody;
        static List<FunctionBoolean> _listCondition;

        private static void Reset()
        {
            _listBody = new List<FunctionArithmetic>();
            _listCondition = new List<FunctionBoolean>();
        }

        /// <summary>
        /// Halla la derivada de una funcion condicional
        /// </summary>
        /// <param name="listBody">Posee los tramos de la funcion</param>
        /// <param name="listCondition">Condiciones</param>
        /// <returns>Una funcion condicional que fue resultado de la derivada</returns>
        public static ConditionalFunction GetDerivate(List<FunctionArithmetic> listBody, List<FunctionBoolean> listCondition)
        {
            Reset();

            _listBody = listBody;
            _listCondition = listCondition;


            //Significa que termina en else -> ultima condicion true si no ocurre ninguna otra
            if (_listBody.Count - _listCondition.Count == 1)
                _listCondition.Add(new ConstantBoolean(true));

            if(DerivateList())
                return Create_Function(0);

            MSharpErrors.OnError("Error. La funcion no tiene derivada");
            return null;
        }

        private static bool DerivateList()
        {
            for (int i = 0; i < _listBody.Count; i++)
            {
                if (!(_listBody[i] is IDerivate))
                {
                    MSharpErrors.OnError("La funcion no es derivable");
                    return false;
                }
                    
                _listBody[i] = (_listBody[i] as IDerivate).Derive;
            }
            return true;  
        }

        /// <summary>
        /// Convierte a funcion condicional
        /// </summary>
        /// <param name="expression">Contiene todos los elementos en forma de lista de la funcion
        /// <returns>Funcion Condicional</returns>
        public static ConditionalFunction FetchFunction(List<Expression> expression)
        {
            Reset();
            if(Create_List(expression))
                return Create_Function(0);

            return null;
        }

        //Metodo recursivo que crea el arbol que describe a las funciones condicionales
        private static ConditionalFunction Create_Function(int pos)
        {
            if (pos == _listBody.Count - 1)
                return new ConditionalFunction(_listBody[pos], _listCondition[pos], null);
            else
                return new ConditionalFunction(_listBody[pos], _listCondition[pos], Create_Function(pos+1));
        }


        //Metodo que asigna a las listas miembros de la clase, las funciones aritmeticas y las
        //funciones booleanas(proposiciones) de la condicional
        private static bool Create_List(List<Expression> expression)
        {
            List<Function> function = new List<Function>();

            for (int i = 0; i < expression.Count; i++)
            {
                if (expression[i] is If)
                {  
                    Function tempFunction1 = Converter_ShuntingYard.FetchFunction(function);

                    if (!(tempFunction1 is FunctionArithmetic))
                    {
                        MSharpErrors.OnError("Incorrecta expresion");
                        return false;
                    }
                        

                    FunctionArithmetic tempFunction = tempFunction1 as FunctionArithmetic;

                    _listBody.Add(tempFunction);
                    function.Clear();
                }

                else if (expression[i] is Else)
                {   
                    Function tempFunction1 = Converter_ShuntingYard.FetchFunction(function);

                    if (!(tempFunction1 is FunctionBoolean))
                    {
                        MSharpErrors.OnError("Incorrecta expresion");
                        return false;
                    }
                        

                    FunctionBoolean tempFunction = tempFunction1 as FunctionBoolean;

                    _listCondition.Add(tempFunction);
                    function.Clear();
                }

                else
                {
                    if (!(expression[i] is Function))
                    {
                        MSharpErrors.OnError("Incorrecta expresion");
                        return false;
                    }
                        
                    function.Add(expression[i] as Function);
                }

            }

            //Formar funcion que quedó
            Function lastFunction = Converter_ShuntingYard.FetchFunction(function);

            if (!(lastFunction is FunctionArithmetic) && !(lastFunction is FunctionBoolean))
            {
                MSharpErrors.OnError("Incorrecta expresion");
                return false;
            }
                

            if (lastFunction is FunctionArithmetic)
                _listBody.Add(lastFunction as FunctionArithmetic);
            else
                _listCondition.Add(lastFunction as FunctionBoolean);

            if (_listBody.Count < _listCondition.Count == true)
            {
                MSharpErrors.OnError("Incorrecta funcion");
                return false;
            }
                

            //Significa que termina en else -> ultima condicion true si no ocurre ninguna otra
            if (_listBody.Count - _listCondition.Count == 1)
                _listCondition.Add(new ConstantBoolean(true));


            return true;
        }


    }
}
