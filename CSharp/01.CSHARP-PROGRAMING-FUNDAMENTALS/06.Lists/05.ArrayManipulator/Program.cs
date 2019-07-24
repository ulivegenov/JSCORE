using System;
using System.Collections.Generic;
using System.Linq;

namespace p05ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();
            var commandString = Console.ReadLine();
            while (commandString != "print")
            {
                var command = commandString.Split(' ').ToArray();
                switch (command[0])
                {
                    case "add":
                        {
                            int index = int.Parse(command[1]);
                            int element = int.Parse(command[2]);
                            numbers.Insert(index, element);
                            break;
                        }
                    case "addMany":
                        {
                            int index = int.Parse(command[1]);
                            var numbersToAdd = command.Skip(2).Select(int.Parse);
                            numbers.InsertRange(index, numbersToAdd);
                            break;
                        }
                    case "contains":
                        {
                            int element = int.Parse(command[1]);
                            if (numbers.Contains(element))
                            { Console.WriteLine(numbers.IndexOf(element)); }
                            else { Console.WriteLine("-1"); }
                            break;
                        }
                    case "remove":
                        {
                            int index = int.Parse(command[1]);
                            numbers.RemoveAt(index);
                            break;
                        }
                    case "shift":
                        {
                            int positions = int.Parse(command[1]);
                            for (int i = 0; i < positions; i++)
                            {
                                ShiftList(numbers);
                            }
                            break;
                        }
                    case "sumPairs":
                        {
                            for (int i = 0; i < numbers.Count - 1; i++)
                            {
                                numbers[i] += numbers[i + 1];
                                numbers.RemoveAt(i + 1);
                            }
                            break;
                        }
                }
                commandString = Console.ReadLine();
            }
            Console.WriteLine($"[{string.Join(", ", numbers)}]");
        }

        static void ShiftList(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                var temp = numbers[i];
                numbers[i] = numbers[i + 1];
                numbers[i + 1] = temp;
            }
        }


    }
}