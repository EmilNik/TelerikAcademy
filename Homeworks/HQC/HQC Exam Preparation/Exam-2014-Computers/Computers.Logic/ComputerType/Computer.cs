namespace Computers.Logic.ComputerType
{
    using HardDrives;

    public class Computer
    {
        private Motherboard motherboard;

        internal Computer(
            Cpu cpu,
            IRam ram,
            HardDrive hardDrives,
            IVideoCard videoCard)
        {
            this.Cpu = cpu;
            this.Ram = ram;
            this.HardDrives = hardDrives;
            this.VideoCard = videoCard;
            this.motherboard = new Motherboard(this.Cpu, this.Ram, this.VideoCard);
        }

        protected HardDrive HardDrives { get; set; }

        protected IVideoCard VideoCard { get; set; }

        protected Cpu Cpu { get; set; }

        protected IRam Ram { get; set; }
    }
}
