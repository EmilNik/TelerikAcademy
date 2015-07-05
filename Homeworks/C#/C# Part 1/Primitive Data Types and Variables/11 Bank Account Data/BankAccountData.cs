//A bank account has a holder name (first name, middle name and last name), available amount of money 
//(balance), bank name, IBAN, 3 credit card numbers associated with the account.
//Declare the variables needed to keep the information for a single bank account using the appropriate
//data types and descriptive names.

using System;

    class BankAccountData
    {
        static void Main()
        {
            string firstName = "Иван";
            string middleName = "Йорданов";
            string lastName = "Костов";
            long balance = 1000000;
            string bankName = "Корпоративна търговска банка";
            string IBAN = "IBAN2551525155ASD445";
            long firstCard = 0123456789;
            long secondCard = 1470258369;
            long thirdCard = 9876543210;
        }
    }
