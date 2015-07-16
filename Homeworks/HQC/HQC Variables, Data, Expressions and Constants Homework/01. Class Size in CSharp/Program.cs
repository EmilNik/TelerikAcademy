//Refactor the following code to use proper variable naming and simplified expressions:

using System;

public class Size
{
    public double width;
    public double height;

    public Size(double width, double height)
    {
        this.Width = width;
        this.Height = height;
    }

    public double Width
    {
        get { return this.Width; }
        set { this.Width = value; }
    }

    public double Height
    {
        get { return this.Height; }
        set { this.Height = value; }
    }

    public static Size GetRotatedSize(
        Size previousSize, double rotationAngle)
    {
        var previousWidth = previousSize.width;
        var previousHeigth = previousSize.height;

        var cos = Math.Cos(rotationAngle);
        var sin = Math.Sin(rotationAngle);

        var newWidth = Math.Abs((cos * previousWidth) + (sin * previousHeigth));
        var newHeigth = Math.Abs((sin * previousWidth) + (cos * previousHeigth));

        var rotatedSize = new Size(newWidth, newHeigth);

        return rotatedSize;
    }
}