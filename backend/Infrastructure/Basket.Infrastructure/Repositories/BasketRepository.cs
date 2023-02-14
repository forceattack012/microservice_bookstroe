using Basket.Infrastructure.Context;
using Bookstore.Domain.Repositories;
using Newtonsoft.Json;
using Bookstore.Api.Helper;

namespace Basket.Infrastructure.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IRedisContext _redisContext;

        public BasketRepository(IRedisContext redisContext)
        {
            _redisContext = redisContext;
        }

        public async Task AddBasket(Bookstore.Domain.Entities.Basket basket, CancellationToken cancellationToken = default)
        {
            await _redisContext.Database.StringSetAsync(basket.UsertName, JsonConvert.SerializeObject(basket), new TimeSpan(0, 0, 30));
            return;
        }

        public async Task<Bookstore.Domain.Entities.Basket> GetBasketByUserName(string userName, CancellationToken cancellationToken = default)
        {
            var result = await _redisContext.Database.StringGetAsync(userName);
            if (result.IsCheckNullOrEmpty())
            {
                return new Bookstore.Domain.Entities.Basket();
            }

            var basket = JsonConvert.DeserializeObject<Bookstore.Domain.Entities.Basket>(result);
            return basket;
        }
    }
}
