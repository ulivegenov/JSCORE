using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.MaxSequenceОfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            int currentSequenceLenght = 1;
            int bestSequenceLenght = 0;
            int symbol = 0;

            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[i] == numbers[i - 1])
                {
                    currentSequenceLenght++;
                }
                else
                {
                    currentSequenceLenght = 1;
                }
                if (currentSequenceLenght > bestSequenceLenght)
                {
                    bestSequenceLenght = currentSequenceLenght;
                    symbol = numbers[i - 1];
                }
            }

            List<int> sequenceList = new List<int>();
            for (int i = 0; i < bestSequenceLenght; i++)
            {
                sequenceList.Add(symbol);
            }
            Console.WriteLine(string.Join(" ", sequenceList));
        }
    }
}
