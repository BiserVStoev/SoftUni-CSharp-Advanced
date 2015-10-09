using System;

    class TextFilter
    {
        static void Main()
        {
            Console.WriteLine("Enter the words to ban: ");
            string[] wordsToBan = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine("Enter the text: ");
            string text = Console.ReadLine();

            foreach (var word in wordsToBan)
            {
                text = text.Replace(word, new string('*', word.Length));
            }

            Console.WriteLine(text);
        }
    }
