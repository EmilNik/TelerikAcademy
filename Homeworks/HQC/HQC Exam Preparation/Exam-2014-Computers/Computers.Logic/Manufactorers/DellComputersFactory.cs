namespace Computers.UI.Manufactorers
{
    using System;
    using System.Collections.Generic;
    using ComputerType;

    public class DellComputersFactory : IComputersFactory
    {
        public PersonalComputer CreatePersonalComputer()
        {
            var ram = new Ram(8);
            var videoCard = new VideoCard() { IsMonochrome = false };

            var pc = new PersonalComputer(new Cpu(4, 64, ram, videoCard), ram, new[] { new HardDrive(1000, false, 0) }, videoCard);

            return pc;
        }

        public Laptop CreateLaptop()
        {
            var ram = new Ram(8);
            var videoCard = new VideoCard() { IsMonochrome = false };

            var laptop = new Laptop(new Cpu(4, 32, ram, videoCard), ram, new[] { new HardDrive(1000, false, 0) }, videoCard, new LaptopBattery());

            return laptop;
        }

        public Server CreateServer()
        {
            var ram = new Ram(64);
            var videoCard = new VideoCard();

            var server = new Server(new Cpu(8, 64, ram, videoCard), ram, new List<HardDrive> { new HardDrive(0, true, 2, new List<HardDrive> { new HardDrive(2000, false, 0), new HardDrive(2000, false, 0) }) }, videoCard);

            return server;
        }
    }
}
