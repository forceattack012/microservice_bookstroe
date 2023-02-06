using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Order.Infrastructure.Context
{
    public class DbContextFactory : IDesignTimeDbContextFactory<OrderContext>
    {
        public OrderContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OrderContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Database=bookstore;Username=admin;Password=abcd1234");

            return new OrderContext(optionsBuilder.Options);
        }
    }
}
