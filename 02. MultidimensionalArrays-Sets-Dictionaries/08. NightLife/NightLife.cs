using System;
using System.Collections.Generic;

class performanceInfo
{
    static void Main()
    {
        string input = Console.ReadLine();

        Dictionary<string, SortedDictionary<string, SortedSet<string>>> performanceInfo = new Dictionary<string, SortedDictionary<string, SortedSet<string>>>();

        while (input != "END")
        {
            string[] inputArray = input.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            string city = inputArray[0];
            string venue = inputArray[1];
            string performer = inputArray[2];

            if (!performanceInfo.ContainsKey(city)) 
            {
                SortedSet<string> performers = new SortedSet<string>();
                performers.Add(performer);

                SortedDictionary<string, SortedSet<string>> venues = new SortedDictionary<string,SortedSet<string>>();
                venues.Add(venue, performers);
                
                performanceInfo.Add(city, venues);
            }
             else if (performanceInfo.ContainsKey(city))
                {
                    if (!performanceInfo[city].ContainsKey(venue))
                    {
                        SortedSet<string> performers = new SortedSet<string>();
                        performers.Add(performer);

                        performanceInfo[city].Add(venue, performers);
                    }
                    else if (performanceInfo[city].ContainsKey(venue))
                    {
                        performanceInfo[city][venue].Add(performer);
                    }
                }

            input = Console.ReadLine();
        }

        foreach (var pair in performanceInfo)
        {
            Console.WriteLine(pair.Key);
            foreach (var pair2 in pair.Value)
            {
                Console.WriteLine("->{0}: {1}", pair2.Key, string.Join(", ", pair2.Value));
            }
        }
    }
}
