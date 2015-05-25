using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tokenizing;
using System.Windows.Forms;
using XControls;

namespace MSharp
{
    /// <summary>
    /// Clase que se encarga de ejecutar el proyecto.
    /// </summary>
    public class Compiler
    {
        //Cola que contiene el codigo que se ejecutara
        Queue<List<Expression>> codeToExecute;

        //Verdadero cuando el read fue escrito correctamente 
        public static bool _isOKRead;

        //Verdadero si se ha encontrado algun error
        public static bool _haveError;

        //Determina en que linea se encuentra un error
        public static int _lineError;

        //Verdadero si estoy analizando un modulo
        public static bool _isInclude;

        //Numero de la operacion que se va a ejecutar
        public int _indexOperation;

        //Verdadero cuando se activa un read
        public bool _isRead;


        //Contiene todo el codigo fuente
        IEnumerable<Token> tokens;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Compiler()
        {
            //Inicializacion

            _indexOperation = 0;
            _isRead = false;
            _isOKRead = false;

            Memory.DataFunction = new Dictionary<string,FunctionArithmetic>();
            Memory.DataText = new Dictionary<string,string>();
            Memory.DataVariable = new Dictionary<string,float>();
            codeToExecute = new Queue<List<Expression>>();

            Memory.MSharpTypes["true"] = new ConstantBoolean(true);
            Memory.MSharpTypes["false"] = new ConstantBoolean(false);

            LoadCode(Display._sourceCode.Text);
        }

        public Compiler(string tokens)
        {
            _indexOperation = 0;
            _isRead = false;
            _isOKRead = false;

            codeToExecute = new Queue<List<Expression>>();

            LoadCode(tokens);
        }

        //Analiza todo el codigo escrito y lo alamcena en una lista que contiene listas de expressiones
        //que posteriormente sera compilado linea a linea.
        public Queue<List<Expression>> GiveMeCode()
        {
            return codeToExecute;
        }
        
        public bool Begin()
        {
            bool flags = false;
            for (int i = 0; i < _indexOperation; i++)
            {
                codeToExecute.Dequeue();
                flags = true;
            }
            if (flags)
                this._indexOperation = 0;

            foreach (List<Expression> line  in codeToExecute)
            {
                if(line[0] is Read)
                {
                    this._isRead = true;
                    if (ExecuteKeyWord(line) && _isOKRead)
                    {
                        _indexOperation++;

                        return true;
                    }
                    else
                        _isRead = false;
                }

                else if(ExecuteKeyWord(line))
                {
                    _indexOperation++;

                }

            }

            return false;
        }


        public IEnumerable<IEnumerable<Token>> GetLineTokens()
        {
            int start = 0, end = 0;
            bool isFirstSeparator = false;

            //Recorrer todo el codigo en interpretarlo
            foreach (Token item in tokens)
            {

                if (item.Type != TokenKind.Separator)
                {
                    end++;
                    isFirstSeparator = true;
                }

                else if (isFirstSeparator)
                {
                    IEnumerable<Token> enumerable = tokens.Skip(start);
                    enumerable = enumerable.Take(end - start);

                    //ExecuteKeyWord(Interpreter.Analize(enumerable));

                    yield return enumerable;

                    start = end + 1;
                    end = start;
                    isFirstSeparator = false;
                }

                else
                {
                    end++;
                    start = end;
                }

            }


            //Por si quedo algun codigo sin guardar
            if (isFirstSeparator)
            {
                IEnumerable<Token> enumerable = tokens.Skip(start);
                enumerable = enumerable.Take(end - start);

                //ExecuteKeyWord(Interpreter.Analize(enumerable));
                codeToExecute.Enqueue(Interpreter.Analize(enumerable));
            }
        }

        //Libera todas las variables y funciones guardadas en memoria
        public static void Close()
        {
            Memory.DataFunction.Clear();
            Memory.DataText.Clear();
            Memory.DataVariable.Clear();
            Display.onActivateGraph = false;
            _isInclude = false;
            _isOKRead = false;
            _lineError = 0;
            _haveError = false;
        }


        //Ejecuta cada codigo dependiendo del keyword que se este analizando
        private bool ExecuteKeyWord(List<Expression> instruction)
        {
            if (!_isInclude)
                _lineError++;

            //Todas las lineas de codigo tienen que comenzar por un tipo keyword
            if (instruction[0] is IExecutable == false)
            {
                MSharpErrors.OnError(string.Format("{0} no es un comando valido", instruction[0].ToString()));
                return false;
            }

            //Si ya hubo algun error no ejecutar el codigo siguienteb
            if (_haveError == true)
                return false;

            (instruction[0] as IExecutable).Execute(instruction);

            return true;

        }
        /// <summary>
        /// Carga el codigo que se desea ejecutar
        /// </summary>
        /// <param name="allCode">Contiene el codigo</param>
        private void LoadCode(string allCode)
        {
            Tokenizer tokenizer = new Tokenizer();

            // Get a IEnumerable object of tokens
            tokens = tokenizer.GetTokens(allCode);


            foreach (IEnumerable<Token> line in GetLineTokens())
            {
                //Encolar las operaciones
                codeToExecute.Enqueue(Interpreter.Analize(line));
            }

        }

    }
}
