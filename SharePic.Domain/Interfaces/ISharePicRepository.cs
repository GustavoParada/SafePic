using SharePic.Domain.Models;
using System.Threading.Tasks;

namespace SharePic.Domain.Interfaces
{
    public interface ISharePicRepository
    {
        Task RegisterShare(SharedPic picShared);
    }
}
