using Bookstore.Domain.Entities;

namespace Bookstore.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<IReadOnlyList<Order>> GetOrders(CancellationToken cancellation);
        Task<IReadOnlyList<Bookstore.Domain.Entities.Order>> GetOrderByCustomerId(long customerId);
        Task<Order> GetOrderById(long id);
        Task CreateOrder(Order order);
        Task DeleteOrder(Order customer);
    }
}
