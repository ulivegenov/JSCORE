using System;
using System.Collections.Generic;
using System.Text;


public class Tiger : Feline
{
    public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
    {
        this.AnimalType = "Tiger";
    }

    public override string AskForFood()
    {
        return "ROAR!!!";
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
            this.Weight += foodQuantity;
        }
    }
}

