using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

internal class SrubskoUnleashed
{
    private static void Main()
    {
        string input = Console.ReadLine();
        Dictionary<string, Dictionary<string, int>> venueData = new Dictionary<string, Dictionary<string, int>>();

        while (input != "End")
        {

            string checkPattern = @"(.+)\s@(.+)\s(\d+)\s(\d+)";
            if (Regex.IsMatch(input, checkPattern))
            {
                string[] firstDivision = input.Split('@');
                string name = firstDivision[0].TrimEnd();

                string splitSecond = firstDivision[1];
                string pattern = @"(.+)\s(\d+)\s(\d+)";
                Regex rgx = new Regex(pattern);
                MatchCollection matches = rgx.Matches(splitSecond);
                string venue = "";
                int ticketPrice = 0;
                int ticketCount = 0;
                foreach (Match match in matches)
                {
                    venue = match.Groups[1].Value;
                    ticketPrice = int.Parse(match.Groups[2].Value);
                    ticketCount = int.Parse(match.Groups[3].Value);
                }

                int totalMoney = ticketCount * ticketPrice;
                if (venueData.ContainsKey(venue))
                {
                    if (venueData[venue].ContainsKey(name))
                    {

                        venueData[venue][name] += totalMoney;
                    }
                    else
                    {
                        venueData[venue].Add(name, totalMoney);

                    }
                }
                else
                {
                    Dictionary<string, int> currentValue = new Dictionary<string, int>();
                    currentValue.Add(name, totalMoney);
                    venueData.Add(venue, currentValue);
                }
            }
            input = Console.ReadLine();
        }

        foreach (var entrydata in venueData)
        {
            Console.WriteLine(entrydata.Key);
            var orderedData = entrydata.Value.OrderByDescending(key => key.Value);

            foreach (var singer in orderedData)
            {
                Console.WriteLine("#  {0} -> {1}", singer.Key, singer.Value);
            }
        }
    }
}




