using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSharp
{
    /// <summary>
    /// Representa un tipo Literal de string
    /// </summary>
    public class Text : Expression
    {
        public string Name { get; private set; }
        public string Value { get; private set; }
        
        //Para diferenciar un texto de una variable tipo Text
        public bool isOnlyText { get; private set; }

        public Text() { }

        public Text(string text, bool onlyText)
        {
            Value = text;
            isOnlyText = onlyText;
        }

        public Text(string name, string text)
        {
            Name = name;
            Value = text;
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
