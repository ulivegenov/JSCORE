using System;

namespace _02.RectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            double widthRectangle = double.Parse(Console.ReadLine());
            double heightRectangle = double.Parse(Console.ReadLine());

            double areaRectangle = widthRectangle * heightRectangle;

            Console.WriteLine($"{areaRectangle:f2}");
        }
    }
}
