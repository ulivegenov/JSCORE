using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        Box<string> stringBox = new Box<string>("Gosho");
        Box<int> intBox = new Box<int>(8);
        Box<string[]> arrayBox = new Box<string[]>(new[] { "aaa", "bbb" });
        Box<List<int>> listBox = new Box<List<int>>(new List<int>(){1,2,3});

        Console.WriteLine(stringBox);
        Console.WriteLine(intBox);
        Console.WriteLine(arrayBox);
        Console.WriteLine(listBox);
    }
}

