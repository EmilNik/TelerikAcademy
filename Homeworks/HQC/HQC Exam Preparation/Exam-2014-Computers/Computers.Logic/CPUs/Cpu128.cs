namespace Computers.Logic.CPUs
{
    public class Cpu128 : Cpu
    {
        public Cpu128(byte numberOfCores)
            : base(numberOfCores)
        {
        }

        protected override int GetMaxValue()
        {
            return 2000;
        }
    }
}
