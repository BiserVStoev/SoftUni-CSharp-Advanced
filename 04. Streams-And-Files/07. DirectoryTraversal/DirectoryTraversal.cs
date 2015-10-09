using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class DirectoryTraversal
{
    static void Main()
    {
        string[] filePaths = Directory.GetFiles("../../");

        List<FileInfo> files = filePaths.Select(path => new FileInfo(path)).ToList();

        var sortedFiles =
            files.OrderBy(file => file.Length).GroupBy(file => file.Extension).OrderByDescending(group => group.Count()).ThenBy(group => group.Key);

        string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        StreamWriter report = new StreamWriter(desktop + "/report.txt");
        using (report)
        {
            foreach (var extension in sortedFiles)
            {
                report.WriteLine(extension.Key);

                foreach (var file in extension)
                {
                    report.WriteLine("--{0} - {1:F3}kb", file.Name, file.Length / 1024.0);
                }
            }
        }

        System.Diagnostics.Process.Start(desktop + "/report.txt");
    }
}
