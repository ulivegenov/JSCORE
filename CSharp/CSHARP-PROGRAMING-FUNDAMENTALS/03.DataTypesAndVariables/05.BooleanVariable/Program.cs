using System;

namespace _05.BooleanVariable
{
    class Program
    {
        static void Main(string[] args)
        {
            string myString = Console.ReadLine();

            if (Convert.ToBoolean(myString) == true)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
