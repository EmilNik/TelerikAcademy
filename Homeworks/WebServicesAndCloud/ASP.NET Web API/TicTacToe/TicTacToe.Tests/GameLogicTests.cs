namespace TicTacToe.Tests
{
    using GameLogic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GameLogicTests
    {
        [TestMethod]
        public void WhenXWins()
        {
            var resultValidator = new GameResultValidator();
            var board = "--X--X--X";

            var result = resultValidator.GetResult(board);

            Assert.AreEqual(GameResult.WonByX, result);
        }

        [TestMethod]
        public void WhenXWinsAgain()
        {
            var resultValidator = new GameResultValidator();
            var board = "X---X---X";

            var result = resultValidator.GetResult(board);

            Assert.AreEqual(GameResult.WonByX, result);
        }

        [TestMethod]
        public void WhenOWins()
        {
            var resultValidator = new GameResultValidator();
            var board = "-O--O--O-";

            var result = resultValidator.GetResult(board);

            Assert.AreEqual(GameResult.WonByO, result);
        }

        [TestMethod]
        public void WhenOWinsAgain()
        {
            var resultValidator = new GameResultValidator();
            var board = "------OOO";

            var result = resultValidator.GetResult(board);

            Assert.AreEqual(GameResult.WonByO, result);
        }

        [TestMethod]
        public void WhenDraw()
        {
            var resultValidator = new GameResultValidator();
            var board = "OXOXOXXOX";

            var result = resultValidator.GetResult(board);

            Assert.AreEqual(GameResult.Draw, result);
        }
    }
}
