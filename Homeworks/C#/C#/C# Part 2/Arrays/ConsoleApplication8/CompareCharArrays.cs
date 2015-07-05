using System;

    class CompareCharArrays
    {
        static void Main()
        {

            //Write a program that compares two char arrays lexicographically (letter by letter).

            Console.Write("Enter the first array: ");
            string firstText = Console.ReadLine();

            Console.Write("Enter the second array: ");
            string secondText = Console.ReadLine();

            char[] firstArray = firstText.ToCharArray();
            char[] secondArray = secondText.ToCharArray();


            for (int i = 0; i < Math.Min(firstArray.Length, secondArray.Length); i++)
            {
                if (firstArray[i] == secondArray[i])
                {
                    Console.WriteLine("{0}. {1} is the same as {2}.", i + 1, firstArray[i], secondArray[i]);
                }

                else
                {
                    Console.WriteLine("{0}. {1} is NOT the same as {2}.", i + 1, firstArray[i], secondArray[i]);
                }
            }
        }
    }