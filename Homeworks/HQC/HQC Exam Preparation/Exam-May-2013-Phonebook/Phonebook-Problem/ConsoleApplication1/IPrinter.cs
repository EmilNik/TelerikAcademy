using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    interface IPrinter
    {
        void Print(string text);

        string GetAllText();
    }
}
