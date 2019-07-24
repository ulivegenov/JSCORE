using System;
using System.Collections.Generic;
using System.Text;


public class Citizen : IBirthday
{
    private string birthdate;

    public Citizen(string birthdate)
    {
        this.Birthdate = birthdate;
    }

    public string Birthdate
    {
        get { return birthdate; }
        set { birthdate = value; }
    }
}

