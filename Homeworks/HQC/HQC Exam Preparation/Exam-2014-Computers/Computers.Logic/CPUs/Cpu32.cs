namespace Computers.Logic.CPUs
{
    public class Cpu32 : Cpu
    {
        public Cpu32(byte numberOfCores)
            : base(numberOfCores)
        {
        }

        protected override int GetMaxValue()
        {
            return 500;
        }
    }
}
