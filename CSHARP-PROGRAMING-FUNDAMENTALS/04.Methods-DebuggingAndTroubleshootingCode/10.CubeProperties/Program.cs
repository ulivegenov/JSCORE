using System;

namespace _10.CubeProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            double cubeSide = double.Parse(Console.ReadLine());
            string cubeParameter = Console.ReadLine();

            Console.WriteLine(CubeParameters(cubeSide, cubeParameter));
        }

        static string CubeParameters(double cubeSide, string cubeParameter)
        {
            double result = 0;
            double cubeFaceDiagonal = Math.Sqrt(Math.Pow(cubeSide, 2) + Math.Pow(cubeSide, 2));
            double cubeSpaceDiagonal = Math.Sqrt(Math.Pow(cubeFaceDiagonal, 2) + Math.Pow(cubeSide, 2));
            double cubeVolume = Math.Pow(cubeSide, 3);
            double cubeArea = Math.Pow(cubeSide, 2) * 6;

            switch (cubeParameter)
            {
                case "face": result = cubeFaceDiagonal; break;
                case "space": result = cubeSpaceDiagonal; break;
                case "volume": result = cubeVolume; break;
                case "area": result = cubeArea; break;
            }

            return $"{result:f2}";
        }
    }
}
