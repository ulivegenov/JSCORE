using System;

namespace _12.MasterNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            long number = long.Parse(Console.ReadLine());

            for (int currentNumberToCheck = 1; currentNumberToCheck <= number; currentNumberToCheck++)
            {
                if (PalindromCheck(currentNumberToCheck))
                {
                    if (ContainsEvenDigit(currentNumberToCheck))
                    {
                        if (IsSumOfDigitsDivisibleBySeven(currentNumberToCheck))
                        {
                            Console.WriteLine(currentNumberToCheck);
                        }
                    }
                }
            }
        }

        static bool PalindromCheck(int numberToCheck)
        {
            bool isPalindrom = false;
            int number = numberToCheck;
            int reversedNumber = 0;

            while (number > 0)
            {
                int lastDigit = number % 10;
                reversedNumber = reversedNumber * 10 + lastDigit;
                number = number / 10;
            }

            if (reversedNumber == numberToCheck)
            {
                isPalindrom = true;
            }

            return isPalindrom;

        }

        static bool IsSumOfDigitsDivisibleBySeven(int numberToCheck)
        {
            bool sumOfDigitdDivisibleBySevent = false;
            int sumOfDigits = 0;

            while (numberToCheck > 0)
            {
                int lastDigit = numberToCheck % 10;
                sumOfDigits += lastDigit;
                numberToCheck = numberToCheck / 10;
            }

            if (sumOfDigits % 7 == 0)
            {
                sumOfDigitdDivisibleBySevent = true;
            }
            return sumOfDigitdDivisibleBySevent;
        }

        static bool ContainsEvenDigit(int numberToCheck)
        {
            bool containsEvenDigit = false;
            int evenDigits = 0;

            while (numberToCheck > 0)
            {
                int lastDigit = numberToCheck % 10;
                int checkForEvenDigit = lastDigit % 2;

                if (checkForEvenDigit == 0)
                {
                    evenDigits++;
                    break;
                }

                numberToCheck = numberToCheck / 10;
            }

            if (evenDigits > 0)
            {
                containsEvenDigit = true;
            }

            return containsEvenDigit;
        }
    }
}
