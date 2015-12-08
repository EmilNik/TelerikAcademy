namespace Words
{
    using System;

    public class Program
    {
        public static int count;
        static void Main()
        {
            var pattern = Console.ReadLine();
            var text = Console.ReadLine();
            var count = 0;
            for (int i = 0; i < pattern.Length; i++)
            {
                var preffix = (pattern.Substring(0, i));
                var suffix = (pattern.Substring(i, (pattern.Length - i)));

                count += CountStringOccurrences(text, suffix, preffix);
            }

            Console.WriteLine(count);
        }

        public static int CountStringOccurrences(string text, string prefix, string suffix)
        {
            var currentCount = 0;
            var preffixCount = 0;
            var sufficCound = 0;
            int i = 0;
            int j = 0;

            if (suffix == string.Empty)
            {
                sufficCound = 1;
            }
            else
            {
                while ((i = text.IndexOf(suffix, i)) != -1)
                {
                    i += suffix.Length;
                    sufficCound++;
                }
            }

            if (prefix == string.Empty)
            {
                preffixCount = 1;
            }
            else
            {
                while ((j = text.IndexOf(prefix, j)) != -1)
                {
                    j += prefix.Length;
                    preffixCount++;
                }
            }

            currentCount = preffixCount * sufficCound;
            return currentCount;
        }
    }
}
