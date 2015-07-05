using System;

class FindSumInArray
{
    static void Main()
    {
        //Write a program that finds in given array of integers a sequence of given sum S (if present).

        Console.Write("Enter number of elements: ");
        int length = int.Parse(Console.ReadLine());

        int[] array = new int[length];
        for (int i = 0; i < length; i++)
        {
            Console.Write("Enter element {0}: ", i);
            array[i] = int.Parse(Console.ReadLine());
        }

        Console.Write("Enter sum: ");
        int sum = int.Parse(Console.ReadLine());

        int currentSum = 0;
        bool sequenceEqualToSum = false;

        for (int i = 0; i < length; i++)
        {
            for (int j = i; j < length; j++)
            {
                currentSum += array[j];

                if (currentSum == sum)
                {
                    sequenceEqualToSum = true;

                    Console.Write("The following sequence has the sum of {0}: ", sum);

                    for (int grandeFinale = i; grandeFinale <= j; grandeFinale++)
                    {
                        Console.Write("{0} ", array[grandeFinale]);
                    }

                    Console.WriteLine();
                }
            }

            currentSum = 0;

        }

        if (!sequenceEqualToSum)
        {
            Console.WriteLine("There is no sequence with the sum of {0}.", sum);
        }
    }
}