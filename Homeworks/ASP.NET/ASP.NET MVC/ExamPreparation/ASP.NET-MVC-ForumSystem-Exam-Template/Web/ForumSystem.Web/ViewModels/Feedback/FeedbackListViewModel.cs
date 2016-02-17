namespace ForumSystem.Web.ViewModels.Feedback
{
    using System.Collections.Generic;

    public class FeedbackListViewModel
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<FeedbackViewModel> Feedbacks { get; set; }
    }
}