namespace JustAsk.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Common.Models;

    public class Comment : BaseModel<int>
    {
        [Required]
        public string Content { get; set; }

        public string AuthorEmail { get; set; }

        public string AuthorId { get; set; }

        public virtual Idea Idea { get; set; }
    }
}
