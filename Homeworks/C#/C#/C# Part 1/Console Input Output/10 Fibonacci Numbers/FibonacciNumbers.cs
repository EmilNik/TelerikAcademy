using System;

    class FibonacciNumbers
    {
        static void Main()
        {
            //Write a program that reads a number n and prints on the console the first n members 
            //of the Fibonacci sequence (at a single line, separated by comma and space - ,) : 
            //0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, ….

            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());

            int num = 0;
            int nextNum = 1;

            for (int i = 0; i < n; i++)
            {
                Console.Write(num + ", ");

                int saveNum = num;
                num = nextNum;
                nextNum = saveNum + nextNum;
            }
        }
    }
