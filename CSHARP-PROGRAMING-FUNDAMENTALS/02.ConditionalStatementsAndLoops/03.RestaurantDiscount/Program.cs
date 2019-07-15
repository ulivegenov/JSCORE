using System;

namespace _03.RestaurantDiscount
{
    class Program
    {
        static void Main(string[] args)
        {
            int groupSize = int.Parse(Console.ReadLine());
            string kindOfPackage = Console.ReadLine();

            string kindOfHall = "";
            int priceOfHall = 0;

            if (groupSize <= 50)
            {
                kindOfHall = "Small Hall";
                priceOfHall = 2500;
            }
            else if (groupSize <= 100)
            {
                kindOfHall = "Terrace";
                priceOfHall = 5000;
            }
            else if (groupSize <= 120)
            {
                kindOfHall = "Great Hall";
                priceOfHall = 7500;
            }
            else
            {
                Console.WriteLine("We do not have an appropriate hall.");
            }
            if (groupSize > 120)
            {
                return;
            }

            double totalPrice = 0;

            switch (kindOfPackage)
            {
                case "Normal":
                    totalPrice = (priceOfHall + 500) * 0.95;
                    break;
                case "Gold":
                    totalPrice = (priceOfHall + 750) * 0.90;
                    break;
                case "Platinum":
                    totalPrice = (priceOfHall + 1000) * 0.85;
                    break;
            }

            double pricePerPerson = totalPrice / groupSize;

            Console.WriteLine($"We can offer you the {kindOfHall}");
            Console.WriteLine($"The price per person is {pricePerPerson:f2}$");
        }
    }
}
