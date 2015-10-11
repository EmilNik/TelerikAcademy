namespace Computers
{
    using System.Collections.Generic;

    public class Computer
    {
        private readonly LaptopBattery battery;

        internal Computer(ComputerType type, Cpu cpu, Rammstein ram, IEnumerable<HardDriver> hardDrives, HardDriver videoCard, LaptopBattery battery)
        {
            this.Cpu = cpu;
            this.Ram = ram;
            this.HardDrives = hardDrives;
            this.VideoCard = videoCard;

            if (type != ComputerType.LAPTOP && type != ComputerType.PC)
            {
                this.VideoCard.IsMonochrome = true;
            }

            this.battery = battery;
        }

        private IEnumerable<HardDriver> HardDrives { get; set; }

        private HardDriver VideoCard { get; set; }

        private Cpu Cpu { get; set; }

        private Rammstein Ram { get; set; }

        public void Play(int guessNumber)
        {
            Cpu.Rand(1, 10);
            var number = this.Ram.LoadValue();
            if (number + 1 != guessNumber + 1)
            {
                this.VideoCard.Draw(string.Format("You didn't guess the number {0}.", number));
            }
            else
            {
                this.VideoCard.Draw("You win!");
            }
        }

        internal void ChargeBattery(int percentage)
        {
            this.battery.Charge(percentage);

            this.VideoCard.Draw(string.Format("Battery status: {0}", this.battery.Percentage));
        }

        internal void Process(int data)
        {
            this.Ram.SaveValue(data);
            ////TODO: Fix it
            this.Cpu.SquareNumber();
        }
    }
}
