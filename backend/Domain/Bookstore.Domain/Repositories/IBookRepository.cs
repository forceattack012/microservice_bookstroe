using Bookstore.Domain.Entities;

namespace Bookstore.Domain.Repositories
{
    public interface IBookRepository
    {
        public Task AddBook(Book book);
        public Task AddBookList(List<Book> books);
        public Task<IEnumerable<Book>> GetBooks();
    }
}
