//A marketing company wants to keep record of its employees. Each record would have the following characteristics:

//First name
//Last name
//Age (0...100)
//Gender (m or f)
//Personal ID number (e.g. 8306112507)
//Unique employee number (27560000…27569999)
//Declare the variables needed to keep the information for a single employee using appropriate
//primitive data types. Use descriptive names. Print the data at the console.

using System;

    class EmployeeData
    {
        static void Main()
        {
            string firstName = "Scumbag";
            string lastName = "Steve";
            byte age = 25;
            char gender = 'M';
            long ID = 8306112507;
            int unqueeNumber = 27560000;

            Console.WriteLine("First name: {0}\nLast name: {1}\nAge: {2}\nGender: {3}\nPersonal ID number: {4}\nUnique employee number: {5}", firstName, lastName, age, gender, ID, unqueeNumber);
        }
    }
