using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _02.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            using (System.IO.StreamReader readWordsStream = new StreamReader("word.txt"))
            {
                Dictionary<string, int> wordsCounter = new Dictionary<string, int>();
                string word;

                while ((word = readWordsStream.ReadLine()) != null)
                {
                    string newWord = word;
                    
                    using (System.IO.StreamReader readTextStream = new StreamReader("text.txt"))
                    {
                        string[] line = readTextStream.ReadToEnd()
                                        .ToLower()
                                        .Split(new char[] {' ','.',',','!','?','-'}, StringSplitOptions.RemoveEmptyEntries);

                        int counter = 1;

                        foreach (string singleWord in line)
                        {
                            if (singleWord == newWord.ToLower())
                            {
                                if (!wordsCounter.ContainsKey(singleWord))
                                {
                                    wordsCounter.Add(singleWord, counter);
                                }
                                else
                                {
                                    wordsCounter[singleWord]++;
                                }
                            }  
                        }
                    }
                }

                using (System.IO.StreamWriter writeResult = new StreamWriter("result.txt"))
                {
                    foreach (var pair in wordsCounter.OrderByDescending(e => e.Value))
                    {
                        writeResult.WriteLine($"{pair.Key} - {pair.Value}");
                        Console.WriteLine($"{pair.Key} - {pair.Value}");
                    }
                }
            }
        }
    }
}
