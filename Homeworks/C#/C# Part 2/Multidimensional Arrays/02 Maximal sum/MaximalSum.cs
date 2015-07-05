using System;

class MaximalSum
{
    static void Main()
    {
        //Write a program that reads a rectangular matrix of size N x M and finds in it the square 3 x 3 
        //that has maximal sum of its elements.


        const int n = 4;
        const int m = 6;
        int[,] array = new int[n, m] { { 0, 2, 4, 0, 9, 5 },
                                        { 7, 1, 3, 3, 2, 1 },
                                        { 1, 3, 9, 8, 5, 6 },
                                        { 4, 6, 7, 9, 1, 0}
                                        };

        Console.WriteLine("The array:");
        Console.WriteLine();

        int bestSum = 0;
        int bestRow = 0;
        int bestCol = 0;

        for (int row = 0; row < array.GetLength(0) - 2; row++)
        {
            for (int col = 0; col < array.GetLength(1) - 2; col++)
            {
                int sum = array[row, col] + array[row, col + 1] + array[row, col + 2] +
                array[row + 1, col] + array[row + 1, col + 1] + array[row + 1, col + 2] +
                array[row + 2, col] + array[row + 2, col + 1] + array[row + 2, col + 2];

                if (sum > bestSum)
                {
                    bestSum = sum;
                    bestRow = row;
                    bestCol = col;
                }
            }
        }

        Console.WriteLine("The maximal sum is: {0}", bestSum);
        Console.WriteLine();
        Console.WriteLine("The square 3x3 with best sums is:");

        for (int rows = 0; rows < 3; rows++)
        {
            for (int cols = 0; cols < 3; cols++)
            {
                Console.Write("{0,3} ", array[bestRow + rows, bestCol + cols]);
            }
            Console.WriteLine();
        }
    }
}

