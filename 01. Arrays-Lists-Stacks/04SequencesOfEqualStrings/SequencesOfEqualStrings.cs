using System;
using System.Linq;
class SequencesOfEqualStrings
{
    static void Main()
    {

        string[] input = Console.ReadLine().Split(' ').ToArray();

        // printing sequences
        // this method works with neighbour equal strings
        Console.WriteLine("\nOutput:");
        Console.Write("{0} ", input[0]);
        for (int i = 1; i < input.Length; i++)
        {
            if (input[i] == input[i - 1])
            {
                Console.Write("{0} ", input[i]);
            }
            else
            {
                Console.Write("\n{0} ", input[i]);
            }
        }
        Console.WriteLine();
    }
}
