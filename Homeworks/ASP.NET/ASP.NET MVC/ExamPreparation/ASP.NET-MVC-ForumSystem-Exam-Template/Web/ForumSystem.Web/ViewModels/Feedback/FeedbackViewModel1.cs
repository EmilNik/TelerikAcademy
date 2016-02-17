namespace ForumSystem.Web.ViewModels.Feedback
{
    using System;
    using AutoMapper;
    using ForumSystem.Web.Infrastructure.Mapping;
    using Infrastructure;
    public class FeedbackViewModel : IMapFrom<ForumSystem.Data.Models.Feedback>, IHaveCustomMappings
    {
        private ISanitizer sanitizer;

        public FeedbackViewModel()
        {
            sanitizer = new HtmlSanitizerAdapter();
        }

        public string Author { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string SanitizedContent => this.sanitizer.Sanitize(this.Content);

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<ForumSystem.Data.Models.Feedback, FeedbackViewModel>()
                .ForMember(x => x.Author, opt => opt.MapFrom(x => x.Author.UserName));
        }
    }
}