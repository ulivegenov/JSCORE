using System;

namespace _04.NumbersInReversedOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal number = decimal.Parse(Console.ReadLine());

            Console.WriteLine(ReversedNumber(number));
        }

        static decimal ReversedNumber(decimal num)
        {
            int places = 0;
            int times = 0;
            decimal reversedNum = 0;

            while (num % 1 > 0)
            {
                num *= 10;
                places++;
            }

            do
            {
                int lastDigit = (int)num % 10;
                reversedNum = reversedNum * 10 + lastDigit;
                num = (int)num / 10;
                times++;
            }
            while (num > 0);

            if (places > 0)
            {
                int division = (int)Math.Pow(10, times - places);
                reversedNum = reversedNum / division;
            }
            return reversedNum;
        }
    }
}
