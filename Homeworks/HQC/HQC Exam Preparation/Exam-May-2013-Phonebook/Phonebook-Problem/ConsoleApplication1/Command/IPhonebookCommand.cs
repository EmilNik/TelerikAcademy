using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Command
{
    interface IPhonebookCommand
    {
        void Execute(string[] argumens);
    }
}
