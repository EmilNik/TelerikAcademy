namespace Phonebook.Command
{
    using System.Linq;

    public class AddPhoneCommand : IPhonebookCommand
    {
        private IPrinter printer;
        private IPhonebookRepository data;
        private IPhonebookSanitizer sanitizer;

        public AddPhoneCommand(IPrinter printer, IPhonebookRepository data, IPhonebookSanitizer sanitizer)
        {
            this.printer = printer;
            this.data = data;
            this.sanitizer = sanitizer;
        }

        public void Execute(string[] arguments)
        {
            string name = arguments[0];
            var phoneNumbers = arguments.Skip(1).ToList();

            for (int i = 0; i < phoneNumbers.Count; i++)
            {
                phoneNumbers[i] = this.sanitizer.Sanitize(phoneNumbers[i]);
            }

            bool phoneEntryCreated = this.data.AddPhone(name, phoneNumbers);

            if (phoneEntryCreated)
            {
                this.printer.Print("Phone entry created");
            }
            else
            {
                this.printer.Print("Phone entry merged");
            }
        }
    }
}
