using System;

    class Trapezoids
        {
            static void Main()
            {
                //Write an expression that calculates trapezoid's area by given sides a and b and height h.
    
                Console.Write("a = ");
                double a = double.Parse(Console.ReadLine());
    
                Console.Write("b = ");
                double b = double.Parse(Console.ReadLine());
    
                Console.Write("h = ");
                double h = double.Parse(Console.ReadLine());
    
                double area = (((a + b) / 2) * h);
                Console.WriteLine("The area of this trapezoid is {0}.", area);
    
            }
        }
    