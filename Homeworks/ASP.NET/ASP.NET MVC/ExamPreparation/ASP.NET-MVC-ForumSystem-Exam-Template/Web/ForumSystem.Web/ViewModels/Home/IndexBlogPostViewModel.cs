namespace ForumSystem.Web.ViewModels.Home
{
    using Data.Models;
    using Infrastructure.Mapping;
    using System.Collections.Generic;
    public class IndexBlogPostViewModel : IMapFrom<Post>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Url => $"/questions/{Id}/{Title.ToLower().Replace(" ","-")}";

        public IEnumerable<IndexBlogPostTagViewModel> Tags { get; set; }
    }
}