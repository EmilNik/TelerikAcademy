namespace Computers.Logic.Manufactorers
{
    using System.Collections.Generic;
    using ComputerType;
    using CPUs;
    using HardDrives;
    using VideoCards;

    public class HPComputersFactory : IComputersFactory
    {
        public const string Name = "HP";

        public PersonalComputer CreatePersonalComputer()
        {
            var pc = new PersonalComputer(
                new Cpu32(2),
                new Ram(2),
                new SingleHardDrive(500),
                new ColorfulVideoCard());

            return pc;
        }

        public Laptop CreateLaptop()
        {
            var laptop = new Laptop(
                new Cpu64(2),
                new Ram(4),
                new SingleHardDrive(500),
                new ColorfulVideoCard(),
                new LaptopBattery());

            return laptop;
        }

        public Server CreateServer()
        {
            var server = new Server(
                new Cpu32(4),
                new Ram(32),
                new RaidArray(
                    new List<HardDrive>
                    {
                        new SingleHardDrive(1000),
                        new SingleHardDrive(1000)
                    }),
                new MonochromeVideoCard());

            return server;
        }
    }
}
