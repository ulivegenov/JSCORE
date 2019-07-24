using System;
using System.Collections.Generic;
using System.Text;


public class Spy : Soldier, ISpy
{
    private int codeNumber;

    public Spy(string firstName, string lastName, string id, int codeNumber):base(firstName, lastName, id)
    {
        this.CodeNumber = codeNumber;
    }

    public int CodeNumber
    {
        get { return codeNumber; }
        set { codeNumber = value; }
    }

    public override string ToString()
    {
        return $"Name: {this.FirstName} {this.LastName} Id: {this.Id}{Environment.NewLine}Code Number: {this.CodeNumber}";
    }
}

