using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Domain.Core.Entities
{
    public class AppSettings
    {
        public HabbitMQSettings HabbitMQSettings { get; set; }
    }

    public class HabbitMQSettings
    {
        public string Host { get; set; }

        public string Password { get; set; }
    }
}
