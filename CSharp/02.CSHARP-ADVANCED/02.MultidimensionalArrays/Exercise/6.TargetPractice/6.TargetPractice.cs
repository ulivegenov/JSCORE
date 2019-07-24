using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.TargetPractice
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
            string snakeName = Console.ReadLine();
            int[] shotData = Console.ReadLine()
                             .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                             .Select(int.Parse)
                             .ToArray();
            int impactRow = shotData[0];
            int impactCol = shotData[1];
            int radius = shotData[2];
            char[][] matrix = new char[matrixRows][];

            char[] elements = new char[matrixRows * matrixCols];
            int currentElement = 0;
            for (int i = 0; i < matrixRows * matrixCols; i++)
            {
                if (currentElement == snakeName.Length)
                {
                    currentElement = 0;
                }
                elements[i] = snakeName[currentElement];
                currentElement++;
            }

            int counter = 1;
            currentElement = 0;
            for (int currentRow = matrix.Length - 1; currentRow >= 0; currentRow--)
            {
                matrix[currentRow] = new char[matrixCols];

                if (counter % 2 == 0)
                {
                    for (int currentCol = 0; currentCol < matrix[currentRow].Length; currentCol++)
                    {
                        matrix[currentRow][currentCol] = elements[currentElement];
                        currentElement++;
                    }
                }
                else
                {
                    for (int currentCol = matrix[currentRow].Length - 1; currentCol >= 0; currentCol--)
                    {
                        matrix[currentRow][currentCol] = elements[currentElement];
                        currentElement++;
                    }
                }

                counter++;
            }

            for (int currentRow = 0; currentRow < matrix.Length; currentRow++)
            {
                for (int currentCol = 0; currentCol < matrix[currentRow].Length; currentCol++)
                {
                    if ((Math.Abs(currentRow - impactRow) + Math.Abs(currentCol - impactCol)) <= radius)
                    {
                        matrix[currentRow][currentCol] = ' ';
                    }
                }
            }

            int[] moves = new int[matrixCols];
            for (int i = 0; i < moves.Length; i++)
            {
                moves[i] = 0;
            }

            for (int currentRow = 0; currentRow < matrix.Length; currentRow++)
            {
                for (int currentCol = 0; currentCol < matrix[currentRow].Length; currentCol++)
                {
                    if (matrix[currentRow][currentCol] == ' ')
                    {
                        moves[currentCol]++;
                    }
                }
            }

            for (int currentRow = 0; currentRow < matrix.Length; currentRow++)
            {
                for (int currentCol = 0; currentCol < matrix[currentRow].Length; currentCol++)
                {
                    matrix = MoveCol(matrix, moves);
                }
            }

            for (int currentRow = 0; currentRow < matrix.Length; currentRow++)
            {
                Console.WriteLine(string.Join("", matrix[currentRow]));
            }
        }

        private static char[][] MoveCol(char[][] matrix, int[] moves)
        {
            char[] temp = new char[matrix.Length];
            
            for (int currentRow = 0; currentRow < matrix.Length; currentRow++)
            {
                int colIndex = 0;
                for (int currentCol = 0; currentCol < matrix[currentRow].Length; currentCol++)
                {
                    if ((moves[colIndex] != 0) && (moves[colIndex] != matrix.Length) && (currentCol == colIndex))
                    {
                        int counter = 0;
                        for (int i = 0; i < moves[colIndex]; i++)
                        {
                            temp[i] = ' ';
                            counter++;
                        }
                        
                        for (int currentRowIndex = 0; currentRowIndex < matrix.Length; currentRowIndex++)
                        {
                            for (int currentColIndex = 0; currentColIndex < matrix[currentRowIndex].Length; currentColIndex++)
                            {
                                if ((currentColIndex == colIndex) && (matrix[currentRowIndex][currentColIndex] != ' '))
                                {
                                    temp[counter] = matrix[currentRowIndex][currentColIndex];
                                    counter++;
                                }
                            }
                        }

                        for (int currentRowIndex = 0; currentRowIndex < matrix.Length; currentRowIndex++)
                        {
                            for (int currentColIndex = 0; currentColIndex < matrix[currentRowIndex].Length; currentColIndex++)
                            {
                                if (currentColIndex == colIndex)
                                {
                                    matrix[currentRowIndex][currentColIndex] = temp[currentRowIndex];
                                    break;
                                }
                            }
                        }
                    }
                    colIndex++;
                }
            }

            return matrix;
        }
    }
}
