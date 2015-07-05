namespace Shapes.Test
{
    using System;
    using Shapes;
    using System.Collections.Generic;

    public class Testing
    {
        public void Testasd(List<Shape> shapes)
        {
            foreach (var shape in shapes)
            {
                Console.WriteLine("{0:F2}", shape.CalculateSurface());
            }
        }
    }
}
