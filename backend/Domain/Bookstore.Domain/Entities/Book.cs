using Bookstore.Domain.Entities.Interfaces;

namespace Bookstore.Domain.Entities
{
    public class Book : Entity<int>
    {
        public string? Name { get; set; }
        public string Type { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public int Pages { get; set; }
        public string Language { get; set; }
        public DateTime? Published { get; set; }
        public List<string> Authors { get; set; }
    }
}
