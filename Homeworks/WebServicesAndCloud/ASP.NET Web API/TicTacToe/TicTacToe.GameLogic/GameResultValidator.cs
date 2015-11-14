namespace TicTacToe.GameLogic
{
    public class GameResultValidator : IGameResultValidator
    {
        static private int[,] Winners = new int[,]
                      {
                        {0,1,2},
                        {3,4,5},
                        {6,7,8},
                        {0,3,6},
                        {1,4,7},
                        {2,5,8},
                        {0,4,8},
                        {2,4,6}
                      };

        public GameResult GetResult(string board)
        {
            if (board.IndexOf('-') < 0)
            {
                return GameResult.Draw;
            }

            for (int i = 0; i < 8; i++)
            {
                var a = board[Winners[i, 0]];
                var b = board[Winners[i, 1]];
                var c = board[Winners[i, 2]];

                if (a == '-' || b == '-' || c == '-')
                {
                    continue;
                }

                if (CheckIfPlayerWins(a, b, c, 'X'))
                {
                    return GameResult.WonByX;
                }

                if (CheckIfPlayerWins(a, b, c, 'O'))
                {
                    return GameResult.WonByO;
                }
            }

            return GameResult.NotFinished;
        }

        private static bool CheckIfPlayerWins(char a, char b, char c, char player)
        {
            if (a == player && b == player && c == player)
            {
                return true;
            }

            return false;
        }
    }
}
