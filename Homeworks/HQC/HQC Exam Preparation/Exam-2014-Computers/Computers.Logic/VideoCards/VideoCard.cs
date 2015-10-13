namespace Computers.Logic
{
    using System;

    public abstract class VideoCard : IVideoCard
    {
        public void Draw(string text)
        {
            Console.ForegroundColor = this.GetColor();

            Console.WriteLine(text);
            Console.ResetColor();
        }

        protected abstract ConsoleColor GetColor();
    }
}
