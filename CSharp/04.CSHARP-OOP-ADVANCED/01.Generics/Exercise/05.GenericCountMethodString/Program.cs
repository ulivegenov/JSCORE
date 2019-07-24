using System;

public class Program
{
    static void Main(string[] args)
    {
        int numberOfStrings = int.Parse(Console.ReadLine());
        RecievList<Box<string>> elements = new RecievList<Box<string>>();

        for (int i = 0; i < numberOfStrings; i++)
        {
            Box<string> boxOfStrings = new Box<string>(Console.ReadLine());
            elements.Add(boxOfStrings);
        }

        Box<string> element = new Box<string>(Console.ReadLine());

        int counter = 0;

        foreach (Box<string> item in elements)
        {
            counter += element.Compare(item);
        }

        Console.WriteLine(counter);
    }
}

