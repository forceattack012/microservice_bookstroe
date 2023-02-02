using Bookstore.Domain.Entities.Interfaces;

namespace Bookstore.Domain.Entities
{
    public class Book : Entity<int>
    {
        public string? Name { get; set; }
        public string Type { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; } = 0;
        public int Qty { get; set; } = 0;
        public int Pages { get; set; } = 0;
        public string Language { get; set; }
        public DateTime? Published { get; set; }
        public List<string> Authors { get; set; }
        public Double Rating { get; set; } = 0.0;
        public string Image { get; set; }   
    }
}
