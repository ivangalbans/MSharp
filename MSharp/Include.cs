using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Reflection;

namespace MSharp
{
    /// <summary>
    /// Comando que incluye modulos a compilar.
    /// </summary>
    public class Include : Statement, IExecutable
    {
        //Almacena el codigo cargado del modulo
        string allCode; 

        //Metodo que carga el modulo guardado
        private bool LoadFile(string fileName)
        {

            //Se crea un objeto de la Clase FileInfo, pasándole como parámetro el nombre del archivo
            //sobre el cual queremos trabajar
            FileInfo moduleInfo = new FileInfo(fileName);

            //Verificar q exista el fichero
            if (!moduleInfo.Exists)
            {
                MSharpErrors.OnError(string.Format("No existe el modulo {0}", fileName));
                return false;
            }  

            //Cargar en un RichTextBox el fichero fileName guardado en formato RTF
            RichTextBox rtbLoadFile = new RichTextBox();

            rtbLoadFile.LoadFile(fileName);
            allCode = rtbLoadFile.Text;

            return true;
        }


        private bool SyntacticAnalysis(List<Expression> instruction)
        {
            //Comprobar que exista solo un elemento luego del include
            if (instruction.Count != 1)
            {
                MSharpErrors.OnError("Despues de include solo puede existir un nombre de modulo");
                return false;
            }
                

            //Comprobar que sea tipo Text
            if(!(instruction[0] is Text))
            {
                MSharpErrors.OnError("Compilation Error. Nombre de modulo invalido");
                return false;
            }
                

            //Comprobar que no sea una variable de texto y si solo un string ("Example")
            if ( (instruction[0] as Text).isOnlyText == false)
            {
                MSharpErrors.OnError("Compilation Error. include recibe una cadena de texto y no un literal tipo string");
                return false;
            }
                

            return LoadFile((instruction[0] as Text).Value);
        }


        public void Execute(List<Expression> instruction)
        {
            //Eliminar keyword de tipo IExecutable. No lo necesito para compilar.
            instruction.RemoveAt(0);

            if(SyntacticAnalysis(instruction))
            {
                Compiler._isInclude = true;
                Compiler module = new Compiler(allCode);
                
                Form temp = Display._frmRead;

                Type type = temp.GetType();
                Type[] paramsTypes = new Type[] { typeof(Compiler)};
                ConstructorInfo constructor = type.GetConstructor(paramsTypes);

                object[] param = new object[] { module};

                object instanceFormRead = constructor.Invoke(param);

                MethodInfo methodShowDialog = type.GetMethod("Activar");

                while (module.Begin())
                {
                    if (module._isRead)
                        methodShowDialog.Invoke(instanceFormRead, null);
                }

                Compiler._isInclude = false;
            }

        }


        public override string ToText
        {
            get { return "include"; }
        }
    }
}
