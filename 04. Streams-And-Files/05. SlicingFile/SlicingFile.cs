using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

class SlicingFile
{
    static List<string> slicedFiles = new List<string>();
    static string ext;
    static void Main()
    {
        Console.Write("Ënter the number of parts you wan the file to be split: ");
        int parts = int.Parse(Console.ReadLine());

        string file = "text.txt";
        string directory = "../../";

        Slice(file, directory, parts);
        Console.WriteLine("Slicing done.");
        Assemble(slicedFiles, directory);
        Console.WriteLine("Assembling done.");
    }

    static void Slice(string sourceFile, string destinationDirectory, int parts)
    {
        string extension = new FileInfo(sourceFile).Extension;
        ext = extension;

        using (var source = new FileStream(destinationDirectory + sourceFile, FileMode.Open))
        {
            int pieceSize = (int)Math.Ceiling((decimal)source.Length / parts);
            byte[] buffer = new byte[4096];

            for (int i = 1; i <= parts; i++)
            {

                string currentFilePath = string.Format(destinationDirectory + "part" + i + extension);
                using (var destination =
                    new FileStream(currentFilePath, FileMode.Create))
                {

                    long partBytes = 0;
                    while (partBytes < pieceSize)
                    {
                        int readBytes = source.Read(buffer, 0, buffer.Length);
                        if (readBytes == 0)
                        {
                            break;;
                        }  
                        destination.Write(buffer, 0, readBytes);
                        partBytes += readBytes;
                    }
                }
                slicedFiles.Add(currentFilePath);
            }
        }
     }

    static void Assemble(List<string> files, string destinationDirectory)
    {
        foreach (var file in files)
        {
            using (var reader = new FileStream(file, FileMode.Open))
            {
                using (var writer = new FileStream(("../../assembled" + ext), FileMode.Append))
                {
                    byte[] buffer = new byte[4096];
                    while (true)
                    {
                        int readBytes = reader.Read(buffer, 0, buffer.Length);
                        if (readBytes == 0)
                            break;

                        writer.Write(buffer, 0, readBytes);
                    }
                }
            }
        }
    }
}
