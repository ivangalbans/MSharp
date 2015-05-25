using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace MSharp
{
    /// <summary>
    /// Clase que contiene Metodos para evaluar expresiones
    /// </summary>
    internal class Converter_ShuntingYard
    {
        /// <summary>
        /// Convierte una expresion a funcion
        /// </summary>
        /// <param name="expression"> Expresion a evaluar</param>
        /// <returns> Un tipo funcion que puede evaluase</returns>
        public static Function FetchFunction(List<Function> expression)
        {
            return RPN(ShuntingYard(expression));
        }


        static int precedenceOper1, precedenceOper2;
        static bool associativityOper1, associativityOper2;
        static int arityOper1, arityOper2;

        //Convierte una expresion de notacion infijo a posfijo
        private static Queue<Function> ShuntingYard(List<Function> expression)
        {
            Stack<Function> stackOperators = new Stack<Function>();
            Queue<Function> queueOut = new Queue<Function>();

            foreach (Function token in expression)
            {

                //Si es un numero poner en la cola de salida
                if (token is ConstantArithmetic || token is Literal || token is Identity || token is ConstantBoolean)
                    queueOut.Enqueue(token);

                else if (token is N_ary_Function)
                    stackOperators.Push(token);

                #region Si es una coma
                else if (token is Comma)
                {
                    if (stackOperators.Count != 0)
                    {
                        // Hasta que el token en el tope de la pila sea un paréntesis abierto
                        while (!(stackOperators.Peek() is OpenParenthesis))
                        {
                            // retirar (pop) a los operadores de la pila y colocarlos en la cola de salida.
                            queueOut.Enqueue(stackOperators.Pop());
                            if (stackOperators.Count == 0)
                            {
                                MSharpErrors.OnError("Los parentesis no estan balanceados");
                                return null;
                            }
                                
                        }

                    }

                    else
                    {
                        MSharpErrors.OnError("Incorrecta escritura de ecuacion");//("La pila de operadores esta vacia");
                        return null;
                    }
                        
                }
                #endregion

                //Si es parantesis abierto poner en la pila
                else if (token is OpenParenthesis)
                    stackOperators.Push(token);

                #region Si es Parentesis Cerrado
                else if (token is ClosedParenthesis)
                {
                    if (stackOperators.Count != 0)
                    {
                        // Hasta que el token en el tope de la pila sea un paréntesis abierto
                        while (!(stackOperators.Peek() is OpenParenthesis))
                        {
                            // retirar (pop) a los operadores de la pila y colocarlos en la cola de salida.
                            queueOut.Enqueue(stackOperators.Pop());
                            if (stackOperators.Count == 0)
                            {
                                MSharpErrors.OnError("Los parentesis no estan balanceados");
                                return null;
                            }
                                
                        }
                        // Retirar(pop) el paréntesis abierto de la pila
                        stackOperators.Pop();
                    }
                    else
                    {
                        MSharpErrors.OnError("Incorrecta escritura de ecuacion");//("La pila de operadores esta vacia");
                        return null;
                    }
                        

                    if (token is N_ary_Function)
                        queueOut.Enqueue(stackOperators.Pop());

                }
                #endregion

                #region Si es un operador
                else if (token is RelationFunctionArithmetic || token is RelationFunctionBoolean || token is LocalFunction)
                {
                    #region Inicializar Operador1
                    Function operator1 = new ConstantArithmetic(0);

                    operator1 = CastOperator(token);

                    #endregion

                    // Si hay elementos en la pila
                    if (stackOperators.Count != 0)
                    {
                        #region Inicializar Operador2
                        Function operator2 = new ConstantArithmetic(0);

                        //Asignar a operator2 el operador q esta en el tope de la pila
                        operator2 = CastOperator(stackOperators.Peek());

                        if(!(operator2 is OpenParenthesis))
                            Get_Precedence_Associatity(operator1, operator2);

                        #endregion

                        #region While
                        // mientras que haya un operador, operator2, en el tope de la pila y no sea el parentesis abierto
                        // y operator1 es asociativo izquierdo y su precedencia es menor o igual que la de operator2 o
                        // operator1 es asociativo derecho y su precedencia es menor que la de operator2
                        while (stackOperators.Count != 0 && !(operator2 is OpenParenthesis) &&
                                ((associativityOper1 && precedenceOper1 <= precedenceOper2) ||
                                  (associativityOper1 == false && precedenceOper1 < precedenceOper2)))
                        {
                            // retirar de la pila el operador de su tope y ponerlo en la cola de salida;
                            queueOut.Enqueue(stackOperators.Pop());

                            if (stackOperators.Count != 0)
                            {
                                operator2 = CastOperator(stackOperators.Peek());
                            }
                            if (operator2 is OpenParenthesis)
                                break;
                            Get_Precedence_Associatity(operator1, operator2);
                        }
                        #endregion
                    }
                    // Poner a operator1 en el tope de la pila
                    stackOperators.Push(operator1);
                }
                #endregion

                else
                {
                    MSharpErrors.OnError("Operador no valido");
                    return null;
                }


            }

            //Mientras todavía haya tokens de operadores en la pila:
            while (stackOperators.Count != 0)
            {
                Function operator1 = stackOperators.Peek();

                // Si el token del operador en el tope de la pila es un paréntesis, 
                // entonces hay paréntesis sin la pareja correspondiente.
                if (operator1 is OpenParenthesis || operator1 is ClosedParenthesis)
                {
                    MSharpErrors.OnError("Hay paréntesis sin la pareja correspondiente.");
                    return null;
                }
                    

                queueOut.Enqueue(stackOperators.Pop());
            }

            return queueOut;
        }

        private static void Get_Precedence_Associatity(Function operator1,Function operator2)
        {
 	          #region Activar Propiedades operador1

               Type oper1Type = operator1.GetType();

               PropertyInfo propertyAssociativeOper1 = oper1Type.GetProperty("Associative");
               PropertyInfo propertyPrecedenceOper1 = oper1Type.GetProperty("Precedence");


               MethodInfo method_propertyAssociativeOper1 = propertyAssociativeOper1.GetGetMethod();
               MethodInfo method_propertyPrecedenceOper1 = propertyPrecedenceOper1.GetGetMethod();

               associativityOper1 = (bool)method_propertyAssociativeOper1.Invoke(operator1, null);
               precedenceOper1 = (int)method_propertyPrecedenceOper1.Invoke(operator1, null);

               #endregion

              #region Activar Propiedades operador2

               Type oper2Type = operator2.GetType();

               PropertyInfo propertyAssociativeOper2 = oper2Type.GetProperty("Associative");
               PropertyInfo propertyPrecedenceOper2 = oper2Type.GetProperty("Precedence");
               PropertyInfo propertyArityOper2 = oper2Type.GetProperty("Arity");

               MethodInfo method_propertyAssociativeOper2 = propertyAssociativeOper2.GetGetMethod();
               MethodInfo method_propertyPrecedenceOper2 = propertyPrecedenceOper2.GetGetMethod();
               MethodInfo method_propertyArityOper2 = propertyArityOper2.GetGetMethod();

               associativityOper2 = (bool)method_propertyAssociativeOper2.Invoke(operator2, null);
               precedenceOper2 = (int)method_propertyPrecedenceOper2.Invoke(operator2, null);
               arityOper2 = (int)method_propertyArityOper2.Invoke(operator2, null);

                #endregion
        }



        private static Function CastOperator(Function function)
        {
            //Inicializar el operador a devolver
            Function operatorToReturn = new ConstantArithmetic(0);

            if (function is RelationFunctionArithmetic)
                operatorToReturn = function as RelationFunctionArithmetic;

            else if (function is RelationFunctionBoolean)
                operatorToReturn = function as RelationFunctionBoolean;

            else if (function is LocalFunction)
                operatorToReturn = function as LocalFunction;

            else if (function is SpecialOperator)
                operatorToReturn = function as SpecialOperator;

            return operatorToReturn;

        }

        //Evalua en posfijo usando Notacion Polaca Inversa
        private static Function RPN(Queue<Function> expression_Postfix)
        {
            if(expression_Postfix != null)
            {
                Stack<Function> auxStack = new Stack<Function>();

                #region Recorrer cada token de la expresion
                foreach (Function token in expression_Postfix)
                {
                    //si es un operando
                    if (!(token is RelationFunctionArithmetic) && !(token is RelationFunctionBoolean) && !(token is LocalFunction))
                    {
                        auxStack.Push(token);
                    }

                    //si es un operador
                    else
                    {
                        //Inicializar variable
                        Function operator1 = new ConstantArithmetic(0);

                        if (token is RelationFunctionArithmetic)
                        {
                            operator1 = token as RelationFunctionArithmetic;
                        }

                        if (token is RelationFunctionBoolean)
                        {
                            operator1 = token as RelationFunctionBoolean;
                        }

                        if (token is LocalFunction)
                        {
                            operator1 = token as LocalFunction;
                        }

                        GetArityOperator(operator1);
                        //comprobar que existan la cantidad necesaria de operandos para trabajar con cierto operador
                        if (arityOper1 > auxStack.Count)
                        {
                            MSharpErrors.OnError(string.Format("Insuficientes operandos para el operador {0}", token.ToString()));
                            return null;
                        }



                        else
                        {
                            //Inicializar Variable con cualquier valor
                            Function result = new ConstantArithmetic(0);

                            #region Sacar operandos de la pila e introducirlos en ella despues de operarlos
                            //Guardar en array los operandos a procesar
                            //Se crea array de tamaño de la aridad del operador
                            object[] parametersOperand = new object[arityOper1];

                            //Asignar los operandos
                            for (int i = parametersOperand.Length - 1; i >= 0; i--)
                                parametersOperand[i] = auxStack.Pop();

                            //Obtener el tipo de operador
                            Type typeOperator1 = operator1.GetType();

                            //
                            Type[] parameterConstructor = new Type[parametersOperand.Length];

                            if (token is RelationFunctionArithmetic)
                            {
                                for (int i = 0; i < parameterConstructor.Length; i++)
                                    parameterConstructor[i] = typeof(FunctionArithmetic);
                            }

                            else if (token is LocalFunction)
                            {
                                for (int i = 0; i < parameterConstructor.Length; i++)
                                    parameterConstructor[i] = typeof(LocalFunction);
                            }

                            else if (token is Relational)
                            {
                                for (int i = 0; i < parameterConstructor.Length; i++)
                                    parameterConstructor[i] = typeof(FunctionArithmetic);
                            }

                                //Es Operador Lógico
                            else
                            {
                                for (int i = 0; i < parameterConstructor.Length; i++)
                                    parameterConstructor[i] = typeof(FunctionBoolean);
                            }

                            ConstructorInfo info = typeOperator1.GetConstructor(parameterConstructor);

                            if (token is LocalFunction)
                            {
                                result = new LocalFunction(token.ToString(), parametersOperand[0] as FunctionArithmetic);
                            }

                            else if (token is RelationFunctionArithmetic)
                            {
                                result = (RelationFunctionArithmetic)info.Invoke(parametersOperand);
                            }

                            //Si es FunctionBoolean
                            else if (token is FunctionBoolean)
                            {
                                result = (RelationFunctionBoolean)info.Invoke(parametersOperand);
                            }

                            else
                            {
                                MSharpErrors.OnError("Compilation Error");
                                return null;
                            }


                            #endregion
                            auxStack.Push(result);
                        }

                    }

                }
                #endregion

                //Si la pila contiene solo un elemento, entonces ese es el resultado de la expresion
                if (auxStack.Count == 1)
                {
                    Function toReturn = auxStack.Pop();
                    return toReturn;
                }
                
            }

            MSharpErrors.OnError("Se ha introducido de manera incorrecta la expresion");
            return null;

            
        }

        private static void GetArityOperator(Function operator1)
        {
            Type oper1Type = operator1.GetType();
            PropertyInfo propertyArityOper1 = oper1Type.GetProperty("Arity");
            MethodInfo method_propertyArityOper1 = propertyArityOper1.GetGetMethod();
            arityOper1 = (int)method_propertyArityOper1.Invoke(operator1, null);
        }

    }
}
