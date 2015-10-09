using System;
using System.Collections.Generic;

class phoneBook
{
    static void Main()
    {
        Dictionary<string, List<string>> phoneBook = new Dictionary<string, List<string>>();

        while (true)
        {
            string input = Console.ReadLine();
            string[] contacts;
            if (input != "search")
            {
                contacts = input.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                string name = contacts[0];
                string phone = contacts[1];

                if (!phoneBook.ContainsKey(name))
                {
                    List<string> phoneNumbers = new List<string>();
                    phoneNumbers.Add(phone);
                    phoneBook.Add(name, phoneNumbers);
                }
                else
                {
                    if (!phoneBook[name].Contains(phone))
                    {
                        phoneBook[name].Add(phone);
                    }
                }
            }
            else
            {
                break;
            }
        }

        while (true)
        {
            string contactName = Console.ReadLine();

            if (phoneBook.ContainsKey(contactName))
            {
                Console.WriteLine("{0} -> {1}", contactName, string.Join(", ", phoneBook[contactName]));
            }
            else
            {
                Console.WriteLine("Contact {0} does not exist.", contactName);
            }
        }
    }
}
