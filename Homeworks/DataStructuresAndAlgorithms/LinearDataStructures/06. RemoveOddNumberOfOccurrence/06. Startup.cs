namespace _06.RemoveOddNumberOfOccurrence
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        static void Main()
        {
            var list = ReadNumbersFromConsoleAndReturnList();
        }

        static IList<int> ReadNumbersFromConsoleAndReturnList()
        {
            var list = new List<int>();
            var line = Console.ReadLine();

            while (line != string.Empty)
            {
                var number = 0;

                if (Int32.TryParse(line, out number))
                {
                    list.Add(number);
                }
                else
                {
                    Console.WriteLine("String could not be parsed.");
                }

                line = Console.ReadLine();
            }

            return list;
        }
    }
}
