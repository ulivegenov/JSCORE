using System;
using System.Collections.Generic;

namespace _01.phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            var phonebook = new Dictionary<string, string>();
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
                else if (command[0] == "END")
                {
                    continueInput = false;
                }
            }

            for (int i = 0; i < result.Count; i++)
            {
                Console.WriteLine(result[i]);
            }
        }
    }
}
