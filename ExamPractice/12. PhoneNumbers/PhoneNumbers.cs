using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

class PhoneNumbers
{
    static void Main()
    {
        string input = Console.ReadLine();
        string pattern = @"(?<name>[A-Z][a-zA-Z]*)[^a-zA-Z+]*?(?<number>\+*\d+[\d.() \-\/ ]*\d)";

        Regex regex = new Regex(pattern);

        Dictionary<string, string> phoneNumbers = new Dictionary<string, string>();

        StringBuilder inputOnOneLine = new StringBuilder();

        inputOnOneLine.Append(input);

        while (input != "END")
        {
            input = Console.ReadLine();
            inputOnOneLine.Append(input);
        }

        MatchCollection matches = regex.Matches(inputOnOneLine.ToString());

        foreach (Match match in matches)
        {
            phoneNumbers.Add(match.Groups["name"].Value, match.Groups["number"].Value);
        }


        if (phoneNumbers.Count == 0)
        {
            Console.WriteLine("<p>No matches!</p>");
            return;
        }

        StringBuilder sb = new StringBuilder(); ;
        sb.Append("<ol>");
        foreach (var pair in phoneNumbers)
        {
            string[] temp = pair.Value.Split(new char[] { '(', ')', '/', '.', '-', ' ' },
                    StringSplitOptions.RemoveEmptyEntries);
            string clearedPhoneNum = string.Join("", temp);
            sb.Append(string.Format("<li><b>{0}:</b> {1}</li>", pair.Key, clearedPhoneNum));
        }
        sb.Append("</ol>");
        Console.WriteLine(sb.ToString());

    }
}
