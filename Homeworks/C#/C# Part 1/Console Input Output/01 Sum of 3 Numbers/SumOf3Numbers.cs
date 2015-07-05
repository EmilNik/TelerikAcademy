using System;

    class SumOf3Numbers
    {
        static void Main()
        {
            //Write a program that reads 3 real numbers from the console and prints their sum.

            Console.Write("Enter first number: ");
            double firstNum = double.Parse(Console.ReadLine());

            Console.Write("Enter second number: ");
            double secondNum = double.Parse(Console.ReadLine());

            Console.Write("Enter third number: ");
            double thirdNum = double.Parse(Console.ReadLine());

            double sum = firstNum + secondNum + thirdNum;

            Console.WriteLine("The sum of those numbers is {0}.", sum);
        }
    }
