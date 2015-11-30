namespace Portals
{
    using System;
    using System.Collections.Generic;

    class Portals
    {
        public static int[,] Directions = new int[,]
        {
            {-1, 0 }, // up
            {+1, 0 }, // down
            {0, -1 }, // left
            {0, +1 } // right
        };

        public static Cube[,] cubes;
        public static int numberOfRows;
        public static int numberOfCols;
        public static int maxSum;

        static void Main(string[] args)
        {
            string[] startingRowAndCol = Console.ReadLine().Split(' ');
            int startRow = int.Parse(startingRowAndCol[0]);
            int startCow = int.Parse(startingRowAndCol[1]);

            string[] numberOfRowsAndCols = Console.ReadLine().Split(' ');
            numberOfRows = int.Parse(numberOfRowsAndCols[0]);
            numberOfCols = int.Parse(numberOfRowsAndCols[1]);

            cubes = new Cube[numberOfRows, numberOfCols];

            for (int row = 0; row < numberOfRows; row++)
            {
                var line = Console.ReadLine().Split(' ');
                for (int col = 0; col < numberOfCols; col++)
                {
                    cubes[row, col] = new Cube(line[col][0]);
                }
            }

            maxSum = Teleport(startRow, startCow, 0, new HashSet<Cube>());
            Console.WriteLine(maxSum);
        }

        public static int Teleport(int row, int col, int sum, HashSet<Cube> steppedOn)
        {
            var cube = cubes[row, col];

            if (sum > maxSum)
            {
                maxSum = sum;
            }

            if (steppedOn.Contains(cube))
            {
                return maxSum;
            }

            cube.SumByNow = sum;

            cube.SteppedOn = steppedOn;
            steppedOn.Add(cube);
            cube.SumByNow += int.Parse(cube.Value.ToString());
            for (int i = 0; i < 4; i++)
            {
                var nextRow = row + int.Parse(cube.Value.ToString()) * Directions[i, 0];
                var nextCol = col + int.Parse(cube.Value.ToString()) * Directions[i, 1];

                if (!(nextRow < 0 || nextRow > numberOfRows - 1
                    ||
                    nextCol < 0 || nextCol > numberOfCols - 1))
                {
                    if (cubes[nextRow, nextCol].Value == '#')
                    {
                        continue;
                    }

                    var currentMax = Teleport(nextRow, nextCol, cube.SumByNow, new HashSet<Cube>(cube.SteppedOn));
                }
            }

            return maxSum;
        }
    }

    public class Cube
    {
        public Cube(char value)
        {
            this.Value = value;
        }

        public char Value { get; set; }

        public HashSet<Cube> SteppedOn { get; set; }

        public int SumByNow;
    }
}
