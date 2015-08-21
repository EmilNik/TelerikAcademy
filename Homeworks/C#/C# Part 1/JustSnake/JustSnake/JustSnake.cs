namespace JustSnake
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    class JustSnake
    {
        public struct Position
        {
            public int row;
            public int col;

            public Position(int row, int col)
            {
                this.row = row;
                this.col = col;
            }
        }

        static void Main()
        {
            byte right = 0;
            byte left = 1;
            byte down = 2;
            byte up = 3;

            Position[] directions = new Position[]
            {
                new Position(0, 1), //right
                new Position(0, -1), //left
                new Position(1, 0), //down
                new Position(-1, 0) //up
            };

            int sleepTime = 100;

            int direction = right;

            Random randomNumberGenerator = new Random();
            Position food = new Position(randomNumberGenerator.Next(0, Console.WindowHeight), randomNumberGenerator.Next(0, Console.WindowWidth));


            Console.BufferHeight = Console.WindowHeight;

            Queue<Position> snakeElements = new Queue<Position>();

            for (int i = 0; i < 5; i++)
            {
                snakeElements.Enqueue(new Position(0, i));
            }

            DrawSnake(snakeElements);

            while (true)
            {

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo userInput = Console.ReadKey();

                    if (userInput.Key == ConsoleKey.RightArrow)
                    {
                        if (userInput.Key == ConsoleKey.LeftArrow)
                        {
                            if (direction != right)
                            {
                                direction = left;
                            }
                        }

                        if (userInput.Key == ConsoleKey.RightArrow)
                        {
                            if (direction != left)
                            {
                                direction = right;
                            }
                        }
                        if (userInput.Key == ConsoleKey.UpArrow)
                        {
                            if (direction != down)
                            {
                                direction = up;
                            }
                        }
                        if (userInput.Key == ConsoleKey.DownArrow)
                        {
                            if (direction != up)
                            {
                                direction = down;
                            }
                        }
                    }
                }

                var snakeHead = snakeElements.Last();

                var nextDirection = directions[direction];
                var snakeNewHead = new Position(snakeHead.row + nextDirection.row, snakeHead.col + nextDirection.col);

                if (snakeNewHead.row < 0 ||
                    snakeNewHead.col < 0 ||
                    snakeNewHead.row >= Console.WindowHeight ||
                    snakeNewHead.col >= Console.WindowWidth ||
                    snakeElements.Contains(snakeNewHead))
                {
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("Game over!");
                    Console.WriteLine("Your points are: {0}", (snakeElements.Count - 5) * 10);
                    return;
                }

                if (snakeNewHead.row == food.row && snakeNewHead.col == food.col)
                {
                    food = new Position(randomNumberGenerator.Next(0, Console.WindowHeight), randomNumberGenerator.Next(0, Console.WindowWidth));
                    sleepTime -= 5;
                }
                else
                {
                    snakeElements.Dequeue();
                }

                snakeElements.Enqueue(snakeNewHead);

                Console.Clear();

                DrawSnake(snakeElements);

                Console.SetCursorPosition(food.col, food.row);
                Console.Write('@');

                Thread.Sleep(sleepTime);
            }
        }

        static void DrawSnake(Queue<Position> snakeElements)
        {
            foreach (Position position in snakeElements)
            {
                Console.SetCursorPosition(position.col, position.row);
                Console.WriteLine('*');
            }
        }
    }
}
