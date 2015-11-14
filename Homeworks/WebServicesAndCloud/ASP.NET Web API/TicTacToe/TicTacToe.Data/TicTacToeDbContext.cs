namespace TicTacToe.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Migrations;
    using Models;

    public class TicTacToeDbContext : IdentityDbContext<User>
    {
        public TicTacToeDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TicTacToeDbContext, Configuration>());
        }

        public IDbSet<Game> Games { get; set; }

        public static TicTacToeDbContext Create()
        {
            return new TicTacToeDbContext();
        }
    }
}
