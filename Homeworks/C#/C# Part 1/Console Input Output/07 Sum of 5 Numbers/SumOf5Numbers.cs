using System;

    class SumOf5Numbers
    {
        static void Main()
        {
//Write a program that enters 5 numbers (given in a single line, separated by a space), calculates and prints their sum.

            string[] num = Console.ReadLine().Split();
            double firstNum = double.Parse(num[0]);
            double secondNum = double.Parse(num[1]);
            double thirdNum = double.Parse(num[2]);
            double forthNum = double.Parse(num[3]);
            double fifthNum = double.Parse(num[4]);

            double sum = firstNum + secondNum + thirdNum + forthNum + fifthNum;
            Console.WriteLine(sum);
        }
    }
