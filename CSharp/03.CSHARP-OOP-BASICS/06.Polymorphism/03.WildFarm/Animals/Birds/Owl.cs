using System;
using System.Collections.Generic;
using System.Text;


public class Owl : Bird
{
    public Owl(string name, double weight, double wingSize):base(name, weight, wingSize)
    {
        this.AnimalType = "Owl";
    }

    public override string AskForFood()
    {
        return "Hoot Hoot";
    }

    public override void Eat(string kindOfFood, int foodQuantity)
    {
        if (kindOfFood != "Meat")
        {
            Console.WriteLine($"{this.AnimalType} does not eat {kindOfFood}!");
        }
        else
        {
            this.FoodEaten += foodQuantity;
            this.Weight += 0.25 * foodQuantity;
        }
    }
}

