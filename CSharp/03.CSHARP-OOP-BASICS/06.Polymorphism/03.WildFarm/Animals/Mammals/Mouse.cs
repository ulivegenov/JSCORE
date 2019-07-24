using System;
using System.Collections.Generic;
using System.Text;


public class Mouse : Mammal
{
    public Mouse(string name, double weight, string livingRegion):base(name, weight, livingRegion)
    {
        this.AnimalType = "Mouse";
    }

    public override string AskForFood()
    {
        return "Squeak";
    }

    public override void Eat(string kindOfFood, int foodQuantity)
    {
        if ((kindOfFood != "Vegetable") && (kindOfFood != "Fruit"))
        {
            Console.WriteLine($"{this.AnimalType} does not eat {kindOfFood}!");
        }
        else
        {
            this.FoodEaten += foodQuantity;
            this.Weight += 0.1 * foodQuantity;
        }
    }
}

