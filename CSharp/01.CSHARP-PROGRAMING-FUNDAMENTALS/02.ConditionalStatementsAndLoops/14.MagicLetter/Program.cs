using System;

namespace _14.MagicLetter1
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstLetter = char.Parse(Console.ReadLine());
            char secondLetter = char.Parse(Console.ReadLine());
            char thirdLetter = char.Parse(Console.ReadLine());

            for (int currentFirstLetter = firstLetter; currentFirstLetter <= secondLetter; currentFirstLetter++)
            {
                for (int currentSecondLetter = firstLetter; currentSecondLetter <= secondLetter; currentSecondLetter++)
                {
                    for (int currentThirdLetter = firstLetter; currentThirdLetter <= secondLetter; currentThirdLetter++)
                    {
                        if ((currentFirstLetter != thirdLetter) && (currentSecondLetter != thirdLetter) && (currentThirdLetter != thirdLetter))
                        {
                            Console.Write($"{(char)currentFirstLetter}{(char)currentSecondLetter}{(char)currentThirdLetter} ");
                        }
                    }
                }
            }
        }
    }
}