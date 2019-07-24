using System;

namespace _02.KnightGame
{
    class KnightGame
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[][] board = new char[size][];

            for (int currentRow = 0; currentRow < size; currentRow++)
            {
                string inputLine = Console.ReadLine();

                for (int currentCol = 0; currentCol < size; currentCol++)
                {
                    board[currentRow] = inputLine.ToCharArray();
                }
            }

            int maxAttackPositions = 0;
            int maxRow = 0;
            int maxCol = 0;
            int countOfRemoveKnights = 0;

            do
            {
                if (maxAttackPositions > 0)
                {
                    board[maxRow][maxCol] = '0';
                    maxAttackPositions = 0;
                    countOfRemoveKnights++;
                }

                int currentAttackPositions = 0;

                for (int currentRow = 0; currentRow < size; currentRow++)
                {
                    for (int currentCol = 0; currentCol < size; currentCol++)
                    {
                        if (board[currentRow][currentCol] == 'K')
                        {
                            currentAttackPositions = CalculateAttackPositions(currentRow, currentCol, board);

                            if (currentAttackPositions > maxAttackPositions)
                            {
                                maxAttackPositions = currentAttackPositions;
                                maxRow = currentRow;
                                maxCol = currentCol;
                            }
                        }
                    }
                }
            } while (maxAttackPositions > 0);

            Console.WriteLine(countOfRemoveKnights);
        }

        private static int CalculateAttackPositions(int currentRow, int currentCol, char[][] board)
        {
            int currentAttackedPositions = 0;

            if (IsPositionAttacked(currentRow - 2, currentCol - 1, board)) currentAttackedPositions++;
            if (IsPositionAttacked(currentRow - 2, currentCol + 1, board)) currentAttackedPositions++;
            if (IsPositionAttacked(currentRow - 1, currentCol - 2, board)) currentAttackedPositions++;
            if (IsPositionAttacked(currentRow - 1, currentCol + 2, board)) currentAttackedPositions++;
            if (IsPositionAttacked(currentRow + 2, currentCol - 1, board)) currentAttackedPositions++;
            if (IsPositionAttacked(currentRow + 2, currentCol + 1, board)) currentAttackedPositions++;
            if (IsPositionAttacked(currentRow + 1, currentCol - 2, board)) currentAttackedPositions++;
            if (IsPositionAttacked(currentRow + 1, currentCol + 2, board)) currentAttackedPositions++;

            return currentAttackedPositions;
        }

        private static bool IsPositionAttacked(int currentRow, int currentCol, char[][] board)
        {
            return isPositionOnBoard(currentRow, currentCol, board[0].Length)
                && board[currentRow][currentCol] == 'K';
        }

        private static bool isPositionOnBoard(int currentRow, int currentCol, int size)
        {
            return currentRow >= 0 && currentRow < size && currentCol >= 0 && currentCol < size;
        }
    }
}
