using Domain.Core.Bus;
using SharePic.Application.Interfaces;
using SharePic.Domain.Commands;
using SharePic.Domain.Interfaces;
using SharePic.Domain.Models;
using System;
using System.Threading.Tasks;

namespace SharePic.Application.Services
{
    public class SharePicService : ISharePicService
    {
        private readonly IEventBus _bus;

        public SharePicService(IEventBus bus)

        {
            _bus = bus;
        }
        //public IEnumerable<Account> GetAccounts()
        //{
        //   return _accountRepository.GetAccounts();
        //}

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
