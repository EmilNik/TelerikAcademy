namespace ConsoleApplication13
{
    using System;
    using System.Text;

    public static class SubstringExtension
    {
        /// <summary>
        ///Retrieves a substring from this instance. The substring starts at a specified
        ///     character position and has a specified length.
        /// </summary>
        /// 
        /// <param name="builder">
        /// 
        /// </param>
        /// 
        /// <param name="index">
        /// The zero-based starting character position of a substring in this instance.
        /// </param>
        /// 
        /// <param name="length">
        /// The number of characters in the substring.
        /// </param>
        /// 
        /// <returns>
        /// A StringBuilder that is equivalent to the substring of length length that begins
        ///     at index in this instance, or an empty StringBuilder if index is equal
        ///     to the length of this instance and length is zero.
        /// </returns>
        public static StringBuilder Substring(this StringBuilder builder, int index, int length)
        {
            string text = builder.ToString();
            string substring = text.Substring(index, length);

            StringBuilder newBuilder = new StringBuilder();

            newBuilder.Append(substring);

            return newBuilder;
        }
    }
}
