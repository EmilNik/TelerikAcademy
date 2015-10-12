namespace Computers.Manufactorers
{
    using System;
    using ComputerType;

    public class LenovoComputersFactory : IComputersFactory
    {
        public PersonalComputer CreatePersonalComputer()
        {
            throw new NotImplementedException();
        }

        public Laptop CreateLaptop()
        {
            throw new NotImplementedException();
        }

        public Server CreateServer()
        {
            throw new NotImplementedException();
        }
    }
}
