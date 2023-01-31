using StackExchange.Redis;

namespace Basket.Infrastructure.Context
{
    public class RedisContext : IRedisContext
    {
        private readonly IConnectionMultiplexer _redis;
        public RedisContext(IConnectionMultiplexer redis)
        {
            _redis = redis;
            var db = _redis.GetDatabase();
            Database = db;
        }

        public IDatabase Database { get; set; }
    }
}
