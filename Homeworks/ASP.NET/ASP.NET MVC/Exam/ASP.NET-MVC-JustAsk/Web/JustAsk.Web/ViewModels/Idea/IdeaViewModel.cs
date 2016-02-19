namespace JustAsk.Web.ViewModels.Idea
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using Comments;
    using Data.Models;
    using Infrastructure;
    using Infrastructure.Mapping;

    public class IdeaViewModel : IMapFrom<Idea>, IHaveCustomMappings
    {
        private ISanitizer sanitizer;

        public IdeaViewModel()
        {
            this.sanitizer = new HtmlSanitizerAdapter();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string SanitizedTitle => this.sanitizer.Sanitize(this.Title);

        public string Description { get; set; }

        public string SanitizedDescription => this.sanitizer.Sanitize(this.Description);

        public ICollection<CommentViewModel> Comments { get; set; }

        public CommentInputModel NewComment { get; set; }

        public string Url => $"/Ideas/Index/{this.Id}";

        public int CommentsCount { get; set; }

        public int Votes { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Idea, IdeaViewModel>()
                .ForMember(x => x.CommentsCount, opt => opt.MapFrom(x => x.Comments.Count))
                .ForMember(x => x.Votes, opt => opt.MapFrom(x => x.Votes.Any() ? x.Votes.Sum(v => (int)v.Value) : 0));
        }
    }
}
