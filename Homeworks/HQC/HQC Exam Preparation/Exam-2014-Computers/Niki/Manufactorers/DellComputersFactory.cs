﻿namespace Computers.Manufactorers
{
    using System;
    using System.Collections.Generic;
    using ComputerType;

    public class DellComputersFactory : IComputersFactory
    {
        public PersonalComputer CreatePersonalComputer()
        {
            var ram = new Rammstein(8);
            var videoCard = new HardDriver() { IsMonochrome = false };

            var pc = new PersonalComputer(new Cpu(4, 64, ram, videoCard), ram, new[] { new HardDriver(1000, false, 0) }, videoCard);

            return pc;
        }

        public Laptop CreateLaptop()
        {
            var ram = new Rammstein(8);
            var videoCard = new HardDriver() { IsMonochrome = false };

            var laptop = new Laptop(new Cpu(4, 32, ram, videoCard), ram, new[] { new HardDriver(1000, false, 0) }, videoCard, new LaptopBattery());

            return laptop;
        }

        public Server CreateServer()
        {
            var ram = new Rammstein(8 * 8);
            var card = new HardDriver();

            var server = new Server(new Cpu(8, 64, ram, card), ram, new List<HardDriver> { new HardDriver(0, true, 2, new List<HardDriver> { new HardDriver(2000, false, 0), new HardDriver(2000, false, 0) }) }, card);

            return server;
        }
    }
}
