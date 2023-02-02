using Bookstore.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Book.Models
{
    public class BookRequest
    {
        [Required]
        public string? Name { get; set; }
        public string Type { get; set; }
        [Required]
        public string ISBN { get; set; }
        public string? Description { get; set; }

        [Required]
        public decimal Price { get; set; } = 0;
        [Required]
        public int Qty { get; set; } = 0;
        [Required] 
        public int Pages { get; set; } = 0;
        public string Language { get; set; }
        public DateTime? Published { get; set; }
        public List<string> Authors { get; set; }
        public string Image { get; set; }
        public Int64 Rating { get; set; }

        public Bookstore.Domain.Entities.Book ConvertToBook(BookRequest request)
        {
            var book = new Bookstore.Domain.Entities.Book()
            {
                ISBN = request.ISBN,
                Authors = request.Authors,
                Description = request?.Description,
                Image = request.Image,
                Name = request.Name,
                Language = request.Language,
                Pages = request.Pages,
                Price = request.Price,
                Published = request.Published,
                Rating = request.Rating,
                Qty = request.Qty,
                Type = request.Type,
            };

            return book;
        }
    }
}
