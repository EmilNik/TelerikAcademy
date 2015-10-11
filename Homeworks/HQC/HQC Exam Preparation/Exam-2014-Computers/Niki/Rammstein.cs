namespace Computers
{
    public class Rammstein
    {
        private int value;

        internal Rammstein(int a)
        {
            this.Amount = a;
        }

        private int Amount { get; set; }

        public void SaveValue(int newValue)
        {
            this.value = newValue;
        }

        public int LoadValue()
        {
            return this.value;
        }
    }
}