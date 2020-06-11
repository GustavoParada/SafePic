using MediatR;
using Project.Domain.Core.Bus;
using SharePic.Domain.Commands;
using SharePic.Domain.Events;
using System.Threading;
using System.Threading.Tasks;

namespace SharePic.Domain.CommandHandlers
{
    public class SharePicCommandHandler : IRequestHandler<CreateSharePicCommand, bool>
    {
        private readonly IEventBus _bus;

        public SharePicCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(CreateSharePicCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new SharePicCreatedEvent(request.From, request.To, request.Pic, request.Duration));
            return Task.FromResult(true);
        }
    }

}
