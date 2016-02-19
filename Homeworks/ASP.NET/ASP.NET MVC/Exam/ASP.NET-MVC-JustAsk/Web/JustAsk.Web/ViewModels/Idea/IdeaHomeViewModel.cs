namespace JustAsk.Web.ViewModels.Idea
{
    using System.Collections.Generic;

    public class IdeaHomeViewModel
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<IdeaViewModel> Ideas { get; set; }
    }
}
