using Domain.Core.Commands;
using System;

namespace SharePic.Domain.Commands
{
    public abstract class SharePicCommand : Command
    {
        public Guid From { get; protected set; }
        public Guid To { get; protected set; }
        public string Pic { get; protected set; }
        public int Duration { get; protected set; }
    }
}

