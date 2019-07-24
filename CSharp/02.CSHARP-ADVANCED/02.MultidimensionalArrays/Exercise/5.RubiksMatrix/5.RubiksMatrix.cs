using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.RubiksMatrix
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
            int countOfCommands = int.Parse(Console.ReadLine());

            int[][] matrix = new int[matrixRows][];
            int counter = 1;

            for (int currentRow = 0; currentRow < matrix.Length; currentRow++)
            {
                matrix[currentRow] = new int[matrixCols];
                for (int currentCol = 0; currentCol < matrix[currentRow].Length; currentCol++)
                {
                    matrix[currentRow][currentCol] = counter;
                    counter++;
                }
            }

            for (int i = 0; i < countOfCommands; i++)
            {
                string[] commandLine = Console.ReadLine()
                                       .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                       .ToArray();

                int rcIndex = int.Parse(commandLine[0]);
                string direction = commandLine[1];
                int moves = int.Parse(commandLine[2]);

                switch (direction)
                {
                    case "up":
                        matrix = MoveCol(matrix, direction, rcIndex, moves);
                        break;
                    case "down":
                        matrix = MoveCol(matrix, direction, rcIndex, moves);
                        break;
                    case "left":
                        matrix = MoveRow(matrix, direction, rcIndex, moves);
                        break;
                    case "right":
                        matrix = MoveRow(matrix, direction, rcIndex, moves);
                        break;
                }
            }

            counter = 1;

            for (int currentRow = 0; currentRow < matrix.Length; currentRow++)
            {
                for (int currentCol = 0; currentCol < matrix[currentRow].Length; currentCol++)
                {
                    if (matrix[currentRow][currentCol] == counter)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
                        {
                            for (int colIndex = 0; colIndex < matrix[rowIndex].Length; colIndex++)
                            {
                                if (matrix[rowIndex][colIndex] == counter)
                                {
                                    int currentElement = matrix[currentRow][currentCol];
                                    matrix[currentRow][currentCol] = counter;
                                    matrix[rowIndex][colIndex] = currentElement;
                                    Console.WriteLine($"Swap ({currentRow}, {currentCol}) with ({rowIndex}, {colIndex})");
                                    break;
                                }
                            }
                        }
                    }
                    counter++;
                }
            }
        }

        private static int[][] MoveRow(int[][] matrix, string direction, int rcIndex, int moves)
        {
            int[] temp = new int[matrix.Length];

            if (moves > matrix.Length)
            {
                moves = moves % matrix.Length;
            }

            if (moves == matrix.Length)
            {
                return matrix;
            }
            else
            {
                if (direction == "right")
                {
                    moves = matrix.Length - moves;
                }

                int counter = 0;

                for (int currentRow = 0; currentRow < matrix.Length; currentRow++)
                {
                    if (currentRow == rcIndex)
                    {
                        for (int currentCol = moves; currentCol < matrix[currentRow].Length; currentCol++)
                        {
                            temp[counter] = matrix[currentRow][currentCol];
                            counter++;
                        }

                        for (int currentCol = 0; currentCol < moves; currentCol++)
                        {
                            temp[counter] = matrix[currentRow][currentCol];
                            counter++;
                        }

                        matrix[currentRow] = temp;
                        break;
                    }
                }

                return matrix;
            }
        }

        private static int[][] MoveCol(int[][] matrix, string direction, int rcIndex, int moves)
        {
            int[] temp = new int[matrix.Length];

            if (moves > matrix.Length)
            {
                moves = moves % matrix.Length;
            }

            if (moves == matrix.Length)
            {
                return matrix;
            }
            else
            {
                if (direction == "down")
                {
                    moves = matrix.Length - moves;
                }

                int counter = 0;

                for (int currentRow = moves; currentRow < matrix.Length; currentRow++)
                {
                    for (int currentCol = 0; currentCol < matrix[currentRow].Length; currentCol++)
                    {
                        if (currentCol == rcIndex)
                        {
                            temp[counter] = matrix[currentRow][currentCol];
                            counter++;
                            break;
                        }
                    }
                }

                for (int currentRow = 0; currentRow < moves; currentRow++)
                {
                    for (int currentCol = 0; currentCol < matrix[currentRow].Length; currentCol++)
                    {
                        if (currentCol == rcIndex)
                        {
                            temp[counter] = matrix[currentRow][currentCol];
                            counter++;
                            break;
                        }
                    }
                }

                for (int currentRow = 0; currentRow < matrix.Length; currentRow++)
                {
                    for (int currentCol = 0; currentCol < matrix[currentRow].Length; currentCol++)
                    {
                        if (currentCol == rcIndex)
                        {
                            matrix[currentRow][currentCol] = temp[currentRow];
                            break;
                        }
                    }
                }

                return matrix;
            }
        }
    }
}
