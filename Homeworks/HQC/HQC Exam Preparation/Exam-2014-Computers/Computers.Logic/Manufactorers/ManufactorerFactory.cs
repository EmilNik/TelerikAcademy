namespace Computers.Logic.Manufactorers
{
    public class ManufactorerFactory
    {
        public IComputersFactory GetManufactorer(string manufactorerName)
        {
            IComputersFactory computerFactory;

            if (manufactorerName == HPComputersFactory.Name)
            {
                computerFactory = new HPComputersFactory();
            }
            else if (manufactorerName == DellComputersFactory.Name)
            {
                computerFactory = new DellComputersFactory();
            }
            else if (manufactorerName == LenovoComputersFactory.Name)
            {
                computerFactory = new LenovoComputersFactory();
            }
            else
            {
                throw new InvalidArgumentException("Invalid manufacturer!");
            }

            return computerFactory;
        }
    }
}
