using System;


public class Program
{
    static void Main(string[] args)
    {
        int numberOfStrings = int.Parse(Console.ReadLine());
        RecievList<Box<double>> elements = new RecievList<Box<double>>();

        for (int i = 0; i < numberOfStrings; i++)
        {
            Box<double> boxOfStrings = new Box<double>(double.Parse(Console.ReadLine()));
            elements.Add(boxOfStrings);
        }

        Box<double> element = new Box<double>(double.Parse(Console.ReadLine()));

        int counter = 0;

        foreach (Box<double> item in elements)
        {
            counter += element.Compare(item);
        }

        Console.WriteLine(counter);
    }
}

