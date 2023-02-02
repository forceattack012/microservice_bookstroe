using CsvHelper.Configuration;

namespace Book.Infrastructure.Data
{
    public class BookMap : ClassMap<BookCsv>
    {
        public BookMap() 
        {
            Map(b => b.book_id).Index(0);
            Map(b => b.book_count).Index(4);
            Map(b => b.isbn).Index(6);
            Map(b => b.authors).Index(7);
            Map(b => b.title).Index(10);
            Map(b => b.language_code).Index(11);
            Map(b => b.ratings_count).Index(12);
            Map(b => b.imageUrl).Index(20);
        }
    }
}
