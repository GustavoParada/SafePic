using System;

namespace SharePic.Application.Models
{
    public class UserModel
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
