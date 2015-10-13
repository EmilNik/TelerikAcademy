namespace Computers.Logic.ComputerType
{
    using HardDrives;

    public class Laptop : Computer
    {
        private readonly ILaptopBattery battery;

        public Laptop(
               Cpu cpu,
               IRam ram,
               HardDrive hardDrives,
               IVideoCard videoCard,
               ILaptopBattery battery)
            : base(cpu, ram, hardDrives, videoCard)
        {
            this.battery = battery;
        }

        public void ChargeBattery(int percentage)
        {
            this.battery.Charge(percentage);

            this.VideoCard.Draw(string.Format("Battery status: {0}", this.battery.Percentage));
        }
    }
}
