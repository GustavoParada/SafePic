using Domain.Core.Bus;
using SharePic.Application.Interfaces;
using SharePic.Domain.Commands;
using SharePic.Domain.Interfaces;
using SharePic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharePic.Application.Services
{
    public class SharePicService : ISharePicService
    {
        private readonly IEventBus _bus;
        private readonly ISharePicRepository _sharePicRepository;

        public SharePicService(IEventBus bus, ISharePicRepository sharePicRepository)
        {
            _bus = bus;
            _sharePicRepository = sharePicRepository;
        }

        public Task<IEnumerable<SharedPic>> GetSharedByUser(Guid userId)
        {
            return _sharePicRepository.GetSharedList(userId, DateTime.Now);
        }

        public async Task SharePic(Guid from, Guid to, string pic, int duration)
        {
            try
            {
                var createdSharePicCommand = new CreateSharePicCommand(from, to, pic, duration);
                await _bus.SendCommand(createdSharePicCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
