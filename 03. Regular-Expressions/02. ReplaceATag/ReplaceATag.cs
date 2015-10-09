using System;
using System.Text.RegularExpressions;

class ReplaceATag
{
    static void Main()
    {
        string html = @"<ul>
 <li>
  <a href=http://softuni.bg>SoftUni</a>
 </li>
</ul>";
        Regex pattern = new Regex(@"(?:<a\s\w+=)(.+)>(\w+)(?:<\/a>)");
        Console.WriteLine(pattern.Replace(html, @"[URL href=$1]$2[/URL]"));
    }
}
