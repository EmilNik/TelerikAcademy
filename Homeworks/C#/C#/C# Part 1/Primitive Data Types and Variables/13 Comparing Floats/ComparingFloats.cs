//Write a program that safely compares floating-point numbers (double) with precision eps = 0.000001.
//Note: Two floating-point numbers a and b cannot be compared directly by a == b 
//because of the nature of the floating-point arithmetic. Therefore, we assume two numbers
//are equal if they are more closely to each other than a fixed constant eps.

using System;

    class ComparingFloats
    {
        static void Main()
        {
            Console.Write("A = ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("B = ");
            double b = double.Parse(Console.ReadLine());
            double eps = 0.000001;

            if(a - b < eps & b - a < eps)
            {
                Console.WriteLine(true + ". The two numbers are equal.");
            }

            else
            {
                Console.WriteLine(false + ". The two numbers are not equal.");
            }

        }
    }

