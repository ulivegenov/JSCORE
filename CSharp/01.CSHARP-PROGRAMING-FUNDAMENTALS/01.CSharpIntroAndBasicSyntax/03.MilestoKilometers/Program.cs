using System;

namespace _03.MilesToKilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            double miles = double.Parse(Console.ReadLine());

            double kilometers = miles * 1.60934;

            Console.WriteLine($"{kilometers:f2}");
        }
    }
}
