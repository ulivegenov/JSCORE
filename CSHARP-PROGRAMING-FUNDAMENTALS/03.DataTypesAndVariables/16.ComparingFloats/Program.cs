using System;

namespace _16.ComparingFloats
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstNumber = double.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());
            double epsConstant = 0.000001;

            bool numbersAreEqual = true;
            double diff = Math.Abs(firstNumber - secondNumber);

            if (diff < epsConstant)
            {
                Console.WriteLine(numbersAreEqual);
            }
            else if (diff == epsConstant)
            {
                numbersAreEqual = false;
                Console.WriteLine(numbersAreEqual);
            }
            else
            {
                numbersAreEqual = false;
                Console.WriteLine(numbersAreEqual);
            }
        }
    }
}
