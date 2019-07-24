using System;
using System.Collections.Generic;
using System.Text;


public class Person
{
    private string name;

    public string Name
    {
        get { return name; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            else
            {
                name = value;
            }
        }
    }

    private decimal money;

    public decimal Money
    {
        get { return money; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            else
            {
                money = value;
            }
        }
    }

    private List<Product> bagOfProducts;

    public List<Product> BagOfProducts
    {
        get { return bagOfProducts; }
        set { bagOfProducts = value; }
    }

    public Person(string name)
    {
        this.Name = name;
    }

    public Person(string name, int money)
    {
        this.Name = name;
        this.Money = money;
        this.BagOfProducts = new List<Product>();
    }

    public string  TryBuyProduct(Product product)
    {
        if (this.Money < product.Cost)
        {
            return $"{this.Name} can't afford {product.Name}";
        }
        else
        {
            this.Money -= product.Cost;
            this.bagOfProducts.Add(product);
            return $"{this.Name} bought {product.Name}";
        }
    }
}

