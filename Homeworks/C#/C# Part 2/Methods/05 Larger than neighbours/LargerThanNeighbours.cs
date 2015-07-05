using System;

class LargerThanNeighbours
{
    //Write a method that checks if the element at given position in given array of integers is 
    //larger than its two neighbours (when such exist).

    static void Main(string[] args)
    {
        Console.Write("Enter number of elements in the array: ");
        int length = int.Parse(Console.ReadLine());

        int[] array = new int[length];

        for (int i = 0; i < length; i++)
        {
            Console.Write("Enter element {0}: ", i);
            array[i] = int.Parse(Console.ReadLine());
        }

        Console.Write("Enter index of element: ");
        int postion = int.Parse(Console.ReadLine());

        if (CheckNeighbours(array, postion))
        {
            Console.WriteLine("{0} is greater than {1} and {2} ", array[postion], array[postion - 1], array[postion + 1]);
        }
        else
        {
            Console.WriteLine("{0} is NOT greater than {1} and {2} ", array[postion], array[postion - 1], array[postion + 1]);
        }
    }

    static bool CheckNeighbours(int[] array, int postion)
    {
        bool isGreater = false;
        if (postion < array.Length && postion > 0)
        {
            if (array[postion] > array[postion - 1] && array[postion] > array[postion + 1])
            {
                isGreater = true;
            }
        }
        else
        {
            Console.WriteLine("There is no such element in the array.");
        }
        return isGreater;
    }
}

