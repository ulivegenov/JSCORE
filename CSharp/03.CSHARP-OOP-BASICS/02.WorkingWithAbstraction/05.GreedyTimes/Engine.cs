using _05GreedyTimes.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05GreedyTimes
{
    public class Engine
    {
        public void Run(long capacity, string command)
        {
            Bag bag = new Bag(capacity);

            CommandParser commandParser = new CommandParser(command);

            List<Hoard> items = commandParser.ParseCommand();

            foreach (var item in items)
            {
                if (item.Name.ToLower() == "gold")
                {
                    bag.AddGoldItem(item);
                }
                else if (item.Name.Substring(item.Name.Length-3).ToLower() == "gem")
                {
                    bag.AddGemItem(item);
                }
                else if (item.Name.Length == 3)
                {
                    bag.AddCashItem(item);
                }
            }

            Console.WriteLine(bag);
        }
    }
}
