using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    class StringBuilderPrinter : IPrinter
    {
        StringBuilder output = new StringBuilder();

        public void Print(string text)
        {
            output.AppendLine(text);
        }

        public string GetAllText()
        {
            return output.ToString();
        }
    }
}
