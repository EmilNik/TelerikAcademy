using System;

    class MaximalSequence
    {
        static void Main()
        {
            //Write a program that finds the maximal sequence of equal elements in an array.

            Console.Write("Enter the number of elements in the array: ");
            int length = int.Parse(Console.ReadLine());

            int[] array = new int[length];
            int maxCount = 0;
            int currentCount = 1;
            int sequenceStart = 0;
            for (int i = 0; i < length; i++)
            {
                Console.Write("Enter element {0}: ", i);
                array[i] = int.Parse(Console.ReadLine());

                if (i > 0)
                {
                    if (array[i] == array[i - 1])
                    {
                        currentCount++;
                    }
                    else
                    {
                        currentCount = 1;
                    }
                    if (currentCount > maxCount)
                    {
                        maxCount = currentCount;
                        sequenceStart = i + 1 - maxCount;
                    }
                }
            }

            Console.Write("The maximal sequence of equal elements is: ");
            for (int i = sequenceStart; i < sequenceStart + maxCount; i++)
            {
                Console.Write("{0} ", array[i]);
            }

            Console.WriteLine();
        }
    }
