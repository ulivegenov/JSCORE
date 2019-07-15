using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SearchForNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            List<int> newList = new List<int>();

            for (int i = 0; i < array[0]; i++)
            {
                newList.Add(list[i]);
            }

            newList.RemoveRange(0, array[1]);

            if (newList.Contains(array[2]))
            {
                Console.WriteLine("YES!");
            }
            else
            {
                Console.WriteLine("NO!");
            }
        }
    }
}
