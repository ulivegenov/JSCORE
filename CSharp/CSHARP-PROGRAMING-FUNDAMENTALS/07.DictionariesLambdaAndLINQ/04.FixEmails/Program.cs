using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FixEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> mailDictionary = new Dictionary<string, string>();
            bool input = true;

            while (input)
            {
                string input1 = Console.ReadLine();
                string input2 = Console.ReadLine();

                if (input1 == "stop")
                {
                    input = false;
                }
                else
                {
                    mailDictionary[input1] = input2;

                    if ((input2.Split('.').Contains("us")) || (input2.Split('.').Contains("uk")))
                    {
                        mailDictionary.Remove(input1);
                    }
                }
            }

            foreach (KeyValuePair<string, string> kvp in mailDictionary)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
