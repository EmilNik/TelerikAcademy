using System;
using System.Text.RegularExpressions;

class ParseTags
{
    //You are given a text. Write a program that changes the text in all regions surrounded by the tags <upcase> 
    //and </upcase> to upper-case.
    //The tags cannot be nested.


    static void Main()
    {
        Console.Write("Enter some text: ");
        string text = Console.ReadLine();
        Console.WriteLine(TagsToUpper(text));
    }
    private static string TagsToUpper(string text)
    {
        return Regex.Replace(text, @"<upcase>(.*?)</upcase>", delegate(Match match)
        {
            string current = match.ToString().ToUpper();
            return Regex.Replace(current, @"<[^>]*>", String.Empty);
        });
    }
}
