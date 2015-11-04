//Write a program that removes from given sequence all negative numbers.

namespace _05.RemoveNegativeNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        static void Main()
        {
            var list = ReadNumbersFromConsoleAndReturnList();

            var positiveList = RemoveNegativeNumbers(list);

            Console.WriteLine("Positive numbers:");

            foreach (var item in positiveList)
            {
                Console.WriteLine(item);
            }
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

        static IList<int> RemoveNegativeNumbers(IList<int> list)
        {
            list = list.Where(i => i >= 0).ToList();

            return list;
        }
    }
}
