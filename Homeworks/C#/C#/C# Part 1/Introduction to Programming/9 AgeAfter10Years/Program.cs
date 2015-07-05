//Write a program to read your birthday from the console and print how old you are now and how old you will be after 10 years.

using System;

    class AgeAfter10Years
    {
        static void Main()
        {
            Console.WriteLine("Enter your age here:");
            int Age = int.Parse(Console.ReadLine());
            Console.WriteLine("Your age after 10 years will be:");
            Console.WriteLine(Age + 10);
        }
    }
