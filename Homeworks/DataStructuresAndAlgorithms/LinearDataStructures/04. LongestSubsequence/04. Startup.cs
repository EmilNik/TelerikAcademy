namespace _04.LongestSubsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        static void Main()
        {
            var list = ReadNumbersFromConsoleAndReturnList();

            var longestSubsequence = FindLongestSubsequence(list);

            Console.WriteLine("Longest subsequence:");

            foreach (var item in longestSubsequence)
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

        static IList<int> FindLongestSubsequence(IList<int> list)
        {
            int maxNumber = 0;
            int currentNumber = 0;
            int maxCount = 1;
            int currentCount = 1;

            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i] == list[i + 1])
                {
                    currentNumber = list[i];
                    currentCount++;

                    if (maxCount < currentCount)
                    {
                        maxCount = currentCount;
                        maxNumber = currentNumber;
                    }
                }
                else if (maxCount <= currentCount)
                {
                    currentCount = 1;
                }
            }

            List<int> longestSequence = new List<int>();
            if (maxCount == 1)
            {
                return longestSequence;
            }

            for (int i = 0; i < maxCount; i++)
            {
                longestSequence.Add(maxNumber);
            }

            return longestSequence;
        }
    }
}
