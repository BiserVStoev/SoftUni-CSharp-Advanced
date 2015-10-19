using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class ShmoogleCounter
{
    static void Main()
    {
        string input = Console.ReadLine();

        string intPattern = @"int\s(?<int>[a-z][a-zA-Z]{0,24})";
        string doublePattern = @"double\s(?<double>[a-z][a-zA-Z]{0,24})";

        List<string> integers = new List<string>();
        List<string> doubles = new List<string>();

        Regex intMatch = new Regex(intPattern);
        Regex doubleMatch = new Regex(doublePattern);
        while (input != "//END_OF_CODE")
        {
            if (intMatch.IsMatch(input))
            {
                MatchCollection matches = intMatch.Matches(input);
                foreach (Match match in matches)
                {
                    integers.Add(match.Groups["int"].Value);
                }
            }
            else if (doubleMatch.IsMatch(input))
            {
                MatchCollection matches = doubleMatch.Matches(input);
                foreach (Match match in matches)
                {
                    doubles.Add(match.Groups["double"].Value);
                }
            }

            input = Console.ReadLine();
        }

        doubles.Sort();
        Console.Write("Doubles: ");
        if (doubles.Count != 0)
        {
            Console.WriteLine(string.Join(", ", doubles));
        }
        else
        {
            Console.WriteLine("None");
        }

        integers.Sort();

        Console.Write("Ints: ");
        if (integers.Count != 0)
        {
            Console.WriteLine(string.Join(", ", integers));
        }
        else
        {
            Console.WriteLine("None");
        }
    }
}

