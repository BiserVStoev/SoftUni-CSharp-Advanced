using System;

class FillThematrixOne
{
    static void Main()
    {
        int input = int.Parse(Console.ReadLine());

        int[,] matrixOne = new int [input, input];
        int[,] matrixTwo = new int [input, input];
        int number = 1;

        for (int row = 0; row < matrixOne.GetLength(0); row++)
        {
            for (int col = 0; col < matrixOne.GetLength(1); col++)
            {
                matrixOne[col, row] = number;
                number++;
            }
        }

        number = 1;

        for (int row = 0; row < matrixTwo.GetLength(0); row++)
        {
            if (row % 2 == 0)
            {
                for (int col = 0; col < matrixTwo.GetLength(1); col++)
                {
                    matrixTwo[col, row] = number;
                    number++;
                }
                
            }
            else
            {
                for (int col = matrixTwo.GetLength(1) - 1; col >= 0; col--)
                {
                    matrixTwo[col, row] = number;
                    number++;
                }
            }
        }

        Console.WriteLine();

        PrintMatrix(matrixOne);
        Console.WriteLine();
        PrintMatrix(matrixTwo);
    }

    static void PrintMatrix(int[,] matrix) 
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write("{0} ", matrix[row, col]);
            }
            Console.WriteLine();
        }
    }
}
