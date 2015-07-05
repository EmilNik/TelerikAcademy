using System;

    class CirclePerimeterAndArea
    {
        static void Main()
        {
            Console.Write("Enter the R of the circle: ");
            double r = double.Parse(Console.ReadLine());

            double perimeter = 2 * Math.PI * r;
            double area = Math.PI * r * r;

            Console.WriteLine("Perimeter of the circle is {0}. ", Math.Round(perimeter, 2));
            Console.WriteLine("Area of the circle is {0}.", Math.Round(area, 2));
        }
    }
