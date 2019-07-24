using System;
using System.Collections.Generic;

namespace _03.MinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, int>();
            bool continueInput = true;
            string key = "";
            int value = 0;

            for (int i = 1; ; i++)
            {
                key = Console.ReadLine();

                if (key == "stop")
                {
                    break;
                }

                if (dict.ContainsKey(key))
                {
                    dict[key] += int.Parse(Console.ReadLine());

                }
                else
                {
                    dict[key] = int.Parse(Console.ReadLine());

                }
            }

            foreach (KeyValuePair<string, int> item in dict)
            {
                Console.WriteLine("{0} -> {1}", item.Key, item.Value);
            }

        }
    }
}
