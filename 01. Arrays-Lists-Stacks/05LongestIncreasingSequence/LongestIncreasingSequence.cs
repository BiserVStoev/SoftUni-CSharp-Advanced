using System;
using System.Linq;

class LongestIncreasingSequence
{
    static void Main()
    {
        int[] numbers = Console.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        int counter = 1;
        int maxLengthCounter = 1;
        int end = 0;

        Console.Write(numbers[0] + " ");
        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] > numbers[i - 1])
            {
                counter++;
                Console.Write(numbers[i] + " ");
            }
            else
            {
                counter = 1;
                Console.WriteLine();
                Console.Write(numbers[i] + " ");
            }
            if (counter > maxLengthCounter)
            {
                maxLengthCounter = counter;
                end = i;
            }
        }
        Console.WriteLine();
        Console.Write("Longest: ");
        for (int i = end - maxLengthCounter + 1; i <= end ; i++)
        {
            Console.Write(numbers[i]);
            if (i != end - 2)
            {
                Console.Write(" ");
            }
        }
        Console.WriteLine();
    }
}
