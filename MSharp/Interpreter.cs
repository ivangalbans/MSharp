using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tokenizing;

namespace MSharp
{
    /// <summary>
    /// Clase Interpreter, utilizada para interpretar el texto insertado por el usuario y establecer a cada token el objeto 
    /// correspondiente en el lenguaje M#, para que el codigo pueda ser compilado
    /// </summary>
    public class Interpreter
    {
        //Determina si el operador unario (+-) estan en correcta posicion 
        private static bool isOKPosicion_OperatorUnary_Sign(List<Expression> tokensUntilMoment)
        {
            //Si esta al inicio
            if (tokensUntilMoment.Count == 0)
                return true;

            //Si tiene otro operador antes
            Expression lastToken = tokensUntilMoment[tokensUntilMoment.Count-1];
            if ((lastToken is SpecialOperator && !(lastToken is ClosedParenthesis)) || (lastToken is Statement) 
                    || (lastToken is RelationFunctionArithmetic && !(lastToken is UnaryFunction)) ||
                        (lastToken is RelationFunctionBoolean && !(lastToken is UnaryOperator)) )
                return true;

            return false;
        }

        //Determina si los operadores relacionales compuestos(==, <=, >=, !=) estan en correcta posicion
        private static bool isOKPosicion_Operator_RelationalComposite(List<Expression> tokensUntilMoment)
        {
            if(tokensUntilMoment.Count != 0)
            {
                Expression lastToken = tokensUntilMoment[tokensUntilMoment.Count - 1];
                if (lastToken is RelationalSimple || lastToken is NegationLogic || lastToken is Assign) 
                    return true;
            }
            return false;
        }


        /// <summary>
        /// Analiza e interpreta los token
        /// </summary>
        /// <param name="tokens"> Tokens a interpretar</param>
        /// <returns>Una lista con objetos del lenguaje M#</returns>
        public static List<Expression> Analize(IEnumerable<Token> tokens)
        {
            List<Expression> toReturn = new List<Expression>();
            

            foreach(var item in tokens)
            {

                if (item.Text == "(" && toReturn.Count != 0)
                    if (toReturn[toReturn.Count - 1] is Literal)
                        toReturn[toReturn.Count - 1] = new LocalFunction(toReturn[toReturn.Count - 1].ToString());

                if(item.Type == TokenKind.Unknown)
                {
                    MSharpErrors.OnError(string.Format("{0} es un simbolo desconocido", item.Text));
                }

                else if ( (item.Text == "+" || item.Text == "-") && isOKPosicion_OperatorUnary_Sign(toReturn))
                {
                    toReturn.Add(Memory.MSharpTypes[item.Text + "unary"]);
                }

                else if( item.Text == "=" && isOKPosicion_Operator_RelationalComposite(toReturn) )
                {
                    Expression lastToken = toReturn[toReturn.Count - 1]; 
                    toReturn[toReturn.Count - 1] = (Memory.MSharpTypes[lastToken.ToString() + "="]);   
                }
                
                else if (item.Type == TokenKind.Symbol || item.Type == TokenKind.Keyword)
                    toReturn.Add(Memory.MSharpTypes[item.Text]);

                else if (item.Type == TokenKind.Number)
                {
                    //float floatNumber = float.Parse(item.Text);//Change_Dot_by_Comma(item.Text));
                    toReturn.Add(new ConstantArithmetic(float.Parse(item.Text)));
                }

                else if (item.Type == TokenKind.Text)
                {

                    if (toReturn.Count > 2)
                        if (toReturn[toReturn.Count - 2] is Literal)
                            toReturn[toReturn.Count - 2] = new Text(toReturn[toReturn.Count - 2].ToString(), item.Text);

                    toReturn.Add(new Text(item.Text, true));
                }
                    
                else if (item.Type == TokenKind.Identifier)
                    toReturn.Add(new Literal(item.Text));

            }
            return toReturn;
        }

        private static string Change_Dot_by_Comma(string number)
        {
            StringBuilder temp = new StringBuilder(number);
            
            for (int i = 0; i < temp.Length; i++)
                if (temp[i] == '.')
                    temp[i] = ',';

            return temp.ToString();
        }


    }
}
