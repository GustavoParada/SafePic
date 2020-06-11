using System;

namespace SharePic.Domain.Models
{
    public class SharedPic
    {
        public Guid Id { get; set; }
        public Guid FromUser { get; set; }
        public Guid ToUser { get; set; }
        
        public string Base64 { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
