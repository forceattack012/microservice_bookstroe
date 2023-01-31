using Basket.Infrastructure.Context;
using Basket.Infrastructure.Repositories;
using Bookstore.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace Basket.Infrastructure.Dependency
{
    public static class RegisterService
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection, string redisConnection)
        {
            var configuration = ConfigurationOptions.Parse(redisConnection, true);
            var multiplexer = ConnectionMultiplexer.Connect(configuration);
            serviceCollection.AddSingleton<IConnectionMultiplexer>(multiplexer);
            serviceCollection.AddSingleton<IRedisContext, RedisContext>();
            serviceCollection.AddScoped<IBasketRepository, BasketRepository>();

            return serviceCollection;
        }
    }
}
