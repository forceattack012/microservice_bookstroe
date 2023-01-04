using Bookstore.Domain.Entities;

namespace Bookstore.Domain.Repositories
{
    public interface IBasketRepository
    {
        Task AddBasket(Basket basket, CancellationToken cancellationToken = default);
        Task<Basket> GetBasketByUserName(string userName, CancellationToken cancellationToken = default);
    }
}
