using System;
using System.IO;

class CopyBinaryFile
{
    static void Main()
    {
        using (var originalPic = new FileStream("../../datPic.jpg", FileMode.Open))
        {
            using (var copiedPic = new FileStream("../../copiedPic.jpg", FileMode.Create))
            {
                byte[] buffer = new byte[4096];
                while (true)
                {
                    int readBytes = originalPic.Read(buffer, 0, buffer.Length);
                    if (readBytes == 0)
                    {
                        break;
                    }
                    copiedPic.Write(buffer, 0, readBytes);
                }
            }
        }
    }
}
