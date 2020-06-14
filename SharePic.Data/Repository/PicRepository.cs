using Domain.MongoDB.Interfaces;
using SharePic.Domain.Interfaces;
using SharePic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharePic.Data.Repository
{
    public class PicRepository : ISharePicRepository
    {
        private readonly IMongoRepository<SharedPic> _sharePicRepository;

        public PicRepository(IMongoRepository<SharedPic> sharePicRepository)
        {
            _sharePicRepository = sharePicRepository;
        }

        public async Task RegisterShare(SharedPic picShared)
        {
            try
            {
                //grava no mongo
               await _sharePicRepository.InsertOneAsync(picShared);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<SharedPic>> GetSharedList(Guid userId, DateTime exporationDate)
        {
            try
            {
                //grava no mongo
                return await _sharePicRepository.FilterByAsync(p => p.ToUser == userId);// && p.ExpirationDate > DateTime.Now);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}