namespace Computers.Logic.Manufactorers
{
    using System.Collections.Generic;
    using HardDrives;
    using ComputerType;
    using CPUs;
    using VideoCards;

    public class HPComputersFactory : IComputersFactory
    {
        public PersonalComputer CreatePersonalComputer()
        {
            var ram = new Ram(2);
            var videoCard = new ColorfulVideoCard();

            var pc = new PersonalComputer(new Cpu32(2, ram, videoCard), ram, new SingleHardDrive(500), videoCard);

            return pc;
        }

        public Laptop CreateLaptop()
        {
            var videoCard = new ColorfulVideoCard();
            var ram = new Ram(4);

            var laptop = new Laptop(new Cpu64(2, ram, videoCard), ram, new SingleHardDrive(500), videoCard, new LaptopBattery());

            return laptop;
        }

        public Server CreateServer()
        {
            var serverRam = new Ram(32);
            var serverVideo = new MonochromeVideoCard();

            var server = new Server(new Cpu32(4, serverRam, serverVideo), serverRam, new RaidArray(2, new List<HardDrive> { new SingleHardDrive(1000), new SingleHardDrive(1000) }), serverVideo);

            return server;
        }
    }
}
