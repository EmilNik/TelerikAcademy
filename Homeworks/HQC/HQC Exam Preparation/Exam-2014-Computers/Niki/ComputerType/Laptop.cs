using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computers.ComputerType
{
    public class Laptop : Computer
    {
        private readonly LaptopBattery battery;

        public Laptop(
               Cpu cpu,
               Rammstein ram,
               IEnumerable<HardDriver> hardDrives,
               HardDriver videoCard,
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
