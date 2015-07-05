using System;

    class QuadraticEquation
    {
        static void Main()
        {   //Write a program that reads the coefficients a, b and c of a quadratic equation 
            //ax2 + bx + c = 0 and solves it (prints its real roots).

            Console.WriteLine("ax2 + bx + c = 0");

            Console.Write("a = ");
            double a = double.Parse(Console.ReadLine());

            Console.Write("b = ");
            double b = double.Parse(Console.ReadLine());

            Console.Write("c = ");
            double c = double.Parse(Console.ReadLine());

            Console.WriteLine(); //Empty line just to look better

            double discrim = ((b * b) - (4 * a * c));
            double discrimSqrt = Math.Sqrt(discrim);
            double x1 = (((-1) * b + discrimSqrt) /( 2 * a));
            double x2 = (((-1) * b - discrimSqrt) / (2 * a));

            if (discrim < 0)
            {
                Console.WriteLine("The equation has no real roots.");
            }

            else if (discrim == 0)
            {
                Console.WriteLine("x1 = x2 = {0}", Math.Round(x1, 2));
            }

            else
            {
                Console.WriteLine("x1 = {0}\nx2 = {1}", Math.Round(x1, 2), Math.Round(x2, 2));
            }

            Console.WriteLine();  //Empty line just to look better
        }
    }
