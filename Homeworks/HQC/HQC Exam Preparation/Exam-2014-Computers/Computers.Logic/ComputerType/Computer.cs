namespace Computers.Logic.ComputerType
{
    using HardDrives;

    public class Computer
    {
        private Motherboard motherboard;

        internal Computer(
            Cpu cpu,
            Ram ram,
            HardDrive hardDrives,
            VideoCard videoCard)
        {
            this.Cpu = cpu;
            this.Ram = ram;
            this.HardDrives = hardDrives;
            this.VideoCard = videoCard;
            this.motherboard = new Motherboard(this.Cpu, this.Ram, this.VideoCard);
        }

        protected HardDrive HardDrives { get; set; }

        protected VideoCard VideoCard { get; set; }

        protected Cpu Cpu { get; set; }

        protected Ram Ram { get; set; }
    }
}
