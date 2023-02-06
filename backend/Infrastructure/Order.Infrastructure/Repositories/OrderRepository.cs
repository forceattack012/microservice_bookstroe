using Bookstore.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Order.Infrastructure.Context;

namespace Order.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _orderContext;

        public OrderRepository(OrderContext orderContext)
        {
            _orderContext = orderContext;
        }

        public async Task CreateOrder(Bookstore.Domain.Entities.Order order)
        {
            _orderContext.Orders.Add(order);
            await _orderContext.SaveChangesAsync();
        }

        public async Task DeleteOrder(Bookstore.Domain.Entities.Order customer)
        {
            _orderContext.Entry(customer).State = EntityState.Detached;
            await _orderContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<Bookstore.Domain.Entities.Order>> GetOrderByCustomerId(long customerId)
        {
            return await _orderContext.Orders.Where(o => o.Id == customerId).ToListAsync();
        }

        public async Task<Bookstore.Domain.Entities.Order> GetOrderById(long id)
        {
            return await _orderContext.Orders.FindAsync(id);
        }

        public async Task<IReadOnlyList<Bookstore.Domain.Entities.Order>> GetOrders(CancellationToken cancellation)
        {
            return await _orderContext.Orders.ToListAsync();
        }
    }
}
