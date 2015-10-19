using System;
using System.Linq;

class RadioactiveBunnies
{
    private static void Main()
    {
        int[] input = Console.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        int rows = input[0];
        int cols = input[1];

        string[,] matrix = new string[rows, cols];
        string[,] secondMatrix = new string[rows, cols];

        for (int row = 0; row < rows; row++)
        {
            string currentLine = Console.ReadLine();
            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = currentLine[col].ToString();
                secondMatrix[row, col] = currentLine[col].ToString();
            }
        }

        string commands = Console.ReadLine();

        int[] rowAndCol = GetIndexOfPlayer(matrix);
        int playerRow = rowAndCol[0];
        int playerCol = rowAndCol[1];

        int rowEndgame = 0;
        int colEndGame = 0;

        for (int i = 0; i < commands.Length; i++)
        {
            bool endGameDead = false;
            bool endGameWin = false;

            int rowMove = 0;
            int colMove = 0;

            switch (commands[i])
            {
                case 'R':

                    colMove = 1;
                    endGameDead = PlayerMovementDead(secondMatrix, playerRow, playerCol, rowMove, colMove, matrix);
                    if (endGameDead == false)
                    {
                        endGameWin = PlayerMovementWin(secondMatrix, playerRow, playerCol, rowMove, colMove);
                    }
                    else
                    {
                        playerCol += 1;
                    }

                    if (endGameDead == false && endGameWin == false)
                    {
                        PlayerAdvance(secondMatrix, playerRow, playerCol, rowMove, colMove);
                        playerCol += 1;
                    }

                    break;
                case 'L':

                    colMove = -1;
                    endGameDead = PlayerMovementDead(secondMatrix, playerRow, playerCol, rowMove, colMove, matrix);
                    if (endGameDead == false)
                    {
                        endGameWin = PlayerMovementWin(secondMatrix, playerRow, playerCol, rowMove, colMove);
                        if (!endGameWin)
                        {
                            PlayerAdvance(secondMatrix, playerRow, playerCol, rowMove, colMove);
                            playerCol -= 1;
                        }
                    }
                    else
                    {
                        playerCol -= 1;
                    }

                    break;
                case 'D':

                    rowMove = 1;
                    endGameDead = PlayerMovementDead(secondMatrix, playerRow, playerCol, rowMove, colMove, matrix);
                    if (endGameDead == false)
                    {
                        endGameWin = PlayerMovementWin(secondMatrix, playerRow, playerCol, rowMove, colMove);
                    }
                    else
                    {
                        playerRow += 1;
                    }

                    if (endGameDead == false && endGameWin == false)
                    {
                        PlayerAdvance(secondMatrix, playerRow, playerCol, rowMove, colMove);
                        playerRow += 1;
                    }

                    break;
                case 'U':

                    rowMove = -1;
                    endGameDead = PlayerMovementDead(secondMatrix, playerRow, playerCol, rowMove, colMove, matrix);
                    if (endGameDead == false)
                    {
                        endGameWin = PlayerMovementWin(secondMatrix, playerRow, playerCol, rowMove, colMove);
                    }
                    else
                    {
                        playerRow -= 1;
                    }

                    if (endGameDead == false && endGameWin == false)
                    {
                        PlayerAdvance(secondMatrix, playerRow, playerCol, rowMove, colMove);
                        playerRow -= 1;
                    }

                    break;
            }

            for (int row = 0; row < secondMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < secondMatrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == "B")
                    {
                        if (row - 1 >= 0)
                        {
                            if (secondMatrix[row - 1, col] == "P")
                            {
                                if (!endGameWin)
                                {
                                    rowEndgame = row - 1;
                                    colEndGame = col;
                                    endGameDead = true;
                                }
                            }
                            secondMatrix[row - 1, col] = "B";
                        }
                        if (col + 1 < secondMatrix.GetLength(1))
                        {
                            if (secondMatrix[row, col + 1] == "P")
                            {
                                if (!endGameWin)
                                {
                                    rowEndgame = row;
                                    colEndGame = col + 1;
                                    endGameDead = true;
                                }

                            }
                            secondMatrix[row, col + 1] = "B";
                        }
                        if (col - 1 >= 0)
                        {
                            if (secondMatrix[row, col - 1] == "P")
                            {
                                if (!endGameWin)
                                {
                                    rowEndgame = row;
                                    colEndGame = col - 1;
                                    endGameDead = true;
                                }

                            }
                            secondMatrix[row, col - 1] = "B";
                        }
                        if (row + 1 < secondMatrix.GetLength(0))
                        {
                            if (secondMatrix[row + 1, col] == "P")
                            {
                                if (!endGameWin)
                                {
                                    rowEndgame = row + 1;
                                    colEndGame = col;
                                    endGameDead = true;
                                }

                            }
                            secondMatrix[row + 1, col] = "B";
                        }
                    }
                }
            }

            MakeFirstMatrixToEqualSecond(secondMatrix, matrix);

            if (endGameWin || endGameDead)
            {
                PrintMatrix(secondMatrix);
                if (endGameWin)
                {
                    rowEndgame = playerRow;
                    colEndGame = playerCol;
                    Console.WriteLine("won: {0} {1}", rowEndgame, colEndGame);
                }
                else if (endGameDead)
                {
                    rowEndgame = playerRow;
                    colEndGame = playerCol;
                    Console.WriteLine("dead: {0} {1}", rowEndgame, colEndGame);
                }
                return;
            }
        }

    }

    private static void MakeFirstMatrixToEqualSecond(string[,] secondMatrix, string[,] matrix)
    {
        for (int row = 0; row < secondMatrix.GetLength(0); row++)
        {
            for (int col = 0; col < secondMatrix.GetLength(1); col++)
            {
                matrix[row, col] = secondMatrix[row, col];
            }
        }
    }

    private static int[] GetIndexOfPlayer(string[,] matrix)
    {
        int[] empty = new int[2];
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] == "P")
                {
                    int[] rowAndCol = { row, col };
                    return rowAndCol;
                }
            }
        }
        return empty;
    }

    private static void PlayerAdvance(string[,] secondMatrix, int playerRow, int playerCol, int rowMove, int colMove)
    {
        secondMatrix[playerRow, playerCol] = ".";
        secondMatrix[playerRow + rowMove, playerCol + colMove] = "P";
    }

    private static bool PlayerMovementDead(string[,] secondMatrix, int playerRow, int playerCol, int rowMove, int colMove, string[,] matrix)
    {
        bool endGameDead = false;
        if (playerRow + rowMove < secondMatrix.GetLength(0) && playerRow + rowMove >= 0 && playerCol + colMove < secondMatrix.GetLength(1) && playerCol + colMove >= 0)
        {
            if (secondMatrix[playerRow + rowMove, playerCol + colMove] == "B")
            {
                secondMatrix[playerRow, playerCol] = ".";
                matrix[playerRow, playerCol] = ".";
                endGameDead = true;
            }
        }

        return endGameDead;
    }

    private static bool PlayerMovementWin(string[,] secondMatrix, int playerRow, int playerCol, int rowMove, int colMove)
    {
        bool endGameWin = (playerRow + rowMove) >= secondMatrix.GetLength(0) || (playerRow + rowMove) < 0 || (playerCol + colMove) >= secondMatrix.GetLength(1) || (playerCol + colMove) < 0;

        if (endGameWin)
        {
            secondMatrix[playerRow, playerCol] = ".";
        }

        return endGameWin;
    }

    private static void PrintMatrix(string[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row, col]);
            }
            Console.WriteLine();
        }
    }
}

