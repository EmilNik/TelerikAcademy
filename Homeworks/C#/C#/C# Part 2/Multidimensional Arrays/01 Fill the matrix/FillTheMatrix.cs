using System;

class FillTheMatrix
{
    static void Main()
    {
        //Write a program that fills and prints a matrix of size (n, n) as shown below:

        Console.Write("Enter matrix size: ");
        int n = int.Parse(Console.ReadLine());

        int arrayStart;

        //first array
        int[,] firstArray = new int[n, n];

        for (int col = 0; col < n; col++)
        {
            for (int row = 0; row < n; row++)
            {
                arrayStart = row + n * col + 1;
                firstArray[row, col] = arrayStart;
            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write("{0,3}", firstArray[i, j]);
            }
            Console.WriteLine();
        }


        Console.WriteLine();


        //second array

        int[,] secondArray = new int[n, n];

        arrayStart = 0;

        for (int col = 0; col < n; col += 2)
        {
            for (int row = 0; row < n; row++)
            {
                arrayStart = row + n * col + 1;
                secondArray[row, col] = arrayStart;
            }
        }

        for (int col = 1; col < n; col += 2)
        {
            for (int row = 0; row < n; row++)
            {
                arrayStart = n * (col + 1) - row;
                secondArray[row, col] = arrayStart;
            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write("{0,3}", secondArray[i, j]);
            }
            Console.WriteLine();
        }

        Console.WriteLine();

        //third array

        arrayStart = 1;

        int[,] thirdArray = new int[n, n];
        int counter = 1;

        for (int i = n - 1; i >= 0; i--)
        {
            for (int col = 0; col < n - i; col++)
            {
                thirdArray[i + col, col] = counter++;
            }
        }

        for (int j = 1; j < n; j++)
        {
            for (int row = 0; row < n - j; row++)
            {
                thirdArray[row, j + row] = counter++;
            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write("{0,3}", thirdArray[i, j]);
            }
            Console.WriteLine();
        }

        Console.WriteLine();
    }
}
