namespace Computers.Logic
{
    public class Motherboard : IMotherboard
    {
        public Motherboard(Cpu cpu, IRam ram, IVideoCard videoCard)
        {
            cpu.AttachTo(this);
            this.Ram = ram;
            this.VideoCard = videoCard;
        }

        public IRam Ram { get; set; }

        public IVideoCard VideoCard { get; set; }

        public void DrawOnVideoCard(string data)
        {
            this.VideoCard.Draw(data);
        }

        public int LoadRamValue()
        {
            return this.Ram.LoadValue();
        }

        public void SaveRamValue(int value)
        {
            this.Ram.SaveValue(value);
        }
    }
}
