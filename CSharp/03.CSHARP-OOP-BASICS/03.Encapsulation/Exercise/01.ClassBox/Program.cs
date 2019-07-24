using System;


class Program
{
    static void Main(string[] args)
    {
        double lenght = double.Parse(Console.ReadLine());
        double width = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());

        Box box = new Box(lenght, width, height);

        Console.WriteLine($"Surface Area - {box.SurfaceArea(box):f2}");
        Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceArea(box):f2}");
        Console.WriteLine($"Volume - {box.Volume(box):f2}");
    }
}

