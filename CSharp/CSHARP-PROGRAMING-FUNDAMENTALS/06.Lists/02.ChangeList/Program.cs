using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            string line = Console.ReadLine();
            string command = "";

            while (line != "Odd" && line != "Even")
            {
                string[] tokens = line.Split();
                command = tokens[0];

                if (command == "Delete")
                {
                    int element = int.Parse(tokens[1]);
                    numbers.RemoveAll(i => i == element);
                }
                else if (command == "Insert")
                {
                    int element = int.Parse(tokens[1]);
                    int index = int.Parse(tokens[2]);
                    numbers.Insert(index, element);
                }

                line = Console.ReadLine();
            }

            if (line == "Odd")
            {
                foreach (var odd in numbers)
                {
                    if (odd % 2 == 1)
                    {
                        Console.Write($"{odd} ");
                    }
                }
            }
            else
            {
                foreach (var even in numbers)
                {
                    if (even % 2 == 0)
                    {
                        Console.Write($"{even} ");
                    }
                }
            }
        }
    }
}
