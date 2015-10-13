namespace Computers.Logic
{
    using System;

    public abstract class Cpu : IMotherboardComponent
    {
        public const string NumberTooHighMessage = "Number too high.";
        public const string NumberTooLowMessage = "Number too low.";
        private const string SquareRootStringFormat = "Square of {0} is {1}.";
        
        private static readonly Random Random = new Random();

        private readonly Ram ram;

        private readonly VideoCard videoCard;

        private IMotherboard motherboard;

        public Cpu(byte numberOfCores)
        {
            this.NumberOfCores = numberOfCores;
        }

        public byte NumberOfCores { get; set; }

        public void SquareNumber()
        {
            var data = this.motherboard.LoadRamValue();

            if (data < 0)
            {
                this.motherboard.DrawOnVideoCard(NumberTooLowMessage);
            }
            else if (data > this.GetMaxValue())
            {
                this.motherboard.DrawOnVideoCard(NumberTooHighMessage);
            }
            else
            {
                int value = data * data;

                this.motherboard.DrawOnVideoCard(string.Format(SquareRootStringFormat, data, value));
            }
        }

        public void Rand(int minValue, int maxValue)
        {
            int randomNumber = Random.Next(minValue, maxValue + 1);
            this.motherboard.SaveRamValue(randomNumber);
        }

        public void AttachTo(IMotherboard motherboard)
        {
            this.motherboard = motherboard;
        }

        protected abstract int GetMaxValue();
    }
}
