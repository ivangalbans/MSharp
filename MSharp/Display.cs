using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XControls;


namespace MSharp
{
    /// <summary>
    /// Clase enlaza los controles y formularios del visual, con la logica del lenguaje
    /// </summary>
    public class Display
    {
        //Control donde se mostraran los datos de salida
        public static Control _output;

        //Control donde se encuentra el codigo fuente
        public static Control _sourceCode;

        //Formulario del area donde se grafican las funciones
        public static FunctionsViewer _fViewer;

        //Formulario donde se insertan los valores
        public static Form _frmRead;
        
        //Verdadero si existe un codigo graph
        public static bool onActivateGraph;

        /// <summary>
        /// Contructor de la clase Display
        /// </summary>
        /// <param name="SourceCode">Control donde se encuentra el codigo fuente</param>
        /// <param name="Output">Control donde se muestran los datos de salida</param>
        /// <param name="frmRead">Formulario que se activa ejecutar comando read para entrar numbers </param>
        /// <param name="fViewer">Tipo FunctionsViewer al cual se le adicionan las funciones a graficar</param>
        public Display(Control SourceCode, Control Output, Form frmRead, FunctionsViewer fViewer)
        {
            _output = Output;
            _sourceCode = SourceCode;
            _frmRead = frmRead;
            _fViewer = fViewer;
        }

    }
}
