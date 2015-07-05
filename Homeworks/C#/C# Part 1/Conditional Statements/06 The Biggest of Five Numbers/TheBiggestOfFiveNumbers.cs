using System;

    class TheBiggestOfFiveNumbers
    {
        static void Main()
        {
            Console.Write("first number: ");
            double firstNum = double.Parse(Console.ReadLine());

            Console.Write("second number: ");
            double secondNum = double.Parse(Console.ReadLine());

            Console.Write("third number: ");
            double thirdNum = double.Parse(Console.ReadLine());

            Console.Write("forth number: ");
            double forthNum = double.Parse(Console.ReadLine());

            Console.Write("fifth number: ");
            double fifthNum = double.Parse(Console.ReadLine());

            if (firstNum > secondNum & firstNum > thirdNum & firstNum > forthNum & firstNum > fifthNum)
            {
                Console.WriteLine("The biggest number is {0}.", firstNum);
            }

            else if (secondNum > firstNum & secondNum > thirdNum & secondNum > forthNum & secondNum > fifthNum)
            {
                Console.WriteLine("The biggest number is {0}.", secondNum);
            }

            else if (thirdNum > firstNum & thirdNum > secondNum & thirdNum > forthNum & thirdNum > fifthNum)
            {
                Console.WriteLine("The biggest number is {0}.", thirdNum);
            }

            else if (forthNum > firstNum & forthNum > secondNum & forthNum > thirdNum & forthNum > fifthNum)
            {
                Console.WriteLine("The biggest number is {0}.", forthNum);
            }

            else
            {
                Console.WriteLine("The biggest number is {0}.", fifthNum);
            }
        }
    }
