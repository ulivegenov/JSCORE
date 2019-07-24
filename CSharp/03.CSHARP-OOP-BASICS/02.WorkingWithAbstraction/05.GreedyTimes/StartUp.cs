using System;

namespace _05GreedyTimes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            long capacity = long.Parse(Console.ReadLine());
            string command = Console.ReadLine();

            Engine engine = new Engine();
            engine.Run(capacity, command);
        }
    }
}
