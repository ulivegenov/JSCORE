using System;


public class Program
{
    static void Main(string[] args)
    {
        string driversName = Console.ReadLine();
        ICar ferari = new Ferari(driversName);

        Console.WriteLine(ferari);
    }
}

