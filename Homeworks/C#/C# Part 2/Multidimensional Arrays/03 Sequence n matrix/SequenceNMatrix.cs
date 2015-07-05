using System;

class SequenceNMatrix
{

    //We are given a matrix of strings of size N x M. Sequences in the matrix we define as 
    //sets of several neighbour elements located on the same line, column or diagonal.
    //Write a program that finds the longest sequence of equal strings in the matrix.

    static string FindLongestSequence(string[,] m)
    {
        int result = 0;
        int max = 0;
        int currRow = 0;
        int currCol = 0;
        int currDiag = 0;
        int temp = 0;
        string maxStr = "";
        for (int rows = 0; rows < m.GetLength(0); rows++)
        {
            for (int cols = 0; cols < m.GetLength(1); cols++)
            {
                string curr = m[rows, cols];
                currRow = FindStreak(m, rows, cols, 0);
                currDiag = FindStreak(m, rows, cols, 1);
                currCol = FindStreak(m, rows, cols, 2);
                temp = Math.Max(Math.Max(currRow, currCol), currDiag);
                if (temp > max)
                {
                    max = temp;
                    maxStr = curr;
                }
            }
            if (max == m.GetLength(0))
            {
                return FormResult(max, maxStr);
            }
        }
        return FormResult(max, maxStr);
    }
    static string FormResult(int n, string str)
    {
        string res = "";
        for (int i = 0; i < n; i++)
        {
            res += str + ", ";
        }
        res = res.Substring(0, res.Length - 2);
        return res;
    }
    static int FindStreak(string[,] m, int startRow, int startCol, int direction)
    {
        int count = -1;

        if (direction == 0)
        {
            count = 1;
            for (int i = startCol + 1; i < m.GetLength(1); i++)
            {
                if (m[startRow, i] == m[startRow, startCol])
                {
                    count++;
                }
            }
        }

        else if (direction == 1)
        {
            count = 1;
            int diagonalSize = (m.GetLength(0) < m.GetLength(1)) ? m.GetLength(0) : m.GetLength(1);
            for (int i = startCol + 1; i < diagonalSize; i++)
            {
                if (m[i, i] == m[startRow, startCol])
                {
                    count++;
                }
            }
        }

        else if (direction == 2)
        {
            count = 1;
            for (int rows = startRow + 1; rows < m.GetLength(0); rows++)
            {
                if (m[rows, startCol] == m[startRow, startCol])
                {
                    count++;
                }
            }
        }
        return count;
    }
    static void Main()
    {
        string[,] matrix = {{"ha", "fifi", "ho", "hi"},
                            {"fo", "ha", "hi", "xx"},
                            {"xxx", "ho", "ha", "xx"}};
        string[,] matrix2 = {{"s", "qq", "s"},
                            {"pp", "pp", "s"},
                            {"pp", "qq", "s"}};
        Console.WriteLine(FindLongestSequence(matrix));
        Console.WriteLine(FindLongestSequence(matrix2));
    }
}
