using System;
using System.Collections.Generic;
using System.Linq;

class CategorizeNumbersAndFindMinAndMax
{
    static void Main()
    {
        float[] numbers = Console.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries).Select(float.Parse).ToArray();

        List<float> roundNumbers = new List<float>();
        List<float> nonZeroNumbers = new List<float>();
        

        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] == Math.Round(numbers[i]))
            {
                roundNumbers.Add(numbers[i]);
            }
            else
            {
                nonZeroNumbers.Add(numbers[i]);
            }
        }
   
        Console.Write("[");
        for (int i = 0; i < nonZeroNumbers.Count; i++)
        {
            Console.Write(nonZeroNumbers[i]);
            if (i != nonZeroNumbers.Count - 1)
            {
                Console.Write(", ");
            }
        }

        Console.WriteLine("] -> min: {0}, max: {1}, sum: {2}, avg: {3:F2}", nonZeroNumbers.Min(), nonZeroNumbers.Max(), nonZeroNumbers.Sum(), nonZeroNumbers.Average());

        Console.Write("[");
        for (int i = 0; i < roundNumbers.Count; i++)
        {
            Console.Write(roundNumbers[i]);
            if (i != roundNumbers.Count - 1)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine("] -> min: {0}, max: {1}, sum: {2}, avg: {3:F2}", roundNumbers.Min(), roundNumbers.Max(), roundNumbers.Sum(), roundNumbers.Average());

        Console.WriteLine();
    }
}
