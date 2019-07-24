using System;
using System.Collections.Generic;
using System.Text;


public class Citizen : IResident, IPerson
{
    private string name;
    private string country;
    private int age;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Country
    {
        get { return country; }
        set { country = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public Citizen(string name, string country, int age)
    {
        this.Name = name;
        this.Country = country;
        this.Age = age;
    }

    string IResident.GetName()
    {
        return $"Mr/Ms/Mrs {this.Name}";
    }

    string IPerson.GetName()
    {
        return this.Name;
    }
}

