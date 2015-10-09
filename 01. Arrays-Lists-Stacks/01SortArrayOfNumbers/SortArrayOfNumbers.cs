using System;
using System.Linq;

class SortArrayOfNumbers
{
    static void Main()
    {
        int[] numbersArr = Console.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();


        Array.Sort(numbersArr);

        Console.WriteLine(string.Join(" ", numbersArr));

        Console.WriteLine();
    }
}
