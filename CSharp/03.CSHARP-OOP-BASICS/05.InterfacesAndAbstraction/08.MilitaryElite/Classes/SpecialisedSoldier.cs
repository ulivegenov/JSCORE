using System;
using System.Collections.Generic;
using System.Text;


public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
{
    private string corps;

    public SpecialisedSoldier(string firstName, string lastName, string id, double salary, string corps):base(firstName, lastName, id, salary)
    {
        this.Corps = corps;
    }

    public string Corps
    {
        get { return corps; }
        set { corps = value; }
    }
}

