using System;
using System.Collections.Generic;
using System.Text;


class Topping
{
    const double BASE_CALORIES_PER_GRAM = 2;

    private Dictionary<string, double> typeModifiers = new Dictionary<string, double>
    {
        ["meat"] = 1.2,
        ["veggies"] = 0.8,
        ["cheese"] = 1.1,
        ["sauce"] = 0.9
    };

    private string type;
    private int weight;
    public double toppingModifier => typeModifiers[this.Type.ToLower()];

    


    public string Type
    {
        get { return type; }
        private set
        {
            if (!typeModifiers.ContainsKey(value.ToLower()))
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
            else
            {
                type = value;
            }
        }
    }

    public int Weight
    {
        get { return weight; }
        private set
        {
            if (value < 1 || value > 50)
            {
                throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");
            }
            weight = value;
        }
    }

    public Topping(string type, int wieght)
    {
        this.Type = type;
        this.Weight = wieght;
    }

}

