namespace Phonebook.Command
{
    public class ChangePhoneCommand : IPhonebookCommand
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
            var currentPhoneNumber = this.sanitizer.Sanitize(arguments[0]);
            var newPhoneNumber = this.sanitizer.Sanitize(arguments[1]);
            var phoneNumbersChanged = this.data.ChangePhone(currentPhoneNumber, newPhoneNumber);
            var output = phoneNumbersChanged + " numbers changed";

            this.printer.Print(output);
        }
    }
}
