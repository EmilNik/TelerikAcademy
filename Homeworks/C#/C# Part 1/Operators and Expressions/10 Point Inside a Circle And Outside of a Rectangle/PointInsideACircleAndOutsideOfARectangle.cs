using System;

    class PointInsideACircleAndOutsideOfARectangle
    {
        static void Main()
        {
            //Write an expression that checks for given point (x, y) if it is within the circle K({1, 1}, 1.5) 
            //and out of the rectangle R(top=1, left=-1, width=6, height=2).

            Console.Write("X = ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("Y = ");
            double y = double.Parse(Console.ReadLine());

            bool isInsideCircle = (x - 1) * (x - 1) + (y - 1) * (y - 1) <= (1.5 * 1.5);
            bool isOutsideRectangle = x > 1 || x < 6 && y > -1 || y < 2;

            if (x == 0 || y == 0)
            {
                Console.WriteLine(false);
            }
            else if (isInsideCircle == true && isOutsideRectangle == true)
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            }
        }
    }
