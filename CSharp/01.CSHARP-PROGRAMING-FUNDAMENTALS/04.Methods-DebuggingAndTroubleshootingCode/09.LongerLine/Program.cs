using System;

namespace _09.LongerLine
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());

            Console.WriteLine(LongerLineCordinatesOfPoints(x1, y1, x2, y2, x3, y3, x4, y4));
        }

        static string LongerLineCordinatesOfPoints(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
        {
            string coordinatesFirstPoint = "";
            string coordinatesSecondPoint = "";

            double lineOneDiffX = Math.Abs(x1 - x2);
            double lineOneDiffY = Math.Abs(y1 - y2);
            double lineTwoDiffX = Math.Abs(x3 - x4);
            double lineTwoDiffY = Math.Abs(y3 - y4);

            double lineOneLenght = Math.Sqrt(Math.Pow(lineOneDiffX, 2) + Math.Pow(lineOneDiffY, 2));
            double lineTwoLenght = Math.Sqrt(Math.Pow(lineTwoDiffX, 2) + Math.Pow(lineTwoDiffY, 2));

            if (lineOneLenght >= lineTwoLenght)
            {
                coordinatesFirstPoint = CoordinatesClosestToTheCenter(x1, y1, x2, y2);
                coordinatesSecondPoint = CoordinatesFarFromTheCenter(x1, y1, x2, y2);
            }
            else
            {
                coordinatesFirstPoint = CoordinatesClosestToTheCenter(x3, y3, x4, y4);
                coordinatesSecondPoint = CoordinatesFarFromTheCenter(x3, y3, x4, y4);
            }
            string coordinates = $"{coordinatesFirstPoint}{coordinatesSecondPoint}";

            return coordinates;
        }

        static string CoordinatesClosestToTheCenter(double x1, double y1, double x2, double y2)
        {
            string coordinates = "";

            if ((Math.Pow(x1, 2) + Math.Pow(y1, 2)) <= (Math.Pow(x2, 2) + Math.Pow(y2, 2)))
            {
                coordinates = $"({x1}, {y1})";
            }
            else
            {
                coordinates = $"({x2}, {y2})";
            }
            return coordinates;
        }

        static string CoordinatesFarFromTheCenter(double x1, double y1, double x2, double y2)
        {
            string coordinates = "";

            if ((Math.Pow(x1, 2) + Math.Pow(y1, 2)) <= (Math.Pow(x2, 2) + Math.Pow(y2, 2)))
            {
                coordinates = $"({x2}, {y2})";
            }
            else
            {
                coordinates = $"({x1}, {y1})";
            }
            return coordinates;
        }
    }
}
