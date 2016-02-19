namespace JustAsk.Web.ViewModels.Idea
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class IdeaInputModel
    {
        [Required]
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        public string Title { get; set; }
    }
}
