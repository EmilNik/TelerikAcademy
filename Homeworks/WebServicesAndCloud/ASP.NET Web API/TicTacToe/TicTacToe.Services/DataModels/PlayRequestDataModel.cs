namespace TicTacToe.Services.DataModels
{
    using System.ComponentModel.DataAnnotations;

    public class PlayRequestDataModel
    {
        [Required]
        public string gameId { get; set; }

        [Range(1, 3)]
        public int row { get; set; }

        [Range(1, 3)]
        public int col { get; set; }
    }
}