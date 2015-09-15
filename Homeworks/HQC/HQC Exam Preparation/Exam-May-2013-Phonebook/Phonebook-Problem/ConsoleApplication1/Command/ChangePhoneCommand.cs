using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Command
{
    class ChangePhoneCommand : IPhonebookCommand
    {
        private IPrinter printer;
        private IPhonebookRepository data;
        private IPhonebookSanitizer sanitizer;

        public ChangePhoneCommand(IPrinter printer, IPhonebookRepository data, IPhonebookSanitizer sanitizer)
        {
            this.printer = printer;
            this.data = data;
            this.sanitizer = sanitizer;
        }

        public void Execute(string[] arguments)
        {
            string output = "" + data.ChangePhone(sanitizer.Sanitize(arguments[0]), sanitizer.Sanitize(arguments[1])) + " numbers changed";
            printer.Print(output);
        }
    }
}
