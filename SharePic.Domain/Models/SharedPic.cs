using Domain.MongoDB.Attributes;
using Domain.MongoDB.Entities;
using MongoDB.Bson;
using System;

namespace SharePic.Domain.Models
{
    [BsonCollection("SharedPic")]
    public class SharedPic : Document
    {
        public Guid FromUser { get; set; }
        public Guid ToUser { get; set; }
        public string Base64 { get; set; }
        public DateTime ExpirationDate { get; set; }

        public SharedPic(Guid fromUser, Guid toUser, string base64, int duration)
        {
            Id = ObjectId.GenerateNewId();
            FromUser = fromUser;
            ToUser = toUser;
            Base64 = base64;
            ExpirationDate = DateTime.Now.AddSeconds(duration);
        }
    }

    public class SharedPicMongo : Document
    {
        public Guid FromUser { get; set; }
        public Guid ToUser { get; set; }
        public string Base64 { get; set; }
        public DateTime ExpirationDate { get; set; }

        public SharedPicMongo(Guid fromUser, Guid toUser, string base64, int duration)
        {
            Id = new ObjectId();
            FromUser = fromUser;
            ToUser = toUser;
            Base64 = base64;
            ExpirationDate = DateTime.Now.AddSeconds(duration);
        }
    }
    public class SharedPicSQL
    {
        public Guid Id { get; set; }
        public Guid FromUser { get; set; }
        public Guid ToUser { get; set; }
        public string Base64 { get; set; }
        public DateTime ExpirationDate { get; set; }

        public SharedPicSQL(Guid fromUser, Guid toUser, string base64, int duration)
        {
            Id = Guid.NewGuid();
            FromUser = fromUser;
            ToUser = toUser;
            Base64 = base64;
            ExpirationDate = DateTime.Now.AddSeconds(duration);
        }
    }
}
