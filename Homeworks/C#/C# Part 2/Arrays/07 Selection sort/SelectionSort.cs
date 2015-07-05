using System;

    class SelectionSort
    {
        static void Main()
        {
            
    //Sorting an array means to arrange its elements in increasing order. Write a program to sort an array.
    //Use the Selection sort algorithm: Find the smallest element, move it at the first position, find the 
    //smallest from the rest, move it at the second position, etc.

            Console.Write("Enter number of elements: ");
            int length = int.Parse(Console.ReadLine());

            int[] array = new int[length];
            int min = int.MaxValue;
            int minIndex = 0;
            int temp = 0;
            string output;

            for (int i = 0; i < length; i++)
            {
                Console.Write("Enter element {0}: ", i);
                array[i] = int.Parse(Console.ReadLine());
            }

             for (int i = 0; i < length; i++)
            {
                for (int j = i; j < length; j++)
                {
                    if (array[j] < min)
                    {
                        min = array[j];
                        minIndex = j;
                    }
                }
                temp = array[i];
                array[i] = min;
                array[minIndex] = temp;
                min = int.MaxValue;
            }

            output = string.Join(", ", array);
            Console.WriteLine(output);
        }
    }
