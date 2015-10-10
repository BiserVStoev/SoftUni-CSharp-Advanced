using System;
using System.Linq;
using System.Text.RegularExpressions;

class PinValidation
{
    static void Main()
    {
        string firstInput = Console.ReadLine();
        string gender = Console.ReadLine();
        string pin = Console.ReadLine();

        string pattern = @"[A-Z][a-z]+\s[A-Z][a-z]+";
        Regex regex = new Regex(pattern);

        while (true)
        {

            if (!regex.IsMatch(firstInput) || pin.Length != 10)
            {
                PrintInvalidInput();
                break;
            }
            else
            {
                int yearBorn = int.Parse(pin.Substring(0, 2));
                int monthBorn = int.Parse(pin.Substring(2, 2));
                int dayBorn = int.Parse(pin.Substring(4, 2));
                if (yearBorn < 90)
                {
                    monthBorn += 20;
                }
                else if (yearBorn > 20)
                {
                    monthBorn += 40;
                }


                int numForGender = int.Parse(pin.Substring(8, 1));

                string genderByPin = "";

                if (numForGender%2 == 0)
                {
                    genderByPin = "male";
                }
                else
                {
                    genderByPin = "female";
                }

                if (genderByPin != gender)
                {
                    PrintInvalidInput();
                    break;
                }

                int[] numForMultiplication = {2, 4, 8, 5, 10, 9, 7, 3, 6};

                int[] result = new int[numForMultiplication.Length];

                GetMultiplicationResult(numForMultiplication, result, pin);

                int sumOfDigits = result.Sum();
                int dividedNum = sumOfDigits%11;

                if (dividedNum == 10)
                {
                    dividedNum = 0;
                }
                int checkSum = int.Parse(pin.Substring(9, 1));

                if (dividedNum != checkSum)
                {
                    PrintInvalidInput();
                    break;
                }

                Console.WriteLine(@"{{""name"":""{0}"",""gender"":""{1}"",""pin"":""{2}""}}", 
                    firstInput, gender, pin);
                break;
            }

        }

    }

    static void PrintInvalidInput()
    {
        Console.WriteLine("<h2>Incorrect data</h2>");
    }

    static void GetMultiplicationResult(int[] multiplicationInts, int[] result, string pin)
    {
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = multiplicationInts[i]*int.Parse(pin[i].ToString());
        }
    }

}
