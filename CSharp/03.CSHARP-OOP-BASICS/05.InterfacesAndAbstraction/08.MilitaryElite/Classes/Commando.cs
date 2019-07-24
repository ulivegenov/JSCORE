using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


public class Commando : SpecialisedSoldier, ICommando
{
    //public HashSet<IMission> Missions { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    //
    //public string CompleteMission(string missionName)
    //{
    //    throw new NotImplementedException();
    //}

    private HashSet<IMission> missions;

    public Commando(string firstName, string lastName, string id, double salary, string corps):base(firstName, lastName, id, salary, corps)
    {
        this.Missions = new HashSet<IMission>();
    }

    public HashSet<IMission> Missions
    {
        get { return missions; }
        set { missions = value; }
    }

    public HashSet<IMission> CompleteMission(string missionName, HashSet<IMission> missions)
    {
        foreach (var mission in missions.Where(m => m.CodeName == missionName))
        {
            mission.State = "finished";
        }

        return missions;
    }

    public override string ToString()
    {
        if (this.Missions.Count == 0)
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}{Environment.NewLine}" +
            $"Corps: {this.Corps}{Environment.NewLine}Missions:";
        }
        return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}{Environment.NewLine}" +
            $"Corps: {this.Corps}{Environment.NewLine}Missions:{Environment.NewLine}  {string.Join("\r\n  ", this.Missions)}";
    }
}

