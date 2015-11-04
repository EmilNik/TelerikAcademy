//Write a program that reads a sequence of integers(List<int>) ending with an empty line and sorts them in an increasing order.

namespace _03.ReadIntsFromConsoleAndSortThem
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        static void Main()
        {
            //Write numbers on different lines and add an empty line to continue
            var list = ReadNumbersFromConsoleAndReturnList();

            list = SortList(list);

            foreach (var item in list)
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

        static IList<int> SortList(IList<int> sequence)
        {
            var length = sequence.Count;
            var isSorted = true;

            for (int i = 0; i < length - 1; i++)
            {
                isSorted = true;
                for (int j = 0; j < length - 1 - i; j++)
                {
                    if (sequence[j] > sequence[j + 1])
                    {
                        sequence[j] = sequence[j] ^ sequence[j + 1];
                        sequence[j + 1] = sequence[j] ^ sequence[j + 1];
                        sequence[j] = sequence[j] ^ sequence[j + 1];
                        isSorted = false;
                    }
                }

                if (isSorted)
                {
                    return sequence;
                }
            }

            return sequence;
        }
    }
}
