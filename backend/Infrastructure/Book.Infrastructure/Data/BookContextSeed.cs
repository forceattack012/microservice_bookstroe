using MongoDB.Driver;


namespace Book.Infrastructure.Data
{
    public class BookContextSeed
    {
        public static void SeedData(IMongoCollection<Bookstore.Domain.Entities.Book> collection)
        {
            collection.DeleteMany(_ => true);
            collection.InsertManyAsync(new Bookstore.Domain.Entities.Book[]
            {
                new Bookstore.Domain.Entities.Book()
                {
                    Name = "",
                    ISBN = "",
                    Authors = new List<string>() {"", ""},
                    Description = "",
                    Language = "",
                    Pages = 0,
                    Price = Convert.ToDecimal(20000.00),
                    Published = new DateTime(),
                    Qty = 0,
                    Type = ""
                }
            });
        }
    }
}
