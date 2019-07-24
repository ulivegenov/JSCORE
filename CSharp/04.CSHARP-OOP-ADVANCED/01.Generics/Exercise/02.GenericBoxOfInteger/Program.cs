using System;


public class Program
{
    static void Main(string[] args)
    {
        int numberOfIntegers = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfIntegers; i++)
        {
            Box<int> boxOfIntegers = new Box<int>(int.Parse(Console.ReadLine()));
            Console.WriteLine(boxOfIntegers);
        }
    }
}

