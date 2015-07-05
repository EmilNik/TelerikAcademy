using System;
using System.Text.RegularExpressions;

class SubStringInText
{

    //Write a program that finds how many times a sub-string is contained in a given text (perform case insensitive search).

    static void Main(string[] args)
    {
        Console.Write("Enter some text: ");
        string text = Console.ReadLine();

        Console.Write("Enter substring to search for: ");
        string substring = Console.ReadLine();

        Console.WriteLine(GetSubstringCount(text, substring));
    }

    private static int GetSubstringCount(string text, string substring)
    {
        return Regex
        .Matches(text, substring, RegexOptions.IgnoreCase)
        .Count;
    }
}

