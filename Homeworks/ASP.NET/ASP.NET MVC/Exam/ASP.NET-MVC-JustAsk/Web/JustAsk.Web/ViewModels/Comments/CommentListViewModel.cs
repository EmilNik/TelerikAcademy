namespace JustAsk.Web.ViewModels.Comments
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Data.Models;
    using Infrastructure.Mapping;

    using Infrastructure;

    public class CommentListViewModel : IMapFrom<Comment>
    {
        private ISanitizer sanitizer;

        public CommentListViewModel()
        {
            this.sanitizer = new HtmlSanitizerAdapter();
        }

        public int Id { get; set; }

        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        public string SanitizedContent => this.sanitizer.Sanitize(this.Content);

        public string AuthorEmail { get; set; }

        public string AuthorId { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
