using System;

namespace _04.VariableInHexFormat
{
    class Program
    {
        static void Main(string[] args)
        {
            string hexValue = Console.ReadLine();

            int decValue = Convert.ToInt32(hexValue, 16);

            Console.WriteLine(decValue);
        }
    }
}
