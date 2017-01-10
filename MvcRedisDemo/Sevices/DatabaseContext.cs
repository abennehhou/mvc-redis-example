using System.Configuration;
using StackExchange.Redis;

namespace MvcRedisDemo.Sevices
{
    public class DatabaseContext : IDatabaseContext
    {
        private const string RedisDatabaseAppSettingKey = "RedisDatabase";

        private readonly IDatabase _database;

        public DatabaseContext()
        {
            var redisDatabaseConnectionString = ConfigurationManager.AppSettings[RedisDatabaseAppSettingKey];
            var connectionMultiplexer = ConnectionMultiplexer.Connect(redisDatabaseConnectionString);
            _database = connectionMultiplexer.GetDatabase();
        }

        public IDatabase GetRedisDatabase()
        {
            return _database;
        }
    }
}