using System;

class SequenceInMatrix
{
    static int maxLength;
    static string element;

    static void Main()
    {
        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());
        string[,] matrix = new string[rows, cols];

        Console.WriteLine("Input rows and cols each on a seperate line");

        for (int i = 0; i < rows; i++)
        {
            string[] input = Console.ReadLine().Split();
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = input[j];
            }
        }
        maxLength = 1;
        element = matrix[0, 0];
        FindLongestSequence(matrix);
        Print();

    }
    static void FindLongestSequence(string[,] matrix)
    {
        //no need to search the entire matrix only searching the 3 outer sides is enough (left, top/bot,right sides)
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            CheckDirections(matrix, 0, col);
        }
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            CheckDirections(matrix, row, 0);
            CheckDirections(matrix, row, matrix.GetUpperBound(1));
        }

    }
    static void CheckDirections(string[,] matrix, int row, int col)
    {
        int rChange = 0;
        int cChange = 0;
        for (int i = 0; i < 4; i++) //directions 0 = right, 1 = rigthDownDiagonal, 2 = down, 3 = leftDownDiagonal
        {
            string start = matrix[row, col];
            int length = 1;
            switch (i)
            {
                case 0: rChange = 0; cChange = 1; break;
                case 1: rChange = 1; cChange = 1; break;
                case 2: rChange = 1; cChange = 0; break;
                case 3: rChange = 1; cChange = -1; break;
            }
            int tempRow = row;
            int tempCol = col;
            while (true)
            {
                tempRow += rChange;
                tempCol += cChange;
                if (tempRow < 0 || tempRow > matrix.GetUpperBound(0) || tempCol < 0 || tempCol > matrix.GetUpperBound(1))
                {
                    break;
                }
                string currentElement = matrix[tempRow, tempCol];
                if (currentElement.Equals(start))
                {
                    length++;
                }
                else
                {
                    length = 1;
                    start = currentElement;
                }
                if (length > maxLength)
                {
                    maxLength = length;
                    element = start;
                }
            }


        }
    }
    static void Print()
    {
        for (int i = 0; i < maxLength; i++)
        {
            if (i == maxLength - 1)
            {
                Console.WriteLine(element);
            }
            else
            {
                Console.Write(element + ", ");
            }
        }
    }
}
