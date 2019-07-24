using System;
using System.Collections.Generic;
using System.Text;


public abstract class Animal
{
    private string name;
    private double weight;
    private int foodEaten;
    private string animalType;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public double Weight
    {
        get { return weight; }
        set { weight = value; }
    }

    public int FoodEaten
    {
        get { return foodEaten; }
        set { foodEaten = value; }
    }

    public string AnimalType
    {
        get { return animalType; }
        set { animalType = value; }
    }

    public Animal(string name, double weight)
    {
        this.Name = name;
        this.Weight = weight;
        this.FoodEaten = 0;
    }

    public abstract string AskForFood();

    public abstract void Eat(string kindOfFood, int foodQuantity);
}

