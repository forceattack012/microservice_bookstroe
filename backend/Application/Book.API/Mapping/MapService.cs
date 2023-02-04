using Book.Models;

namespace Book.API.Mapping
{
    public static class MapService
    {
        public static Bookstore.Domain.Entities.Book ConvertToBook(BookRequest request)
        {
            var book = new Bookstore.Domain.Entities.Book()
            {
                ISBN = request.ISBN,
                Authors = request.Authors,
                Description = request.Description,
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

        public static Bookstore.Domain.Entities.Book ConvertToBook(BookRequest request, int id)
        {
            var book = new Bookstore.Domain.Entities.Book()
            {
                Id = id,
                ISBN = request.ISBN,
                Authors = request.Authors,
                Description = request.Description,
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
