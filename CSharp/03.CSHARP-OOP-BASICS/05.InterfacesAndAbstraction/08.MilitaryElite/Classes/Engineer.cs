using System;
using System.Collections.Generic;
using System.Text;


public class Engineer : SpecialisedSoldier, IEngineer
{
    //public HashSet<IRepair> Repairs { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    private HashSet<IRepair> repairs;

    public Engineer(string firstName, string lastName, string id, double salary, string corps):base(firstName, lastName, id, salary, corps)
    {
        this.Repairs = new HashSet<IRepair>();
    }

    public HashSet<IRepair> Repairs
    {
        get { return repairs; }
        set { repairs = value; }
    }

    public override string ToString()
    {
        if (this.Repairs.Count == 0)
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}{Environment.NewLine}" +
            $"Corps: {this.Corps}{Environment.NewLine}Repairs:";
        }
        return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}{Environment.NewLine}" +
            $"Corps: {this.Corps}{Environment.NewLine}Repairs:{Environment.NewLine}  {string.Join("\r\n  ", this.Repairs)}";
    }
}

