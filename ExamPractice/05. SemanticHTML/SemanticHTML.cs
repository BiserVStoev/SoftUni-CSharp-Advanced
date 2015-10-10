using System;
using System.Text;
using System.Text.RegularExpressions;

class SemanticHTML
{
    static void Main()
    {
        var row = Console.ReadLine();
        var openTagPattern = @"<div(.*)(id|class)\s*=\s*""(\w+)""(.*)>";
        var closeTagPattern = @"</div>(\s*<!--\s*(\w+)\s*-->)";

        StringBuilder text = new StringBuilder();
        while (row != "END")
        {
            if (Regex.IsMatch(row, openTagPattern))
            {
                var matches = Regex.Match(row, @"(id|class)\s*=\s*""(\w+)""");
                var tagName = matches.Groups[2].Value.Trim();
                var before = matches.Groups[0].Value.Trim();
                var result = row.Replace("div", tagName);
                result = result.Replace(before, "");
                result = result.Replace("  ", " ");
                result = result.Replace(" >", ">");

                text.AppendLine(result);


            }
            else if (Regex.IsMatch(row, closeTagPattern))
            {
                var mathes = Regex.Match(row, closeTagPattern);
                var tagname = mathes.Groups[2].Value;
                var comment = mathes.Groups[1].Value;
                var result = row.Replace(comment, "");
                result = result.Replace("div", tagname);
                text.AppendLine(result);
            }
            else
            {
                text.AppendLine(row);
            }
            row = Console.ReadLine();
        }
        Console.WriteLine(text.ToString());
    }
}
