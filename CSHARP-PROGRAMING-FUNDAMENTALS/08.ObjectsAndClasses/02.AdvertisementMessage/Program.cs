using System;

namespace _02.AdvertisementMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] phrases = new string[] { "Excellent product.", "Such a great product.", "I always use that product.",
                                            "Best product of its category.", "Exceptional product.", "I can’t live without this product." };

            string[] evenst = new string[] { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!",
                                           "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };

            string[] authors = new string[] { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };

            string[] cities = new string[] { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            Random randomise = new Random();

            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                string phrasesIndex = phrases[randomise.Next(0, phrases.Length)];
                string eventsIndex = evenst[randomise.Next(0, evenst.Length)];
                string authorsIndex = authors[randomise.Next(0, authors.Length)];
                string citiesIndex = cities[randomise.Next(0, cities.Length)];

                Console.WriteLine($"{phrasesIndex} {eventsIndex} {authorsIndex} – {citiesIndex}");
            }
        }
    }
}
