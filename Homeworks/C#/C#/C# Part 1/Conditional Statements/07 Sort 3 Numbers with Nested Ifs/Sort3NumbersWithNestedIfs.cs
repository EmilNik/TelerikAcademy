using System;

class Sort3NumbersWithNestedIfs
{
    static void Main()
        {
            //Write a program that enters 3 real numbers and prints them sorted in descending order.
            //Use nested if statements.

            Console.Write("First number: ");
            double firstNum = double.Parse(Console.ReadLine());
            
            Console.Write("Second number: ");
            double secondNum = double.Parse(Console.ReadLine());

            Console.Write("Third number: ");
            double thirdNum = double.Parse(Console.ReadLine());
 
            if ((firstNum > secondNum) && (firstNum > thirdNum))
            {
                if (secondNum > thirdNum)
                {
                    Console.WriteLine("{0} {1} {2}", firstNum, secondNum, thirdNum);
                }
                else
                {
                    Console.WriteLine("{0} {1} {2}", firstNum, thirdNum, secondNum);
                }
            }
            else if ((secondNum > firstNum) && (secondNum > thirdNum))
            {
                if (firstNum > thirdNum)
                {
                    Console.WriteLine("{0} {1} {2}", secondNum, firstNum, thirdNum);
                }
                else
                {
                    Console.WriteLine("{0} {1} {2}", secondNum, thirdNum, firstNum);
                }
            }
            else if ((thirdNum > firstNum) && (thirdNum > secondNum))
            {
                if (firstNum > secondNum)
                {
                    Console.WriteLine("{0} {1} {2}", thirdNum, firstNum, secondNum);
                }
                else
                {
                    Console.WriteLine("{0} {1} {2}", thirdNum, secondNum, firstNum);
                }
            }
        }
     }
