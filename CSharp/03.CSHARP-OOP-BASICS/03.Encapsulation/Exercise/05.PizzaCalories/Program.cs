using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] inputDataPizzaName = Console.ReadLine().Split();
            Pizza pizza = GetPizzaName(inputDataPizzaName);

            string[] inputDataDough = Console.ReadLine().Split();
            pizza.Dough = GetPizzaDough(inputDataDough);

            string outputCommand;

            while ((outputCommand = Console.ReadLine()) != "END")
            {
                pizza.AddToping(GetTopping(outputCommand), pizza.Toppings);
            }

            Console.WriteLine($"{pizza.Name} - {pizza.TottalPizzaCalories(pizza.Dough, pizza.Toppings):f2} Calories.");
        }
        catch (ArgumentException argEx)
        {
            Console.WriteLine(argEx.Message);
        }
    }

    private static Pizza GetPizzaName(string[] inputDataPizzaName)
    {
        string pizzaName = inputDataPizzaName[1];
        Pizza pizza = new Pizza(pizzaName);
        return pizza;
    }

    private static Dough GetPizzaDough(string[] inputDataDough)
    {
        string doughType = inputDataDough[1];
        string doughBakingTechnique = inputDataDough[2];
        int doughWeight = int.Parse(inputDataDough[3]);
        Dough dough = new Dough(doughType, doughWeight, doughBakingTechnique);

        return dough;
    }

    private static Topping GetTopping(string outputCommand)
    {
        string[] inputToppingData = outputCommand.Split();
        string toppingType = inputToppingData[1];
        int toppingWeight = int.Parse(inputToppingData[2]);
        Topping currentTopping = new Topping(toppingType, toppingWeight);

        return currentTopping;
    }
}

