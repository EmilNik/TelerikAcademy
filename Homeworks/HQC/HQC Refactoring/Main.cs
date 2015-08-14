namespace TraverseMatrix
{
    using System;

    public class Main
    {
        public static void Main()
        {
            Console.Write("Enter a number: ");
            int value = int.Parse(Console.ReadLine());

            Matrix matrix = new Matrix(value);
            Console.WriteLine(matrix);
        }
    }
}