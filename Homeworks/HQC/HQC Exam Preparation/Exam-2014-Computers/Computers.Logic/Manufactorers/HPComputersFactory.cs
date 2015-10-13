namespace Computers.UI.Manufactorers
{
    using System.Collections.Generic;
    using ComputerType;

    public class HPComputersFactory : IComputersFactory
    {
        public PersonalComputer CreatePersonalComputer()
        {
            var ram = new Ram(2);
            var videoCard = new VideoCard() { IsMonochrome = false };

            var pc = new PersonalComputer(new Cpu(2, 32, ram, videoCard), ram, new[] { new HardDrive(500, false, 0) }, videoCard);

            return pc;
        }

        public Laptop CreateLaptop()
        {
            var videoCard = new VideoCard() { IsMonochrome = false };
            var ram = new Ram(4);

            var laptop = new Laptop(new Cpu(2, 64, ram, videoCard), ram, new[] { new HardDrive(500, false, 0) }, videoCard, new LaptopBattery());

            return laptop;
        }

        public Server CreateServer()
        {
            var serverRam = new Ram(32);
            var serverVideo = new VideoCard();

            var server = new Server(new Cpu(4, 32, serverRam, serverVideo),  serverRam, new List<HardDrive> { new HardDrive(0, true, 2, new List<HardDrive> { new HardDrive(1000, false, 0), new HardDrive(1000, false, 0) }) }, serverVideo);

            return server;
        }
    }
}
