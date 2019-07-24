using System;
using System.Linq;
using System.Numerics;

namespace _02.ConvertFromBase_NToBase10
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();
            int baseN = int.Parse(input[0]);
            BigInteger numberToConvert = BigInteger.Parse(input[1]);
            string numberToConvertAsString = numberToConvert.ToString();
            BigInteger result = 0;
            int power = 0;

            for (int i = numberToConvertAsString.Length - 1; i >= 0; i--)
            {
                int digit = int.Parse(numberToConvertAsString[i].ToString());
                result += digit * BigInteger.Pow(baseN, power);
                power++;
            }


            Console.WriteLine(result);
        }
    }
}
