namespace Bank_accounts.Accounts
{
    using System;

    public class Account
    {
        private Customer customer;
        private decimal balance;
        private decimal interestRate;

        public Account(Customer customer, decimal balance, decimal interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public Customer Customer { get; private set; }
        public decimal Balance { get; protected set; }
        public decimal InterestRate { get; private set; }

        public virtual decimal CalculateInterestRate(int numberOfMonths)
        {
            return numberOfMonths * this.InterestRate;
        }
    }
}
