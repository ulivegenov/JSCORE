using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.ExtractSentencesByKeyword
{
    class Program
    {
        static void Main(string[] args)
        {
            string keyWord = Console.ReadLine();
            string[] input = Console.ReadLine().Split(new char[] { '!', '.', '?' }, StringSplitOptions.RemoveEmptyEntries);
            string pattern = $@"\s({keyWord})\s";

            foreach (string sentence in input)
            {
                string[] words = Regex.Split(sentence, "[^A-Za-z]");
                if (words.Contains(keyWord))
                {
                    Console.WriteLine(sentence.Trim());
                }
            }

        }
    }
}
