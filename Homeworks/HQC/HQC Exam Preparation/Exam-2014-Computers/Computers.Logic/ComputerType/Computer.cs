namespace Computers.Logic.ComputerType
{
    using HardDrives;

    public class Computer
    {
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
        }

        protected HardDrive HardDrives { get; set; }

        protected VideoCard VideoCard { get; set; }

        protected Cpu Cpu { get; set; }

        protected Ram Ram { get; set; }
    }
}
