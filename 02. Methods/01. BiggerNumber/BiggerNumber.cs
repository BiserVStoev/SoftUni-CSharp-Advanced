using System;

class BiggerNumber
{
    static void Main()
    {
        int firstNum = int.Parse(Console.ReadLine());
        int secondNum = int.Parse(Console.ReadLine());

        int max = GetMax(firstNum, secondNum);
        Console.WriteLine(max);
    }

    static int GetMax(int firstNum, int secondNum) 
    {
        int max = Math.Max(firstNum, secondNum);
        return max;
    }
}
