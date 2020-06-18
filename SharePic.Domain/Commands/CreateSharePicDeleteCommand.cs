using System;

namespace SharePic.Domain.Commands
{
    public class CreateSharePicDeleteCommand : SharePicDeleteCommand
    {
        public CreateSharePicDeleteCommand(Guid id)
        {
            Id = id;
        }
    }
}
