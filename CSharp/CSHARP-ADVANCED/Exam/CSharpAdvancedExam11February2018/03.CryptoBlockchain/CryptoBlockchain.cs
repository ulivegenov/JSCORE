using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.CryptoBlockchain
{
    class CryptoBlockchain
    {
        static void Main(string[] args)
        {
            string pattern = @"\[[^\[\]\{\}]*?[^\[\]\{\}]*?\]|\{[^\[\]\{\}]*?[^\[\]\{\}]\}";
            int countOfRows = int.Parse(Console.ReadLine());
            StringBuilder constructBuilder = new StringBuilder();

            for (int i = 0; i < countOfRows; i++)
            {
                string inputLine = Console.ReadLine();
                constructBuilder.Append(inputLine);
            }

            string text = constructBuilder.ToString();
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(text);
            Queue constructNums = new Queue();
            List<char> resultNums = new List<char>();
            StringBuilder singleNumConstruct = new StringBuilder();


            for (int currentMatch = 0; currentMatch < matches.Count; currentMatch++)
            {
                int counter = 0;
                var currentString = matches[currentMatch].ToString();
                for (int currentCh = 0; currentCh < currentString.Length; currentCh++)
                {
                    if (Char.IsDigit(currentString[currentCh]))
                    {
                        constructNums.Enqueue(currentString[currentCh]);
                        counter++;
                    }
                }

                if (constructNums.Count % 3 == 0)
                {
                    for (int i = 0; i < counter; i+=3)
                    {
                        singleNumConstruct.Append(constructNums.Dequeue().ToString());
                        singleNumConstruct.Append(constructNums.Dequeue().ToString());
                        singleNumConstruct.Append(constructNums.Dequeue().ToString());
                        resultNums.Add((char)(int.Parse(singleNumConstruct.ToString()) - currentString.Length));
                        singleNumConstruct.Clear();
                    }
                }
                else
                {
                    constructNums.Clear();
                }
            }

            Console.WriteLine(string.Join("", resultNums));
        }
    }
}
