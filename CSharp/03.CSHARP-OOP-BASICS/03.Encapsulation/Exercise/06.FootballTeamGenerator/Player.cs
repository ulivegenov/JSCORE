using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Player
{
    const int MIN_ATTRIBUTE_VALUE = 0;
    const int MAX_ATTRIBUTE_VALUE = 100;
    private Dictionary<string, int> playersAttributes = new Dictionary<string, int>();

    private string name;
    private Stats playerStats;
    public double skillLevel => GetSkillLevel(playersAttributes);

    public string Name
    {
        get { return name; }
        private set { name = ValidateName(value); }
    }

    public Stats PlayerStats
    {
        get { return playerStats; }
        private set { playerStats = value; }
    }



    public Player(string name)
    {
        this.Name = name;
        this.PlayerStats = new Stats();
    }

    private double GetSkillLevel(Dictionary<string, int> playersAttributes)
    {

        double skillLevelValue = Math.Round((double)(playersAttributes.Values.Sum()/5.0));

        return skillLevelValue;
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

    public void AddPlayerAttributes(int[] attributesValue)
    {
        playersAttributes["Endurance"] = attributesValue[0];
        playersAttributes["Sprint"] = attributesValue[1];
        playersAttributes["Dribble"] = attributesValue[2];
        playersAttributes["Passing"] = attributesValue[3];
        playersAttributes["Shooting"] = attributesValue[4];

        string statName = null;
        foreach (var attribute in playersAttributes.Where(a => (a.Value < MIN_ATTRIBUTE_VALUE) || (a.Value > MAX_ATTRIBUTE_VALUE)))
        {
            statName = attribute.Key;
            if (statName != null)
            {
                break;
            }
        }
        if (statName != null)
        {
            throw new ArgumentException($"{statName} should be between {MIN_ATTRIBUTE_VALUE} and {MAX_ATTRIBUTE_VALUE}.");
        }
        else
        {
            this.PlayerStats.Endurance = attributesValue[0];
            this.PlayerStats.Sprint = attributesValue[1];
            this.PlayerStats.Dribble = attributesValue[2];
            this.PlayerStats.Passing = attributesValue[3];
            this.PlayerStats.Shooting = attributesValue[4];
        }
    }
}

