using Bookstore.Domain.Repositories;
using Microsoft.Extensions.Caching.Memory;

namespace Basket.Infrastructure.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IMemoryCache _memoryCache;

        public BasketRepository(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public Task AddBasket(Bookstore.Domain.Entities.Basket basket, CancellationToken cancellationToken = default)
        {
            _memoryCache.Set(basket.UsertName, basket);
            return Task.CompletedTask;
        }

        public async Task<Bookstore.Domain.Entities.Basket> GetBasketByUserName(string userName, CancellationToken cancellationToken = default)
        {
            var basket = _memoryCache.Get<Bookstore.Domain.Entities.Basket>(userName) ?? new Bookstore.Domain.Entities.Basket();
            return await Task.FromResult<Bookstore.Domain.Entities.Basket>(basket);
        }
    }
}
