namespace JustAsk.Web.ViewModels.Comments
{
    using System;
    using System.Text.RegularExpressions;
    using Data.Models;
    using Infrastructure;
    using Infrastructure.Mapping;

    public class CommentViewModel : IMapFrom<Comment>
    {
        private ISanitizer sanitizer;

        public CommentViewModel()
        {
            this.sanitizer = new HtmlSanitizerAdapter();
        }

        public string Content { get; set; }

        public string SanitizedContent => this.sanitizer.Sanitize(this.Content);

        public string AuthorEmail { get; set; }

        public string HiddenEmail
        {
            get
            {
                string regex = @"(.{2}).+@.+(.{2}(?:\..{2,3}){1,2})";
                string replace = "$1*@*$2";

                return Regex.Replace(this.AuthorEmail, regex, replace);
            }
        }

        public DateTime CreatedOn { get; set; }
    }
}
