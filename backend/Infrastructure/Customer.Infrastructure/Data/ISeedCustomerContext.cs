using Customer.Infrastructure.Context;

namespace Customer.Infrastructure.Data
{
    public interface ISeedCustomerContext
    {
        Task SeedAsync(CancellationToken cancellationToken = default);
    }
}
