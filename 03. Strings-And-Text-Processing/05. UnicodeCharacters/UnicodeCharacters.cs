using System;
using System.Text;

class UnicodeCharacters
{
    static void Main()
    {
        string input = Console.ReadLine().Trim();

        StringBuilder unicodeChars = new StringBuilder();
        foreach (var symbol in input)
        {
            unicodeChars.Append("\\u");
            unicodeChars.Append(String.Format("{0:x4}", (int)symbol));
        }

        Console.WriteLine(unicodeChars.ToString());
    }
}
