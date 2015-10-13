namespace Computers.Logic.CPUs
{
    public class Cpu32 : Cpu
    {
        internal Cpu32(byte numberOfCores, Ram ram, VideoCard videoCard)
            : base(numberOfCores, ram, videoCard)
        {
        }

        protected override int GetMaxValue()
        {
            return 500;
        }
    }
}
