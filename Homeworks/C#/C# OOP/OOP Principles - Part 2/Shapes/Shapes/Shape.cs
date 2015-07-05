namespace Shapes.Shapes
{
    using System;

    public abstract class Shape
    {
        private double width;
        private double height;

        public Shape(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public double Width { get; set; }
        public double Height { get; set; }

        public abstract double CalculateSurface();
    }
}