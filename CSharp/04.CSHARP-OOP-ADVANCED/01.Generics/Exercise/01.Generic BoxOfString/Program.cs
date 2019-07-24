using System;


public class Program
{
    static void Main(string[] args)
    {
        int numberOfStrings = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfStrings; i++)
        {
            Box<string> boxOfStrings = new Box<string>(Console.ReadLine());
            Console.WriteLine(boxOfStrings);
        }
    }
}

