namespace Computers.Logic.Manufactorers
{
    using System.Collections.Generic;
    using ComputerType;
    using CPUs;
    using HardDrives;
    using VideoCards;

    public class LenovoComputersFactory : IComputersFactory
    {
        public const string Name = "Lenovo";

        public PersonalComputer CreatePersonalComputer()
        {
            var pc = new PersonalComputer(
                new Cpu64(2),
                new Ram(4),
                new SingleHardDrive(2000),
                new MonochromeVideoCard());

            return pc;
        }

        public Laptop CreateLaptop()
        {
            var laptop = new Laptop(
                new Cpu64(2),
                new Ram(16),
                new SingleHardDrive(1000),
                new ColorfulVideoCard(),
                new LaptopBattery());

            return laptop;
        }

        public Server CreateServer()
        {
            var server = new Server(
                new Cpu128(2),
                new Ram(8),
                new RaidArray(
                    new List<HardDrive>
                    {
                        new SingleHardDrive(500),
                        new SingleHardDrive(500)
                    }),
                new MonochromeVideoCard());

            return server;
        }
    }
}
