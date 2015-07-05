using System;
using System.Linq;

class MaximalKSum
{
    static void Main()
    {
        //Write a program that reads two integer numbers N and K and an array of N elements from the console.
        //Find in the array those K elements that have maximal sum.


        Console.Write("Enter number of elements: ");
        int n = int.Parse(Console.ReadLine());

        int[] array = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter element {0}: ", i);
            array[i] = int.Parse(Console.ReadLine());
        }
        Console.Write("Enter number of elements to sum: ");
        int k = int.Parse(Console.ReadLine());

        int maxSum = int.MinValue;
        int currentSum = 0;
        int firstOfSequence = 0;

        for (int index = 0; index < n + 1 - k; index++)
        {
            for (int add = 0; add < k; add++)
            {
                currentSum += array[index + add];
            }
            if (currentSum > maxSum)
            {
                maxSum = currentSum;
                firstOfSequence = index;
            }
            currentSum = 0;
        }

        Console.Write("The {0} consecutive elements with maximum sum are: ", k);
        for (int index = firstOfSequence; index < firstOfSequence + k; index++)
        {
            Console.Write("{0} ", array[index]);
        }
        Console.WriteLine();
    }
}
