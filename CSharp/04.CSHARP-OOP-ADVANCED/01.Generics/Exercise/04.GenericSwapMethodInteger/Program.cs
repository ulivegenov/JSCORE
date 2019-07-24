using System;


class Program
{
    static void Main(string[] args)
    {
        int numberOfStrings = int.Parse(Console.ReadLine());
        RecievList<Box<int>> elements = new RecievList<Box<int>>();

        for (int i = 0; i < numberOfStrings; i++)
        {
            Box<int> boxOfStrings = new Box<int>(int.Parse(Console.ReadLine()));
            elements.Add(boxOfStrings);
        }

        string[] elementsToSwap = Console.ReadLine().Split();
        int firstIndex = int.Parse(elementsToSwap[0]);
        int secondIndex = int.Parse(elementsToSwap[1]);

        elements.Swap(firstIndex, secondIndex);

        foreach (Box<int> item in elements)
        {
            Console.WriteLine(item);
        }
    }
}

