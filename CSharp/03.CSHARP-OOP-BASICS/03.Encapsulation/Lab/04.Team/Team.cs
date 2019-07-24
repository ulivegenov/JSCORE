using System;
using System.Collections.Generic;
using System.Text;


public class Team
{
    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }


    private List<Person> firstTeam;

    public IReadOnlyCollection<Person> FirstTeam
    {
        get { return firstTeam; }
    }

    private List<Person> reserveTeam;

    public IReadOnlyCollection<Person> ReserveTeam
    {
        get { return reserveTeam; }
    }

    public Team(string name)
    {
        this.firstTeam = new List<Person>();
        this.reserveTeam = new List<Person>();
        this.Name = name;
    }

    public void AddPlayer(Person player)
    {
        if (player.Age < 40)
        {
            firstTeam.Add(player);
        }
        else
        {
            reserveTeam.Add(player);
        }
    }
}
