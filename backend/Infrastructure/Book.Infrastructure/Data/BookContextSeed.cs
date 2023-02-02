using CsvHelper;
using MongoDB.Driver;
using System.Globalization;

namespace Book.Infrastructure.Data
{
    public class BookContextSeed
    {
        private static string FILE_NAME = "books.csv";
        public static void SeedData(IMongoCollection<Bookstore.Domain.Entities.Book> collection)
        {
            Console.WriteLine("START {0}\n",DateTime.Now);

            collection.DeleteMany(_ => true);
            var books = readCSV(FILE_NAME);
            collection.InsertManyAsync(books);

            Console.WriteLine("END {0}", DateTime.Now);
        }

        private static List<Bookstore.Domain.Entities.Book> readCSV(string path)
        {
            List<Bookstore.Domain.Entities.Book> books = new List<Bookstore.Domain.Entities.Book>();

            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<BookMap>();
                var records = csv.GetRecords<BookCsv>();

                foreach (var record in records)
                {
                    books.Add(new Bookstore.Domain.Entities.Book()
                    {
                        Id = int.Parse(record.book_id),
                        ISBN = record.isbn,
                        Description = "",
                        Language = record.language_code,
                        Name = record.title,
                        Qty = record.book_count,
                        Rating = record.ratings_count,
                        Image  = record.imageUrl,
                        Authors = record.authors.Split(',').Select(r => r.TrimStart()).ToList(),
                    });
                }
            }
            return books;
        }
    }
}
