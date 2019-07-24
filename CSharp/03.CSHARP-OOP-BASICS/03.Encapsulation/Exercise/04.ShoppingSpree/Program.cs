using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            List<Person> persons = ParsePersons();
            List<Product> products = ParseProducts();
            BuyProducts(persons, products);



            foreach (var person in persons)
            {
                if (person.BagOfProducts.Count > 0)
                {
                    Console.WriteLine($"{person.Name} - {string.Join(", ", person.BagOfProducts)}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
            }
        }
        catch (ArgumentException argEx)
        {
            Console.WriteLine(argEx.Message);
        }

    }
    private static List<Person> ParsePersons()
    {
        List<Person> persons = new List<Person>();

        string[] inputPersons = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < inputPersons.Length; i++)
        {
            string[] data = inputPersons[i].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);

            Person currentPerson = new Person(data[0], int.Parse(data[1]));
            persons.Add(currentPerson);
        }

        return persons;
    }

    private static List<Product> ParseProducts()
    {
        List<Product> products = new List<Product>();

        string[] inputProducts = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < inputProducts.Length; i++)
        {
            string[] data = inputProducts[i].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);

            Product currentProduct = new Product(data[0], int.Parse(data[1]));
            products.Add(currentProduct);
        }

        return products;
    }

    private static void BuyProducts(List<Person> persons, List<Product> products)
    {
        string inputCommand;

        while ((inputCommand = Console.ReadLine()) != "END")
        {
            string[] data = inputCommand.Split();
            string personName = data[0];
            string productName = data[1];

            Person person = persons.First(p => p.Name == personName);
            Product product = products.First(p => p.Name == productName);

            string output = person.TryBuyProduct(product);
            Console.WriteLine(output);
        }
    }
}

