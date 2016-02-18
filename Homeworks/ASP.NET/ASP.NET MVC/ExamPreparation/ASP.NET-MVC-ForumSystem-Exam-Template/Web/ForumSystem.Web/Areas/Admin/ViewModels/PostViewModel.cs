namespace ForumSystem.Web.Areas.Admin.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;
    using Infrastructure;
    using System.Web.Mvc;
    public class PostViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        ISanitizer sanitizer;
        public PostViewModel()
        {
            this.sanitizer = new HtmlSanitizerAdapter();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

        public string AuthorName { get; set; }

        [AllowHtml]
        [UIHint("tinymce_full")]
        public string Content { get; set; }

        public string SanitizedContent => this.sanitizer.Sanitize(this.Content);

        public bool IsDeleted { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Post, PostViewModel>()
                .ForMember(x => x.AuthorName, opt => opt.MapFrom(x => x.Author.UserName));
        }
    }
}