using System;

namespace _01.Hello_Name_
{
    class Program
    {

        static void Main(string[] args)
        {

            PrintGreeting();
        }

        static void PrintGreeting()
        {
            string name = Console.ReadLine();
            Console.WriteLine($"Hello, {name}!");
        }
    }
}
