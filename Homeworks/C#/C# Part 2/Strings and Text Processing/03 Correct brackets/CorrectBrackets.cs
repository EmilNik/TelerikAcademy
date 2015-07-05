using System;

    class CorrectBrackets
    {
        //Write a program to check if in a given expression the brackets are put correctly.

        static void Main()
        {
            Console.Write("Enter an expression: ");
            string expression = Console.ReadLine();

            int counter = 0;

            foreach (char element in expression)
            {
                if (element == '(')
                {
                    counter++;
                }
                else if (element == ')')
                {
                    counter--; ;
                }

                if (counter < 0)
                {
                    break;
                }
            }

            if (counter == 0)
            {
                Console.WriteLine("Brackets are put corectly.");
            }
            else
            {
                Console.WriteLine("Breckets are NOT put corectly and the expression is invalid.");
            }
        }
    }
