namespace _03.BasicMarkupLanguage
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class BasicMarkupLanguage
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            List<string> output = new List<string>();
            int counter = 1;

            string inversePattern = @"<\s*inverse\s*content\s*=\s*""(.{0,50})""\s*\/\s*>";
            string reversePattern = @"<\s*reverse\s*content\s*=\s*""(.{0,50})""\s*\/\s*>";
            string repeatPattern = @"<\s*repeat\s*value\s*=\s*""\s*(\d{0,10})\s*""\s*content\s*=\s*""(.{0,50})""\s*\/\s*>";

            while (input != "<stop/>")
            {
                if (Regex.IsMatch(input, inversePattern))
                {
                    Regex regex = new Regex(inversePattern);
                    Match match = regex.Match(input);
                    string strToInverse = match.Groups[1].Value;
                    if (strToInverse.Length == 0)
                    {
                        input = Console.ReadLine();
                        continue;
                    }

                    string toAdd = Inverse(strToInverse);
                    output.Add(counter + ". " + toAdd);
                    counter++;
                }
                else if (Regex.IsMatch(input, reversePattern))
                {
                    Regex regex = new Regex(reversePattern);
                    Match match = regex.Match(input);
                    string strToReverse = match.Groups[1].Value;
                    if (strToReverse.Length == 0)
                    {
                        input = Console.ReadLine();
                        continue;
                    }

                    string toAdd = Reverse(strToReverse);
                    output.Add(counter + ". " + toAdd);
                    counter++; 
                }
                else if (Regex.IsMatch(input, repeatPattern))
                {
                    Regex regex = new Regex(repeatPattern);
                    Match match = regex.Match(input);
                    int repeats = int.Parse(match.Groups[1].Value);
                    string strToRepeat = match.Groups[2].Value;
                    if (strToRepeat.Length == 0)
                    {
                        input = Console.ReadLine();
                        continue;
                    }

                    for (int i = 0; i < repeats; i++)
                    {
                        string toAdd = counter + ". " + strToRepeat;
                        counter++;
                        output.Add(toAdd);
                    }  
                }

                input = Console.ReadLine();
            }

            foreach (var str in output)
            {
                Console.WriteLine(str);
            }
        }

        public static string Reverse(string text)
        {  
            char[] array = text.ToCharArray();
            Array.Reverse(array);

            return new string(array);
        }

        public static string Inverse(string text)
        {
            char[] array = text.ToCharArray();
            string inversed = string.Empty;
            foreach (var ch in array)
            {
                if (ch.ToString().ToUpper() == ch.ToString())
                {
                    inversed += ch.ToString().ToLower();
                }
                else
                {
                    inversed += ch.ToString().ToUpper();
                }
            }

            return inversed;
        }
    }
}
