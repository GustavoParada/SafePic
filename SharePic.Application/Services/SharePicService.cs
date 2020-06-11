using SharePic.Application.Interfaces;
using SharePic.Application.Models;
using SharePic.Domain.Commands;
using SharePic.Domain.Interfaces;
using SharePic.Domain.Models;
using Project.Domain.Core.Bus;
using System.Collections.Generic;
using System;

namespace SharePic.Application.Services
{
    public class SharePicService : ISharePicService
    {
        private readonly ISharePicRepository _sharePicRepository;
        private readonly IEventBus _bus;

        public SharePicService(ISharePicRepository sharePicRepository, IEventBus bus)

        {
            _sharePicRepository = sharePicRepository;
            _bus = bus;
        }
        //public IEnumerable<Account> GetAccounts()
        //{
        //   return _accountRepository.GetAccounts();
        //}

        public void SharePic(Guid from, Guid to, string pic, int duration)
        {
            var createdSharePicCommand = new CreateSharePicCommand(from, to, pic, duration);

            _bus.SendCommand(createdSharePicCommand);
        }
    }
}
