using System;
using System.Collections.Generic;
using System.Security;

public class ClearingCommands
{
    public const string CommandSymbols = "<>v^";

    public static void Main()
    {
        List<char[]> matrix = new List<char[]>();

        FillMatrix(matrix);

        TraverseMatrix(matrix);

        PrintMatrix(matrix);
    }

    private static void TraverseMatrix(List<char[]> matrix)
    {
        for (int row = 0; row < matrix.Count; row++)
        {
            for (int col = 0; col < matrix[row].Length; col++)
            {
                switch (matrix[row][col])
                {
                    case '<':
                        ClearCells(matrix, row, col - 1, 0, -1);
                        break;
                    case '>':
                        ClearCells(matrix, row, col + 1, 0, 1);
                        break;
                    case 'v':
                        ClearCells(matrix, row + 1, col, 1, 0);
                        break;
                    case '^':
                        ClearCells(matrix, row - 1, col, -1, 0);
                        break;
                }
            }
        }
    }

    private static void FillMatrix(List<char[]> matrix)
    {
        while (true)
        {
            string line = Console.ReadLine();

            if (line == "END")
            {
                break;
            }

            matrix.Add(line.ToCharArray());
        }
    }

    private static void ClearCells(List<char[]> matrix, int row, int col, int rowUpdate, int colUpdate)
    {
        while (ShouldContinueCleaning(row, col, matrix)
            && !CommandSymbols.Contains(matrix[row][col].ToString()))
        {
            matrix[row][col] = ' ';
            row += rowUpdate;
            col += colUpdate;
        }
    }

    private static bool ShouldContinueCleaning(int row, int col, List<char[]> matrix)
    {
        bool isRowValid = 0 <= row && row < matrix.Count;

        if (!isRowValid)
        {
            return false;
        }

        bool isColValid = 0 <= col && col < matrix[row].Length;

        return isColValid;
    }

    private static void PrintMatrix(List<char[]> matrix)
    {
        for (int row = 0; row < matrix.Count; row++)
        {
            Console.WriteLine("<p>{0}</p>", SecurityElement.Escape(new string(matrix[row])));
        }
    }
}
