using System;
using System.Linq;

public class StartUp
{
    static void Main(string[] args)
    {
        CastomStack<int> castomStack = new CastomStack<int>();

        string input;

        while ((input = Console.ReadLine()) != "END")
        {
            string[] commandArgs = input.Split(' ');
            string command = commandArgs[0];

            switch (command)
            {
                case "Push":
                    string inputArgs = input.Substring(command.Length).Trim().ToString();
                    int[] elements = inputArgs.Split(", ").Select(int.Parse).ToArray();
                    castomStack.Push(elements);
                    break;
                case "Pop":
                    castomStack.Pop();
                    break;
                default:
                    break;
            }
        }
        for (int i = 0; i < 2; i++)
        {
            foreach (var element in castomStack)
            {
                Console.WriteLine(element);
            }
        }
    }
}

