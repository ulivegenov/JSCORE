using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Team> teams = new List<Team>();
        string inputCommand;

        while ((inputCommand = Console.ReadLine()) != "END")
        {
            string[] data = inputCommand.Split(';',StringSplitOptions.RemoveEmptyEntries);
            switch (data.Length)
            {
                case 2:
                    try
                    {
                        switch (data[0])
                        {
                            case "Team":
                                Team team = new Team(data[1]);
                                teams.Add(team);
                                break;
                            case "Rating":
                                Console.WriteLine(PrintTeamStats(data[1], teams));
                                break;
                        }
                    }
                    catch (ArgumentException argEx)
                    {
                        Console.WriteLine(argEx.Message);
                    }
                    break;
                case 8:
                    try
                    {
                        switch (data[0])
                        {
                            case "Add":
                                if (TeamCheck(data[1], teams))
                                {
                                    Player player = new Player(data[2]);
                                    int[] attributes = data.Skip(3).Take(5).Select(int.Parse).ToArray();
                                    player.AddPlayerAttributes(attributes);
                                    teams.Where(t => t.Name == data[1]).Select(t => t.NewPalyer == player);

                                    foreach (var team in teams.Where(t => t.Name == data[1]))
                                    {
                                        team.AddPlayer(player);
                                    }
                                }
                                else
                                {
                                    throw new ArgumentException($"Team {data[1]} does not exist.");
                                }
                                break;
                            case "Remove":
                                RemovePlayer(inputCommand, teams);
                                break;
                        }
                        
                    }
                    catch (ArgumentException argEx)
                    {
                        Console.WriteLine(argEx.Message);
                    }
                    break;

                case 3:
                    try
                    {
                        RemovePlayer(inputCommand, teams);
                    }
                    catch (ArgumentException argEx)
                    {
                        Console.WriteLine(argEx.Message);
                    }
                    break;
            }
        }

    }

    private static Team PrintTeamStats(string teamName, List<Team> teams)
    {
        if (!teams.Any(p => p.Name == teamName))
        {
            throw new ArgumentException($"Team {teamName} does not exist.");
        }
        else
        {
            return teams.Find(p => p.Name == teamName);
        }
    }

    private static bool TeamCheck(string teamName, List<Team> teams)
    {
        bool isInList = false;

        if (teams.Any(p => p.Name == teamName))
        {
            isInList = true;
        }

        return isInList;
    }

    private static void RemovePlayer(string inputCommand, List<Team> teams)
    {
        string[] data = inputCommand.Split(';');
        string teamName = data[1];
        string playerName = data[2];
        Team team = teams.Find(p => p.Name == teamName);
        team.RemovingPlayer(playerName);
    }
}

