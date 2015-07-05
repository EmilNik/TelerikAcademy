using System;

    class DecimalToHexadecimal
    {
        //Write a program to convert decimal numbers to their hexadecimal representation.

        static void Main()
        {
            Console.Write("Enter number: ");
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine("Heximal: {0:X}", number);
        }
    }
