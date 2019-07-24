using System;
using System.Collections.Generic;
using System.Text;


public class Hen : Bird
{
    public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
    {
        this.AnimalType = "Hen";
    }

    public override string AskForFood()
    {
        return "Cluck";
    }

    public override void Eat(string kindOfFood, int foodQuantity)
    {
        this.FoodEaten += foodQuantity;
        this.Weight += 0.35 * foodQuantity;
    }
}
