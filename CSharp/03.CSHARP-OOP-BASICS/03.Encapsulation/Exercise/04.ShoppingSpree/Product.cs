using System;
using System.Collections.Generic;
using System.Text;


public class Product
{
    private string name;

    public string Name
    {
        get { return name; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            else
            {
                name = value;
            }
        }
    }

    private decimal cost;

    public decimal Cost
    {
        get { return cost; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            else
            {
                cost = value;
            }
        }
    }

    public Product(string name)
    {
        this.Name = name;
    }

    public Product(string name, int cost)
    {
        this.Name = name;
        this.Cost = cost;
    }

    public override string ToString()
    {
        return this.Name;
    }
}

