using System;

class FormattingNumbers
{
    static void Main()
    {

        //Write a program that reads 3 numbers:
        //    integer a (0 <= a <= 500)
        //    floating-point b
        //    floating-point c
        //The program then prints them in 4 virtual columns on the console. Each column should have a width of 10 characters.
        //    The number a should be printed in hexadecimal, left aligned
        //    Then the number a should be printed in binary form, padded with zeroes
        //    The number b should be printed with 2 digits after the decimal point, right aligned
        //    The number c should be printed with 3 digits after the decimal point, left aligned.

        Console.Write("Enter first number A (0 <= A <= 500): ");
        int a = int.Parse(Console.ReadLine());

        if (a >= 0 && a <= 500)
        {
            Console.Write("Enter second number B: ");
            float b = float.Parse(Console.ReadLine());

            Console.Write("Enter third number C: ");
            float c = float.Parse(Console.ReadLine());

            string aInBinary = Convert.ToString(a, 2);

            Console.WriteLine("{0,10:X}{1, 10}{2, 10}{3, 10}", a, aInBinary, (Math.Round(b, 2)), (Math.Round(c, 2)));
        }

        else
        {
            Console.WriteLine("Number A must be between 0 and 500!");
        }


    }
}
