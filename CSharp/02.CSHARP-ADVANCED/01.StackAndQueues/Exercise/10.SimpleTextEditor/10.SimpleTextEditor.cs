using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfOperations = int.Parse(Console.ReadLine());
            Stack<string> textElements = new Stack<string>();
            string text = string.Empty;

            for (int i = 0; i < countOfOperations; i++)
            {
                string[] inputLine = Console.ReadLine()
                                     .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                     .ToArray();
                
                
                switch (inputLine[0])
                {
                    case "1":
                        textElements.Push(text);
                        text+=inputLine[1];
                        break;

                    case "2":
                        textElements.Push(text);
                        text = text.Substring(0, text.Length - int.Parse(inputLine[1]));
                        break;

                    case "3":
                        Console.WriteLine(text[int.Parse(inputLine[1])-1]);
                        break;

                    case "4":
                        text = textElements.Pop();
                        break;
                }
            }
        }
    }
}
