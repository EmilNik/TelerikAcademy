namespace Computers.ComputerType
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    public class Server : Computer
    {
        public Server(
            Cpu cpu,
            Rammstein ram,
            IEnumerable<HardDrive> hardDrives,
            HardDrive videoCard)
            : base(cpu, ram, hardDrives, videoCard)
        {
        }

        internal void Process(int data)
        {
            this.Ram.SaveValue(data);
            ////TODO: Fix it
            this.Cpu.SquareNumber();
        }
    }
}
