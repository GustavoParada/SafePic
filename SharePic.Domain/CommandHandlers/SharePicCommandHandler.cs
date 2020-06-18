using Domain.Core.Bus;
using MediatR;
using SharePic.Domain.Commands;
using SharePic.Domain.Events;
using SharePic.Domain.Interfaces;
using SharePic.Domain.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SharePic.Domain.CommandHandlers
{
    public class SharePicCommandHandler : IRequestHandler<CreateSharePicCommand, bool>, IRequestHandler<CreateSharePicDeleteCommand, bool>
    {
        private readonly IEventBus _bus;
        private readonly ISharePicRepository _sharePicRepository;

        public SharePicCommandHandler(IEventBus bus, ISharePicRepository sharePicRepository)
        {
            _bus = bus;
            _sharePicRepository = sharePicRepository;
        }

        public async Task<bool> Handle(CreateSharePicCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var sharedPic = new SharedPic(request.From, request.To, request.Pic, request.Duration);
                await _sharePicRepository.RegisterShare(sharedPic);

                _bus.Publish(new SharePicCreatedEvent(request.From, request.To, request.Pic, request.Duration));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return await Task.FromResult(true);
        }

        public async Task<bool> Handle(CreateSharePicDeleteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _sharePicRepository.DeleteShare(request.Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return await Task.FromResult(true);
        }
    }
}
