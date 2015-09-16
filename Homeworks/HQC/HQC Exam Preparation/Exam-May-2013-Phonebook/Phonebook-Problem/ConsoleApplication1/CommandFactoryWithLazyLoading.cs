namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Phonebook.Command;

    public class CommandFactoryWithLazyLoading : ICommandFactory
    {
        private IPhonebookRepository data;
        private IPrinter printer;
        private IPhonebookSanitizer sanitizer;
        private IPhonebookCommand addCommand;
        private IPhonebookCommand changeCommand;
        private IPhonebookCommand listCommand;

        public CommandFactoryWithLazyLoading(IPhonebookRepository data, IPrinter printer, IPhonebookSanitizer sanitizer)
        {
            this.data = data;
            this.printer = printer;
            this.sanitizer = sanitizer;
        }

        public IPhonebookCommand CreateCommand(string commandName, int argumentsCount)
        {
            IPhonebookCommand command;

            if (commandName.StartsWith("AddPhone") && (argumentsCount >= 2))
            {
                if (this.addCommand == null)
                {
                    this.addCommand = new AddPhoneCommand(this.printer, this.data, this.sanitizer);
                }

                command = this.addCommand;
            }
            else if ((commandName == "ChangePhone") && (argumentsCount == 2))
            {
                if (this.changeCommand == null)
                {
                    this.changeCommand = new ChangePhoneCommand(this.printer, this.data, this.sanitizer);
                }

                command = this.changeCommand;
            }
            else if ((commandName == "List") && (argumentsCount == 2))
            {
                if (this.listCommand == null)
                {
                    this.listCommand = new ListPhonesCommand(this.printer, this.data);
                }

                command = this.listCommand;
            }
            else
            {
                throw new ArgumentException("Invalid command!");
            }

            return command;
        }
    }
}
