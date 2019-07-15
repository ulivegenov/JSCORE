using System;

namespace _11.FiveDifferentNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOne = int.Parse(Console.ReadLine());
            int numberTwo = int.Parse(Console.ReadLine());


            if ((numberTwo - numberOne) >= 4)
            {
                for (int currentFirstNum = numberOne; currentFirstNum <= numberTwo - 4; currentFirstNum++)
                {
                    if (currentFirstNum >= numberOne)
                    {
                        for (int currentSecondNum = numberOne + 1; currentSecondNum <= numberTwo - 3; currentSecondNum++)
                        {
                            if (currentSecondNum > currentFirstNum)
                            {
                                for (int currentThirdNum = numberOne + 2; currentThirdNum <= numberTwo - 2; currentThirdNum++)
                                {
                                    if (currentThirdNum > currentSecondNum)
                                    {
                                        for (int currentFourthNum = numberOne + 3; currentFourthNum <= numberTwo - 1; currentFourthNum++)
                                        {
                                            if (currentFourthNum > currentThirdNum)
                                            {
                                                for (int currentFifthNum = numberOne + 4; currentFifthNum <= numberTwo; currentFifthNum++)
                                                {
                                                    if (currentFifthNum > currentFourthNum)
                                                    {
                                                        Console.WriteLine($"{currentFirstNum} {currentSecondNum} {currentThirdNum} {currentFourthNum} {currentFifthNum}");
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
