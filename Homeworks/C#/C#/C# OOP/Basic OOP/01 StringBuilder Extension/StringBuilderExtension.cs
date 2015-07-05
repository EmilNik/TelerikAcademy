//Implement an extension method Substring(int index, int length) for the class StringBuilder
//that returns new StringBuilder and has the same functionality as Substring in the class String.

namespace ConsoleApplication13
{
    using System;
    using System.Text;

    public class StringBuilderExtension
    {
        static void Main(string[] args)
        {
            StringBuilder builder = new StringBuilder();
            builder.Substring(0, 0);
        }
    }
}
