using System;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;

public class UppercaseWords
{
    static void Main()
    {
        StringBuilder line = new StringBuilder(Console.ReadLine());
        Regex regex = new Regex(@"(?<![a-zA-Z])[A-Z]+(?![a-zA-Z])");

        while (line.ToString() != "END")
        {
            MatchCollection matches = regex.Matches(line.ToString());

            int offset = 0;
            foreach (Match match in matches)
            {
                string word = match.Value;
                string reversed = Reverse(word);

                if (reversed == word)
                {
                    reversed = DoubleEachLetter(reversed);
                }

                int index = match.Index;
                line.Remove(index + offset, word.Length);
                line.Insert(index + offset, reversed);
                offset += reversed.Length - word.Length;
            }

            Console.WriteLine(SecurityElement.Escape(line.ToString()));
            line = new StringBuilder(Console.ReadLine());
        }
    }

    private static string DoubleEachLetter(string reversed)
    {
        StringBuilder doubled = new StringBuilder();
        for (int i = 0; i < reversed.Length; i++)
        {
            doubled.Append(new string(reversed[i], 2));
        }

        return doubled.ToString();
    }

    private static string Reverse(string value)
    {
        StringBuilder reversed = new StringBuilder(value.Length);
        for (int i = value.Length - 1; i >= 0; i--)
        {
            reversed.Append(value[i]);
        }

        return reversed.ToString();
    }
}