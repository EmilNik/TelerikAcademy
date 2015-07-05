using System;

    class ModifyABitAtGivenPosition
    {
        static void Main()
        {
            
            //We are given an integer number n, a bit value v (v=0 or 1) and a position p.
            //Write a sequence of operators (a few lines of C# code) that modifies n to hold 
            //the value v at the position p from the binary representation of n while preserving all other bits in n.

            Console.Write("Enter your number: ");
            int number = int.Parse(Console.ReadLine());

            string binaryNum = Convert.ToString(number, 2);
            Console.WriteLine("Your number in binary looks like this: {0}.", binaryNum);

            Console.WriteLine("The bit on which position would you like to change?");
            Console.Write("Enter the position here: ");
            byte position = byte.Parse(Console.ReadLine());

            Console.WriteLine("How would you like to change it?\nNote: This number should be either '0' or '1'.");
            Console.Write("Enter your number here: ");
            byte newBitValue = byte.Parse(Console.ReadLine());

            //bool isTrue = newBitValue == 0 || newBitValue == 1;

            if (newBitValue == 1)
            {
                int setOne = 1 << position;
                int foundBitOne = number | setOne;
                Console.WriteLine("Your new number in binary is {0}.", Convert.ToString(foundBitOne, 2).PadLeft(16, '0'));
                Console.WriteLine("Your new number is {0}.", foundBitOne);

            }
            else if (newBitValue == 0)
            {
                int setOne = ~(1 << position);
                int foundBitOne = number & setOne;
                Console.WriteLine("Your new number in binary is {0}.", Convert.ToString(foundBitOne, 2).PadLeft(16, '0'));
                Console.WriteLine("Your new number is {0}.", foundBitOne);
            }
            else
            {
                Console.WriteLine(false);
            }
        }
    }
