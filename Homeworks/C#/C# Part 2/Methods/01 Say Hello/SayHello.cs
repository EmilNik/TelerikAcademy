using System;

    class SayingHello
    {
        
    //Write a method that asks the user for his name and prints “Hello, <name>”
    //Write a program to test this method.


        static void Main()
        {
            Console.Write(" -What is your name?\n -My name is ");
            string name = Console.ReadLine();
            SayHello(name);
        }

        static void SayHello(string name)
        {
            Console.WriteLine(" -Hello, {0}.", name);
        }
    }
