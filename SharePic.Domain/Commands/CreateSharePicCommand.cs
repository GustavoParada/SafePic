using System;

namespace SharePic.Domain.Commands
{
    public class CreateSharePicCommand : SharePicCommand
    {
        public CreateSharePicCommand(Guid from, Guid to, string pic, int duration)
        {
            From = from;
            To = to;
            Pic = pic;
            Duration = duration;
        }
    }
}
