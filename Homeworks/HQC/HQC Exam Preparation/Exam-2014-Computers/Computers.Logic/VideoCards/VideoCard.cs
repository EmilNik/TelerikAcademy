namespace Computers.Logic
{
    using System;

    public abstract class VideoCard
    {
        public void Draw(string a)
        {
            Console.ForegroundColor = this.GetColor();

            Console.WriteLine(a);
            Console.ResetColor();
        }

        protected abstract ConsoleColor GetColor();
    }
}
