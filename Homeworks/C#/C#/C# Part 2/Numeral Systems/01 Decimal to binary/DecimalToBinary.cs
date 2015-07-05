using System;
using System.Text;

class DecimalToBinary
{
    //Write a program to convert decimal numbers to their binary representation.

    static void Main()
    {
        Console.Write("Enter number: ");
        int decimalNumber = int.Parse(Console.ReadLine());

        int remainder;
        string result = string.Empty;

        while (decimalNumber > 0)
        {
            remainder = decimalNumber % 2;
            decimalNumber /= 2;
            result = remainder.ToString() + result;
        }

        Console.WriteLine("Binary:  {0}", result);
    }
}
