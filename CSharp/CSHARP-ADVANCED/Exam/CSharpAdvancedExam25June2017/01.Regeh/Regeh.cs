using System;
using System.Text;
using System.Text.RegularExpressions;

namespace CSharpAdvancedExam25June2017
{
    class Regeh
    {
        static void Main(string[] args)
        {
            string pattern = @"\[[a-zA-Z]+<(\d+)REGEH(\d+)>[a-zA-Z]+\]";

            string inputLine = Console.ReadLine();

            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(inputLine);
            int firstNum = 0;
            int secondNum = 0;
            int currentIndex = 0;
            StringBuilder result = new StringBuilder();

            foreach (Match match in matches)
            {
                firstNum = int.Parse(match.Groups[1].Value);
                currentIndex = (currentIndex + firstNum) % (inputLine.Length - 1);
                string chr = inputLine[currentIndex].ToString();
                result.Append(chr);

                secondNum = int.Parse(match.Groups[2].Value);
                currentIndex = (currentIndex + secondNum) % (inputLine.Length - 1);
                chr = inputLine[currentIndex].ToString();
                result.Append(chr);
            }

            Console.WriteLine(result);
        }
    }
}
