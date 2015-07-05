using System;

class StringLength
{

    //Write a program that reads from the console a string of maximum 20 characters. If the length of the string
    //is less than 20, the rest of the characters should be filled with *.
    //Print the result string into the console.

    static void Main()
    {
        {
            Console.Write("Enter string (MAX LENGTH: 20 chars): ");
            string input = Console.ReadLine();

            if (input.Length > 20)
            {
                Console.WriteLine("The string is too long.");
                return;
            }

            Console.WriteLine(input.PadRight(20, '*'));
        }
    }
}

