using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<double, int> equalNums = new SortedDictionary<double, int>();
            string inputLine = Console.ReadLine();
            
            double[] tokens = inputLine
                              .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                              .Select(double.Parse)
                              .ToArray();

            for (int i = 0; i < tokens.Length; i++)
            {
                if (!equalNums.ContainsKey(tokens[i]))
                {
                    equalNums.Add(tokens[i], 1);
                }
                else
                {
                    equalNums[tokens[i]] += 1;
                }
            }

            foreach (KeyValuePair<double, int> num in equalNums)
            {
                string numAsString = num.Key.ToString();
                if (numAsString.Contains('.'))
                {
                    numAsString = numAsString.Replace('.', ',');
                }
                Console.WriteLine($"{numAsString} - {num.Value} times");
            }
        }
    }
}
