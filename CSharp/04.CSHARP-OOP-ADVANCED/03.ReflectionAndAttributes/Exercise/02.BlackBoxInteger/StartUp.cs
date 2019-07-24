using System;


public class StartUp
{
    static void Main(string[] args)
    {
        BlackBoxIntegerTests blackBoxIntegerTests = new BlackBoxIntegerTests();

        Console.WriteLine(blackBoxIntegerTests.Run(typeof(BlackBoxInteger)));
    }
}

