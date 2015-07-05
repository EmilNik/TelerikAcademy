using System;

    class ReverseString
    {
        //Write a program that reads a string, reverses it and prints the result at the console.

        static void Main()
        {
            Console.Write("Enter a string: ");
            string text = Console.ReadLine();

            char[] textToChar = text.ToCharArray();
            Array.Reverse(textToChar);

            text = string.Join("", textToChar);
            Console.WriteLine(text);
        }
    }
