using System;

    class FourDigitNumber
    {
        static void Main()
        {
    //    Write a program that takes as input a four-digit number in format abcd (e.g. 2011) and performs the following:
    //        Calculates the sum of the digits (in our example 2 + 0 + 1 + 1 = 4).
    //        Prints on the console the number in reversed order: dcba (in our example 1102).
    //        Puts the last digit in the first position: dabc (in our example 1201).
    //        Exchanges the second and the third digits: acbd (in our example 2101).
    
    //The number has always exactly 4 digits and cannot start with 0.

            Console.Write("Enter your number here: ");
            int number = int.Parse(Console.ReadLine());

            if(number > 999 & number <= 9999)
            {
                int forthDigit = number % 10;

                int thirdDigit = (number / 10) % 10;

                int secondDigit = (number / 100) % 10;

                int firstDigit = (number / 1000) % 10;

                //Calculates the sum of the digits.
                Console.WriteLine("Sum: {0} + {1} + {2} + {3} = {4}", firstDigit, secondDigit, thirdDigit, forthDigit, (forthDigit + thirdDigit + secondDigit + firstDigit));

                //Prints on the console the number in reversed order.
                Console.WriteLine("Reversed order: {0}{1}{2}{3}", forthDigit, thirdDigit, secondDigit, firstDigit);

                //Puts the last digit in the first position.
                Console.WriteLine("Last digit in first position: {0}{1}{2}{3}", forthDigit, firstDigit, secondDigit, thirdDigit);

                //Exchanges the second and the third digits.
                Console.WriteLine("Exchanges the second and the third digits: {0}{1}{2}{3}", firstDigit, thirdDigit, secondDigit, forthDigit);
            }

            else
            {
                Console.WriteLine(false+ ". Your number must have exactly 4 digits and can not start with 0.");
            }
            

        }
    }
