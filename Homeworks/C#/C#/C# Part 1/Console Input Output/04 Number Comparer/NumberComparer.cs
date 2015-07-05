using System;

    class NumberComparer
    {
        static void Main()
        {
            Console.Write("First number: ");
            double a = double.Parse(Console.ReadLine());

            Console.Write("Second number: ");
            double b = double.Parse(Console.ReadLine());

            Console.WriteLine("Greater number: " + (a > b ? a : b));
        }
    }
