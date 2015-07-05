using System;
using System.Collections.Generic;

class CompareArrays
{
    static void Main()
    {
        //Write a program that reads two integer arrays from the console and compares them element by element.

        Console.Write("Enter the lenght of the first array: ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Enter the lenght of the second array: ");
        int m = int.Parse(Console.ReadLine());

        string[] firstArray = new string[n];
        string[] secondArray = new string[m];

        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter the {0} element of the first array: ", i);
            firstArray[i] = Console.ReadLine();
        }

        for (int i = 0; i < m; i++)
        {
            Console.Write("Enter the {0} element of the second array: ", i);
            secondArray[i] = Console.ReadLine();
        }

        for (int i = 0; i < Math.Min(n, m); i++)
        {
            if (firstArray[i] == secondArray[i])
            {
                Console.WriteLine("{0}. {1} is the same as {2}.", i + 1, firstArray[i], secondArray[i]);
            }

            else
            {
                Console.WriteLine("{0}. {1} is NOT the same as {2}.", i + 1, firstArray[i], secondArray[i]);
            }
        }
    }
}
