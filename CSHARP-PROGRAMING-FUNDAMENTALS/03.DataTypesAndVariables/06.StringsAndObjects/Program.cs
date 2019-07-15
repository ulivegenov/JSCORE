using System;

namespace _06.StringsAndObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstWord = "Hello";
            string secondWord = "World";

            object textEdit = $"{firstWord} {secondWord}";

            string finalText = Convert.ToString(textEdit);

            Console.WriteLine(finalText);
        }
    }
}
