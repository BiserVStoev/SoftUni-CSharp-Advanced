using System;
using System.Collections.Generic;

class StuckNumbers
{
    static void Main()
    {
        var count = Console.ReadLine();
        var inputNumbers = Console.ReadLine();
        var numbersArray = inputNumbers.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var output = new List<string>();
        foreach (var a in numbersArray)
        {
            foreach (var b in numbersArray)
            {
                foreach (var c in numbersArray)
                {
                    foreach (var d in numbersArray)
                    {
                        if ((a != b) && (a != c) && (a != d) && (b != c) && (b != d) && (c != d))
                        {
                            if (a + b == c + d)
                            {
                                output.Add(string.Format("{0}|{1}=={2}|{3}", a, b, c, d));
                            }
                        }
                    }
                }
            }
        }
        if (output.Count > 0)
        {
            Console.WriteLine(string.Join("\n", output));
        }
        else
        {
            Console.WriteLine("No");
        }
    }
}