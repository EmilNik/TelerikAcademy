//Write a program that reads N integers from the console and reverses them using a stack.

//Use the Stack<int> class.

namespace _02.ReverseIntsUsingStack
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        static void Main()
        {
            int numberOfLines = ReadIntFromConsole("Enter number of lines: ");
            
            var stack = new Stack<int>();

            for (int i = 0; i < numberOfLines; i++)
            {
                var number = ReadIntFromConsole("Enter number: ");
                stack.Push(number);
            }

            Console.WriteLine("Reverted numbers:");

            for (int i = 0; i < numberOfLines; i++)
            {
                Console.WriteLine(stack.Pop());
            }
        }

        static int ReadIntFromConsole(string text)
        {
            int number;

            while (true)
            {
                Console.Write(text);

                if (Int32.TryParse(Console.ReadLine(), out number))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Enter valid number!");
                }
            }

            return number;
        }
    }
}
