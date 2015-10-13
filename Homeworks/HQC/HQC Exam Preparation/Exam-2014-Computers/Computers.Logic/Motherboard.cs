namespace Computers.Logic
{
    public class Motherboard : IMotherboard
    {
        public Motherboard(Cpu cpu, Ram ram, VideoCard videoCard)
        {
            cpu.AttachTo(this);
            this.Ram = ram;
            this.VideoCard = videoCard;
        }

        public Ram Ram { get; set; }

        public VideoCard VideoCard { get; set; }

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
