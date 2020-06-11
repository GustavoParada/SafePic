using SharePic.Domain.Models;
using System;

namespace SharePic.Application.Interfaces
{
    public interface ISharePicService
    {
        void SharePic(Guid from, Guid to, string pic, int duration);
    }
}
