using System;
using System.Globalization;
using System.Text;
using System.Threading;

class ReverseNumber
{
    //Write a method that reverses the digits of given decimal number

    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

        Console.Write("Enter a decimal number: ");
        double number = double.Parse(Console.ReadLine());

        double reversedNum = ReverseDecimal(number);

        Console.WriteLine("The reversed number is: {0}", reversedNum);
    }

    static double ReverseDecimal(double number)
    {
        return double.Parse(ReverseString(number.ToString(CultureInfo.InvariantCulture)));
    }

    static string ReverseString(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}
