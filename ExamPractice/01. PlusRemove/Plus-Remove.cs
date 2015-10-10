using System;
using System.Collections.Generic;

class PlusRemove
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
            var maxLength = Math.Min(inputMatrix[row].Length, Math.Min(inputMatrix[row + 1].Length - 1, inputMatrix[row + 2].Length));
            for (int col = 1; col < maxLength; col++)
            {
                var first = inputMatrix[row][col].ToString().ToLower();
                var second = inputMatrix[row + 1][col - 1].ToString().ToLower();
                var third = inputMatrix[row + 1][col].ToString().ToLower();
                var fourth = inputMatrix[row + 1][col + 1].ToString().ToLower();
                var fifth = inputMatrix[row + 2][col].ToString().ToLower();
                if ((first == second) && (second == third) && (third == fourth) && (fourth == fifth))
                {
                    outputMatrix[row][col] = '\0';
                    outputMatrix[row + 1][col - 1] = '\0';
                    outputMatrix[row + 1][col] = '\0';
                    outputMatrix[row + 1][col + 1] = '\0';
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
