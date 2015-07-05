using System;

    class HexadecimalToDecimal
    {
        static void Main()
        {
            Console.Write("Enter hexadecimal number: ");
            string hexNumberString = Console.ReadLine();

            char[] hexDigits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

            int result = 1;

            foreach (char digit in hexNumberString)
            {
                result *= (Array.IndexOf(hexDigits, digit) + 1);
            }

            Console.WriteLine(result - 1);
        }
    }
