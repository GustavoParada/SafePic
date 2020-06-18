using Domain.Core.Commands;
using System;

namespace SharePic.Domain.Commands
{
    public class SharePicDeleteCommand : Command
    {
        public Guid Id { get; protected set; }
    }
}
