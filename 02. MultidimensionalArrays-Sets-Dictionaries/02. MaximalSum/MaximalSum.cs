using System;
using System.Linq;

class MaximalSum
{
    static void Main()
    {
        int[] input = Console.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        int rows = input[0];
        int cols = input[1];

        int[,] matrix = new int[rows, cols];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            input = Console.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = input[col];
            }
        }

        int maxSum = int.MinValue;
        int rowIndex = 0;
        int colIndex = 0;
        for (int row = 0; row < matrix.GetLength(0) - 2; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 2; col++)
            {
                int currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
                    + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
                    + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    rowIndex = row;
                    colIndex = col;
                }
            }
        }
        Console.WriteLine();
        Console.WriteLine("Sum = {0}", maxSum);

        for (int row = rowIndex; row < rowIndex + 3; row++)
        {
            for (int col = colIndex; col < colIndex + 3; col++)
            {
                Console.Write("{0} ", matrix[row, col]);
            }
            Console.WriteLine();
        }
    }
}
