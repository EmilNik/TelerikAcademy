using System;

    class PrintCompanyInformation
    {
        static void Main()
        {
            //A company has name, address, phone number, fax number, web site and manager. 
            //The manager has first name, last name, age and a phone number.
            //Write a program that reads the information about a company and its manager and prints it back on the console.

            Console.Write("Company name: ");
            string companyName = Console.ReadLine();

            Console.Write("Company address: ");
            string companyAddress = Console.ReadLine();

            Console.Write("Phone number: ");
            string companyPhone = Console.ReadLine();

            Console.Write("Fax number: ");
            string faxNumber = Console.ReadLine();

            Console.Write("Web site: ");
            string webSite = Console.ReadLine();

            Console.Write("Manager first name: ");
            string firstName = Console.ReadLine();

            Console.Write("Manager last name: ");
            string lastName = Console.ReadLine();

            Console.Write("Manager age: ");
            string age = Console.ReadLine();

            Console.Write("Manager phone: ");
            string managerPhone = Console.ReadLine();

            Console.Clear();

            Console.WriteLine("{0}\nAddress: {1}\nTel. {2}\nFax: {3}\nWeb site: {4}\nManager: {5} {6} (Age: {7}, Tel. {8})", companyName, companyAddress, companyPhone, faxNumber, webSite, firstName, lastName, age, managerPhone);
        }
    }
