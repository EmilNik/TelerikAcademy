using System;

    class PointInACircle
    {
        static void Main()
        {
            //Write an expression that checks if given point (x, y) is inside a circle K({0, 0}, 2).

            Console.Write("X = ");
            int x = int.Parse(Console.ReadLine());

            Console.Write("Y = ");
            int y = int.Parse(Console.ReadLine());

            Console.WriteLine((x * x) + (y * y) <= 4 ? "Your point is INSIDE the circle." : "Your poin is OUTSIDE the circle.");
        }
    }
