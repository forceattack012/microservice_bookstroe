using MongoDB.Driver;

namespace Book.Infrastructure.Context
{
    public interface IMongoContext
    {
        IMongoCollection<Bookstore.Domain.Entities.Book> Collection { get; set; }
    }
}
