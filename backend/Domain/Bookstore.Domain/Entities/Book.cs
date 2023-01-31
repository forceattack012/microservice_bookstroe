using Bookstore.Domain.Entities.Interfaces;

namespace Bookstore.Domain.Entities
{
    public class Book : Entity<int>
    {
        public string? Name { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
    }
}
