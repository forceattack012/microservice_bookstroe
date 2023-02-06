using Order.Infrastructure.Context;

namespace Order.Infrastructure.Data
{
    public interface ISeedOrderContext 
    {
        Task SeedAsync(CancellationToken cancellationToken = default);
    }
}
