using System;

    class PrimeNumberCheck
    {
        static void Main()
        {
            //Write an expression that checks if given positive integer number n (n <= 100) 
            //is prime (i.e. it is divisible without remainder only to itself and 1).

            Console.WriteLine("Enter a number and i will see if it is prime: ");
            int num = int.Parse(Console.ReadLine());

            if (num >= 0 & num <= 100)
            {
                bool isPrime = num % 2 != 0 & num % 3 != 0 & num % 5 != 0;
                Console.WriteLine(isPrime ? "Yes, your number is prime." : "No, your number is not prime.");
            }

            else
            {
                Console.WriteLine("Your number must be positive and less than 100.");
            }
        }
    }
