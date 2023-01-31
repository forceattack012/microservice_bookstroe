using Bookstore.Api.Enum.Book;
using MongoDB.Driver;

namespace Book.Infrastructure.Context
{
    public class MongoContext : IMongoContext
    {
        public MongoContext(string connection, string databaseName) 
        {
            var mongoClient = new MongoClient(connection);
            var mongoDatabase = mongoClient.GetDatabase(databaseName);
            var collection = mongoDatabase.GetCollection<Bookstore.Domain.Entities.Book>(BookDbSettings.COLLECTION_NAME);

            var count = collection.Count(_ => true);
            if (count == 0)
            {
                collection.InsertMany(new Bookstore.Domain.Entities.Book[]
                {
                    new Bookstore.Domain.Entities.Book()
                    {
                        ISBN = "100"
                    }
                });
            }
            Collection = collection;
        }

        public IMongoCollection<Bookstore.Domain.Entities.Book> Collection { get; set; }
    }
}
