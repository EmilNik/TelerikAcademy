namespace Computers.Logic.VideoCards
{
    using System;

    public class ColorfullVideoCard : VideoCard
    {
        protected override ConsoleColor GetColor()
        {
            return ConsoleColor.Green;
        }
    }
}
