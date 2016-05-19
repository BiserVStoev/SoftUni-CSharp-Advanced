namespace _02.Monopoly
{
    using System;
    using System.Linq;

    public class Monopoly
    {
        public static void Main()
        {
            int[] dimensons = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[,] board = new char[dimensons[0], dimensons[1]];

            for (int i = 0; i < dimensons[0]; i++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();
                for (int j = 0; j < currentRow.Length; j++)
                {
                    board[i, j] = currentRow[j];
                }
            }

            int money = 50;
            int hotels = 0;
            int turns = 0;
            for (int row = 0; row < board.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < board.GetLength(1); col++)
                    {
                        CompleteCurrentTurn(ref turns, board, row, col, ref money, ref hotels);
                    }
                }
                else
                {
                    for (int col = board.GetLength(1) - 1; col >= 0; col--)
                    {
                        CompleteCurrentTurn(ref turns, board, row, col, ref money, ref hotels);
                    }
                }
            }

            Console.WriteLine("Turns {0}", turns);
            Console.WriteLine("Money {0}", money);
        }

        private static void CompleteCurrentTurn(ref int turns, char[,] board, int row, int col, ref int money, ref int hotels)
        {
            turns++;

            if (board[row, col] == 'H')
            {
                hotels++;
                Console.WriteLine("Bought a hotel for {0}. Total hotels: {1}.", money, hotels);
                money = 0;
            }
            else if (board[row, col] == 'J')
            {
                Console.WriteLine("Gone to jail at turn {0}.", turns - 1);
                turns += 2;
                money += 20 * hotels;
            }
            else if (board[row, col] == 'S')
            {
                int moneyToSpend = (row + 1) * (col + 1);
                if (money == 0)
                {
                    moneyToSpend = 0;
                }
                else if (moneyToSpend > money)
                {
                    moneyToSpend = money;
                }

                Console.WriteLine("Spent {0} money at the shop.", moneyToSpend);
                money -= moneyToSpend;
            }

            money += 10 * hotels;
        }
    }
}