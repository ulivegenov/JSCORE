using System;


class Program
{
    private static char[][] board;
    private static int samRow;
    private static int samCol;

    public static void Main()
    {
        board = InitializeBoard();

        var command = Console.ReadLine();
        var isSamDead = false;
        var isNicDead = false;

        for (var row = 0; row < board.Length; row++)
        {
            for (var col = 0; col < board[row].Length; col++)
            {
                if (board[row][col] == 'S')
                {
                    samRow = row;
                    samCol = col;
                }
            }
        }

        while (!isSamDead && !isNicDead)
        {
            for (int i = 0; i < command.Length; i++)
            {
                var move = command[i];

                MoveEnemies();
                if (IsSamDead())
                {
                    isSamDead = true;
                    board[samRow][samCol] = 'X';
                    break;
                }

                MoveSam(move);

                if (IsNicDead())
                {
                    isNicDead = true;
                    break;
                }
            }
        }

        if (isSamDead)
        {
            Console.WriteLine($"Sam died at {samRow}, {samCol}");
            foreach (var a in board)
            {
                Console.WriteLine(string.Join("", a));
            }
        }

        if (isNicDead)
        {
            Console.WriteLine($"Nikoladze killed!");
            foreach (var a in board)
            {
                Console.WriteLine(string.Join("", a));
            }
        }
    }

    private static bool IsNicDead()
    {
        var a = board[samRow];

        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] == 'N')
            {
                board[samRow][i] = 'X';
                return true;
            }
        }

        return false;
    }

    private static bool IsSamDead()
    {
        var a = board[samRow];

        for (var i = 0; i < a.Length; i++)
        {
            if (a[i] == 'b' && i < samCol)
            {
                return true;
            }

            if (a[i] == 'd' && i > samCol)
            {
                return true;
            }
        }

        return false;
    }

    private static void MoveEnemies()
    {
        for (var row = 0; row < board.Length; row++)
        {
            for (var col = 0; col < board[row].Length; col++)
            {
                if (board[row][col] == 'b')
                {
                    if (IsEnemyAtTheEnd(row, col))
                    {
                        board[row][col] = 'd';
                        continue;
                    }

                    board[row][col] = '.';
                    board[row][col + 1] = 'b';
                    col++;
                }

                if (board[row][col] == 'd')
                {
                    if (IsEnemyAtBeggining(row, col))
                    {
                        board[row][col] = 'b';
                        continue;
                    }

                    board[row][col] = '.';
                    board[row][col - 1] = 'd';
                }
            }
        }
    }

    private static bool IsEnemyAtBeggining(int row, int col)
    {
        return col == 0;
    }

    private static bool IsEnemyAtTheEnd(int row, int col)
    {
        return col == board[row].Length - 1;
    }

    private static void MoveSam(char move)
    {
        switch (move)
        {
            case 'U':
                board[samRow][samCol] = '.';
                board[samRow - 1][samCol] = 'S';
                samRow -= 1;
                break;
            case 'D':
                board[samRow][samCol] = '.';
                board[samRow + 1][samCol] = 'S';
                samRow += 1;
                break;
            case 'L':
                board[samRow][samCol] = '.';
                board[samRow][samCol - 1] = 'S';
                samCol -= 1;
                break;
            case 'R':
                board[samRow][samCol] = '.';
                board[samRow][samCol + 1] = 'S';
                samCol += 1;
                break;
            case 'W': break;
        }
    }


    private static char[][] InitializeBoard()
    {
        var size = int.Parse(Console.ReadLine());

        var boardToReturn = new char[size][];

        for (int i = 0; i < boardToReturn.Length; i++)
        {
            boardToReturn[i] = Console.ReadLine().ToCharArray();
        }

        return boardToReturn;
    }
}

