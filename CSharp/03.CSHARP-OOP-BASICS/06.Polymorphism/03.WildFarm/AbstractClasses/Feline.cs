using System;
using System.Collections.Generic;
using System.Text;


public abstract class Feline : Mammal
{
    private string breed;

    public string Breed
    {
        get { return breed; }
        set { breed = value; }
    }

    public Feline(string name, double weight, string livingRegion, string breed):base(name, weight, livingRegion)
    {
        this.Breed = breed;
    }

    public override string ToString()
    {
        return $"{this.AnimalType} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}

