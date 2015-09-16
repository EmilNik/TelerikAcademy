namespace Phonebook
{
    using System;
    using System.Linq;
    using Command;

    public static class PhonebookEntryPoint
    {
        public static void Main()
        {
            IPhonebookRepository data = new PhonebookRepository();
            IPrinter printer = new StringBuilderPrinter();
            IPhonebookSanitizer sanitizer = new PhonebookSanitizer();

            ICommandFactory commandFactory = new CommandFactoryWithLazyLoading(data, printer, sanitizer);
            ICommandParser commandParser = new CommandParser();

            while (true)
            {
                string userLine = Console.ReadLine();

                if (userLine == "End" || userLine == null)
                {
                    // Error reading from console 
                    break;
                }

                var commandInfo = commandParser.Parse(userLine);

                IPhonebookCommand command = commandFactory.CreateCommand(commandInfo.CommandName, commandInfo.Arguments.Count());

                command.Execute(commandInfo.Arguments.ToArray());
            }

            printer.Accept(new ConsolePrinterVisitorWithNewLine());
        }
    }
}
