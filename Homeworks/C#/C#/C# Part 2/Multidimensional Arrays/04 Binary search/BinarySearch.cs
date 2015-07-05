using System;

    class BinarySearch
    {
        static void Main()
        {
            //Write a program, that reads from the console an array of N integers and an integer K, sorts the array 
            //and using the method Array.BinSearch() finds the largest number in the array which is ≤ K. 

            int[] array = { 8, 1, 0, 2, 3, 6, 6, 7 };
            Console.WriteLine("Please Enter K number: ");
            int K = int.Parse(Console.ReadLine());
            Array.Sort(array);
            int searchedNumber = Array.BinarySearch(array, K);

            foreach (int number in array)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine();

            if (searchedNumber < -1)
            {
                Console.WriteLine("Largest number lower than or equal to {0} is {1}", K, array[~searchedNumber - 1]);
            }
            else if (~searchedNumber == 0)
            {
                Console.WriteLine("No such number");
            }
            else
            {
                Console.WriteLine("Largest number lower than or equal to {0} is {1}", K, array[searchedNumber]);
            }
        }
    }
}