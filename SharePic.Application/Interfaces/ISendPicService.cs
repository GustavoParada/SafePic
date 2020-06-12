using SharePic.Domain.Models;
using System;
using System.Threading.Tasks;

namespace SharePic.Application.Interfaces
{
    public interface ISharePicService
    {
        Task SharePic(Guid from, Guid to, string pic, int duration);
    }
}
