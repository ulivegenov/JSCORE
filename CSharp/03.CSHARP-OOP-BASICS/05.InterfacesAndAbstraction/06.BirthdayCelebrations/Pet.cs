using System;
using System.Collections.Generic;
using System.Text;


public class Pet : IBirthday
{
    private string birthdate;

    public Pet(string birthdate)
    {
        this.Birthdate = birthdate;
    }

    public string Birthdate
    {
        get { return birthdate; }
        set { birthdate = value; }
    }
}

