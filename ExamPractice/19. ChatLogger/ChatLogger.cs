using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security;
using System.Text.RegularExpressions;
using System.Threading;

class ChatLogger
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");
        DateTime currentDateTime = DateTime.Parse(Console.ReadLine());

        SortedDictionary<DateTime, string> text = new SortedDictionary<DateTime, string>();
        var input = Console.ReadLine();
        while (input != "END")
        {
            string pattern = @"(.+)(\s\/\s)(\d{2}-\d{2}-\d{4}\s\d{2}:\d{2}:\d{2})";
            Regex rgx = new Regex(pattern);
            MatchCollection matches = rgx.Matches(input);

            string firstGroup = "";
            DateTime thisDateTime = DateTime.MinValue;
            foreach (Match match in matches)
            {
                firstGroup = match.Groups[1].Value;
                thisDateTime = DateTime.Parse(match.Groups[3].Value);
            }

            text.Add(thisDateTime, firstGroup);
            input = Console.ReadLine();
        }

        string timestamp = "";
        DateTime mostRecentDate = text.Last().Key;

        if ((currentDateTime - mostRecentDate).TotalHours < 1 && (currentDateTime - mostRecentDate).TotalMinutes >= 1 )
        {
            string minutes = (int)(currentDateTime - mostRecentDate).TotalMinutes + " " + "minute(s) ago";
            timestamp = minutes;
        }
        else if ((currentDateTime.Day == mostRecentDate.Day) && (currentDateTime - mostRecentDate).TotalHours >= 1)
        {
            string hour = (int)(currentDateTime - mostRecentDate).TotalHours + " " + "hour(s) ago";
            timestamp = hour;
        }
        else if (mostRecentDate.Day == currentDateTime.Day - 1)
        {
            timestamp = "yesterday";
        }
        else if ((currentDateTime - mostRecentDate).TotalDays > 1)
        {
            timestamp = mostRecentDate.ToString("dd-MM-yyyy");

        }
        else
        {
            timestamp = "a few moments ago";
        }
        foreach (var sentence in text)
        {
            Console.WriteLine("<div>{0}</div>", SecurityElement.Escape(sentence.Value));
        }

        Console.WriteLine("<p>Last active: <time>{0}</time></p>", timestamp);
    }
}
