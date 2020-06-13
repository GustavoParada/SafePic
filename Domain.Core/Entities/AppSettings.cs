namespace Domain.Core.Entities
{
    public class AppSettings
    {
        public RabbitMQSettings RabbitMQSettings { get; set; }

        public MongoDbSettings MongoDbSettings { get; set; }
    }

    public class RabbitMQSettings
    {
        public string Host { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }
    }

    public interface IMongoDbSettings
    {
        string DatabaseName { get; set; }
        string ConnectionString { get; set; }
    }

    public class MongoDbSettings : IMongoDbSettings
    {
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
    }
}
