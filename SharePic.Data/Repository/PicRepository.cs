using SharePic.Domain.Interfaces;
using SharePic.Domain.Models;
using System;

namespace SharePic.Data.Repository
{
    public class PicRepository : ISharePicRepository
    {
        public void RegisterShare(SharedPic picShared)
        {
            //grava no mongo
            throw new NotImplementedException();
        }
    }
}