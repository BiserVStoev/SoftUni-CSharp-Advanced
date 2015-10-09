using System;
using System.Text.RegularExpressions;

class SeriesOfLetters
{
    static void Main()
    {
        string input = Console.ReadLine();

        Regex regex = new Regex(@"([a-zA-Z])\1{0,}");

        MatchCollection matches = regex.Matches(input);

        string result = null;

        for (int i = 0; i < matches.Count; i++)
        {
            result += matches[i].ToString().Substring(0, 1);
        }

        Console.WriteLine(result);

    }
}

