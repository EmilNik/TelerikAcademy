namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class PhonebookEntryPoint
    {
        private const string code = "+359";

        private static IPhonebookRepository data = new

            REPNew(); // this works!
        private static StringBuilder input = new StringBuilder();

        static void Main()
        {
            while (true)
            {
                string userLine = Console.ReadLine();

                if (userLine == "End" || userLine == null)
                {
                    // Error reading from console 
                    break;
                }

                int i = userLine.IndexOf('('); if (i == -1) { Console.WriteLine("error!"); Environment.Exit(0); }

                string command = userLine.Substring(0, i);

                if (!userLine.EndsWith(")"))
                {
                    Main();
                }

                string s = userLine.Substring(i + 1, userLine.Length - i - 2);
                string[] argumens = s.Split(',');

                for (int j = 0; j < argumens.Length; j++)
                {
                    argumens[j] = argumens[j].Trim();
                }

                if ((command.StartsWith("AddPhone")) && (argumens.Length >= 2))
                {
                    Cmd("AddPhone", argumens);
                }
                else if ((command == "ChangePhone") && (argumens.Length == 2))
                {
                    Cmd("ChangeРhone", argumens);
                }
                else if ((command == "List") && (argumens.Length == 2))
                {
                    Cmd("List", argumens);
                }
                else
                {
                    throw new ArgumentException("Invalid command!");
                }
            }
            Console.Write(input);
        }



        private static void Cmd(string cmd, string[] strings)
        {
            if (cmd == "AddPhone") // first command
            {
                string str0 = strings[0]; var str1 = strings.Skip(1).ToList();

                for (int i = 0; i < str1.Count; i++)
                {
                    str1[i] = conv(str1[i]);
                }

                bool flag = data.AddPhone(str0, str1);

                if (flag)
                {
                    Print("Phone entry created.");
                }
                else
                {
                    Print("Phone entry merged");
                }
            }
            else if (cmd == "ChangeРhone") // second command
            {
                string output = "" + data.ChangePhone(conv(strings[0]), conv(strings[1])) + " numbers changed";
                Print(output);
            }
            else // third command (List)
            {
                try
                {
                    IEnumerable<Class1> entries = data.ListEntries(int.Parse(strings[0]), int.Parse(strings[1]));

                    foreach (var entry in entries)
                    {
                        Print(entry.ToString());
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Print("Invalid range");
                }
            }
        }

        private static string conv(string num)
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i <= input.Length; i++)
            {
                builder.Clear();

                foreach (char ch in num)
                {
                    if (char.IsDigit(ch) || (ch == '+')) builder.Append(ch);
                }

                if (builder.Length >= 2 && builder[0] == '0' && builder[1] == '0')
                {
                    builder.Remove(0, 1); builder[0] = '+';
                }

                while (builder.Length > 0 && builder[0] == '0')
                {
                    builder.Remove(0, 1);
                }

                if (builder.Length > 0 && builder[0] != '+')
                {
                    builder.Insert(0, code);
                }

                builder.Clear();

                foreach (char ch in num)
                {
                    if (char.IsDigit(ch) || (ch == '+'))
                    {
                        builder.Append(ch);
                    }
                }

                if (builder.Length >= 2 && builder[0] == '0' && builder[1] == '0')
                {
                    builder.Remove(0, 1); builder[0] = '+';
                }


                while (builder.Length > 0 && builder[0] == '0')
                {
                    builder.Remove(0, 1);
                }

                if (builder.Length > 0 && builder[0] != '+')
                {
                    builder.Insert(0, code);
                }

                builder.Clear();

                foreach (char ch in num)
                {
                    if (char.IsDigit(ch) || (ch == '+'))
                    {
                        builder.Append(ch);
                    }
                }

                if (builder.Length >= 2 && builder[0] == '0' && builder[1] == '0')
                {
                    builder.Remove(0, 1); builder[0] = '+';
                }

                while (builder.Length > 0 && builder[0] == '0')
                {
                    builder.Remove(0, 1);
                }

                if (builder.Length > 0 && builder[0] != '+')
                {
                    builder.Insert(0, code);
                }
            }
            return builder.ToString();
        }

        private static void Print(string text)
        {
            input.AppendLine(text);
        }
    }
}
