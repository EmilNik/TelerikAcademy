namespace TicTacToe.Services.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using TicTacToe.Models;

    public class GameInfoDataModel
    {
        public Guid Id { get; set; }

        public string Board { get; set; }

        public string FirstPlayerName { get; set; }

        public string SecondPlayerName { get; set; }

        public GameState State { get; set; }
    }
}