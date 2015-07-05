namespace Shapes.Shapes
{
    using System;

    public class Square : Shape
    {
        public Square(double width, double height)
            : base(width, height)
        {
            this.Width = this.Height;
        }

        public override double CalculateSurface()
        {
            return this.Width * this.Width;
        }
    }
}
