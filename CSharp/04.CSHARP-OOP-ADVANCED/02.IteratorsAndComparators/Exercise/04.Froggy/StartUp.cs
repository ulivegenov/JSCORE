using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    static void Main(string[] args)
    {
        int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

        Lake lake = new Lake(input);

        List<int> output = new List<int>();

        foreach (var item in lake)
        {
            output.Add(item);
        }

        Console.WriteLine(string.Join(", ", output));
    }
}

