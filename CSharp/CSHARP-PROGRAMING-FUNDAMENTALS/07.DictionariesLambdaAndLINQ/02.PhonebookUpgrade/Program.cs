using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.PhonebookUpgrade
{
    class Program
    {
        static void Main(string[] args)
        {
            var phonebook = new SortedDictionary<string, string>();
            List<string> result = new List<string>();
            bool continueInput = true;

            while (continueInput)
            {
                string[] command = Console.ReadLine().Split(' ');

                if (command[0] == "A")
                {
                    if (phonebook.ContainsKey(command[1]))
                    {
                        phonebook[command[1]] = command[2];
                    }
                    else
                    {
                        phonebook.Add(command[1], command[2]);
                    }
                }
                else if (command[0] == "S")
                {
                    if (phonebook.ContainsKey(command[1]))
                    {
                        result.Add($"{command[1]} -> {phonebook[command[1]]}");
                    }
                    else
                    {
                        result.Add($"Contact {command[1]} does not exist.");
                    }
                }
                else if (command[0] == "ListAll")
                {
                    foreach (KeyValuePair<string, string> kvp in phonebook)
                    {
                        result.Add($"{kvp.Key} -> {kvp.Value}");
                    }
                    phonebook.Keys.OrderBy(k => k);
                }
                else if (command[0] == "END")
                {
                    continueInput = false;
                }
            }

            foreach (string item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
