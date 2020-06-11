using SharePic.Domain.Commands;
using System;

namespace SharePic.API.ViewModels
{
    public class SharePicViewModel : SharePicCommand
    {
        public Guid From { get; protected set; }
        public Guid To { get; protected set; }
        public string Pic { get; protected set; }
        public int Duration { get; protected set; }

        public SharePicViewModel(Guid from, Guid to, string pic, int duration)
        {
            From = from;
            To = to;
            Pic = pic;
            Duration = duration;
        }
    }
}
