using StackExchange.Redis;

namespace MvcRedisDemo.Sevices
{
    public interface IDatabaseContext
    {
        IDatabase GetRedisDatabase();
    }
}