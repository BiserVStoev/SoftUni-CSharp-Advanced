using System;
using System.Collections.Generic;
using System.Linq;
class CountSymbols
{
    static void Main()
    {
        string input = Console.ReadLine();

        List<char> charList = new List<char>();

        SortedDictionary<char, int> characters = new SortedDictionary<char, int>();

        for (int i = 0; i < input.Length; i++)
        {
            if (!characters.ContainsKey(input[i]))
            {
                characters.Add(input[i], input.Count(x => x == input[i]));
            }
        }

        foreach (var pair in characters)
        {
            Console.WriteLine("{0}: {1} time/s", pair.Key, pair.Value);
        }
       
    }
}
