using System;

class LargerThanNeighbours
{
    static void Main()
    {
        int[] numbers = { 1, 3, 4, 5, 1, 0, 5 };

        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine(IsLargerThanNeighbours(numbers, i));
        }
    }

    static bool IsLargerThanNeighbours(int[] numbers, int i)
    {
        bool isLarger = false;

        if (i == 0)
        {
            isLarger = numbers[i] > numbers[i + 1];
        }
        else if (i == numbers.Length - 1)
        {
            isLarger = numbers[i] > numbers[i - 1];
        }
        else
        {
            isLarger = numbers[i] > numbers[i - 1] && numbers[i + 1] < numbers[i];
        }

        return isLarger;
    }
}
