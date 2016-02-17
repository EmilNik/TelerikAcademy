namespace ForumSystem.Web.ViewModels.Feedback
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    public class FeedbackViewModel
    {
        [Required]
        [StringLength(20)]
        public string Title { get; set; }

        [Required]
        [AllowHtml]
        [StringLength(500)]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
    }
}