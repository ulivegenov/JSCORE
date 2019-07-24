using System;


public class Program
{
    static void Main(string[] args)
    {
        Box<int> box = new Box<int>();

        box.Add(1);
        box.Add(2);
        box.Add(3);
        box.Add(4);
        box.Add(5);

        var element = box.Remove();

        Console.WriteLine(element);
        Console.WriteLine(box.Count);
    }
}

