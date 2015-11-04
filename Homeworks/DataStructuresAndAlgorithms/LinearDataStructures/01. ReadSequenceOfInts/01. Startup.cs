//Write a program that reads from the console a sequence of positive integer numbers.

//The sequence ends when empty line is entered.
//Calculate and print the sum and average of the elements of the sequence.
//Keep the sequence in List<int>.

namespace _01.ReadSequenceOfInts
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        static void Main()
        {
            var list = new List<int>();
            string line;
            var count = 0;
            var sum = 0;

            line = Console.ReadLine();

            while (line != string.Empty)
            {
                var number = 0;

                if (Int32.TryParse(line, out number))
                {
                    list.Add(number);
                    sum += number;
                    count++;
                }
                else
                {
                    Console.WriteLine("String could not be parsed.");
                }

                line = Console.ReadLine();
            }

            var average = sum / count;

            Console.WriteLine("Total sum of all numbers: {0}\nAverage of all numbers: {1}", sum, average);

            Console.WriteLine("All numbers:");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }
    }
}
