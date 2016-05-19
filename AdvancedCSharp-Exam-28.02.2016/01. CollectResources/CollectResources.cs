namespace _01.CollectResources
{
    using System;

    public class CollectResources
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split(' ');
            int paths = int.Parse(Console.ReadLine());
            bool[] collected = new bool[input.Length];

            int maximum = 0;
            for (int i = 0; i < paths; i++)
            {
                string[] coordinates = Console.ReadLine().Split(' ');
                int index = int.Parse(coordinates[0]);
                int jump = int.Parse(coordinates[1]);
                int currentSum = 0;
                while (true)
                {
                    if (IsValid(input[index]))
                    {
                        if (input[index].Contains("_"))
                        {
                            currentSum += int.Parse(input[index].Split('_')[1]);
                            collected[index] = true;
                        }
                        else
                        {
                            collected[index] = true;
                            currentSum++;
                        }
                    }

                    index = (jump + index) % collected.Length;
                    if (collected[index])
                    {
                        break;
                    }
                }

                if (maximum < currentSum)
                {
                    maximum = currentSum;
                }

                collected = new bool[input.Length];
            }

            Console.WriteLine(maximum);
        }

        public static bool IsValid(string input)
        {
            if (input.Contains("stone")
                                 || input.StartsWith("wood")
                                 || input.StartsWith("gold")
                                 || input.StartsWith("food"))
            {
                return true;
            }

            return false;
        }
    }
}