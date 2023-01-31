using StackExchange.Redis;

namespace Basket.Infrastructure.Context
{
    public interface IRedisContext
    {
        IDatabase Database { get; set; }
    }
}
