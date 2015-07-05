//Create a program that assigns null values to an integer and to a double variable.
//Try to print these variables at the console.
//Try to add some number or the null literal to these variables and print the result.

using System;

    class NullValuesArithmetic
    {
        static void Main()
        {
            int? nullInt = null;
            double? nullDouble = null;

            Console.WriteLine("Null value: " + nullInt);
            Console.WriteLine("Null value: " + nullDouble);

            nullInt += 5;
            nullDouble += 10.5524;

            Console.WriteLine("Number + null value: " + nullInt);
            Console.WriteLine("Number + null value: " + nullDouble);

            nullInt = 5;
            nullDouble = 10.5524;

            Console.WriteLine("Number value: " + nullInt);
            Console.WriteLine("Number value: " + nullDouble);
        }
    }
