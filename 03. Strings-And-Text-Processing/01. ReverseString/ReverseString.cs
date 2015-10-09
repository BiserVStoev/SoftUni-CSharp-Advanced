using System;
using System.Linq;

class ReverseString
{
    static void Main()
    {
        string input = Console.ReadLine();
        Console.WriteLine(string.Join("", input.Reverse()));
    }
}
