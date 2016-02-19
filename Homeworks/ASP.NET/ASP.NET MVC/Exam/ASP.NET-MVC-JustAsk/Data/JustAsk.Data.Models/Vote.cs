namespace JustAsk.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Common.Models;

    public class Vote : BaseModel<int>
    {
        public string AuthorId { get; set; }

        public VoteType Value { get; set; }

        [Required]
        public int IdeaId { get; set; }

        public virtual Idea Idea { get; set; }
    }
}
