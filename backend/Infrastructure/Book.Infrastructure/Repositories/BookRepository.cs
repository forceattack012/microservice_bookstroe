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

        public async Task<bool> DeleteBook(int id, CancellationToken cancellationToken)
        {
            var filter = Builders<Bookstore.Domain.Entities.Book>.Filter.Eq(s => s.Id, id);
            var deleteResult = await _collection.DeleteOneAsync(filter, cancellationToken);

            return deleteResult.IsAcknowledged;
        }

        public IQueryable<Bookstore.Domain.Entities.Book> GetBooks()
        {
            return _collection.AsQueryable();
        }

        public async Task UpdateBook(Bookstore.Domain.Entities.Book book)
        {
            var filter = Builders<Bookstore.Domain.Entities.Book>.Filter.Eq(s => s.Id, book.Id);
            await _collection.ReplaceOneAsync(filter, book);
        }

        public Task AddBookList(List<Bookstore.Domain.Entities.Book> books)
        {
            throw new NotImplementedException();
        }

        public int GetLastBookId()
        {
            return _collection.Find(_ => true).SortByDescending(x => x.Id).FirstOrDefault().Id;
        }
    }
}
