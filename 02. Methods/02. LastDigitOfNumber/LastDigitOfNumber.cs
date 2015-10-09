using System;

class LastDigitOfNumber
{
    static void Main()
    {
        Console.WriteLine(GetLastDigitAsWord(512));
        Console.WriteLine(GetLastDigitAsWord(1024));
        Console.WriteLine(GetLastDigitAsWord(12309));
    }

    static string GetLastDigitAsWord(int num) 
    {
        int lastDigit = num % 10;
        string lastDigitAsWord = "";

        switch (lastDigit)
        {
            case 0:
                lastDigitAsWord = "zero";
                break;
            case 1:
                lastDigitAsWord = "one";
                break;
            case 2:
                lastDigitAsWord = "two";
                break;
            case 3:
                lastDigitAsWord = "three";
                break;
            case 4:
                lastDigitAsWord = "four";
                break;
            case 5:
                lastDigitAsWord = "five";
                break;
            case 6:
                lastDigitAsWord = "six";
                break;
            case 7:
                lastDigitAsWord = "seven";;
                break;
            case 8:
                lastDigitAsWord = "eight";;
                break;
            case 9:
                lastDigitAsWord = "nine";
                break;
        }
        return lastDigitAsWord;
    }
}
