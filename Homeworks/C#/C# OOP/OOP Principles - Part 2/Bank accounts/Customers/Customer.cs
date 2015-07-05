namespace Bank_accounts.Accounts
{
    using System;

    public abstract class Customer
    {
        private string name;

        public Customer(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }
    }
}
