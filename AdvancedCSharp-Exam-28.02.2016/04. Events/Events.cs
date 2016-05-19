namespace _04.Events
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Events
    {
        public static void Main()
        {
            Dictionary<string, Dictionary<string, List<string>>> eventData =
                new Dictionary<string, Dictionary<string, List<string>>>();
            string pattern = @"#([A-Za-z]+):\s*@([A-Z][a-z]+)\s*(\d+)\s*:\s*(\d+)";
            int numberOfEvents = int.Parse(Console.ReadLine());

            Regex regex = new Regex(pattern);
            
            for (int i = 0; i < numberOfEvents; i++)
            {
                string input = Console.ReadLine();

                MatchCollection matches = regex.Matches(input);

                foreach (Match match in matches)
                {
                    string person = match.Groups[1].Value;
                    string location = match.Groups[2].Value;
                    int hours = int.Parse(match.Groups[3].Value);
                    int minutes = int.Parse(match.Groups[4].Value);

                    if (hours < 0 || hours > 23 || minutes < 0 || minutes > 59)
                    {
                        continue;
                    }


                    string time = match.Groups[3].Value + ":" + match.Groups[4].Value;

                    if (!eventData.ContainsKey(location))
                    {
                        eventData.Add(location, new Dictionary<string, List<string>>());
                        eventData[location].Add(person, new List<string>());
                        eventData[location][person].Add(time);
                    }
                    else if (!eventData[location].ContainsKey(person))
                    {
                        eventData[location].Add(person, new List<string>());
                        eventData[location][person].Add(time);
                    }
                    else
                    {
                        eventData[location][person].Add(time);
                    }
                }
            }

            string[] cities = Console.ReadLine().Split(',');

            var sortedByLocation = eventData.OrderBy(x => x.Key);

            foreach (var location in sortedByLocation)
            {
                if (cities.Contains(location.Key))
                {
                    Console.WriteLine(location.Key + ":");
                    int personNumber = 1;

                    var orderedPeople = location.Value.OrderBy(p => p.Key);

                    foreach (var person in orderedPeople)
                    {
                        Console.Write("{0}. {1} -> ", personNumber, person.Key);
                        var sortedTime = (person.Value as IEnumerable<string>).OrderBy(x => x);

                        StringBuilder sb = new StringBuilder();
                        foreach (var hour in sortedTime)
                        {
                            sb.Append(hour + ", ");
                        }

                        string times = sb.ToString(0, sb.Length - 2);
                        Console.WriteLine(times);

                        personNumber++;
                    }
                }
                
            }
        }
    }
}