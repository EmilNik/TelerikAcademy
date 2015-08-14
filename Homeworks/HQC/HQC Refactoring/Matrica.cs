namespace TraverseMatrix
{
    using System;
    using System.Text;

    public class Matrix
    {
        private const int DirectionsCount = 8;
        private int size = 3;

        private int[,] matrix;
        private int row = 0;
        private int col = 0;

        public Matrix(int size)
        {
            this.Size = size;

            this.matrix = new int[this.size, this.size];

            this.FindAvailableCell();
            this.FillAvailableCells();
        }

        public int Size
        {
            get
            {
                return this.size;
            }

            set
            {
                if (value < 1 || value > 100)
                {
                    throw new ArgumentOutOfRangeException("Size of the matrix must be between 1 and 100!");
                }

                this.size = value;
            }
        }

        public override string ToString()
        {
            StringBuilder matrixAsStirng = new StringBuilder();

            for (int row = 0; row < this.size; row++)
            {
                for (int col = 0; col < this.size; col++)
                {
                    matrixAsStirng.AppendFormat("{0,3}", this.matrix[row, col]);
                }

                matrixAsStirng.Append("\r\n");
            }

            return matrixAsStirng.ToString();
        }

        private void GetDirection(ref int dirRow, ref int dirCol)
        {
            int[] directionRow = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionCol = { 1, 0, -1, -1, -1, 0, 1, 1 };

            int currentDirection = 0;

            for (int dirIndex = 0; dirIndex < DirectionsCount; dirIndex++)
            {
                if (directionRow[dirIndex] == dirRow && directionCol[dirIndex] == dirCol)
                {
                    currentDirection = dirIndex;
                    break;
                }
            }

            if (currentDirection == DirectionsCount - 1)
            {
                dirRow = directionRow[0];
                dirCol = directionCol[0];
                return;
            }

            dirRow = directionRow[currentDirection + 1];
            dirCol = directionCol[currentDirection + 1];
        }

        private bool IsCellAvailable(int row, int col)
        {
            int[] directionRow = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionCol = { 1, 0, -1, -1, -1, 0, 1, 1 };

            for (int dirIndex = 0; dirIndex < DirectionsCount; dirIndex++)
            {
                int nextRow = row + directionRow[dirIndex];

                if (!this.IsInRange(nextRow))
                {
                    directionRow[dirIndex] = 0;
                }

                int nextCol = col + directionCol[dirIndex];

                if (!this.IsInRange(nextCol))
                {
                    directionCol[dirIndex] = 0;
                }
            }

            return this.IsNextCellEmpty(row, col, directionRow, directionCol);
        }

        private void FindAvailableCell()
        {
            this.row = 0;
            this.col = 0;

            for (int currRow = 0; currRow < this.size; currRow++)
            {
                for (int currCol = 0; currCol < this.size; currCol++)
                {
                    if (this.matrix[currRow, currCol] == 0)
                    {
                        this.row = currRow;
                        this.col = currCol;
                        return;
                    }
                }
            }
        }

        private void FillAvailableCells()
        {
            int directionRow = 1;
            int directionCol = 1;
            int cellValue = 1;

            while (true)
            {
                this.matrix[this.row, this.col] = cellValue;

                if (!this.IsCellAvailable(this.row, this.col))
                {
                    this.FindAvailableCell();
                    if (this.IsCellAvailable(this.row, this.col))
                    {
                        cellValue++;
                        this.matrix[this.row, this.col] = cellValue;
                        directionRow = 1;
                        directionCol = 1;
                    }
                    else
                    {
                        break;
                    }
                }

                int nextRow = this.row + directionRow;
                int nextCol = this.col + directionCol;

                if (!this.IsInRange(nextRow) || !this.IsInRange(nextCol) || this.matrix[nextRow, nextCol] != 0)
                {
                    while (!this.IsInRange(nextRow) || !this.IsInRange(nextCol) || this.matrix[nextRow, nextCol] != 0)
                    {
                        this.GetDirection(ref directionRow, ref directionCol);

                        nextRow = this.row + directionRow;
                        nextCol = this.col + directionCol;
                    }
                }

                this.row = nextRow;
                this.col = nextCol;
                cellValue++;
            }
        }

        private bool IsNextCellEmpty(int row, int col, int[] directionRow, int[] directionCol)
        {
            for (int dirIndex = 0; dirIndex < DirectionsCount; dirIndex++)
            {
                int nextRow = row + directionRow[dirIndex];
                int nextCol = col + directionCol[dirIndex];

                if (this.matrix[nextRow, nextCol] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsInRange(int value)
        {
            if (value >= this.size || value < 0)
            {
                return false;
            }

            return true;
        }
    }
}