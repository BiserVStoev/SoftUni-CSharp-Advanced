using System;

class CountSubstringOccurences
{
    static void Main()
    {
        string input = Console.ReadLine().ToLower();
        string subString = Console.ReadLine().ToLower();

        int poss = input.IndexOf(subString);
        int counter = 0;
        while (poss >= 0 && poss <= input.Length)
        {
            counter++;
            poss = input.IndexOf(subString, poss + 1);

        }
        Console.WriteLine(counter);
    }
}
