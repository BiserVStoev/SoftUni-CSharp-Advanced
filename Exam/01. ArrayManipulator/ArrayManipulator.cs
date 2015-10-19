using System;
using System.Collections.Generic;
using System.Linq;

class ArrayManipulator
{
    static void Main()
    {
        int[] intArray = Console.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        while (true)
        {
            string input = Console.ReadLine();

            if (input == "end")
            {
                break;
            }

            string[] command = input.Split();

            switch (command[0])
            {
                case "exchange":

                    if (int.Parse(command[1]) > intArray.Length - 1 || int.Parse(command[1]) < 0)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        intArray = Exchange(intArray, int.Parse(command[1]));
                    }

                    break;
                case "max":
                    Max(intArray, command[1]);
                    break;
                case "min":
                    Min(intArray, command[1]);
                    break;
                case "first":
                    if (int.Parse(command[1]) > intArray.Length)
                    {
                        Console.WriteLine("Invalid count");
                    }
                    else
                    {
                        PrintFirstElements(intArray, int.Parse(command[1]), command[2]);
                    }
                  
                    break;
                case "last":
                    if (int.Parse(command[1]) > intArray.Length)
                    {
                        Console.WriteLine("Invalid count");
                    }
                    else
                    {
                        PrintLastElements(intArray, int.Parse(command[1]), command[2]);
                    }
                    break;
            }
        }
        Console.Write("[");
        Console.Write(string.Join(", ", intArray));
        Console.WriteLine("]");
    }

    static void PrintFirstElements(int[] intArray, int count, string numType)
    {
        int oddOrEven = 0;

        if (numType == "odd")
        {
            oddOrEven = 1;
        }

        int counter = 0;
        List<int> nums = new List<int>();
        Console.Write("[");
        for (int i = 0; i < intArray.Length; i++)
        {
            int currentValue = intArray[i];
            if (currentValue % 2 == oddOrEven)
            {

                nums.Add(intArray[i]);
                counter++;

            }
            if (counter == count)
            {
                break;
            }
        }
        Console.Write(string.Join(", ", nums));
        Console.WriteLine("]");
    }
    static void PrintLastElements(int[] intArray, int count, string numType)
    {
        int oddOrEven = 0;

        if (numType == "odd")
        {
            oddOrEven = 1;
        }

        int counter = 0;
        List<int> nums = new List<int>();
        Console.Write("[");
 
        for (int i = intArray.Length - 1; i >= 0; i--)
        {
            int currentValue = intArray[i];
            if (currentValue % 2 == oddOrEven)
            {

                nums.Add(intArray[i]);
                counter++;

            }
            if (counter == count)
            {
                break;
            }
        }
        nums.Reverse();
        Console.Write(string.Join(", ", nums));
        Console.WriteLine("]");
    }

    static int[] Exchange(int[] array, int index)
    {
        int[] arrayAfterExchange = new int[array.Length];

        for (int i = 0; i < array.Length; i++)
        {
            arrayAfterExchange[i] = array[(i + index + 1) % array.Length];
        }

        return array = arrayAfterExchange;
    }

    static void Max(int[] arrayInts, string typeOfNumber)
    {
        int max = int.MinValue;
        int maxValueIndex = 0;

        int oddOrEven = 0;

        if (typeOfNumber == "odd")
        {
            oddOrEven = 1;
        }

        for (int i = 0; i < arrayInts.Length; i++)
        {

            int currentValue = arrayInts[i];

            if (max == currentValue)
            {
                maxValueIndex = i;
            }

            if (currentValue % 2 == oddOrEven)
            {
                if (currentValue > max)
                {
                    max = currentValue;
                    maxValueIndex = i;
                }
            }
        }

        if (max == int.MinValue)
        {
            Console.WriteLine("No matches");
        }
        else
        {
            Console.WriteLine(maxValueIndex);
        }
    }

    static void Min(int[] arrayInts, string typeOfNumber)
    {
        int min = int.MaxValue;

        int minValueIndex = 0;

        int oddOrEven = 0;

        if (typeOfNumber == "odd")
        {
            oddOrEven = 1;
        }

        for (int i = 0; i < arrayInts.Length; i++)
        {

            int currentValue = arrayInts[i];

            if (min == currentValue)
            {
                minValueIndex = i;
            }

            if (currentValue % 2 == oddOrEven)
            {
                if (currentValue < min)
                {
                    min = currentValue;
                    minValueIndex = i;
                }
            }
        }

        if (min == int.MaxValue)
        {
            Console.WriteLine("No matches");
        }
        else
        {
            Console.WriteLine(minValueIndex);
        }
    }
}
