namespace Computers.Logic.ComputerType
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
            Ram ram,
            IEnumerable<HardDrive> hardDrives,
            VideoCard videoCard)
            : base(cpu, ram, hardDrives, videoCard)
        {
        }

        public void Process(int data)
        {
            this.Ram.SaveValue(data);
            ////TODO: Fix it
            this.Cpu.SquareNumber();
        }
    }
}
