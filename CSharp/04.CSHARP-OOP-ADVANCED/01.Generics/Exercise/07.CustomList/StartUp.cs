using System;


public class StartUp
{
    static void Main(string[] args)
    {
        CustomList<string> list = new CustomList<string>();

        string input;

        while ((input = Console.ReadLine()) != "END")
        {
            string[] commandArgs = input.Split();
            string command = commandArgs[0];

            switch (command)
            {
                case "Add":
                    list.Add(commandArgs[1]);
                    break;
                case "Remove":
                    list.Remove(int.Parse(commandArgs[1]));
                    break;
                case "Contains":
                    bool result = list.Contains(commandArgs[1]);
                    Console.WriteLine(result);
                    break;
                case "Swap":
                    list.Swap(int.Parse(commandArgs[1]), int.Parse(commandArgs[2]));
                    break;
                case "Greater":
                    int count = list.CounterGreaterThan(commandArgs[1]);
                    Console.WriteLine(count);
                    break;
                case "Max":
                    string maxEl = list.Max();
                    Console.WriteLine(maxEl);
                    break;
                case "Min":
                    string minEl = list.Min();
                    Console.WriteLine(minEl);
                    break;
                case "Print":
                    list.Print();
                    break;
                case "Sort":
                    list.Sort();
                    break;
                default:
                    break;
            }
        }
    }
}

