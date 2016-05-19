namespace _04.ChampionsLeague
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ChampionsLeague
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            SortedDictionary<string, int> teamWins = new SortedDictionary<string, int>();
            Dictionary<string, List<string>> teamOpponents = new Dictionary<string, List<string>>();

            while (input != "stop")
            {
                string[] data = input.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                string firstTeam = data[0].Trim();
                string secondTeam = data[1].Trim();
                string[] firstScores = data[2].Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                string[] secondScores = data[3].Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                int firstGameFirstScore = int.Parse(firstScores[0]);
                int firstGameSecondScore = int.Parse(firstScores[1]);
                int secondGameFirstScore = int.Parse(secondScores[0]);
                int secondGameSecondScore = int.Parse(secondScores[1]);

                int firstTeamTotalScore = firstGameFirstScore + secondGameSecondScore;
                int secondTeamTotalScore = firstGameSecondScore + secondGameFirstScore;

                if (!teamWins.ContainsKey(firstTeam))
                {
                    teamWins.Add(firstTeam, 0);
                    teamOpponents.Add(firstTeam, new List<string>());
                }

                if (!teamWins.ContainsKey(secondTeam))
                {
                    teamWins.Add(secondTeam, 0);
                    teamOpponents.Add(secondTeam, new List<string>());
                }

                if (!teamOpponents[secondTeam].Contains(firstTeam))
                {
                    teamOpponents[secondTeam].Add(firstTeam);
                }

                if (!teamOpponents[firstTeam].Contains(secondTeam))
                {
                    teamOpponents[firstTeam].Add(secondTeam);
                }

                if (firstTeamTotalScore > secondTeamTotalScore)
                {
                    teamWins[firstTeam]++;
                }
                else if (firstTeamTotalScore < secondTeamTotalScore)
                {
                    teamWins[secondTeam]++;
                }
                else
                {
                    if (firstGameSecondScore > secondGameSecondScore)
                    {
                        teamWins[secondTeam]++;
                    }
                    else
                    {
                        teamWins[firstTeam]++;
                    }
                }

                input = Console.ReadLine();
            }

            var queue = teamWins.OrderByDescending(w => w.Value);

            foreach (var team in queue)
            {
                Console.WriteLine(team.Key);
                Console.WriteLine("- Wins: {0}", team.Value);
                var opponents = teamOpponents[team.Key].OrderBy(n => n);
                string opp = string.Join(", ", opponents);
                Console.WriteLine("- Opponents: {0}", opp);
            }
        }
    }
}