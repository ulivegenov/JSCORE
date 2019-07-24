using System;
using System.Collections.Generic;
using System.Text;


public abstract class Bird : Animal
{
    private double wingSize;

    public double WingSize
    {
        get { return wingSize; }
        set { wingSize = value; }
    }

    public Bird(string name, double weight, double wingSize):base(name, weight)
    {
        this.WingSize = wingSize;
    }

    public override string ToString()
    {
        return $"{this.AnimalType} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
    }
}

