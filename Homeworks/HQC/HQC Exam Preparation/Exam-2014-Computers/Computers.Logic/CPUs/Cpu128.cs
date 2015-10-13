namespace Computers.Logic.CPUs
{
    public class Cpu128 : Cpu
    {
        internal Cpu128(byte numberOfCores, Ram ram, VideoCard videoCard)
            : base(numberOfCores, ram, videoCard)
        {
        }

        protected override int GetMaxValue()
        {
            return 2000;
        }
    }
}
