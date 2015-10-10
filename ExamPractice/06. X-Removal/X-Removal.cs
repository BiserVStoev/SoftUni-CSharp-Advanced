using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        List<char[]> inputMatrix = new List<char[]>();
        var inputRow = Console.ReadLine();
        var outputMatrix = new List<char[]>();
        while (inputRow != "END")
        {
            var charArray = inputRow.ToCharArray();
            outputMatrix.Add(charArray);
            var lowerChars = inputRow.ToLower().ToCharArray();
            inputMatrix.Add(lowerChars);
            inputRow = Console.ReadLine();
        }
        for (int row = 0; row < inputMatrix.Count - 2; row++)
        {
            var maxLength = Math.Min(inputMatrix[row].Length - 2, Math.Min(inputMatrix[row + 1].Length - 1, inputMatrix[row + 2].Length - 2));
            for (int col = 0; col < maxLength; col++)
            {
                var first = inputMatrix[row][col];
                var second = inputMatrix[row][col + 2];
                var third = inputMatrix[row + 1][col + 1];
                var fourth = inputMatrix[row + 2][col];
                var fifth = inputMatrix[row + 2][col + 2];
                if ((first == second) && (second == third) && (third == fourth) && (fourth == fifth))
                {
                    outputMatrix[row][col] = '\0';
                    outputMatrix[row][col + 2] = '\0';
                    outputMatrix[row + 1][col + 1] = '\0';
                    outputMatrix[row + 2][col + 2] = '\0';
                    outputMatrix[row + 2][col] = '\0';
                }

            }

        }
        foreach (var result in outputMatrix)
        {
            foreach (var ch in result)
            {
                if (ch != '\0')
                {
                    Console.Write(ch);
                }
            }
            Console.WriteLine();
        }
    }
}
