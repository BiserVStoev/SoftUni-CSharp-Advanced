using System;
using System.Linq;

class ReverseNumber
{
    static void Main()
    {
        double input = double.Parse(Console.ReadLine());

        double reversed = GetReversedNumber(input);

        Console.WriteLine(reversed);
    }

    static double GetReversedNumber(double number)
    {
        bool isNegative = number < 0;
        string input = string.Join("", number.ToString().TrimStart('-').Reverse());
        double result = double.Parse(input);
        return isNegative ? -result : result;
    }
}
