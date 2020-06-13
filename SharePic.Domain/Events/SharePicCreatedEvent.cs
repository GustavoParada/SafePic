using Domain.Core.Events;
using System;

namespace SharePic.Domain.Events
{
    public class SharePicCreatedEvent : Event
    {
        public SharePicCreatedEvent(Guid from, Guid to, string pic, int duration)
        {
            From = from;
            To = to;
            Pic = pic;
            Duration = duration;
        }

        public Guid From { get; set; }
        public Guid To { get; set; }
        public string Pic { get; set; }
        public int Duration { get; set; }
    }
}
