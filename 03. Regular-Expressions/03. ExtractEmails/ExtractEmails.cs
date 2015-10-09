using System;
using System.IO;
using System.Text.RegularExpressions;

class ExtractEmails
{
    static void Main()
    {
        string text = Console.ReadLine();

        string pattern = @"((?<=\s|^)([a-z0-9]+(?:[_.-][a-z0-9]+)*@(?:[a-z]+\-?[a-z]+\.)+[a-z]+\-?[a-z]+)\b)";
        Regex rgx = new Regex(pattern);
        MatchCollection matches = rgx.Matches(text);

        using (StreamWriter URL = new StreamWriter(@"..\..\emails.html"))
        {
            foreach (Match email in matches)
            {
                URL.WriteLine(email.Groups[1]);
            }
        }
        Console.WriteLine();
        Console.WriteLine(File.ReadAllText(@"..\..\emails.html"));


    }
}
