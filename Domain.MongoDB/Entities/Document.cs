using Domain.MongoDB.Interfaces;
using System;

namespace Domain.MongoDB.Entities
{
    public abstract class Document : IDocument
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt => DateTime.Now;
    }
}
