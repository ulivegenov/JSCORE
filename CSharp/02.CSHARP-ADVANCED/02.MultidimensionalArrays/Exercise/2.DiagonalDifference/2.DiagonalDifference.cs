using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int[][] matrix = new int[matrixSize][];
            int primeryDiagonalSum = 0;
            int secondaryDiagonalSum = 0;
            decimal difference = 0;

            for (int currentRow = 0; currentRow < matrix.Length; currentRow++)
            {
                matrix[currentRow] = Console.ReadLine()
                                   .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                   .Select(int.Parse)
                                   .ToArray();
            }

            for (int currentRow = 0; currentRow < matrix.Length; currentRow++)
            {
                for (int currentCol = 0; currentCol < matrix.Length; currentCol++)
                {
                    if (currentRow == currentCol)
                    {
                        primeryDiagonalSum += matrix[currentRow][currentCol];
                    }
                }


                int counterCol = 0;

                for (int currentCol = matrix.Length-1; currentCol >= 0; currentCol--)
                {
                    
                    if (counterCol == currentRow)
                    {
                        secondaryDiagonalSum += matrix[currentRow][currentCol];   
                    }
                    counterCol++;
                }   
            }

            difference = Math.Abs(primeryDiagonalSum - secondaryDiagonalSum);

            Console.WriteLine(difference);
        }
    }
}
