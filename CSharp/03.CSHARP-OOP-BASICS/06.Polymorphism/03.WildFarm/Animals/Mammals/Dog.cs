using System;
using System.Collections.Generic;
using System.Text;


public class Dog : Mammal
{
    public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
    {
        this.AnimalType = "Dog";
    }

    public override string AskForFood()
    {
        return "Woof!";
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
            this.Weight += 0.4 * foodQuantity;
        }
    }
}

