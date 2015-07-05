//Write a program that prints from given array of integers all 
//numbers that are divisible by 7 and 3. Use the built-in 
//extension methods and lambda expressions. 
//Rewrite the same with LINQ.

namespace _04_Divisible_by_7_and_3
{
    using System;
    using System.Linq;

    class DivisibleBy7And3
    {
        static void Main()
        {
            int[] array = Enumerable.Range(1, 50).ToArray();

            int[] resultWithLambda = array.Where(x => x % 3 == 0 && x % 7 == 0).ToArray();

            Console.WriteLine("Numbers, divisable by 3 and 7 usung lambda: " + string.Join(", ", resultWithLambda));

            var resultWithLinq =
                from number in array
                where number % 3 == 0 && number % 7 == 0
                select number;

            Console.WriteLine("Numbers, divisable by 3 and 7 usung LINQ: " + string.Join(", ", resultWithLinq));
        }
    }
}
