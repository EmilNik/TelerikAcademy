namespace Computers.Logic.CPUs
{
    public class Cpu64 : Cpu
    {
        internal Cpu64(byte numberOfCores)
            : base(numberOfCores)
        {
        }

        protected override int GetMaxValue()
        {
            return 1000;
        }
    }
}
