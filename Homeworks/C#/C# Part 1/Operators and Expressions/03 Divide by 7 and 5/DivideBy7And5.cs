using System;

    class DivideBy7And5
    {
        static void Main()
        {
            //Write a Boolean expression that checks for given integer if it can be divided 
            //(without remainder) by 7 and 5 at the same time.

            Console.WriteLine("Write a number and i will chack if it can be devided by 5 and by 7 at the same time.");
            Console.Write("Write your number here: ");
            int number = int.Parse(Console.ReadLine());

            bool isTrue = number % 5 == 0 & number % 7 == 0;

            if(isTrue == true)
            {
                Console.WriteLine(true + ". Your number can be devided by 5 and by 7 at the same time.");
            }

            else
            {
                Console.WriteLine(false + "I am really sorry, but your number can not be devided by 5 and by 7 at the same time.");
            }
        }
    }
