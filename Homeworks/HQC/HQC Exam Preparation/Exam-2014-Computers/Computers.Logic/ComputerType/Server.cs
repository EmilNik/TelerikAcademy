namespace Computers.Logic.ComputerType
{
    using HardDrives;

    public class Server : Computer
    {
        public Server(
            Cpu cpu,
            Ram ram,
            HardDrive hardDrives,
            VideoCard videoCard)
            : base(cpu, ram, hardDrives, videoCard)
        {
        }

        public void Process(int data)
        {
            this.Ram.SaveValue(data);
            this.Cpu.SquareNumber();
        }
    }
}
