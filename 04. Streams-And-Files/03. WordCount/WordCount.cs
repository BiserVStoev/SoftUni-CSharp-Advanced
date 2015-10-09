using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class WordCount
{
    static void Main()
    {
        StreamReader readerText = new StreamReader("../../Text.txt");
        StreamReader readerWords = new StreamReader("../../words.txt");
        StreamWriter writer = new StreamWriter("../../result.txt");

        List<string> words = new List<string>();
        SortedDictionary<string, int> result = new SortedDictionary<string, int>();


        using (readerText)
        {
            using (readerWords)
            {
                words = WordsToMatch(readerWords);
                string line = readerText.ReadToEnd();

                for (int i = 0; i < words.Count; i++)
                {
                    string pattern = String.Format(@"\b{0}\b", words[i]);
                    Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
                    int numberOfTimesTheWordIsMatched = 0;
                    MatchCollection matches = regex.Matches(line);
                    foreach (var match in matches)
                    {
                        numberOfTimesTheWordIsMatched++;
                    }

                    result.Add(words[i], numberOfTimesTheWordIsMatched);
                }

            }
        }

        using (writer)
        {
            foreach (var item in result.OrderByDescending(key => key.Value))
            {
                writer.WriteLine("{0} - {1}", item.Key, item.Value);
            }

        }
    }
    private static List<string> WordsToMatch(StreamReader readerWords)
    {
        List<string> words = new List<string>();
        string lineOfWords = readerWords.ReadLine();
        while (lineOfWords != null) 
        {
            string[] word = lineOfWords.Split(' ');
            for (int i = 0; i < word.Length; i++)
            {
                words.Add(word[i]);
            }
            lineOfWords = readerWords.ReadLine();
        }
        return words;
    }

}
