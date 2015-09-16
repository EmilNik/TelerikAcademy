namespace Phonebook
{
    using System.Text;

    public class StringBuilderPrinter : IPrinter
    {
        private StringBuilder output = new StringBuilder();

        public void Print(string text)
        {
            this.output.AppendLine(text);
        }

        public string GetAllText()
        {
            return this.output.ToString();
        }
    }
}
