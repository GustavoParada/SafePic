using Domain.MongoDB.Interfaces;
using MongoDB.Bson;
using System;

namespace Domain.MongoDB.Entities
{
    public abstract class Document : IDocument
    {
        public ObjectId Id { get; set; }
        public DateTime CreatedAt => Id.CreationTime;
    }
}
