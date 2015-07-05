//Declare an integer variable and assign it with the value 254 in hexadecimal format (0x##).
//Use Windows Calculator to find its hexadecimal representation.
//Print the variable and ensure that the result is 254.

using System;
    class VariableInHexadecimalFormat
    {
        static void Main()
        {
            int decNum = 254;
            Console.WriteLine("{0:X}", decNum);

            int hexNum = 0xFE;
            Console.WriteLine("{0}", hexNum);
        }
    }
