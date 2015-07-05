//Declare two string variables and assign them with following value: The "use" of quotations causes difficulties.
//Do the above in two different ways - with and without using quoted strings.
//Print the variables to ensure that their value was correctly defined.

using System;

    class QuotesInStrings
    {
        static void Main()
        {
            //First way
            string firstWayQuote = "The \"use\" of quotations causes difficulties.";
            Console.WriteLine(firstWayQuote);

            //Second way
            string quote = "\"";
            string secondWayQuote = "The " + quote + "use" + quote + " " + "of quatations causes difficulties.";
            Console.WriteLine(secondWayQuote);
        }
    }
