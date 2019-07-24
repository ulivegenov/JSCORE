using System;
using System.Collections.Generic;
using System.Text;


public class Private : Soldier, IPrivate
{
    private double salary;

    public Private(string firstName,string lastName, string id, double salary):base(firstName,lastName,id)
    {
        this.Salary = salary;
    }

    public double Salary
    {
        get { return salary; }
        set { salary = value; }
    }

    public override string ToString()
    {
        return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}";
    }
}

