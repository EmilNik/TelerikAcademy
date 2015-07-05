using System;

class BinarySearch
{
    static void Main()
    {
        //Write a program that finds the index of given element in a sorted array of 
        //integers by using the Binary search algorithm.

        Console.Write("Enter number of elements: ");
        int length = int.Parse(Console.ReadLine());

        int[] array = new int[length];

        for (int i = 0; i < length; i++)
        {

            Console.Write("Enter element {0}: ", i);
            array[i] = int.Parse(Console.ReadLine());
        }

        Console.Write("Enter the elemetn you are looking for: ");
        int key = int.Parse(Console.ReadLine());

        int max = length - 1;
        int min = 0;
        int middle = 0;

        Array.Sort(array);
        
        Console.Write("Sorted array is: ");
        
        for (int i = 0; i < length; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();

        int counter = 0;
        
        while (min <= max)
        {
            counter++;
            middle = (max + min) / 2;

            if (key > array[middle])
            {
                min = middle + 1;
            }
            else if (key < array[middle])
            {
                max = middle - 1;
            }
            else if (key == array[middle])
            {
                break;
            }
        }

        if (array[middle] == key)
        {
            Console.WriteLine("Your element {0} is with index: {1}", key, middle);
            Console.WriteLine("It was found with {0} steps.", counter);
        }
        else
        {
            Console.WriteLine("Your element {0} does not exist in this array!", key);
        }
    }
}
