using System;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;

namespace _01.ConvertFromBase_10ToBase_N
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();
            int baseN = int.Parse(input[0]);
            BigInteger base10 = BigInteger.Parse(input[1]);
            List<BigInteger> listBaseN = new List<BigInteger>();

            while (base10 != 0)
            {
                BigInteger surplusBase10 = base10 % baseN;
                base10 = base10 / baseN;
                listBaseN.Add(surplusBase10);
            }

            BigInteger[] arreyBaseN = new BigInteger[listBaseN.Count];

            for (int i = 0; i < arreyBaseN.Length; i++)
            {
                arreyBaseN[i] = listBaseN[arreyBaseN.Length - i - 1];
            }

            Console.WriteLine(string.Join("", arreyBaseN));
        }
    }
}
