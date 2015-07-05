//Which of the following values can be assigned to a variable of type float and which to a variable of type 
//double: 34.567839023, 12.345, 8923.1234857, 3456.091?
//Write a program to assign the numbers in variables and print them to ensure no precision is lost.

using System;
    class FloatOrDouble
    {
        static void Main()
        {
            double numA = 34.567839023;
            float numB = 12.345F;
            double numC = 8923.1234857;
            float numD = 3456.091F;

            Console.WriteLine("{0}\n{1}\n{2}\n{3}", numA, numB, numC, numD);
        }
    }
