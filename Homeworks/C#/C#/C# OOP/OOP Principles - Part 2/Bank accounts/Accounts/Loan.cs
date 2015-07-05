namespace Bank_accounts.Accounts
{
    using Bank_accounts.Interfaces;
    using System;

    public class LoanAccount : Account, IDepositable
    {
        public LoanAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {

        }

        public void DepositAmount(decimal ammount)
        {
            this.Balance += ammount;
        }

        public override decimal CalculateInterestAmount(int numOfMonths)
        {
            if (this.Customer is IndividualCustomer)
            {
                numOfMonths -= 3;
            }
            else if (this.Customer is Company)
            {
                numOfMonths -= 2;
            }
            if (numOfMonths <= 0)
            {
                return 0;
            }
            return numOfMonths * this.InterestRate;
        }
    }
}
