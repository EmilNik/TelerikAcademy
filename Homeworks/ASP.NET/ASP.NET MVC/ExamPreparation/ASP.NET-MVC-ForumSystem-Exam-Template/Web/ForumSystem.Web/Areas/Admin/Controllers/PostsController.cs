namespace ForumSystem.Web.Areas.Admin
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using ForumSystem.Data.Models;
    using ForumSystem.Data.Common.Repository;
    using ViewModels;
    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNet.Identity;
    public class PostsController : Controller
    {
        IDeletableEntityRepository<Post> posts;

        public PostsController(IDeletableEntityRepository<Post> posts)
        {
            this.posts = posts;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Posts_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.posts.All()
                .Project().To<PostViewModel>()
                .ToDataSourceResult(request);

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Posts_Create([DataSourceRequest]DataSourceRequest request, PostInputModel post)
        {
            var newId = 0;
            if (ModelState.IsValid)
            {
                var entity = new Post
                {
                    Title = post.Title,
                    Content = post.Content,
                    AuthorId = this.User.Identity.GetUserId()
                };

                this.posts.Add(entity);
                this.posts.SaveChanges();
                newId = entity.Id;
            }

            var postToDisplay = this.posts.All().Project()
                .To<PostViewModel>()
                .FirstOrDefault(x => x.Id == newId);
            return Json(new[] { postToDisplay }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Posts_Update([DataSourceRequest]DataSourceRequest request, PostViewModel post)
        {
            var newId = 0;
            if (ModelState.IsValid)
            {
                var entity = this.posts.GetById(post.Id);
                entity.Title = post.Title;
                entity.Content = post.Content;
                newId = entity.Id;

                this.posts.SaveChanges();
            }

            var postToDisplay = this.posts.All().Project()
                .To<PostViewModel>()
                .FirstOrDefault(x => x.Id == newId);
            return Json(new[] { postToDisplay }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Posts_Destroy([DataSourceRequest]DataSourceRequest request, Post post)
        {
            var entity = new Post
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                IsDeleted = post.IsDeleted,
                DeletedOn = post.DeletedOn,
                CreatedOn = post.CreatedOn,
                ModifiedOn = post.ModifiedOn
            };

            this.posts.Delete(post.Id);
            this.posts.SaveChanges();

            return Json(new[] { post }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }

        protected override void Dispose(bool disposing)
        {
            this.posts.Dispose();
            base.Dispose(disposing);
        }
    }
}
