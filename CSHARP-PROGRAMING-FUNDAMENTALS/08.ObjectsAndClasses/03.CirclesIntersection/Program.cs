using System;
using System.Linq;

namespace _03.CirclesIntersection
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] circleOneParameters = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] circleTwoParameters = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int cordinateX1 = circleOneParameters[0];
            int cordinateY1 = circleOneParameters[1];
            int radius1 = circleOneParameters[2];
            int cordinateX2 = circleTwoParameters[0];
            int cordinateY2 = circleTwoParameters[1];
            int radius2 = circleTwoParameters[2];

            if (Intersect(cordinateX1, cordinateY1, radius1, cordinateX2, cordinateY2, radius2))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
        class Circle
        {
            public int Center { get; set; }
            public int Radius { get; set; }
        }
        class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
        static bool Intersect(int cordinateX1, int cordinateY1, int radius1, int cordinateX2, int cordinateY2, int radius2)
        {
            Circle circleOne = new Circle();
            Circle circleTwo = new Circle();
            Point centerOne = new Point();
            Point centrerTwo = new Point();
            centerOne.X = cordinateX1;
            centerOne.Y = cordinateY1;
            circleOne.Radius = radius1;
            centrerTwo.X = cordinateX2;
            centrerTwo.Y = cordinateY2;
            circleTwo.Radius = radius2;

            double distanceX = Math.Abs(centerOne.X - centrerTwo.X);
            double distanceY = Math.Abs(centerOne.Y - centrerTwo.Y);
            double distanceBetweenCenters = Math.Sqrt(Math.Pow(distanceX, 2.0) + Math.Pow(distanceY, 2.0));

            if (distanceBetweenCenters <= circleOne.Radius + circleTwo.Radius)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
