using Bookstore.Domain.Entities;

namespace Bookstore.Domain.Repositories
{
    public interface IBookRepository
    {
        public Task AddBook(Book book);
        public Task AddBookList(List<Book> books);
        public Task DeleteBook(int id, CancellationToken cancellationToken);
        public Task UpdateBook(Book book);
        public IQueryable<Bookstore.Domain.Entities.Book> GetBooks();
        public int GetLastBookId();
    }
}
