using System;
using System.Collections.Generic;
using System.Text;


public class Robot : ITraveler
{
    private string id;

    public Robot(string id)
    {
        this.Id = id;
    }

    public string Id
    {
        get { return id; }
        set { id = value; }
    }
}

