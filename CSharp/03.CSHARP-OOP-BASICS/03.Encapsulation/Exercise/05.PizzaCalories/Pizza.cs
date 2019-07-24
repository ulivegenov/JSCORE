using System;
using System.Collections.Generic;
using System.Text;


class Pizza
{
    const double BASE_CALORIES_PER_GRAM = 2;

    private string name;
    private List<Topping> toppings = new List<Topping>();
    private Dough dough;
    private Topping newTopping;
    
    


    public string Name
    {
        get { return name; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > 15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }
            else
            {
                name = value;
            }
        }
    }

    public List<Topping> Toppings
    {
        get { return toppings; }
        private set
        {
            toppings = AddToping(NewTopping, value);
        }
    }

    public Dough Dough
    {
        get { return dough; }
        set { dough = value; }
    }

    public Topping NewTopping
    {
        get { return newTopping; }
        set { newTopping = value; }
    }

    public Pizza(string name)
    {
        this.Name = name;
    }

    public Pizza(string name, Dough dough):this(name)
    {
        this.Dough = dough;
    }

    public Pizza(string name ,List<Topping> toppings, Dough dough):this(name,dough)
    {
        this.Toppings = new List<Topping>();
    }

    public List<Topping> AddToping(Topping newTopping, List<Topping> toppings)
    {
        if (toppings.Count > 10)
        {
            throw new ArgumentException("Number of toppings should be in range [0..10].");
        }
        else
        {
            toppings.Add(newTopping);
        }

        return toppings;
    }

    public double TottalPizzaCalories(Dough dough, List<Topping> toppings)
    {
        double sumOfToppingsCalories = 0.0;

        foreach (var topping in this.Toppings)
        {
            sumOfToppingsCalories += BASE_CALORIES_PER_GRAM*topping.Weight*topping.toppingModifier;
        }

        double doughCalories = BASE_CALORIES_PER_GRAM * this.Dough.Weight * this.Dough.flourModifier*this.Dough.bakingTechniqueModifier;
        double pizzaCalories = sumOfToppingsCalories + doughCalories;

        return pizzaCalories;
    }
}

