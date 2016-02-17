namespace TicketSystem.Data
{
    using System.Data.Entity;
    using TicketSystem.Models;

    public interface ITicketSystemData
    {
        DbContext Context { get; }

        IRepository<Category> Categories { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Image> Images { get; }

        IRepository<Ticket> Tickets { get; }

        IRepository<User> Users { get; }

        void Dispose();

        int SaveChanges();
    }
}