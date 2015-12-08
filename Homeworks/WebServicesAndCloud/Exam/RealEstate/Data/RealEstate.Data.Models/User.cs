namespace RealEstate.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        private ICollection<RealEstate> realEstates;
        private ICollection<Rating> raitings;
        private ICollection<Comment> comments;

        public User()
        {
            this.realEstates = new HashSet<RealEstate>();
            this.raitings = new HashSet<Rating>();
            this.comments = new HashSet<Comment>();
        }

        public double Rate { get; set; }

        public virtual ICollection<RealEstate> RealEstates
        {
            get
            {
                return this.realEstates;
            }
            set
            {
                this.realEstates = value;
            }
        }

        public virtual ICollection<Rating> Raiting
        {
            get
            {
                return this.raitings;
            }
            set
            {
                this.raitings = value;
            }
        }

        public object ProjectTo<T>()
        {
            throw new NotImplementedException();
        }

        public virtual ICollection<Comment> Comments
        {
            get
            {
                return this.comments;
            }
            set
            {
                this.comments = value;
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            return userIdentity;
        }
    }
}
