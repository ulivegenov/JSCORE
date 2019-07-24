using System;
using System.Collections.Generic;

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

        string[] elementsToSwap = Console.ReadLine().Split();
        int firstIndex = int.Parse(elementsToSwap[0]);
        int secondIndex = int.Parse(elementsToSwap[1]);

        elements.Swap(firstIndex, secondIndex);

        foreach (Box<string> item in elements)
        {
            Console.WriteLine(item);
        }
    }
}

