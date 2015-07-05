using System;

class GetLargestNumber
{

    //Write a method GetMax() with two parameters that returns the larger of two integers.
    //Write a program that reads 3 integers from the console and prints the largest of them using the method GetMax().

    static void Main()
    {
        Console.Write("Enter your first number: ");
        int firstNumber = int.Parse(Console.ReadLine());
        Console.Write("Enter your second number: ");
        int secondNumber = int.Parse(Console.ReadLine());
        Console.Write("Enter your third number: ");
        int thirdNumber = int.Parse(Console.ReadLine());

        Console.WriteLine("The biggest number of {0}, {1} and {2} is {3}.",
        firstNumber, secondNumber, thirdNumber, GetMaxOfThree(firstNumber, secondNumber, thirdNumber));
    }

    static int GetMax(int a, int b)
    {
        int largestNumber = Math.Max(a, b);
        return largestNumber;
    }

    static int GetMaxOfThree(int a, int b, int c)
    {
        int largestOfThree = GetMax(GetMax(a, b), c);
        return largestOfThree;
    }
}
