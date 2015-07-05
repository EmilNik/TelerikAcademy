using System;

    class TheBiggestOf3Numbers
    {
        static void Main()
        {
            //Write a program that finds the biggest of three numbers.

            Console.Write("first number: ");
            double firstNum = double.Parse(Console.ReadLine());

            Console.Write("second number: ");
            double secondNum = double.Parse(Console.ReadLine());

            Console.Write("third number: ");
            double thirdNum = double.Parse(Console.ReadLine());

            if (firstNum > secondNum & firstNum > thirdNum)
            {
                Console.WriteLine(firstNum);
            }

            else if (secondNum > firstNum & secondNum > thirdNum)
            {
                Console.WriteLine(secondNum);
            }

            else
            {
                Console.WriteLine(thirdNum);
            }
        }
    }