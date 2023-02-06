using Microsoft.EntityFrameworkCore;

namespace Order.Infrastructure.Context
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        { 
        }

        public DbSet<Bookstore.Domain.Entities.Order> Orders { get; set; }
    }
}
