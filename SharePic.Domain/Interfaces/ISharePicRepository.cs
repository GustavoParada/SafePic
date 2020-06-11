using SharePic.Domain.Models;

namespace SharePic.Domain.Interfaces
{
    public interface ISharePicRepository
    {
        void RegisterShare(SharedPic picShared);
    }
}
