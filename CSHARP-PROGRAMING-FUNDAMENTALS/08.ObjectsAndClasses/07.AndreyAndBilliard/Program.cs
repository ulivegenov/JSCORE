using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.AndreyAndBilliard
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfGods = int.Parse(Console.ReadLine());
            Dictionary<string, decimal> shopList = new Dictionary<string, decimal>();

            for (int i = 0; i < countOfGods; i++)
            {
                string[] input = Console.ReadLine().Split('-');
                if (!shopList.ContainsKey(input[0]))
                {
                    shopList.Add(input[0], decimal.Parse(input[1]));
                }
                else
                {
                    shopList[input[0]] = decimal.Parse(input[1]);
                }
            }

            List<Customer> allCustumers = new List<Customer>();

            while (true)
            {
                string[] inputClientsOrder = Console.ReadLine().Split('-', ',');

                if (inputClientsOrder[0] == "end of clients")
                {
                    break;
                }
                else
                {
                    string customerName = inputClientsOrder[0];
                    string productName = inputClientsOrder[1];
                    int quantity = int.Parse(inputClientsOrder[2]);

                    if (!shopList.ContainsKey(productName))
                    {
                        continue;
                    }

                    Customer client = new Customer();
                    client.Order = new Dictionary<string, int>();
                    client.Name = inputClientsOrder[0];
                    client.Order.Add(productName, quantity);

                    if (allCustumers.Any(x => x.Name == customerName))
                    {
                        Customer existingCustomer = allCustumers.First(x => x.Name == customerName);

                        if (existingCustomer.Order.ContainsKey(productName))
                        {
                            existingCustomer.Order[productName] += quantity;
                        }
                        else
                        {
                            existingCustomer.Order[productName] = quantity;
                        }
                    }
                    else
                    {
                        allCustumers.Add(client);
                    }
                }
            }

            foreach (var customer in allCustumers)
            {
                foreach (var item in customer.Order)
                {
                    foreach (var product in shopList)
                    {
                        if (item.Key == product.Key)
                        {
                            customer.Bill += item.Value * product.Value;
                        }
                    }
                }
            }

            var ordered = allCustumers.OrderBy(x => x.Name).ThenBy(x => x.Bill).ToList();
            foreach (var customer in ordered)
            {
                Console.WriteLine(customer.Name);
                foreach (KeyValuePair<string, int> item in customer.Order)
                {
                    Console.WriteLine($"-- {item.Key} - {item.Value}");
                }
                Console.WriteLine($"Bill: {customer.Bill:f2}");
            }
            Console.WriteLine($"Total bill: {allCustumers.Sum(x => x.Bill):f2}");
        }
        class Customer
        {
            public string Name { get; set; }
            public Dictionary<string, int> Order { get; set; }
            public decimal Bill { get; set; }
        }
    }
}



