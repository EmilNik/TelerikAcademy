namespace Computers.Logic.ComputerType
{
    using HardDrives;

    public class PersonalComputer : Computer
    {
        private const string WinMessage = "You win!";
        private const string WrongNumberStringFormat = "You didn't guess the number {0}.";

        public PersonalComputer(
            Cpu cpu,
            Ram ram,
            HardDrive hardDrives,
            VideoCard videoCard)
            : base(cpu, ram, hardDrives, videoCard)
        {
        }

        public void Play(int guessNumber)
        {
            Cpu.Rand(1, 10);
            var number = this.Ram.LoadValue();
            if (number != guessNumber)
            {
                this.VideoCard.Draw(string.Format(WrongNumberStringFormat, number));
            }
            else
            {
                this.VideoCard.Draw(WinMessage);
            }
        }
    }
}
