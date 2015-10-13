namespace Computers.Logic.Manufactorers
{
    using System.Collections.Generic;
    using ComputerType;
    using CPUs;
    using VideoCards;
    using HardDrives;

    public class LenovoComputersFactory : IComputersFactory
    {
        public PersonalComputer CreatePersonalComputer()
        {
            var ram = new Ram(4);
            var videoCard = new MonochromeVideoCard();

            var pc = new PersonalComputer(new Cpu64(2, ram, videoCard), ram, new SingleHardDrive(2000), videoCard);

            return pc;
        }

        public Laptop CreateLaptop()
        {
            var ram = new Ram(16);
            var videoCard = new ColorfulVideoCard();

            var laptop = new Laptop(new Cpu64(2, ram, videoCard), ram, new SingleHardDrive(1000), videoCard, new LaptopBattery());

            return laptop;
        }

        public Server CreateServer()
        {
            var ram = new Ram(8);
            var videoCard = new MonochromeVideoCard();

            var server = new Server(new Cpu128(2, ram, videoCard), ram, new RaidArray(2, new List<HardDrive> { new SingleHardDrive(500), new SingleHardDrive(500) }), videoCard);

            return server;
        }
    }
}
