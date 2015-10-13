namespace Computers.Logic
{
    public class LaptopBattery : ILaptopBattery
    {
        private const int MinBatteryPercentage = 0;
        private const int MaxBatteryPercentage = 100;
        private const int DefaultBatteryPercentage = 100 / 2;

        public LaptopBattery()
        {
            this.Percentage = DefaultBatteryPercentage;
        }

        public int Percentage { get; set; }

        public void Charge(int percentage)
        {
            this.Percentage += percentage;

            if (this.Percentage > MaxBatteryPercentage)
            {
                this.Percentage = MaxBatteryPercentage;
            }

            if (this.Percentage < MinBatteryPercentage)
            {
                this.Percentage = MinBatteryPercentage;
            }
        }
    }
}
