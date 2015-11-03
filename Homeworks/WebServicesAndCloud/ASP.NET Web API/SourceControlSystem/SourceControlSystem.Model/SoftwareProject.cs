namespace SourceControlSystem.Model
{
    using System;
    using System.Collections.Generic;

    public class SoftwareProject
    {
        private ICollection<User> users;

        public SoftwareProject()
        {
            this.users = new HashSet<User>();
        }

        public int Id { get; set; }

        public virtual ICollection<User> users { get; set; }
    }
}
