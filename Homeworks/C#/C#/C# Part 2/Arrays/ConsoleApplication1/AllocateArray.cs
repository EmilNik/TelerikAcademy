using System;

    class AllocateArray
    {
        static void Main()
        {  
        //Write a program that allocates array of 20 integers and initializes each element by its index multiplied by 5.
        //Print the obtained array on the console.

            int[] input = new int[20];

            for (int i = 0; i < input.Length; i++)
            {
                input[i] = i * 5;
            }

            string output = string.Join(", ", input);
            Console.WriteLine(output);
        }
    }
