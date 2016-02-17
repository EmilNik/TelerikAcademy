namespace TicketSystem.Data.Migrations
{
    using Common;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<TicketSystemDbContext>
    {
        private UserManager<User> userManager;
        private IRandomGenerator randomGenerator;

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.randomGenerator = new RandomGenerator();
        }

        protected override void Seed(TicketSystemDbContext context)
        {
            this.userManager = new UserManager<User>(new UserStore<User>(context));
            this.SeedRolles(context);
            this.SeedUsers(context);
            this.SeedCategoriesWithTicketsAndComments();
        }

        private void SeedRolles(TicketSystemDbContext context)
        {
            context.Roles.AddOrUpdate(x => x.Name, new IdentityRole(GlobalConstants.AdminRole));
            context.SaveChanges();
        }

        private void SeedUsers(TicketSystemDbContext context)
        {
            for (int i = 0; i < 10; i++)
            {
                var user = new User
                {
                    Email = string.Format("{0}@{1}.com", this.randomGenerator.RandomString(6, 16), this.randomGenerator.RandomString(6, 16)),
                    UserName = this.randomGenerator.RandomString(6, 16)
                };

                this.userManager.Create(user, "123456");

                this.userManager.AddToRole(user.Id, GlobalConstants.AdminRole);
            }

        }

        private void SeedCategoriesWithTicketsAndComments()
        {
            throw new NotImplementedException();
        }
    }
}
