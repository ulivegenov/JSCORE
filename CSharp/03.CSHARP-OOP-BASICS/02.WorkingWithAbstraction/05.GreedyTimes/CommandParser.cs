using _05GreedyTimes.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace _05GreedyTimes
{
    public class CommandParser
    {
        public CommandParser(string command)
        {
            this.Command = command;
        }

        public string Command { get; set; }

        public List<Hoard> ParseCommand()
        {
            List<Hoard> hoards = new List<Hoard>();
            string[] tokens = this.Command.Split();

            for (int i = 0; i < tokens.Length - 1; i+=2)
            {
                if (tokens[i].ToLower() == "gold")
                {
                    Gold gold = new Gold(tokens[i], int.Parse(tokens[i + 1]));
                    hoards.Add(gold);
                }
                else if (tokens[i].Length == 3)
                {
                    Cash cash = new Cash(tokens[i], int.Parse(tokens[i + 1]));
                    hoards.Add(cash);
                }
                else if (tokens[i].Substring(tokens[i].Length -  3).ToLower() == "gem")
                {
                    Gem gem = new Gem(tokens[i], int.Parse(tokens[i + 1]));
                    hoards.Add(gem);
                }
            }

            return hoards;
        }
    }
}
