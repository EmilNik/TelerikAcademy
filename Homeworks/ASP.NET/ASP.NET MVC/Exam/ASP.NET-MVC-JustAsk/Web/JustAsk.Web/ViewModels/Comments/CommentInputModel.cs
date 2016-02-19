namespace JustAsk.Web.ViewModels.Comments
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class CommentInputModel
    {
        [Required]
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [Required]
        public string AuthorEmail { get; set; }

        public int IdeaId { get; set; }
    }
}
