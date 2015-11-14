namespace TicTacToe.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Data;
    using Data.Repositories;
    using GameLogic;
    using Services.Controllers;
    using Services.DataModels;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using Moq;
    using Services.Infrastructure;

    [TestClass]
    public class PlayActionTests
    {
        [TestMethod]
        public void WhenIsXsTurnChangeGameStateToO()
        {
            var userId = "some user id";
            var newGameId = Guid.NewGuid();
            var game = new Game
            {
                Id = newGameId,
                FirstPlayerId = userId,
                State = GameState.TurnX
            };

            var userIdProviderMock = new Mock<IUserIdProvider>();
            userIdProviderMock.Setup(x => x.GetUserId())
                .Returns(userId);

            var repositoryMock = new Mock<IRepository<Game>>();
            repositoryMock.Setup(x => x.All())
                .Returns(() => new List<Game>()
                {
                    game
                }
                .AsQueryable());

            repositoryMock.Setup(x => x.Find(It.IsAny<Guid>()))
                .Returns(game);

            var uowData = new Mock<ITicTacToeData>();
            uowData.SetupGet(x => x.Games)
                .Returns(repositoryMock.Object);
            var controller = new GamesController
                (
                uowData.Object,
                new GameResultValidator(),
                userIdProviderMock.Object
                );

            controller.Play(new PlayRequestDataModel()
            {
                gameId = newGameId.ToString(),
                col = 1,
                row = 1
            });

            Assert.AreEqual(GameState.TurnO, game.State);
        }
    }
}
