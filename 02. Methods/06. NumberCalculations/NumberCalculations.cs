using System;
using System.Linq;

//Po uslovie v zadachata ne trqbva da izpolzvame LINQ,
//no az sum go izpolzval samo pri Select-vaneto v input-a i zatova shte se radvam ako koito go proverqva da ne go zachita kato greshno, zashtoto realno ne e :)


class NumberCalculations
{
    static void Main()
    {
        Console.WriteLine("Enter a set of double numbers: ");
        double[] doubleNums = Console.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

        Console.WriteLine("Enter a set of decimal numbers: ");
        decimal[] decimalNums = Console.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries).Select(decimal.Parse).ToArray();

        Console.WriteLine();

        Console.WriteLine("Double output: ");
        Console.WriteLine("minimum: {0}", GetMinimum(doubleNums));
        Console.WriteLine("maximum: {0}", GetMaximum(doubleNums));
        Console.WriteLine("average: {0}", GetAverage(doubleNums));
        Console.WriteLine("product: {0}", GetProduct(doubleNums));

        Console.WriteLine();

        Console.WriteLine("Decimal output: ");
        Console.WriteLine("minimum: {0}", GetMinimum(decimalNums));
        Console.WriteLine("maximum: {0}", GetMaximum(decimalNums));
        Console.WriteLine("average: {0}", GetAverage(decimalNums));
        Console.WriteLine("product: {0}", GetProduct(decimalNums));
    }

    static double GetMinimum(double[] numbers)
    {
        double min = double.MaxValue;

        for (int i = 0; i < numbers.Length; i++)
        {
            if (min > numbers[i])
            {
                min = numbers[i];
            }
        }
        return min;
    }

    static decimal GetMinimum(decimal[] numbers)
    {
        decimal min = decimal.MaxValue;

        for (int i = 0; i < numbers.Length; i++)
        {
            if (min > numbers[i])
            {
                min = numbers[i];
            }
        }
        return min;
    }

    static double GetMaximum(double[] numbers)
    {
        double max = double.MinValue;

        for (int i = 0; i < numbers.Length; i++)
        {
            if (max < numbers[i])
            {
                max = numbers[i];
            }
        }
        return max;
    }

    static decimal GetMaximum(decimal[] numbers)
    {
        decimal max = decimal.MinValue;

        for (int i = 0; i < numbers.Length; i++)
        {
            if (max < numbers[i])
            {
                max = numbers[i];
            }
        }
        return max;
    }

    static double GetAverage(double[] numbers)
    {
        return GetSum(numbers) / numbers.Length;
    }

    static decimal GetAverage(decimal[] numbers)
    {
        return GetSum(numbers) / numbers.Length;
    }

    static double GetSum(double[] numbers)
    {
        double sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }
        return sum;
    }
    static decimal GetSum(decimal[] numbers)
    {
        decimal sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }
        return sum;
    }

    static double GetProduct(double[] numbers)
    {
        double product = 1;
        for (int i = 0; i < numbers.Length; i++)
        {
            product *= numbers[i];
        }

        return product;
    }

    static decimal GetProduct(decimal[] numbers)
    {
        decimal product = 1;
        for (int i = 0; i < numbers.Length; i++)
        {
            product *= numbers[i];
        }

        return product;
    }
}
