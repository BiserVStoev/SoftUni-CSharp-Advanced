using System;
using System.IO;

class OddLines
{
    static void Main()
    {
        StreamReader reader = new StreamReader("../../oddLinesToPrint.txt");
        using (reader)
        {
            string line = reader.ReadLine();
            while (line != null)
            {
                
                Console.WriteLine(line);
                line = reader.ReadLine();
                line = reader.ReadLine();
            }
        } 
    }
}
