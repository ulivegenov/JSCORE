using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.HitList
{
    class HitList
    {
        static void Main(string[] args)
        {
            int targetInfoIndex = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, string>> infoList = new Dictionary<string, Dictionary<string, string>>();
            string inputLine;

            while ((inputLine = Console.ReadLine()) != "end transmissions")
            {
                string[] dataSplit = inputLine.Split(new[] { '=', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);

                string name = dataSplit[0];

                if (!infoList.ContainsKey(name))
                {
                    infoList.Add(name, new Dictionary<string, string>());
                }

                for (int i = 1; i < dataSplit.Length; i+=2)
                {
                    string inputKey = dataSplit[i];
                    string inputValue = dataSplit[i + 1];

                    if (!infoList[name].ContainsKey(inputKey))
                    {
                        infoList[name].Add(inputKey, inputValue);
                    }
                    else
                    {
                        infoList[name][inputKey] = inputValue;
                    }
                }
            }

            string[] killCommand = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string nameToKill = killCommand[1];

            int infoIndex = 0;

            Console.WriteLine($"Info on {nameToKill}:");
            foreach (var pair in infoList)
            {
                if (pair.Key == nameToKill)
                {
                    foreach (var element in pair.Value.OrderBy(x=>x.Key))
                    {
                        infoIndex += element.Key.Length;
                        infoIndex += element.Value.Length;
                        Console.WriteLine($"---{element.Key}: {element.Value}");
                    }
                }
            }
            Console.WriteLine($"Info index: {infoIndex}");
            if (infoIndex >= targetInfoIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {targetInfoIndex-infoIndex} more info.");
            }

        }
    }
}
