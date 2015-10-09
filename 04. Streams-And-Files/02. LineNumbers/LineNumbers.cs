using System;
using System.IO;
class LineNumbers
{
    static void Main()
    {
        StreamReader fileToRead = new StreamReader("../../fileToReadFrom.txt");
        StreamWriter fileToWrite = new StreamWriter("../../fileToWriteOn.txt");

        using (fileToRead)
        {
            string line = fileToRead.ReadLine();
            int lineNum = 1;
            using (fileToWrite)
            {
                while (line != null)
                {
                    fileToWrite.WriteLine("{0,4} {1}",lineNum, line);
                    lineNum++;
                    line = fileToRead.ReadLine();
                }
                
            }
        }

    }
}
