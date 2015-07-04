using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeer
{
    public class Minesweeer
    {
        public class Scores
        {
            string name;
            int score;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public int Score
            {
                get { return score; }
                set { score = value; }
            }

            public Scores() { }

            public Scores(string name, int score)
            {
                this.name = name;
                this.score = score;
            }
        }

        static void Main(string[] args)
        {
            const int MOVES_TO_WIN = 35;

            string command = string.Empty;
            char[,] playground = GeneratePlayground();
            char[,] mines = GenerateMines();
            int pointsCount = 0;
            bool gaveOver = false;
            List<Scores> highScores = new List<Scores>(6);
            int row = 0;
            int col = 0;
            bool startOfGame = true;
            bool wonTheGame = false;

            do
            {
                if (startOfGame)
                {
                    Console.WriteLine("Let's play Minesweeper! Try your luck and find all mines on the field." +
                    " Command 'top' shows the HighScores, 'restart' starts a new game, 'exit' quits the game!");
                    PrintPlayground(playground);
                    startOfGame = false;
                }

                Console.Write("Enter row and col: ");
                command = Console.ReadLine().Trim();

                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                    int.TryParse(command[2].ToString(), out col) &&
                        row <= playground.GetLength(0) && col <= playground.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        ShowHighScores(highScores);
                        break;
                    case "restart":
                        playground = GeneratePlayground();
                        mines = GenerateMines();
                        PrintPlayground(playground);
                        gaveOver = false;
                        startOfGame = false;
                        break;
                    case "exit":
                        Console.WriteLine("Bye, bye!");
                        break;
                    case "turn":
                        if (mines[row, col] != '*')
                        {
                            if (mines[row, col] == '-')
                            {
                                ShowFieldValue(playground, mines, row, col);
                                pointsCount++;
                            }
                            if (MOVES_TO_WIN == pointsCount)
                            {
                                wonTheGame = true;
                            }
                            else
                            {
                                PrintPlayground(playground);
                            }
                        }
                        else
                        {
                            gaveOver = true;
                        }
                        break;
                    default:
                        Console.WriteLine("\nInvalid command!\n");
                        break;
                }

                if (gaveOver)
                {
                    PrintPlayground(mines);
                    Console.Write("\nYou ded with {0} points!" +
                        "Enter your name: ", pointsCount);
                    string nickName = Console.ReadLine();
                    Scores t = new Scores(nickName, pointsCount);
                    if (highScores.Count < 5)
                    {
                        highScores.Add(t);
                    }
                    else
                    {
                        for (int i = 0; i < highScores.Count; i++)
                        {
                            if (highScores[i].Score < t.Score)
                            {
                                highScores.Insert(i, t);
                                highScores.RemoveAt(highScores.Count - 1);
                                break;
                            }
                        }
                    }

                    highScores.Sort((Scores r1, Scores r2) => r2.Name.CompareTo(r1.Name));
                    highScores.Sort((Scores r1, Scores r2) => r2.Score.CompareTo(r1.Score));
                    ShowHighScores(highScores);

                    playground = GeneratePlayground();
                    mines = GenerateMines();
                    pointsCount = 0;
                    gaveOver = false;
                    startOfGame = true;
                }

                if (wonTheGame)
                {
                    Console.WriteLine("\nNice job! you opened 35 fields without stepping on a mine!");
                    PrintPlayground(mines);
                    Console.WriteLine("Enter your name, batka: ");
                    string imeee = Console.ReadLine();
                    Scores playerScore = new Scores(imeee, pointsCount);
                    highScores.Add(playerScore);
                    ShowHighScores(highScores);
                    playground = GeneratePlayground();
                    mines = GenerateMines();
                    pointsCount = 0;
                    wonTheGame = false;
                    startOfGame = true;
                }
            }

            while (command != "exit");
            Console.WriteLine("Press any key to exit!");
            Console.Read();
        }

        private static void ShowHighScores(List<Scores> highScore)
        {
            Console.WriteLine("\nHighScore:");
            if (highScore.Count > 0)
            {
                for (int i = 0; i < highScore.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} fields opened",
                        i + 1, highScore[i].Name, highScore[i].Score);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("The HighScore chart is empty yet!\n");
            }
        }

        private static void ShowFieldValue(char[,] playground,
                                            char[,] mines, int row, int col)
        {
            char numberOfBombs = CountMines(mines, row, col);
            mines[row, col] = numberOfBombs;
            playground[row, col] = numberOfBombs;
        }

        private static void PrintPlayground(char[,] board)
        {
            int row = board.GetLength(0);
            int col = board.GetLength(1);

            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int i = 0; i < row; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < col; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }
                Console.Write("|");
                Console.WriteLine();
            }
            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] GeneratePlayground()
        {
            int rows = 5;
            int cols = 10;
            char[,] playground = new char[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    playground[i, j] = '?';
                }
            }

            return playground;
        }

        private static char[,] GenerateMines()
        {
            int rows = 5;
            int cols = 10;
            char[,] playground = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    playground[i, j] = '-';
                }
            }

            List<int> mines = new List<int>();
            while (mines.Count < 15)
            {
                Random random = new Random();
                int randomNumber = random.Next(50);
                if (!mines.Contains(randomNumber))
                {
                    mines.Add(randomNumber);
                }
            }

            foreach (int mine in mines)
            {
                int col = (mine / cols);
                int row = (mine % cols);

                if (row == 0 && mine != 0)
                {
                    col--;
                    row = cols;
                }
                else
                {
                    row++;
                }

                playground[col, row - 1] = '*';
            }

            return playground;
        }

        private static void CalculateFieldValue(char[,] playground)
        {
            int col = playground.GetLength(0);
            int row = playground.GetLength(1);

            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (playground[i, j] != '*')
                    {
                        char minesCount = CountMines(playground, i, j);
                        playground[i, j] = minesCount;
                    }
                }
            }
        }

        private static char CountMines(char[,] playground, int row, int col)
        {
            int count = 0;
            int rows = playground.GetLength(0);
            int cols = playground.GetLength(1);

            if (row - 1 >= 0)
            {
                if (playground[row - 1, col] == '*')
                {
                    count++;
                }
            }
            if (row + 1 < rows)
            {
                if (playground[row + 1, col] == '*')
                {
                    count++;
                }
            }
            if (col - 1 >= 0)
            {
                if (playground[row, col - 1] == '*')
                {
                    count++;
                }
            }
            if (col + 1 < cols)
            {
                if (playground[row, col + 1] == '*')
                {
                    count++;
                }
            }
            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (playground[row - 1, col - 1] == '*')
                {
                    count++;
                }
            }
            if ((row - 1 >= 0) && (col + 1 < cols))
            {
                if (playground[row - 1, col + 1] == '*')
                {
                    count++;
                }
            }
            if ((row + 1 < rows) && (col - 1 >= 0))
            {
                if (playground[row + 1, col - 1] == '*')
                {
                    count++;
                }
            }
            if ((row + 1 < rows) && (col + 1 < cols))
            {
                if (playground[row + 1, col + 1] == '*')
                {
                    count++;
                }
            }
            return char.Parse(count.ToString());
        }
    }
}
