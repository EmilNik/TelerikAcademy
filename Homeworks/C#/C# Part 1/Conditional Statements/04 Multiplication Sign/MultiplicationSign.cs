using System;

    class MultiplicationSign
    {
        static void Main()
        {
            //Write a program that shows the sign (+, - or 0) of the product of three real numbers, without calculating it.
            //    Use a sequence of if operators.

            Console.Write("first number: ");
            double firstNum = double.Parse(Console.ReadLine());

            Console.Write("second number: ");
            double secondNum = double.Parse(Console.ReadLine());

            Console.Write("third number: ");
            double thirdNum = double.Parse(Console.ReadLine());

            if (firstNum < 0)
            {
                if (secondNum < 0)
                {
                    if (thirdNum < 0)
                    {
                        Console.WriteLine("-");
                    }

                    else
                    {
                        Console.WriteLine("+");
                    }
                }
                else
                {
                    if (thirdNum < 0)
                    {
                        Console.WriteLine("-");
                    }
                    else
                    {
                        Console.WriteLine("+");
                    }
                }
            }
            else if (firstNum > 0)
            {
                if (secondNum < 0)
                {
                    if (thirdNum < 0)
                    {
                        Console.WriteLine("+");
                    }
                    else
                    {
                        Console.WriteLine("-");
                    }
                }
                else
                {
                    if (thirdNum < 0)
                    {
                        Console.WriteLine("-");
                    }
                    else
                    {
                        Console.WriteLine("+");
                    }
                }
            }
            else if ((firstNum == 0) || (secondNum == 0) || (thirdNum == 0))
            {
                Console.WriteLine("0");
            }
            }
        }
