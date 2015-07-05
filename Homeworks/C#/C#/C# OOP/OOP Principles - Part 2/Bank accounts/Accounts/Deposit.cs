namespace Bank_accounts.Accounts
{
    using Bank_accounts.Interfaces;
    using System;

    public class DepositAccount : Account, IDepositable, IWithdrowable
    {
        public DepositAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {

        }

        public void DepositAmount(decimal ammount)
        {
            this.Balance += ammount;
        }

        public void WithdrawAmount(decimal ammount)
        {
            if (ammount > this.Balance)
            {
                throw new ArgumentException("Amount is higher than balance in the account");
            }
            this.Balance -= ammount;
        }
        public override decimal CalculateInterestAmount(int numOfMonths)
        {
            if (this.Balance > 0 && this.Balance < 1000)
            {
                return 0;
            }
            return base.CalculateInterestRate(numOfMonths);
        }
    }
}
