using SharePic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharePic.Domain.Interfaces
{
    public interface ISharePicRepository
    {
        Task<IEnumerable<SharedPic>> GetSharedList(Guid userId, DateTime exporationDate);
        Task RegisterShare(SharedPic picShared);
        Task DeleteShare(Guid id);
    }
}
