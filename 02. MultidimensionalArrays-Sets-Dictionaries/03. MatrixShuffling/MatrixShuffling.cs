using System;

class MatrixShuffling
{
    static void Main()
    {
        int firstDimension = int.Parse(Console.ReadLine());
        int secondDimension = int.Parse(Console.ReadLine());

        string[,] matrix = new string[firstDimension, secondDimension];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = Console.ReadLine();
            }
        }

        string command = Console.ReadLine();
        while (command != "END")
        {
            string[] commandArray = command.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            


            if (commandArray[0] == "swap" && commandArray.Length == 5)
            {
                int x1 = int.Parse(commandArray[1]);
                int y1 = int.Parse(commandArray[2]);
                int x2 = int.Parse(commandArray[3]);
                int y2 = int.Parse(commandArray[4]);

                if ((x1 >= 0 && x1 < commandArray.Length) &&
                    (y1 >= 0 && y1 < commandArray.Length) &&
                    (x2 >= 0 && x2 < commandArray.Length) &&
                    (y2 >= 0 && y2 < commandArray.Length))
                {
                    string temp = matrix[x1, y1];
                    matrix[x1, y1] = matrix[x2, y2];
                    matrix[x2, y2] = temp;

                    PrintCurrentMatrixState(matrix);
                }
                
            }
            else
            {
                Console.WriteLine("Invalid input!");
            }

            command = Console.ReadLine();
        }
    }

    static void PrintCurrentMatrixState(string[,] matrix) 
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
