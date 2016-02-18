namespace ForumSystem.Web.Areas.Admin
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class PostInputModel
    {
        [MaxLength(100)]
        public string Title { get; set; }

        [AllowHtml]
        public string Content { get; set; }
    }
}