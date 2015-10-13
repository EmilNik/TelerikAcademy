namespace Computers.Logic
{
    using System;

    public abstract class Cpu : IMotherboardComponent
    {
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
                this.motherboard.DrawOnVideoCard("Number too low.");
            }
            else if (data > this.GetMaxValue())
            {
                this.motherboard.DrawOnVideoCard("Number too high.");
            }
            else
            {
                int value = data * data;

                this.motherboard.DrawOnVideoCard(string.Format("Square of {0} is {1}.", data, value));
            }
        }

        public void Rand(int a, int b)
        {
            int randomNumber = Random.Next(1, 11);
            this.motherboard.SaveRamValue(randomNumber);
        }

        public void AttachTo(IMotherboard motherboard)
        {
            this.motherboard = motherboard;
        }

        protected abstract int GetMaxValue();
    }
}
