using System;

    class IsThirdDigit7
    {
        static void Main()
        {
            //Write an expression that checks for given integer if its third digit from right-to-left is 7.

            //1st way

            Console.WriteLine("Write a number and i will check if the third digit is 7");
            Console.Write("Your number is: ");
            int number = int.Parse(Console.ReadLine());

            number /= 100;
            Console.WriteLine(number % 10 == 7 ? true + ". \nThe third digit of your number is 7." : false + ". \nI am sorry. The third digit of your number is not 7.");

            //2nd way
            Console.WriteLine("\n\n\n");

            Console.WriteLine("Write a number and i will check if the third digit is 7");
            Console.Write("Your number is: ");
            int number2 = int.Parse(Console.ReadLine());

            number2 /= 100;

            if(number2 % 10 == 7)
            {
                Console.WriteLine(true + ". \nThe third digit of your number is 7.");
            }

            else
            {
                Console.WriteLine(false + ". \nI am sorry. The third digit of your number is not 7.");
            }
        
        }
    }
