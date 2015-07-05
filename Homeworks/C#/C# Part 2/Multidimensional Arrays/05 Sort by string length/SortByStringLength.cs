using System;

class SortByStringLength
{
    static void Main()
    {
        //You are given an array of strings. Write a method that sorts the array by the length of its elements 
        //(the number of characters composing them).

        string[] array = { "SomeString", "AnotherString", "ThirdString", "TelerikAcademyString", "StillOtherString" };

        Array.Sort(array, (x, y) => (x.Length).CompareTo(y.Length));

        foreach (string element in array)
        {
            Console.WriteLine(element);
        }
    }
}
