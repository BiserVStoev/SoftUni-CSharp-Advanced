namespace _03.SoftUniNumerals
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    using System.Text.RegularExpressions;

    public class SoftUniNumerals
    {
        public static void Main()
        {
            Dictionary<string, ulong> data = new Dictionary<string, ulong>();
            data.Add("aa", 0);
            data.Add("aba", 1);
            data.Add("bcc", 2);
            data.Add("cc", 3);
            data.Add("cdc", 4);

            string input = Console.ReadLine();

            string pattern = @"(aa)|(aba)|(bcc)|(cc)|(cdc)";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);

            string numberInFifthSystem = string.Empty;
            foreach (Match match in matches)
            {
                string word = match.Value;
                numberInFifthSystem += data[word];
            }

            BigInteger result = new BigInteger();
            int degree = 0;

            for (int i = numberInFifthSystem.Length - 1; i >= 0; i--)
            {
                int currentDigit = int.Parse(numberInFifthSystem[i].ToString());
                var multiplier = BigInteger.Pow(5, degree);
                result += currentDigit*multiplier;
                degree++;
            }

            Console.WriteLine(result);
        }
    }
}