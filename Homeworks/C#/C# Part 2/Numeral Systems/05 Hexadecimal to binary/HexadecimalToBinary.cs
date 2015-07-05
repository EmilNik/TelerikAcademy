using System;

    class HexadecimalToBinary
    {
        //Write a program to convert hexadecimal numbers to binary numbers (directly).

        static void Main()
        {
            string inputHexRepresentation = Console.ReadLine();
            string binaryRepresentation = String.Empty;
            for (int i = inputHexRepresentation.Length - 1; i >= 0; i--)
            {
                char hexDigit = inputHexRepresentation[i];
                byte decimalRepresentation = 0;
                if (char.IsNumber(hexDigit))
                {
                    decimalRepresentation = (byte)(hexDigit - '0');
                }
                else
                {
                    switch (hexDigit)
                    {
                        case 'A':
                            decimalRepresentation = 10;
                            break;
                        case 'B':
                            decimalRepresentation = 11;
                            break;
                        case 'C':
                            decimalRepresentation = 12;
                            break;
                        case 'D':
                            decimalRepresentation = 13;
                            break;
                        case 'E':
                            decimalRepresentation = 14;
                            break;
                        case 'F':
                            decimalRepresentation = 15;
                            break;
                    }
                }
                // Convert to binary
                while (decimalRepresentation != 0)
                {
                    byte remainder = (byte)(decimalRepresentation % 2);
                    binaryRepresentation = remainder + binaryRepresentation;
                    decimalRepresentation = (byte)(decimalRepresentation / 2);
                }
                while (binaryRepresentation.Length % 4 != 0)
                {
                    binaryRepresentation = '0' + binaryRepresentation;
                }
                binaryRepresentation = " " + binaryRepresentation;
            }
            Console.WriteLine(binaryRepresentation);
        }
    }