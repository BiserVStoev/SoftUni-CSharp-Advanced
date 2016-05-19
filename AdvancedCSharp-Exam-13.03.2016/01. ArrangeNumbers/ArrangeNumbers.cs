namespace _1attempt2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ArrangeNumbers
    {
        public static void Main()
        {
            int[] input =
                Console.ReadLine()
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            List<string> numbersAsWords = new List<string>();

            foreach (var number in input)
            {
                var numArray = number.ToString().ToCharArray();
                List<string> words = new List<string>();
                ConvertNumberToText(numArray, words);

                string result = string.Join("-", words);
                numbersAsWords.Add(result);
            }

            var orderedNumbersAsString = numbersAsWords.OrderBy(w => w);

            List<int> numbers = new List<int>();

            foreach (var word in orderedNumbersAsString)
            {
                string[] nums = word.Split('-');
                var result = ConvertTextToNumber(nums);

                numbers.Add(int.Parse(result));
            }

            Console.WriteLine(string.Join(", ", numbers));
        }

        private static void ConvertNumberToText(char[] numArray, List<string> words)
        {
            foreach (var ch in numArray)
            {
                switch (ch)
                {
                    case '0':
                        words.Add("zero");
                        break;
                    case '1':
                        words.Add("one");
                        break;
                    case '2':
                        words.Add("two");
                        break;
                    case '3':
                        words.Add("three");
                        break;
                    case '4':
                        words.Add("four");
                        break;
                    case '5':
                        words.Add("five");
                        break;
                    case '6':
                        words.Add("six");
                        break;
                    case '7':
                        words.Add("seven");
                        break;
                    case '8':
                        words.Add("eight");
                        break;
                    case '9':
                        words.Add("nine");
                        break;
                }
            }
        }

        private static string ConvertTextToNumber(string[] nums)
        {
            string result = string.Empty;
            foreach (var n in nums)
            {
                switch (n)
                {
                    case "zero":
                        result += 0;
                        break;
                    case "one":
                        result += 1;
                        break;
                    case "two":
                        result += 2;
                        break;
                    case "three":
                        result += 3;
                        break;
                    case "four":
                        result += 4;
                        break;
                    case "five":
                        result += 5;
                        break;
                    case "six":
                        result += 6;
                        break;
                    case "seven":
                        result += 7;
                        break;
                    case "eight":
                        result += 8;
                        break;
                    case "nine":
                        result += 9;
                        break;
                }
            }
            return result;
        }
    }
}
