using System;

    class BinaryToDecimal
    {
        //Write a program to convert binary numbers to their decimal representation.

        static void Main()
        {
            Console.Write("Enter binary number: ");
            string binaryNumber = Console.ReadLine();

            char[] digits = new char[binaryNumber.Length];
            digits = binaryNumber.ToCharArray();
            Array.Reverse(digits);

            int counter = 0;
            double result = 0;

            for (int i = 0; i < digits.Length; i++)
            {
                string stringNum = digits[i].ToString();
                int currentNum = int.Parse(stringNum);

                result += currentNum * Math.Pow(2, i);
            }

            Console.WriteLine(result);
        }
    }
