using System;
using System.Collections.Generic;
using System.Text;


public class Cat : Feline
{
    public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
    {
        this.AnimalType = "Cat";
    }

    public override string AskForFood()
    {
        return "Meow";
    }

    public override void Eat(string kindOfFood, int foodQuantity)
    {
        if ((kindOfFood != "Meat") && (kindOfFood != "Vegetable"))
        {
            Console.WriteLine($"{this.AnimalType} does not eat {kindOfFood}!");
        }
        else
        {
            this.FoodEaten += foodQuantity;
            this.Weight += 0.3 * foodQuantity;
        }
    }
}

