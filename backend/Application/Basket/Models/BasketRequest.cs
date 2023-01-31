using Bookstore.Domain.Entities;

namespace Basket.Models
{
    public class BasketRequest
    {
        public string UserName { get; set; }
        public List<Book> Books { get; set; }
    }
}
