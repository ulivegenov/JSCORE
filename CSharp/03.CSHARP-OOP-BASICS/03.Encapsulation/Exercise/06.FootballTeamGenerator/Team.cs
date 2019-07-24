using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Team
{
    private string name;
    private List<Player> players = new List<Player>();
    private Player newPlayer;
    private int averageRating => AverageRating(players);

    public string Name
    {
        get { return name; }
        set { name = ValidateName(value); }
    }

    public IReadOnlyCollection<Player> Players
    {
        get { return players.AsReadOnly(); }
    }

    public Player NewPalyer
    {
        get { return newPlayer; }
        set { newPlayer = value; }
    }

    public Team(string name)
    {
        this.Name = name;
    }

    private string ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("A name should not be empty.");
        }
        else
        {
            return name;
        }
    }

    public void AddPlayer(Player newPlayer)
    {
        this.players.Add(newPlayer);
    }

    public void RemovingPlayer(string playerName)
    {
        if (!this.Players.Any(p => p.Name == playerName))
        {
            throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
        }
        else
        {
            Player playerToRemove = players.Find(p => p.Name == playerName);
            players.Remove(playerToRemove);
        }
    }

    private int AverageRating(List<Player> players)
    {
        if (players.Count == 0)
        {
            return 0;
        }
        else
        {
            double sumOfSkills = 0;

            foreach (var player in players)
            {
                sumOfSkills += player.skillLevel;
            }

            int averageRating = (int)Math.Ceiling((decimal)(sumOfSkills / players.Count));
            return averageRating;
        }
    }

    public override string ToString()
    {
        return $"{this.Name} - {averageRating}";
    }
}

