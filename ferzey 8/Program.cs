using System;

class Program
{
    static void Main()
    {
        int[] board = new int[8];
        int count = 0;
        Solve(0, board, ref count);

        Console.WriteLine($"Найдено решений: {count}");
        Console.ReadKey();
    }

    static void Solve(int col, int[] board, ref int count)
    {
        if (col == 8)
        {
            count++;
            Print(board);
            return;
        }

        for (int row = 0; row < 8; row++)
        {
            if (IsSafe(row, col, board))
            {
                board[col] = row;
                Solve(col + 1, board, ref count);

            }
        }
    }


    static bool IsSafe(int row, int col, int[] board)
    {
        for (int c = 0; c < col; c++)
        {
            int r = board[c];

            if (r == row) return false;

            int rowDiff = Math.Abs(r - row);
            int colDiff = Math.Abs(c - col);

            if (rowDiff == colDiff) return false;
        }
        return true;
    }

    static void Print(int[] board)
    {
        Console.WriteLine("Решение:");
        for (int r = 0; r < 8; r++)
        {
            for (int c = 0; c < 8; c++)
            {
                if (board[c] == r)
                    Console.Write("Q ");
                else
                    Console.Write(". ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}