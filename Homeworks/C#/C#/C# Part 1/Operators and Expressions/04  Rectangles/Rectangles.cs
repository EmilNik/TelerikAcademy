using System;

    class Rectangles
    {
        static void Main()
        {
            //Write an expression that calculates rectangle’s perimeter and area by given width and height.

            Console.WriteLine("Please, tell me your rectangle's width and height.");
            Console.Write("Width: ");
            string width = Console.ReadLine();
            Console.Write("Height: ");
            string height = Console.ReadLine();

            //string into int

            float a = float.Parse(width);
            float b = float.Parse(height);

            float p = 2 * (a + b);
            float s = a * b;

            Console.WriteLine("Your rectangle's perimeter is {0}.", p);
            Console.WriteLine("Your rectangle's area is {0}.", s);
        }
    }
