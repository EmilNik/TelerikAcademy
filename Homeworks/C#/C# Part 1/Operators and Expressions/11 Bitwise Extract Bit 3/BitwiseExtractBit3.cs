using System;

    class BitwiseExtractBit3
    {
        static void Main()
        {
            //Using bitwise operators, write an expression for finding the value of the bit #3 of a given unsigned integer.
            //The bits are counted from right to left, starting from bit #0.
            //The result of the expression should be either 1 or 0.


            Console.Write("Enter your number: ");
            int number = int.Parse(Console.ReadLine());

            int thirdBit = 1 << 3;
            int comparedBit = number & thirdBit;

            string binaryNum = Convert.ToString(number, 2);

            if (comparedBit == 0)
            {
                Console.WriteLine("Third bit of {0} is '0'.", binaryNum);
            }
            else
            {
                Console.WriteLine("Third bit of {0} is '1' ", binaryNum);
            }
        }
    }
