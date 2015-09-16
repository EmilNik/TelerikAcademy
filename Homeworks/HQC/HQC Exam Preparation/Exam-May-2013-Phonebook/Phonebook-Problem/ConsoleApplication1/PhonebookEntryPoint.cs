namespace Phonebook
{
    using System;
    using Command;

    public static class PhonebookEntryPoint
    {
        public static void Main()
        {
            IPhonebookRepository data = new PhonebookRepository();
            IPrinter printer = new StringBuilderPrinter();
            IPhonebookSanitizer sanitizer = new PhonebookSanitizer();

            ICommandFactory commandFactory = new CommandFactoryWithLazyLoading(data, printer, sanitizer);

            while (true)
            {
                string userLine = Console.ReadLine();

                if (userLine == "End" || userLine == null)
                {
                    // Error reading from console 
                    break;
                }

                int i = userLine.IndexOf('(');

                if (i == -1)
                {
                    Console.WriteLine("error!");
                    Environment.Exit(0);
                }

                string k = userLine.Substring(0, i);

                if (!userLine.EndsWith(")"))
                {
                    Main();
                }

                string s = userLine.Substring(i + 1, userLine.Length - i - 2);
                string[] strings = s.Split(',');

                for (int j = 0; j < strings.Length; j++)
                {
                    strings[j] = strings[j].Trim();
                }

                IPhonebookCommand command = commandFactory.CreateCommand(k, strings.Length);

                command.Execute(strings);
            }

            Console.Write(printer.GetAllText());
        }
    }
}
