using System;
using System.Linq;
using System.Collections.Generic;

class SubsetSums
{

    static int number;
    static int[] intArr;
    static bool hasSubSets = false;
    static void Main()
    {
        number = int.Parse(Console.ReadLine());
        intArr = Console.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Distinct().ToArray();

        List<int> subset = new List<int>();

        MakeSubset(0, subset);
        if (hasSubSets == false)
        {
            Console.WriteLine("No matching subsets.");
        }

    }

    static void MakeSubset(int index, List<int> subset)
    {
        if (subset.Sum() == number && subset.Count > 0)
        {
            Console.WriteLine(" {0} = {1}", string.Join(" + ", subset), number);
            hasSubSets = true;
        }

        for (int i = index; i < intArr.Length; i++)
        {
            subset.Add(intArr[i]);
            MakeSubset(i + 1, subset);
            subset.RemoveAt(subset.Count - 1);
        }
    }

    private static void PrintSubset(List<int> subset)
    {
        Console.WriteLine(" {0} = {1}", string.Join(" + ", subset), number);
    }


}