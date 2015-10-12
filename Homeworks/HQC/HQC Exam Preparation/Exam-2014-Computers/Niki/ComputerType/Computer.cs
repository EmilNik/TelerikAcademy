namespace Computers.ComputerType
{
    using System.Collections.Generic;

    public class Computer
    {
        internal Computer(
            Cpu cpu,
            Rammstein ram,
            IEnumerable<HardDrive> hardDrives,
            HardDrive videoCard)
        {
            this.Cpu = cpu;
            this.Ram = ram;
            this.HardDrives = hardDrives;
            this.VideoCard = videoCard;
        }

        protected IEnumerable<HardDrive> HardDrives { get; set; }

        protected HardDrive VideoCard { get; set; }

        protected Cpu Cpu { get; set; }

        protected Rammstein Ram { get; set; }
    }
}
