using SharePic.Domain.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SharePic.Domain.Events;
using Domain.Core.Bus;

namespace SharePic.Domain.EventHandlers
{
    public class SharePicEventHandler : IEventHandler<SharePicCreatedEvent>
    {
        private readonly IEventBus _bus;

        public SharePicEventHandler(IEventBus bus)
        {
            _bus = bus;
        }
        public Task<bool> Handle(CreateSharePicCommand request, CancellationToken cancellationToken)
        {
            //publicando evento no RabbitMQ
            return Task.FromResult(true);
        }

        public Task Handle(SharePicCreatedEvent @event)
        {
            throw new System.NotImplementedException();
        }
    }
}
