namespace Phonebook
{
    using Command;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class PhonebookEntryPoint
    {
        private static IPhonebookRepository data = new REPNew(); // this works!
        static void Main()
        {
            IPrinter printer = new StringBuilderPrinter();
            IPhonebookSanitizer sanitizer = new PhonebookSanitizer();

            while (true)
            {
                string userLine = Console.ReadLine();

                if (userLine == "End" || userLine == null)
                {
                    // Error reading from console 
                    break;
                }

                int i = userLine.IndexOf('('); if (i == -1) { Console.WriteLine("error!"); Environment.Exit(0); }

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

                IPhonebookCommand command;

                if ((k.StartsWith("AddPhone")) && (strings.Length >= 2))
                {
                    command = new AddPhoneCommand(printer, data, sanitizer);
                }
                else if ((k == "ChangePhone") && (strings.Length == 2))
                {
                    command = new ChangePhoneCommand(printer, data, sanitizer);
                }
                else if ((k == "List") && (strings.Length == 2))
                {
                    command = new ListPhonesCommand(printer, data, sanitizer);
                }
                else
                {
                    throw new ArgumentException("Invalid command!");
                }

                command.Execute(strings);
            }
            Console.Write(printer.GetAllText());
        }
    }
}
