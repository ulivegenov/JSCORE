using System;

namespace _12.RectangleProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            double rectangleWidth = double.Parse(Console.ReadLine());
            double rectangleHeight = double.Parse(Console.ReadLine());

            double rectanglePerimeter = rectangleHeight * 2 + rectangleWidth * 2;
            double rectangleArea = rectangleHeight * rectangleWidth;
            double rectangleDiagonal = Math.Sqrt(rectangleHeight * rectangleHeight + rectangleWidth * rectangleWidth);

            Console.WriteLine($"{rectanglePerimeter}");
            Console.WriteLine($"{rectangleArea}");
            Console.WriteLine($"{rectangleDiagonal}");
        }
    }
}
