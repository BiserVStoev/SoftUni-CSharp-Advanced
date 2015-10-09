using System;
using System.Linq;


class SortArrayOfnumbersArrUsingSelectionSort
{
    static void Main()
    {
        int[] numbersArr = Console.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        int index = 0;

        for (int i = 0; i < numbersArr.Length; i++)
        {
            int minValue = numbersArr[i];
            for (int j = i + 1; j < numbersArr.Length; j++)
            {
                if (numbersArr[j] < minValue)
                {
                    minValue = numbersArr[j];
                    index = j;
                }
            }

            if (minValue < numbersArr[i])
            {
                int temp = numbersArr[i];
                numbersArr[i] = minValue;
                numbersArr[index] = temp;
            }
        }

        Console.WriteLine(string.Join(" ", numbersArr));
    }
}
