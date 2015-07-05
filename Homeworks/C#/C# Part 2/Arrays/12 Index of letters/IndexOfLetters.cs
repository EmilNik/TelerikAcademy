using System;

    class IndexOfLetters
    {
        static void Main()
        {
   //Write a program that creates an array containing all letters from the alphabet (A-Z).
   //Read a word from the console and print the index of each of its letters in the array.

            int[] letters = new int[53];

            for (int i = 0; i < 53 / 2 + 1; i++)
            {
                letters[i] = 'a' + i;
            }

            for (int i = 53/2, k = 0; i < 53; i++, k++)
            {
                letters[i] = 'A' + k;
            }

            Console.Write("Enter your word: ");
            string text = Console.ReadLine();

            char[] chars = text.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                Console.WriteLine("The index of {0} is {1}.", chars[i], Array.IndexOf(letters, chars[i]));
            }
        }
    }
