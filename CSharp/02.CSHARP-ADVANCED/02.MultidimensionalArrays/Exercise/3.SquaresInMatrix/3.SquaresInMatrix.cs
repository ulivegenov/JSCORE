using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                               .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToArray();
            int matrixRows = matrixSize[0];
            int matrixCols = matrixSize[1];
            char[][] matrix = new char[matrixRows][];

            for (int currentRow = 0; currentRow < matrix.Length; currentRow++)
            {
                matrix[currentRow] = Console.ReadLine()
                                   .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                   .Select(char.Parse)
                                   .ToArray();
            }

            int counterOfEqualCharsSquares = 0;

            for (int currentRow = 0; currentRow < matrix.Length-1; currentRow++)
            {
                for (int currentCol = 0; currentCol < matrix[currentRow].Length - 1; currentCol++)
                {
                    bool equalCharsSquare = (matrix[currentRow][currentCol] == matrix[currentRow][currentCol + 1])
                                            && (matrix[currentRow][currentCol] == matrix[currentRow + 1][currentCol])
                                            && (matrix[currentRow][currentCol] == matrix[currentRow + 1][currentCol + 1]);
                    if (equalCharsSquare)
                    {
                        counterOfEqualCharsSquares++;
                    }
                }
            }

            Console.WriteLine(counterOfEqualCharsSquares);
        }
    }
}
