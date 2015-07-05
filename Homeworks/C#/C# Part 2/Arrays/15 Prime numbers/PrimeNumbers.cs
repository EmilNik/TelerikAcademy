using System;

class PrimeNumbers
{
    static void Main()
    {
        //Write a program that finds all prime numbers in the range [1...10 000 000]. 
        //Use the Sieve of Eratosthenes algorithm.

        bool[] isPrime = new bool[10000000];

        for (int i = 2; i < Math.Sqrt(isPrime.Length); i++)
        {

            if (isPrime[i] == false)
            {
                for (int j = i * i; j < isPrime.Length; j += i)
                {
                    isPrime[j] = true;
                }
            }
        }

        for (int i = 2; i < isPrime.Length; i++)
        {
            if (!isPrime[i]) Console.Write(i + " ");
        }
    }
}
