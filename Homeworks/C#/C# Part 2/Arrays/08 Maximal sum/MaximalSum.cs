using System;

class MaxSumSequence
{
    static void Main()
    {
        //Write a program that finds the sequence of maximal sum in given array.

        Console.Write("Enter number of elements: ");
        int length = int.Parse(Console.ReadLine());

        int[] array = new int[length];
        for (int i = 0; i < length; i++)
        {
            Console.Write("Enter element {0}: ", i);
            array[i] = int.Parse(Console.ReadLine());
        }

        int maxSum = array[0]; 
        int currentSum = array[0];
        int start = 0; 
        int startTemp = 0;
        int end = 0;

        for (int i = 1; i < array.Length; i++)
        {
            currentSum += array[i];
            if (currentSum < array[i])
            {
                currentSum = array[i];
                startTemp = i;
            }
            if (currentSum > maxSum)
            {
                maxSum = currentSum;
                start = startTemp;
                end = i;
            }
        }

        Console.Write("The sequence with maximal sum is: ");
        for (int i = start; i <= end; i++)
        {
            Console.Write("{0} ", array[i]);
        }

        Console.WriteLine();
    }
}