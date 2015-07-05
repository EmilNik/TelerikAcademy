using System;

    class OddOrEvenIntegers
    {
        static void Main()
        {
            //Write an expression that checks if given integer is odd or even.

            //Frist way

            Console.Write("Write your number and i will tell you if it is odd.\nYour number is: ");
            int number = int.Parse(Console.ReadLine());

            if (number % 2 == 1)
            {
                Console.WriteLine(true + ". Your number is odd.");
            }

            else
            {
                Console.WriteLine(false + ". Your number is NOT odd.");
            }

            //I will add some empty lines because of the two different solutions.
            Console.WriteLine("\n\n\n");

            Console.Write("Write your number and i will tell you if it is odd.\nYour number is: ");
            int number2 = int.Parse(Console.ReadLine());
            Console.WriteLine(number2 % 2 == 1 ? "\nYour number is odd." : "Your number is NOT odd.");

        }
    }
