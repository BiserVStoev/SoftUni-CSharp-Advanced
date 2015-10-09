using System;

class StringLength
{
    static void Main()
    {
        string input = Console.ReadLine().Trim();
        int stringLength = input.Length;

        if (stringLength < 20)
        {
            input += new string('*', 20 - stringLength);
        }
        else if (stringLength > 20)
        {
            input = input.Substring(0, 20);
        }

        Console.WriteLine(input);
    }
}
