using System;
using System.Collections.Generic;
using System.Linq;

class Polindromes
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(new char[] { '.', ',','?', '!', ' ' }, StringSplitOptions.RemoveEmptyEntries);

        SortedSet<string> sortedPalindromes = new SortedSet<string>();

        foreach (var word in input)
        {
            if (word == string.Join("", word.Reverse()))
            {
                sortedPalindromes.Add(word);
            }
        }

        Console.WriteLine(string.Join(", ", sortedPalindromes));
    }
}
