using Microsoft.EntityFrameworkCore;
using Order.Infrastructure.Context;

namespace Order.Infrastructure.Data
{
    public class SeedOrderContext : ISeedOrderContext
    {
        public readonly OrderContext _orderContext;

        public SeedOrderContext(string connectionStr)
        {
            var contextOptions = new DbContextOptionsBuilder<OrderContext>()
            .UseNpgsql(connectionStr)
            .Options;

            using var context = new OrderContext(contextOptions);
            _orderContext = context;
            SeedAsync(CancellationToken.None).Wait();
        }

        public async Task SeedAsync(CancellationToken cancellationToken = default)
        {
            try
            { 
                await _orderContext.Database.MigrateAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
