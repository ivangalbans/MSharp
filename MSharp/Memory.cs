using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using XControls;
using System.Reflection;
using System.IO;


namespace MSharp
{
    /// <summary>
    /// Clase referente al manejo de la memoria del programa
    /// </summary>
    public class Memory
    {
        internal static Dictionary<string, float> DataVariable;
        internal static Dictionary<string, string> DataText;
        internal static Dictionary<string, FunctionArithmetic> DataFunction;
        public static Dictionary<string, Expression> MSharpTypes;

        private static void InitilizeMemory()
        {
            DataVariable = new Dictionary<string, float>();
            DataFunction = new Dictionary<string, FunctionArithmetic>();
            MSharpTypes = new Dictionary<string, Expression>();
            DataText = new Dictionary<string, string>();
        }

        public static void InitializeTypes()
        {
            InitilizeMemory();
            LoadMSharpTypes();
        }


        //Carga usando Reflection todos los tipos de los emsamblados del Proyecto
        private static void LoadMSharpTypes()
        {
            //Obtener directorio actual
            DirectoryInfo dir = new DirectoryInfo(Directory.GetCurrentDirectory());

            //Cargar todos los ensamblados
            foreach (var file in dir.GetFiles("*.dll"))
            {
                
                var instances = InvokerClass<Expression>.FetchInstance(file.FullName);

                foreach (var item in instances)
                {
                    Type type = item.GetType();

                    PropertyInfo propertyToText = type.GetProperty("ToText");
                    MethodInfo method_PropertyToTex = propertyToText.GetGetMethod();
                    
                    string representationText = (method_PropertyToTex.Invoke(item, null)).ToString();

                    Memory.MSharpTypes.Add(representationText, item);
                }
            }
        }

        /// <summary>
        /// Clase que contiene metodo para obtener intancias de tipos dado un ensamblado
        /// </summary>
        /// <typeparam name="T"> Tipos Expression del lenguaje M#</typeparam>
        private static class InvokerClass<T> where T : Expression
        {
            /// <summary>
            /// Metodo que obtiene intancias de tipos que implementan la propiedad ToText
            /// </summary>
            /// <param name="clientCode">Nombre del ensamblado que se esta analizando</param>
            /// <returns>Las instancias de clases que contienen cierta propiedad</returns>
            public static IEnumerable<T> FetchInstance(string clientCode)
            {
                var clientAssembly = Assembly.LoadFrom(clientCode);

                foreach (var item in clientAssembly.GetTypes())
                {

                    PropertyInfo propertyToText = item.GetProperty("ToText");

                    if (item.IsClass && !item.IsAbstract && propertyToText != null)
                        yield return (T)clientAssembly.CreateInstance(item.FullName);
                }
            }
        }



        //Busca si en los datos guardados existe algun tipo con este mismo nombre.
        //Para evitar distintos tipos con el mismo nombre.
        internal static bool ExistName(string name)
        {
            return (DataVariable.ContainsKey(name) || DataText.ContainsKey(name) || DataFunction.ContainsKey(name));
        }

        #region Text
        internal static void SaveText(string nameVariable, string text)
        {
            if (AnalizeText(nameVariable, text) == false)
                return;

            if (ExistName(nameVariable))
            {
                MSharpErrors.OnError(string.Format("Existe ya otro tipo con el nombre {0}", nameVariable));
                return;
            }
            Memory.DataText.Add(nameVariable,text);
        }

        private static bool AnalizeText(string nameVariable, string text)
        {
            if (nameVariable == null || text == null)
            {
                if (nameVariable == null)
                    MSharpErrors.OnError(string.Format("Compilation Error. Nombre de Literal {0} no puede ser null", nameVariable));
                else
                    MSharpErrors.OnError(string.Format("Compilation Error. El texto: {0} no puede ser null", text));
                return false;
            }
            return true;
        }

        internal static void ChangeText(string name, string text)
        {
            if (AnalizeText(name, text) == false)
                return;

            if (!DataText.ContainsKey(name))
            {
                MSharpErrors.OnError(string.Format("El Literal {0} no ha sido declarado", name));
                return;
            }
                
            Memory.DataText[name] = text;
        }

        private static bool AnalizeVariable(string name)
        {
            if (name == null)
            {
                MSharpErrors.OnError(string.Format("La variable {0} no ha sido declarada", name));
                return false;
            }
            return true;
        }

        internal static string GetText(string name)
        {
            if (AnalizeVariable(name) == false)
                return null;

            if (!DataText.ContainsKey(name))
            {
                MSharpErrors.OnError(string.Format("La variable {0} no ha sido declarada", name));
                return null;
            }
                
            return DataText[name];
        }

        #endregion

        #region Variables
        internal static void SaveVariable(string name, float number)
        {
            if (AnalizeVariable(name) == false)
                return;

            if (ExistName(name))
            {
                MSharpErrors.OnError(string.Format("Existe ya otro tipo con el nombre {0}", name));
                return;
            }
                
            Memory.DataVariable.Add(name, number);
        }

        internal static float GetVariable(string name)
        {
            if (AnalizeVariable(name) == false)
                return 0;

            if (name == null)
            {
                MSharpErrors.OnError(string.Format("Compilation Error. Nombre de variable no puede ser null", name));
                return 0;
            }

            if(!DataVariable.ContainsKey(name))
            {
                MSharpErrors.OnError(string.Format("La variable {0} no ha sido declarada", name));
                return 0;
            }
                
            return DataVariable[name];
        }

        public static void ChangeVariable(string name, float number)
        {
            if (AnalizeVariable(name) == false)
                return;

            if(name == null)
            {
                MSharpErrors.OnError(string.Format("Compilation Error. Nombre de variable no puede ser null", name));
                return;
            }

            if (!DataVariable.ContainsKey(name))
            {
                MSharpErrors.OnError(string.Format("La variable {0} no ha sido declarado", name));
                return;
            }
                
            Memory.DataVariable[name] = number;
        }

        #endregion
        
        #region Funciones
        internal static void SaveFunction(string name, FunctionArithmetic function)
        {
            if (AnalizeFunction(name, function) == false)
                return;

            if (ExistName(name))
            {
                MSharpErrors.OnError(string.Format("Existe ya otro tipo con el nombre {0}", name));
                return;
            }
                
            Memory.DataFunction.Add(name, function);
        }

        internal static FunctionArithmetic GetFunction(string name)
        {
            if (name == null)
            {
                MSharpErrors.OnError(string.Format("El nombre de funcion {0} no puede ser null", name));
                return null;
            }

            if (!DataFunction.ContainsKey(name))
            {
                MSharpErrors.OnError(string.Format("La funcion {0} no ha sido declarada", name));
                return null;
            }
                
            return DataFunction[name];
        }

        private static bool AnalizeFunction(string name, FunctionArithmetic function)
        {
            if (name == null || function == null)
            {
                if (name == null)
                    MSharpErrors.OnError(string.Format("Compilation Error. Nombre de variable no puede ser null", name));
                else
                    MSharpErrors.OnError(string.Format("Compilation Error. La funcion {0} no puede ser null", name));
                return false;
            }
            return true;
        }


        #endregion

    }
}
