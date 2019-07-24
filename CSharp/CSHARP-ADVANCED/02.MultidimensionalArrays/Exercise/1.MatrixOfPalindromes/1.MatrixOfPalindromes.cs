using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.MatrixOfPalindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            int[] matrixSize = Console.ReadLine()
                               .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToArray();
            int matrixRows = matrixSize[0];
            int matrixCols = matrixSize[1];
            StringBuilder element = new StringBuilder();

            string[][] palindromes = new string[matrixRows][];

            for (int currentRow = 0; currentRow < matrixRows; currentRow++)
            {
                for (int currentCol = 0; currentCol < matrixCols; currentCol++)
                {
                    element.Append(alphabet[currentRow]);
                    element.Append(alphabet[currentCol + currentRow]);
                    element.Append(alphabet[currentRow]);
                    element.Append(" ");
                }

                palindromes[currentRow] = element
                                          .ToString()
                                          .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                element.Clear();
            }

            foreach (var row in palindromes)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
