using System;
using System.Linq;

class BinaryToHexadecimal
{
    static void Main()
    {
        string binaryRepresentation = Console.ReadLine();

        string clearBinaryRepresentation = null;

        for (int i = 0; i < binaryRepresentation.Length; i++)
        {
            if (binaryRepresentation[i] == '1')
            {
                for (int j = i; j < binaryRepresentation.Length; j++)
                {
                    clearBinaryRepresentation = binaryRepresentation[j] + clearBinaryRepresentation;
                }
                break;
            }
        }

        string reversedBinaryRepresentation = clearBinaryRepresentation.Aggregate<char, string>(null, (current, t) => t + current);
        string hexadecimalRepresentation = null;
        int countOfBits = reversedBinaryRepresentation.Length;
        int bitPosition = 0;

        while (bitPosition < countOfBits)
        {

            byte decimalRepresentation = 0;

            for (int i = 0; i < 4; i++)
            {
                if (bitPosition >= countOfBits)
                {
                    break;
                }

                int multiplier = 1;

                for (int j = 0; j < i; j++)
                {
                    multiplier = multiplier * 2;
                }

                if (reversedBinaryRepresentation[bitPosition] == '1')
                {
                    decimalRepresentation = (byte)(decimalRepresentation + multiplier);
                }

                bitPosition++;
            }

            char symbol = ' ';

            if ((decimalRepresentation >= 0) && (decimalRepresentation <= 9))
            {
                symbol = (char)(decimalRepresentation + '0');
            }

            else
            {

                switch (decimalRepresentation)
                {
                    case 10:
                        symbol = 'A';
                        break;
                    case 11:
                        symbol = 'B';
                        break;
                    case 12:
                        symbol = 'C';
                        break;
                    case 13:
                        symbol = 'D';
                        break;
                    case 14:
                        symbol = 'E';
                        break;
                    case 15:
                        symbol = 'F';
                        break;
                }
            }

            hexadecimalRepresentation = symbol + hexadecimalRepresentation;
        }

        Console.WriteLine(hexadecimalRepresentation);
    }
}