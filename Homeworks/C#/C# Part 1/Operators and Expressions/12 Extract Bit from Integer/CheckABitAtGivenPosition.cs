using System;

class CheckABitAtGivenPosition
    {
        static void Main()
        {
            ////Write an expression that extracts from given integer n the value of given bit at index p.

            Console.Write("Enter your number: ");
            int number = int.Parse(Console.ReadLine());

            Console.Write("Enter the number of the bit you want to check if it is equal to '1': ");
            int p = int.Parse(Console.ReadLine());

            int bit = 1 << p;
            int comparedBit = number & bit;

            string binaryNum = Convert.ToString(number, 2);
            Console.WriteLine("Your number is {0}.", binaryNum);

            if (comparedBit == 1)
            {
                Console.WriteLine("Yes, your bit is '1'.");
            }
            else
            {
                Console.WriteLine("No, your bit is '0'.");
            }
        }
    }
