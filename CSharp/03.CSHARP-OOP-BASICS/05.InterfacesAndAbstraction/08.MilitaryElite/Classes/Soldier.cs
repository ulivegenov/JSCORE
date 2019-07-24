using System;
using System.Collections.Generic;
using System.Text;


public abstract class Soldier : ISoldier
{
    private string id;
    private string firstName;
    private string lastName;

    public Soldier(string firstName, string lastName, string id)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Id = id;
    }
    public string Id
    {
        get { return id; }
        set { id = value; }
    }

    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }

    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }
}

