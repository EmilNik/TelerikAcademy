namespace TicTacToe.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using Models;
    using Repositories;

    public class TicTacToeData : ITicTacToeData
    {
        private DbContext context;
        private IDictionary<Type, object> repositories;

        public TicTacToeData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Game> Games
        {
            get
            {
                return this.GetRepository<Game>();
            }
        }

        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>()
            where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(EFRepository<T>), this.context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }
    }
}
