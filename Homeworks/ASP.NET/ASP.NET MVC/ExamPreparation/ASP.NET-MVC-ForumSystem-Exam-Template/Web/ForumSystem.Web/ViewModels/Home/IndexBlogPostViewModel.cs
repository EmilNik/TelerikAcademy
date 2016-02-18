namespace ForumSystem.Web.ViewModels.Home
{
    using Data.Models;
    using Infrastructure.Mapping;
    using System.Collections.Generic;
    using AutoMapper;
    using System.Linq;

    public class IndexBlogPostViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Url => $"/questions/{Id}/{Title.ToLower().Replace(" ", "-")}";

        public IEnumerable<IndexBlogPostTagViewModel> Tags { get; set; }

        public int VotesCount { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Post, IndexBlogPostViewModel>()
                .ForMember(x => x.VotesCount,
                opt => opt.MapFrom(x => x.Votes.Any() ? x.Votes.Sum(v => (int)v.Type) : 0));
        }
    }
}