﻿namespace Computers.ComputerType
{
    using System.Collections.Generic;

    public class Computer
    {
        internal Computer(
            Cpu cpu,
            Rammstein ram,
            IEnumerable<HardDriver> hardDrives,
            HardDriver videoCard)
        {
            this.Cpu = cpu;
            this.Ram = ram;
            this.HardDrives = hardDrives;
            this.VideoCard = videoCard;
        }

        protected IEnumerable<HardDriver> HardDrives { get; set; }

        protected HardDriver VideoCard { get; set; }

        protected Cpu Cpu { get; set; }

        protected Rammstein Ram { get; set; }
    }
}
