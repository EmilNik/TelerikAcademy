using System;
using System.Linq;

class FrequentNumber
{
    static void Main()
    {
        //Write a program that finds the most frequent number in an array.

        Console.Write("Enter number of elements: ");
        int length = int.Parse(Console.ReadLine());
        int[] counter = new int[length];
        int[] array = new int[length];
        int largestCounter = 0;
        int index = 0;

        for (int i = 0; i < length; i++)
        {
            Console.Write("Enter element {0}: ", i);
            array[i] = int.Parse(Console.ReadLine());
            counter[array[i]]++;
        }

        for (int i = 0; i < length; i++)
        {
            if (counter[i] > largestCounter)
            {
                largestCounter = counter[i];
                index = i;
            }
        }

        Console.WriteLine("The most frequent number in the array is {0} ({1} times).", index, largestCounter);

    }
}
