using System;
using System.Collections.Generic;
using System.Linq;

namespace Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            List<int> bomb = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            int bombNumber = bomb[0];
            int bombPower = bomb[1];

            int index = numbers.IndexOf(bombNumber);

            while (!index.Equals(-1))
            {
                List<int> range = new List<int>();

                if (index < bombPower)
                {
                    range.AddRange(numbers
                        .Take(numbers.Count - (numbers.Count - index) + bombPower + 1));

                    numbers.RemoveRange(0, range.Count);
                }
                else
                {
                    range.AddRange(numbers
                        .Skip(index - bombPower)
                        .Take(2 * bombPower + 1));

                    numbers.RemoveRange(index - bombPower, range.Count);
                }

                index = numbers.IndexOf(bombNumber);
            }

            Console.WriteLine(numbers.Sum());
        }
    }
}