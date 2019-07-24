using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.MaximalSum
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
            int[][] matrix = new int[matrixRows][];

            for (int currentRow = 0; currentRow < matrixRows; currentRow++)
            {
                matrix[currentRow] = Console.ReadLine()
                                   .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                   .Select(int.Parse)
                                   .ToArray();
            }

            StringBuilder tempElements = new StringBuilder();
            int[][] tempMatrix = new int[3][];
            int[][] resultMatrix = new int[3][];
            int currentSum = 0;
            int maxSum = int.MinValue;

            for (int currentRow = 0; currentRow < matrix.Length - 2; currentRow++)
            {
                for (int currentCol = 0; currentCol < matrix[currentRow].Length - 2; currentCol++)
                {
                    tempElements.Append(matrix[currentRow][currentCol]);
                    tempElements.Append(" ");
                    tempElements.Append(matrix[currentRow][currentCol + 1]);
                    tempElements.Append(" ");
                    tempElements.Append(matrix[currentRow][currentCol + 2]);
                    tempElements.Append(" ");
                    tempElements.Append(matrix[currentRow + 1][currentCol]);
                    tempElements.Append(" ");
                    tempElements.Append(matrix[currentRow + 1][currentCol + 1]);
                    tempElements.Append(" ");
                    tempElements.Append(matrix[currentRow + 1][currentCol + 2]);
                    tempElements.Append(" ");
                    tempElements.Append(matrix[currentRow + 2][currentCol]);
                    tempElements.Append(" ");
                    tempElements.Append(matrix[currentRow + 2][currentCol + 1]);
                    tempElements.Append(" ");
                    tempElements.Append(matrix[currentRow + 2][currentCol + 2]);

                    int[] tempElementsAsArray = tempElements
                                                .ToString()
                                                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                                .Select(int.Parse)
                                                .ToArray();
                    tempElements.Clear();
                    currentSum = tempElementsAsArray.Sum();
                    int[] tempMatrixFirstRow = new int[] { tempElementsAsArray[0], tempElementsAsArray[1], tempElementsAsArray[2] };
                    int[] tempMatrixSecondRow = new int[] { tempElementsAsArray[3], tempElementsAsArray[4], tempElementsAsArray[5] };
                    int[] tempMatrixThirdtRow = new int[] { tempElementsAsArray[6], tempElementsAsArray[7], tempElementsAsArray[8] };
                    tempMatrix[0] = tempMatrixFirstRow;
                    tempMatrix[1] = tempMatrixSecondRow;
                    tempMatrix[2] = tempMatrixThirdtRow;
                    
                    if (maxSum < currentSum)
                    {
                        resultMatrix[0] = tempMatrixFirstRow;
                        resultMatrix[1] = tempMatrixSecondRow;
                        resultMatrix[2] = tempMatrixThirdtRow;
                        maxSum = currentSum;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            foreach (var row in resultMatrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
