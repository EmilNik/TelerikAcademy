namespace TicketSystem.Web.Models
{
    using Microsoft.AspNet.Identity.EntityFramework;

    using TicketSystem.Models;


    public class TicketSystemDbContext : IdentityDbContext<User>
    {
        public TicketSystemDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static TicketSystemDbContext Create()
        {
            return new TicketSystemDbContext();
        }
    }
}