using System;
using System.Collections.Generic;
using System.Text;


public class Citizen : IBuyer
{
    private string name;
    private int food;

    public Citizen(string name)
    {
        this.Name = name;
        this.Food = food;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Food
    {
        get { return food; }
        set { food = value; }
    }

    public int BuyFood()
    {
        this.Food += 10;

        return this.Food;
    }
}

