using Book.Infrastructure.Context;
using Bookstore.Domain.Repositories;
using MongoDB.Driver;

namespace Book.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IMongoCollection<Bookstore.Domain.Entities.Book> _collection;

        public BookRepository(IMongoContext context)
        {
            _collection = context.Collection;
        }

        public async Task AddBook(Bookstore.Domain.Entities.Book book)
        {
            await _collection.InsertOneAsync(book);
        }

        public Task AddBookList(List<Bookstore.Domain.Entities.Book> books)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Bookstore.Domain.Entities.Book>> GetBooks()
        {
            return _collection.Find(_ => true).ToEnumerable();
        }
    }
}
