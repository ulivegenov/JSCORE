using System;
using System.Collections.Generic;
using System.Text;


public class Cititzen : ITraveler
{
    private string id;

    public Cititzen(string id)
    {
        this.Id = id;
    }

    public string Id
    {
        get { return id; }
        set { id = value; }
    }
}

