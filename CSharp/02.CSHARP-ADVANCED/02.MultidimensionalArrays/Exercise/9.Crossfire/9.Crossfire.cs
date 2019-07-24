using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.Crossfire
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                               .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToArray();
            int countOfRows = matrixSize[0];
            int countOfCols = matrixSize[1];
            string[][] matrix = new string[countOfRows][];
            int counter = 1;

            for (int currentRow = 0; currentRow < countOfRows; currentRow++)
            {
                matrix[currentRow] = new string[countOfCols];
                for (int currentCol = 0; currentCol < countOfCols; currentCol++)
                {
                    matrix[currentRow][currentCol] = counter.ToString();
                    counter++;
                }
            }

            string command = Console.ReadLine();
            
            while (command != "Nuke it from orbit")
            {
                int[] shotData = command
                                 .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToArray();
                int shotRow = shotData[0];
                int shotCol = shotData[1];
                int shotRadius = shotData[2];

                if ((shotRow >= 0) && (shotCol >= 0))
                {
                    matrix = Shot(matrix, shotRow, shotCol, shotRadius, countOfRows, countOfCols);
                }
                else
                {
                    matrix = matrix;
                }
                
                command = Console.ReadLine();
            }

            for (int currentRow = 0; currentRow < countOfRows; currentRow++)
            {
                Console.WriteLine(string.Join(" ", matrix[currentRow]));
            }
        }

        private static string[][] Shot(string[][] matrix, int shotRow, int shotCol, int shotRadius, int countOfRows, int countOfCols)
        {
            for (int currentRow = 0; currentRow < countOfRows; currentRow++)
            {
                for (int currentCol = 0; currentCol < countOfCols; currentCol++)
                {
                    if ((Math.Abs(shotRow - currentRow) <= shotRadius)  && (currentCol == shotCol))
                    {
                        matrix[currentRow][currentCol] = " ";
                    }

                    if ((Math.Abs(shotCol - currentCol) <= shotRadius) && (currentRow == shotRow))
                    {
                        matrix[currentRow][currentCol] = " ";
                    }
                }
            }

            for (int currentRow = 0; currentRow < shotRow; currentRow++)
            {
                for (int currentCol = 0; currentCol < shotCol; currentCol++)
                {
                    if ((shotRow - currentRow <= shotRadius) && (currentCol == shotCol))
                    {
                        matrix[currentRow][currentCol] = " ";
                    }

                    if ((shotCol - currentCol <= shotRadius) && (currentRow == shotRow))
                    {
                        matrix[currentRow][currentCol] = " ";
                    }
                }
            }

            Queue<string> newRow = new Queue<string>();

            for (int currentRow = 0; currentRow < countOfRows; currentRow++)
            {
                for (int currentCol = 0; currentCol < countOfCols; currentCol++)
                {
                    if (matrix[currentRow][currentCol] != " ")
                    {
                        newRow.Enqueue(matrix[currentRow][currentCol]);
                    }
                }

                int currentRowLenght = newRow.Count;

                for (int i = 0; i < countOfCols; i++)
                {
                    if (i < currentRowLenght)
                    {
                        matrix[currentRow][i] = newRow.Dequeue();
                    }
                    else
                    {
                        matrix[currentRow][i] = " ";
                    }
                    
                }

                newRow.Clear();
            }

            return matrix;
        }
    }
}
