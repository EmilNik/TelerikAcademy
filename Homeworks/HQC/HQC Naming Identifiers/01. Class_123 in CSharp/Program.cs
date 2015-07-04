//Refactor the following examples to produce code with well-named C# identifiers.

using System;

class class_123
{
    const int MAX_COUNT = 6;

    class Converter
    {
        public void BoolToString(bool value)
        {
            string valueAsString = value.ToString();
            Console.WriteLine(valueAsString);
        }
    }

    public static void EntryPoint()
    {
        Converter converter = new Converter();
        converter.BoolToString(true);
    }
}
