namespace JustAsk.Common
{
    using System;

    public class RandomGenerator
    {
        private Random random;

        public RandomGenerator()
        {
            this.random = new Random();
        }

        public string GetRandomIp()
        {
            return string.Format("{0}.{1}.{2}.{3}", this.random.Next(0, 255), this.random.Next(0, 255), this.random.Next(0, 255), this.random.Next(0, 255));
        }

        public int GetRandomNumber(int minNumber, int maxNumber)
        {
            return this.random.Next(minNumber, maxNumber + 1);
        }
    }
}
