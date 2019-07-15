﻿using System;

namespace _08.CenterPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            Console.WriteLine(CoordinatesClosestToTheCenter(x1, y1, x2, y2));
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
    }
}
