//Define abstract class Shape with only one abstract method CalculateSurface()
//and fields width and height.
//Define two new classes Triangle and Rectangle that implement the virtual 
//method and return the surface of the figure (height * width for rectangle and height * width/2 for triangle).
//Define class Square and suitable conShapesor so that at initialization height 
//must be kept equal to width and implement the CalculateSurface() method.
//Write a program that tests the behaviour of the CalculateSurface() method 
//for different shapes (Square, Rectangle, Triangle) stored in an array.

namespace Shapes
{
    using System;
    using Shapes;
    using Test;
    using System.Collections.Generic;

    class ShapesMail
    {
        static void Main()
        {
            List<Shape> shapes = new List<Shape>
            {
                new Triangle(4, 3),
                new Square(2, 2),
                new Rectangle(5, 12)
            };
        }
    }
}
