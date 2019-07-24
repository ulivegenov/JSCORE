using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.LegoBlocks
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfRows = int.Parse(Console.ReadLine());
            int[][] firstJaggedArray = new int[countOfRows][];
            int[][] secondJaggedArray = new int[countOfRows][];
            int[][] reversedSecondJaggedArray = new int[countOfRows][];

            for (int currentRow = 0; currentRow < countOfRows; currentRow++)
            {
                int[] row = Console.ReadLine()
                            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();
                firstJaggedArray[currentRow] = row;
            }

            for (int currentRow = 0; currentRow < countOfRows; currentRow++)
            {
                int[] row = Console.ReadLine()
                            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();
                secondJaggedArray[currentRow] = row;
                int[] reversedRow = row.Reverse().ToArray();
                reversedSecondJaggedArray[currentRow] = reversedRow;
            }

            bool isFit = true;

            for (int currentRow = 1; currentRow < countOfRows; currentRow++)
            {
                if (firstJaggedArray[currentRow].Length+secondJaggedArray[currentRow].Length != firstJaggedArray[currentRow-1].Length+secondJaggedArray[currentRow-1].Length)
                {
                    isFit = false;
                }
            }

            int[][] matchedArrays = new int[countOfRows][];

            if (isFit)
            {
                for (int currentRow = 0; currentRow < countOfRows; currentRow++)
                {
                    StringBuilder row = new StringBuilder();
                    row.Append(string.Join(" ", firstJaggedArray[currentRow]).TrimEnd());
                    row.Append(" ");
                    row.Append(string.Join(" ", reversedSecondJaggedArray[currentRow]).TrimStart());
                    int[] rowAsArray = row.ToString()
                                       .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                       .Select(int.Parse)
                                       .ToArray();
                    matchedArrays[currentRow] = rowAsArray;
                    Console.WriteLine($"[{string.Join(", ", matchedArrays[currentRow])}]");
                }
            }
            else
            {
                int countOfElements = 0;

                for (int currentRow = 0; currentRow < countOfRows; currentRow++)
                {
                    StringBuilder row = new StringBuilder();
                    row.Append(string.Join(" ", firstJaggedArray[currentRow]).TrimEnd());
                    row.Append(" ");
                    row.Append(string.Join(" ", reversedSecondJaggedArray[currentRow]).TrimStart());
                    int[] rowAsArray = row.ToString()
                                       .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                       .Select(int.Parse)
                                       .ToArray();
                    countOfElements += rowAsArray.Length;
                }

                Console.WriteLine($"The total number of cells is: {countOfElements}");
            }
        }
    }
}
