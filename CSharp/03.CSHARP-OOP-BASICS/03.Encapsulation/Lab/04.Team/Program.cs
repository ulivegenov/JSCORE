using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int countOfPlayers = int.Parse(Console.ReadLine());
        Team team = new Team("SoftUni");

        for (int i = 0; i < countOfPlayers; i++)
        {
            string[] data = Console.ReadLine().Split();
            try
            {
                Person person = new Person(data[0], data[1], int.Parse(data[2]), decimal.Parse(data[3]));
                team.AddPlayer(person);
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);
            }
        }
  
        Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
        Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");
    }
}

