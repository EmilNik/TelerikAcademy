namespace ForumSystem.Data.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;

            // TODO: Remove in production
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            var tagList = new List<Tag>();
            if (!context.Tags.Any())
            {
                for (int i = 0; i < 20; i++)
                {
                    var tag = new Tag() { Name = $"Tag {i}" };
                    context.Tags.Add(tag);
                    tagList.Add(tag);
                }

                context.SaveChanges();

                var tagIndex = 0;
                for (int i = 0; i < 20; i++)
                {
                    var post = new Post() { Content = $"Post content {i}", Title = $"Post title {i}" };

                    for (int j = 0; j < 5; j++)
                    {
                        post.Tags.Add(tagList[tagIndex % tagList.Count]);
                        tagIndex++;
                    }

                    context.Posts.Add(post);
                }

                context.SaveChanges();

                if (!context.Feedbacks.Any())
                {
                    for (int i = 0; i < 18; i++)
                    {
                        var feedback = new Feedback()
                        {
                            Content = $"Feedback <b>content</b> {i}",
                            Title = $"Feedback Title {i}"
                        };

                        context.Feedbacks.Add(feedback);
                    }

                    context.SaveChanges();
                }
            }
        }
    }
}
