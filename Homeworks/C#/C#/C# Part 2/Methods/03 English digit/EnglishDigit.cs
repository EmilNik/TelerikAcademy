using System;

    class EnglishDigit
    {
        static void Main()
        {
            Console.Write("Enter your number: ");
            int number = int.Parse(Console.ReadLine());

            ReturnDigit(number);
        }

        static void ReturnDigit(int input)
        {
            string[] digits = { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
            int lastDigit = input % 10;
            string englishDigit = digits[lastDigit - 1];

            Console.WriteLine(englishDigit);
        }
    }