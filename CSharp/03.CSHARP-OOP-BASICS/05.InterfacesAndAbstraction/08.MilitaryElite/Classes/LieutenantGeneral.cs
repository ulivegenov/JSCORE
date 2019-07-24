using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


public class LieutenantGeneral : Private, ILieutenantGeneral
{
    private HashSet<IPrivate> privates;

    public LieutenantGeneral(string firstName, string lastName, string id, double salary):base(firstName, lastName, id, salary)
    {
        this.Privates = new HashSet<IPrivate>();
    }

    public HashSet<IPrivate> Privates
    {
        get { return privates; }
        set { privates = value; }
    }

    public override string ToString()
    {
        if (this.Privates.Count == 0)
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}{Environment.NewLine}" +
            $"Privates:";
        }
        return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}{Environment.NewLine}" +
            $"Privates:{Environment.NewLine}  {string.Join("\r\n  ", this.Privates)}";
    }
}

