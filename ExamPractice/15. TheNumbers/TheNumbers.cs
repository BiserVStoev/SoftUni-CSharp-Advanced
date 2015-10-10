using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class TheNumbers
{
    static void Main()
    {
        string input = Console.ReadLine();

        MatchCollection matches = Regex.Matches(input, @"\d+");

        List<string> convertedNums = new List<string>();

        foreach (Match match in matches)
        {
            string hexNum = int.Parse(match.Value).ToString("X");

            if (hexNum.Length < 4)
            {
                string zeroes = new string('0', 4 - hexNum.Length);
                hexNum = hexNum.Insert(0, zeroes);
            }
            hexNum = hexNum.Insert(0, "0x");
            convertedNums.Add(hexNum);
        }

        Console.WriteLine(string.Join("-", convertedNums));
    }
}
