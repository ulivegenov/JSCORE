using System;

namespace _05.WordInPlural
{
    class Program
    {
        static void Main(string[] args)
        {
            string noun = Console.ReadLine();



            if (noun.EndsWith("y"))
            {
                noun = noun.Replace("y", "ies");
            }
            else if ((noun.EndsWith("o") || (noun.EndsWith("sh")) || (noun.EndsWith("s")) || (noun.EndsWith("ch")) || (noun.EndsWith("x")) || (noun.EndsWith("z"))))
            {
                noun += "es";

            }
            else
            {
                noun += 's';
            }

            Console.WriteLine(noun);
        }
    }
}
