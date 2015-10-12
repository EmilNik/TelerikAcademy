﻿namespace Computers.ComputerType
{
    using System.Collections.Generic;

    public class Laptop : Computer
    {
        private readonly LaptopBattery battery;

        public Laptop(
               Cpu cpu,
               Rammstein ram,
               IEnumerable<HardDrive> hardDrives,
               HardDrive videoCard,
               LaptopBattery battery)
            : base(cpu, ram, hardDrives, videoCard)
        {
            this.battery = battery;
        }

        internal void ChargeBattery(int percentage)
        {
            this.battery.Charge(percentage);

            this.VideoCard.Draw(string.Format("Battery status: {0}", this.battery.Percentage));
        }
    }
}
