using System;

class AppearanceCount
{

    //Write a method that counts how many times given number appears in given array.
    //Write a test program to check if the method is workings correctly.

    static int counter = 0;

    static void Main()
    {
        int[] array = Array();

        int number = Number();

        Counter(number, array);

        Console.WriteLine("The number {0} appears {1} times in the array.", number, counter);
    }

    static int[] Array()
    {
        Console.Write("Enter number of elements in the array: ");
        int length = int.Parse(Console.ReadLine());

        int[] array = new int[length];

        for (int i = 0; i < length; i++)
        {
            Console.Write("Enter element {0}: ", i);
            array[i] = int.Parse(Console.ReadLine());
        }

        return array;
    }

    static int Number()
    {

        Console.Write("Enter number: ");
        int number = int.Parse(Console.ReadLine());

        return number;
    }

    static int Counter(int number, int[] array)
    {
        foreach (int element in array)
        {
            if (element == number)
            {
                counter++;
            }
        }

        return counter;
    }
}