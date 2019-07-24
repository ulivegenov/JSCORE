using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.RadioactiveBunnies
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
            char[][] resultMatrix = new char[countOfRows][];
            char[][] matrix = new char[countOfRows][];

            for (int currentRow = 0; currentRow < countOfRows; currentRow++)
            {
                string inputRow = Console.ReadLine();
                matrix[currentRow] = new char[countOfCols];
                resultMatrix[currentRow] = new char[countOfCols];

                for (int currentCol = 0; currentCol < countOfCols; currentCol++)
                {
                    resultMatrix[currentRow][currentCol] = inputRow[currentCol];
                    matrix[currentRow][currentCol] = inputRow[currentCol];
                }
            }

            string inputCommandLine = Console.ReadLine();
            int currentPlayerRow = 0;
            int currentPlayerCol = 0;
            bool won = false;
            bool dead = false;

            for (int i = 0; i < inputCommandLine.Length; i++)
            {
                char currentCommand = inputCommandLine[i];

                for (int currentRow = 0; currentRow < countOfRows; currentRow++)
                {
                    for (int currentCol = 0; currentCol < countOfCols; currentCol++)
                    {
                        if (resultMatrix[currentRow][currentCol] == 'P')
                        {
                            currentPlayerRow = currentRow;
                            currentPlayerCol = currentCol;
                        }
                    }
                }

                if (currentCommand == 'U')
                {
                    resultMatrix[currentPlayerRow][currentPlayerCol] = '.';

                    if (currentPlayerRow - 1 < 0)
                    {
                        won = true;
                    }
                    else if (resultMatrix[currentPlayerRow - 1][currentPlayerCol] == 'B')
                    {
                        dead = true;
                        currentPlayerRow--;
                    }
                    else
                    {
                        resultMatrix[currentPlayerRow - 1][currentPlayerCol] = 'P';
                        currentPlayerRow--;
                    }
                }
                else if (currentCommand == 'D')
                {
                    resultMatrix[currentPlayerRow][currentPlayerCol] = '.';

                    if (currentPlayerRow + 1 > countOfRows - 1)
                    {
                        won = true;
                    }
                    else if (resultMatrix[currentPlayerRow + 1][currentPlayerCol] == 'B')
                    {
                        dead = true;
                        currentPlayerRow++;
                    }
                    else
                    {
                        resultMatrix[currentPlayerRow + 1][currentPlayerCol] = 'P';
                        currentPlayerRow++;
                    }
                }
                else if (currentCommand == 'L')
                {
                    resultMatrix[currentPlayerRow][currentPlayerCol] = '.';

                    if (currentPlayerCol - 1 < 0)
                    {
                        won = true;
                    }
                    else if (resultMatrix[currentPlayerRow][currentPlayerCol - 1] == 'B')
                    {
                        dead = true;
                        currentPlayerCol--;
                    }
                    else
                    {
                        resultMatrix[currentPlayerRow][currentPlayerCol - 1] = 'P';
                        currentPlayerCol--;
                    }
                }
                else if (currentCommand == 'R')
                {
                    resultMatrix[currentPlayerRow][currentPlayerCol] = '.';

                    if (currentPlayerCol + 1 > countOfCols - 1)
                    {
                        won = true;
                    }
                    else if(resultMatrix[currentPlayerRow][currentPlayerCol + 1] == 'B')
                    {
                        dead = true;
                        currentPlayerCol++;
                    }
                    else
                    { 
                        resultMatrix[currentPlayerRow][currentPlayerCol + 1] = 'P';
                        currentPlayerCol++;
                    }
                }

                for (int currentRow = 0; currentRow < countOfRows; currentRow++)
                {
                    for (int currentCol = 0; currentCol < countOfCols; currentCol++)
                    {
                        if (matrix[currentRow][currentCol] == 'B')
                        {
                            if (currentRow == 0)
                            {
                                if (currentCol == 0)
                                {
                                    resultMatrix[currentRow][currentCol + 1] = 'B';
                                    resultMatrix[currentRow + 1][currentCol] = 'B';
                                }
                                else if (currentCol == countOfCols - 1)
                                {
                                    resultMatrix[currentRow][currentCol - 1] = 'B';
                                    resultMatrix[currentRow + 1][currentCol] = 'B';
                                }
                                else
                                {
                                    resultMatrix[currentRow][currentCol + 1] = 'B';
                                    resultMatrix[currentRow][currentCol - 1] = 'B';
                                    resultMatrix[currentRow + 1][currentCol] = 'B';
                                }
                            }
                            else if (currentRow == countOfRows - 1)
                            {
                                if (currentCol == 0)
                                {
                                    resultMatrix[currentRow][currentCol + 1] = 'B';
                                    resultMatrix[currentRow - 1][currentCol] = 'B';
                                }
                                else if (currentCol == countOfCols - 1)
                                {
                                    resultMatrix[currentRow][currentCol - 1] = 'B';
                                    resultMatrix[currentRow - 1][currentCol] = 'B';
                                }
                                else
                                {
                                    resultMatrix[currentRow][currentCol + 1] = 'B';
                                    resultMatrix[currentRow][currentCol - 1] = 'B';
                                    resultMatrix[currentRow - 1][currentCol] = 'B';
                                }
                            }
                            else
                            {
                                if (currentCol == 0)
                                {
                                    resultMatrix[currentRow][currentCol + 1] = 'B';
                                    resultMatrix[currentRow - 1][currentCol] = 'B';
                                    resultMatrix[currentRow + 1][currentCol] = 'B';
                                }
                                else if (currentCol == countOfCols - 1)
                                {
                                    resultMatrix[currentRow][currentCol - 1] = 'B';
                                    resultMatrix[currentRow - 1][currentCol] = 'B';
                                    resultMatrix[currentRow + 1][currentCol] = 'B';
                                }
                                else
                                {
                                    resultMatrix[currentRow][currentCol + 1] = 'B';
                                    resultMatrix[currentRow][currentCol - 1] = 'B';
                                    resultMatrix[currentRow - 1][currentCol] = 'B';
                                    resultMatrix[currentRow + 1][currentCol] = 'B';
                                }
                            }
                        }
                    }
                }

                int counter = 0;

                for (int currentRow = 0; currentRow < countOfRows; currentRow++)
                {
                    StringBuilder temp = new StringBuilder();
                    if (resultMatrix[currentRow].Contains('P'))
                    {
                        counter++;
                    }

                    temp.Append(string.Join("",resultMatrix[currentRow]));

                    for (int currentCol = 0; currentCol < countOfCols; currentCol++)
                    {
                        matrix[currentRow][currentCol] = temp.ToString()[currentCol];
                    }
                }
                if ((counter == 0) && (won == false))
                {
                    dead = true;
                }

                if (won)
                {
                    break;
                }
                if (dead)
                {
                    break;
                }
            }

            if (won == true)
            {
                for (int currentRow = 0; currentRow < countOfRows; currentRow++)
                {
                    Console.WriteLine(string.Join("", resultMatrix[currentRow]));
                }
                Console.WriteLine($"won: {currentPlayerRow} {currentPlayerCol}");
            }
            else if (dead == true)
            {
                for (int currentRow = 0; currentRow < countOfRows; currentRow++)
                {
                    Console.WriteLine(string.Join("", resultMatrix[currentRow]));
                }
                Console.WriteLine($"dead: {currentPlayerRow} {currentPlayerCol}");
            }
        }
    }
}
