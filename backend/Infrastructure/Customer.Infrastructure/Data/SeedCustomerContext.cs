using Microsoft.EntityFrameworkCore;
using Customer.Infrastructure.Context;

namespace Customer.Infrastructure.Data
{
    public class SeedCustomerContext : ISeedCustomerContext
    {
        public readonly CustomerContext _context;

        public SeedCustomerContext(string connectionStr)
        {
            var contextOptions = new DbContextOptionsBuilder<CustomerContext>()
            .UseNpgsql(connectionStr)
            .Options;

            using var context = new CustomerContext(contextOptions);
            _context = context;
            SeedAsync(CancellationToken.None).Wait();
        }

        public async Task SeedAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await _context.Database.MigrateAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
